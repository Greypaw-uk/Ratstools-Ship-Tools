using System.Windows;
using System.Windows.Input;

namespace Ship_Loadout
{
    public partial class Dragon : Window
    {
        public Dragon()
        {
            InitializeComponent();
        }

        private void Dragon_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }
    }
}
