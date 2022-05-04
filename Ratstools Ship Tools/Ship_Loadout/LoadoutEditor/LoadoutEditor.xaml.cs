using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class LoadoutEditor : Page
    {
        public static Ship ShipCache;

        public LoadoutEditor()
        {
            InitializeComponent();

            // Refresh lists to ensure nothing added since program started is missing from dropdowns
            Components.Components.PopulateAllComponents();
        }

        private void Btn_new_OnClick(object sender, RoutedEventArgs e)
        {
            shipFrame.Content = new NewLoadout();

            sp_loadoutNew.Visibility = Visibility.Visible;
            sp_loadoutStart.Visibility = Visibility.Collapsed;
            sp_loadMenu.Visibility = Visibility.Collapsed;
        }

        private void Btn_load_OnClick(object sender, RoutedEventArgs e)
        {
            shipFrame.Content = new OpenLoadout();

            sp_loadoutStart.Visibility = Visibility.Collapsed;
            sp_loadMenu.Visibility = Visibility.Visible;
            sp_loadoutDisplayed.Visibility = Visibility.Collapsed;
            sp_loadoutNew.Visibility = Visibility.Collapsed;
        }

        private void Btn_next_OnClick(object sender, RoutedEventArgs e)
        {
            if (ShipCache != null)
            {
                shipFrame.Content = new DisplayLoadout(ShipCache);

                sp_loadoutNew.Visibility = Visibility.Collapsed;
                sp_loadoutStart.Visibility = Visibility.Collapsed;
                sp_loadMenu.Visibility = Visibility.Collapsed;
                sp_loadoutDisplayed.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Please select a ship.");
        }

        private void Btn_back_OnClick(object sender, RoutedEventArgs e)
        {
            sp_loadoutStart.Visibility = Visibility.Visible;
            sp_loadoutNew.Visibility = Visibility.Collapsed;
            sp_loadoutDisplayed.Visibility = Visibility.Collapsed;
            sp_loadMenu.Visibility = Visibility.Collapsed;

            shipFrame.Content = null;
            ShipCache = null;
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Ship> tempSavedShips = new List<Ship>();

                if (OpenLoadout.SavedShips.Count == 0)
                    tempSavedShips.Add(ShipCache);
                else
                {
                    foreach (var ship in OpenLoadout.SavedShips)
                    {
                        if (ship.ID != ShipCache.ID)
                            tempSavedShips.Add(ship);
                        else
                            tempSavedShips.Add(ShipCache);
                    }
                }

                using (StreamWriter file = File.CreateText("Ship_Data/SavedShips.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, tempSavedShips);
                }

                MessageBox.Show("Ship saved");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void Btn_open_OnClick(object sender, RoutedEventArgs e)
        {
            shipFrame.Content = new DisplayLoadout(ShipCache);
        }
    }
}
