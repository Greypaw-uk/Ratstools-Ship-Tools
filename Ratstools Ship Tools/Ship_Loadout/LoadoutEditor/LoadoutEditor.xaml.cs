using System.Windows;
using System.Windows.Controls;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class LoadoutEditor : Page
    {
        public LoadoutEditor()
        {
            InitializeComponent();

            // Refresh lists to ensure nothing added since program started is missing from dropdowns
            Components.Components.PopulateAllComponents();
        }

        private void Btn_new_OnClick(object sender, RoutedEventArgs e)
        {
            shipFrame.Content = new NewLoadout();

            sp_loadoutStart.Visibility = Visibility.Collapsed;
            sp_loadoutNew.Visibility = Visibility.Visible;
        }

        private void Btn_load_OnClick(object sender, RoutedEventArgs e)
        {
            shipFrame.Content = new OpenLoadout();
        }

        private void Btn_next_OnClick(object sender, RoutedEventArgs e)
        {
            if (LoadoutData.ShipListSelection != -1)
            {
                MainWindow.ShipCache = LoadoutData.ShipList[LoadoutData.ShipListSelection];

                shipFrame.Content = new DisplayLoadout();
            }
            else
                MessageBox.Show("Please select a ship.");
        }

        private void Btn_back_OnClick(object sender, RoutedEventArgs e)
        {
            sp_loadoutStart.Visibility = Visibility.Visible;
            sp_loadoutNew.Visibility = Visibility.Collapsed;

            shipFrame.Content = null;
            LoadoutData.ShipListSelection = -1;
        }
    }
}
