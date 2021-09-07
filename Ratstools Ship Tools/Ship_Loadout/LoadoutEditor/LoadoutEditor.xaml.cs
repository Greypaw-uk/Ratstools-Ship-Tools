using System.Windows;
using System.Windows.Controls;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class LoadoutEditor : Page
    {
        public LoadoutEditor()
        {
            InitializeComponent();
        }

        private void Btn_new_OnClick(object sender, RoutedEventArgs e)
        {
            shipFrame.Content = new NewLoadout();
        }

        private void Btn_load_OnClick(object sender, RoutedEventArgs e)
        {
            shipFrame.Content = new OpenLoadout();
        }
    }
}
