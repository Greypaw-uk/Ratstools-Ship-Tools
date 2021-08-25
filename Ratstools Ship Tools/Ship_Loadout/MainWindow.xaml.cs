using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Ship_Loadout
{
    public partial class MainWindow : Window
    {
        StringBuilder phrase = new StringBuilder();

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

        private void Rectangle_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dragon dragon = new Dragon();
            dragon.Show();
        }

        private void BtnShipLoadouts_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new ShipLoadout.ShipCreator();
        }
    }
}
