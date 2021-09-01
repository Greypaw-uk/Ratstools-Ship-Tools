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

            List<Ship> ShipDisplayList = new List<Ship>();

            if (cb_rebel.IsChecked == true)
                foreach (var ship in ShipList.Where(ship => ship.Faction == 0))
                    ShipDisplayList.Add(ship);


            if (cb_imperial.IsChecked == true)
                foreach (var ship in ShipList.Where(ship => ship.Faction == 1))
                    ShipDisplayList.Add(ship);


            if (cb_freelance.IsChecked == true)
                foreach (var ship in ShipList.Where(ship => ship.Faction == 2))
                    ShipDisplayList.Add(ship);

            if (cb_special.IsChecked == true)
                foreach (var ship in ShipList.Where(ship => ship.Faction == 3))
                    ShipDisplayList.Add(ship);

            dg_ships.ItemsSource = ShipDisplayList;
        }
    }
}
