using System.Collections.Generic;
using System.Windows.Controls;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class OpenLoadout : Page
    {
        public static List<Ship> SavedShips;

        public OpenLoadout()
        {
            InitializeComponent();

            dg_ships.ItemsSource = SavedShips;
        }

        private void Dg_ships_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadoutEditor.ShipCache = (Ship)dg_ships.SelectedItem;
        }
    }
}
