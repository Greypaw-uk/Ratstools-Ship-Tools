using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;

namespace Ship_Loadout
{
    public partial class DroidCalculator : Page
    {
        private List<DroidCommand> commandList = new List<DroidCommand>();
        private int max = 20; //Maximum capacity of droid
        public int TotalLoad { get; set; } //Current TotalLoad of loaded commands

        private bool isLoaded = false; //Throttle to stop program crashing when trying to enact combobox onchange when loading

        public DroidCalculator()
        {
            InitializeComponent();
            DataContext = this;

            PopulateCommandsList();

            isLoaded = true;
        }

        private void PopulateCommandsList()
        {
            var json = new StreamReader("DroidCommands.json").ReadToEnd();
            commandList = JsonConvert.DeserializeObject<List<DroidCommand>>(json);

            dg_otherChips.ItemsSource = commandList;
        }

        private void Cb_AstroMechLevel_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                switch (cb_AstroMechLevel.SelectedIndex)
                {
                    case 0:
                        max = 20;
                        break;
                    case 1:
                        max = 40;
                        break;
                    case 2:
                        max = 70;
                        break;
                    case 3:
                        max = 110;
                        break;
                    case 4:
                        max = 125;
                        break;
                    case 5:
                        max = 150;
                        break;
                }

                ChangeProgressBarColour();

                ProgressBar.Maximum = max;
            }
        }

        private void CalculateTotalLoad()
        {
            if (isLoaded)
            {
                TotalLoad = 0;

                switch (cb_reactor.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 19;
                        break;
                    case 4:
                        TotalLoad += 24;
                        break;
                }

                switch (cb_engine.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 19;
                        break;
                    case 4:
                        TotalLoad += 24;
                        break;
                }

                switch (cb_capacitor.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 19;
                        break;
                    case 4:
                        TotalLoad += 24;
                        break;
                }

                switch (cb_weapon.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 19;
                        break;
                    case 4:
                        TotalLoad += 24;
                        break;
                }

                switch (cb_capShunt.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 20;
                        break;
                    case 4:
                        TotalLoad += 25;
                        break;
                }

                switch (cb_frontShieldAdjust.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 20;
                        break;
                    case 4:
                        TotalLoad += 24;
                        break;
                }

                switch (cb_frontShieldReinforce.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 20;
                        break;
                    case 4:
                        TotalLoad += 24;
                        break;
                }

                switch (cb_rearShieldReinforce.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 20;
                        break;
                    case 4:
                        TotalLoad += 24;
                        break;
                }

                switch (cb_rearShieldAdjust.SelectedIndex)
                {
                    case 0:
                        TotalLoad += 0;
                        break;
                    case 1:
                        TotalLoad += 5;
                        break;
                    case 2:
                        TotalLoad += 10;
                        break;
                    case 3:
                        TotalLoad += 20;
                        break;
                    case 4:
                        TotalLoad += 24;
                        break;
                }

                foreach (DroidCommand dCommand in dg_otherChips.SelectedItems)
                    TotalLoad += dCommand.Size;

                ChangeProgressBarColour();

                tb_totalLoad.Text = TotalLoad.ToString();
                ProgressBar.Value = TotalLoad;
            }
        }

        private void ChangeProgressBarColour()
        {
            ProgressBar.Foreground = TotalLoad > max ? new SolidColorBrush(Colors.DarkRed) : new SolidColorBrush(Colors.Green);
        }

        private void ReadyChip_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateTotalLoad();
        }

        private void Dg_otherChips_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateTotalLoad();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            dg_otherChips.SelectedIndex = -1;
        }
    }

    public class DroidCommand
    {
        public string Name { get; set; }
        public int Size { get; set; }
    }
}
