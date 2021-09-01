using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout
{
    public partial class MainWindow : Window
    {
        StringBuilder phrase = new StringBuilder();
        public static Ship ShipCache;

        public MainWindow()
        {
            InitializeComponent();

            Title = "Ratstool's Ship Tools";

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

            //Check Folders exist
            //First: Check for Components folder
            //Second: Check for Ships folder
            //Third: Check for Ship Loadouts folder
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (!Directory.Exists(path+"/Components"))
                Directory.CreateDirectory(path+"/Components");

            if (!Directory.Exists(path + "/Ship_Data"))
            {
                MessageBox.Show("Warning - Ship information missing from /Ship_Data." +
                                "You will need to add the ships before you can use the Ship Loadout tool");
                Directory.CreateDirectory(path + "/Ship_Data");
            }

            if (!Directory.Exists(path + "/Ship_Loadouts"))
                Directory.CreateDirectory(path + "/Ship_Loadouts");
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
            Dragon dragon = new Dragon();
            dragon.Show();
        }
    }
}
