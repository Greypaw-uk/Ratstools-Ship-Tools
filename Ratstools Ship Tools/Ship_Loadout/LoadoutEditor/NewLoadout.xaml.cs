using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class NewLoadout : Page
    {
        private List<Ship> ShipList = new List<Ship>();
        private bool isLoaded;

        public NewLoadout()
        {
            InitializeComponent();

            GetShipList();

            isLoaded = true;
        }

        private void GetShipList()
        {
            if (File.Exists("Ship_Data/Ships.json"))
            {
                var json = new StreamReader("Ship_Data/Ships.json").ReadToEnd();
                ShipList = JsonConvert.DeserializeObject<List<Ship>>(json);

                dg_ships.ItemsSource = ShipList;
            }
        }

        private void CheckboxChanged(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;

            var ShipDisplayList = new List<Ship>();

            if (cb_rebel.IsChecked == true) ShipDisplayList.AddRange(ShipList.Where(ship => ship.Faction == 0));
            if (cb_imperial.IsChecked == true) ShipDisplayList.AddRange(ShipList.Where(ship => ship.Faction == 1));
            if (cb_freelance.IsChecked == true) ShipDisplayList.AddRange(ShipList.Where(ship => ship.Faction == 2));
            if (cb_special.IsChecked == true) ShipDisplayList.AddRange(ShipList.Where(ship => ship.Faction == 3));

            dg_ships.ItemsSource = ShipDisplayList;
        }

        private void Btn_next_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_ships.SelectedIndex != -1)
            {
                MainWindow.ShipCache = ShipList[dg_ships.SelectedIndex];

                //loadoutFrame
            }
            else
                MessageBox.Show("Please select a ship.");
        }
    }
}
