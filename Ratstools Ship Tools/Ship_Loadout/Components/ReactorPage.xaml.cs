using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class ReactorPage : Page
    {
        public ReactorPage()
        {
            InitializeComponent();

            dg_reactor.ItemsSource = Components.Reactors;
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_reactor.SelectedIndex = -1;

            ClearControls();
        }

        private void Dg_reactor_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            var i = dg_reactor.SelectedIndex;

            if (i != -1)
            {
                tb_name.Text = Components.Reactors[i].Name;
                tb_armour.Text = Components.Reactors[i].Armour.ToString();
                tb_mass.Text = Components.Reactors[i].Mass.ToString();
                tb_generation.Text = Components.Reactors[i].Generation.ToString();
            }
        }

        private void ClearControls()
        {
            tb_name.Text = "";
            tb_armour.Text = "";
            tb_mass.Text = "";
            tb_generation.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            Reactor reactor = new Reactor
            {
                Name = tb_name.Text,
                Armour = float.Parse(tb_armour.Text),
                Mass = float.Parse(tb_mass.Text),
                Generation = float.Parse(tb_generation.Text)
            };

            if (dg_reactor.SelectedIndex != -1)
            {
                reactor.ID = Components.Reactors[dg_reactor.SelectedIndex].ID;

                Components.Reactors[dg_reactor.SelectedIndex] = reactor;
            }
            else
            {
                reactor.ID = Guid.NewGuid().ToString();

                Components.Reactors.Add(reactor);
            }

            SaveJSON();

            dg_reactor.Items.Refresh();
        }

        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/Reactors.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.Reactors);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_reactor.SelectedIndex != -1)
            {
                Components.Reactors.RemoveAt(dg_reactor.SelectedIndex);

                SaveJSON();

                dg_reactor.Items.Refresh();
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsValidated()
        {
            if (string.IsNullOrEmpty(tb_name.Text)) return false;
            if (string.IsNullOrEmpty(tb_armour.Text)) return false;
            if (string.IsNullOrEmpty(tb_mass.Text)) return false;
            if (string.IsNullOrEmpty(tb_generation.Text)) return false;

            return true;
        }
    }
}
