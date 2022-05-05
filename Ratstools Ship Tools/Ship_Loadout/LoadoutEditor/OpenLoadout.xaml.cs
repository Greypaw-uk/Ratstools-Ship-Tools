using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class OpenLoadout : Page
    {
        public static List<Ship> SavedShips;

        public OpenLoadout()
        {
            InitializeComponent();

            LoadSavedShips();

            dg_ships.ItemsSource = SavedShips;
        }

        private void LoadSavedShips()
        {
            SavedShips = new List<Ship>();

            if (File.Exists("Ship_Data/SavedShips.json"))
            {
                try
                {
                    var json = new StreamReader("Ship_Data/SavedShips.json").ReadToEnd();
                    SavedShips = JsonConvert.DeserializeObject<List<Ship>>(json);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to load saved ships " + e);
                }
            }
        }

        private void Dg_ships_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadoutEditor.ShipCache = (Ship)dg_ships.SelectedItem;
        }
    }
}
