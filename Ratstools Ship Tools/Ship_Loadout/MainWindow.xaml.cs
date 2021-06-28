using System.Windows;

namespace Ship_Loadout
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Title = "Ratstool's Ship Tools";
        }

        private void BtnDroidCalculator_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new DroidCalculator();
        }

        private void BtnRECalculator_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new RECalculator();
        }
    }
}
