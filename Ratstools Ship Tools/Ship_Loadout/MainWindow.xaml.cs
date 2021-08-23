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

        //Show a dancing cock if the user types in 'Dragon'
        private void DragonCheat(object sender, KeyEventArgs e)
        {
            phrase.Append(e.Key);

            if (phrase.ToString().ToLowerInvariant().Equals("dragon"))
            {
                Dragon dragon = new Dragon();
                dragon.Show();

                phrase.Clear();
            }

            if (phrase.Length > 6)
                phrase.Clear();
        }
    }
}
