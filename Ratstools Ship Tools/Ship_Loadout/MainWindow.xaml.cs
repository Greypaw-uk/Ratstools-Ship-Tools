using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using Ship_Loadout.LoadoutEditor;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Title = "Ratstool's Ship Tools";

            PopulateComponents();
            PopulateFolders();
            LoadSavedShips();
        }

        private void PopulateComponents()
        {
            Components.Components.PopulateArmourList();
            Components.Components.PopulateBoosterList();
            Components.Components.PopulateCapacitorList();
            Components.Components.PopulateCargoList();
            Components.Components.PopulateCounterMeasureList();
            Components.Components.PopulateDroidInterfaces();
            Components.Components.PopulateEngines();
            Components.Components.PopulateOrdinance();
            Components.Components.PopulateReactors();
            Components.Components.PopulateShields();
            Components.Components.PopulateWeapons();
        }

        private void PopulateFolders()
        {
            //Check Folders exist
            //First: Check for Components folder
            //Second: Check for Ships folder
            //Third: Check for Ship Loadouts folder
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (!Directory.Exists(path + "/Components"))
                Directory.CreateDirectory(path + "/Components");

            if (!Directory.Exists(path + "/Ship_Data"))
            {
                MessageBox.Show("Warning - Ship information missing from /Ship_Data." +
                                "You will need to add the ships before you can use the Ship Loadout tool");
                Directory.CreateDirectory(path + "/Ship_Data");
            }
        }

        private void LoadSavedShips()
        {
            OpenLoadout.SavedShips = new List<Ship>();

            if (File.Exists("Ship_Data/SavedShips.json"))
            {
                try
                {
                    var json = new StreamReader("Ship_Data/SavedShips.json").ReadToEnd();
                    OpenLoadout.SavedShips = JsonConvert.DeserializeObject<List<Ship>>(json);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to load saved ships " + e);
                }
            }
        }

        private void BtnDroidCalculator_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new DroidCalculator();
        }

        private void BtnRECalculator_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new RECalculator();
        }

        private void BtnComponent_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new Components.ComponentsPage();
        }

        private void BtnShipLoadouts_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new LoadoutEditor.LoadoutEditor();
        }

        private void ShipEditor_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new ShipCreator();
        }

        private void Rectangle_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dragon dragon = new Dragon {Owner = this};
            dragon.Show();
        }
    }
}
