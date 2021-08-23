using System.Windows.Controls;

namespace Ship_Loadout.Components
{
    public partial class ComponentsPage : Page
    {
        public ComponentsPage()
        {
            InitializeComponent();

            #region Populate Component Pages

            armourFrame.Content = new ArmourPage();
            boosterFrame.Content = new BoosterPage();
            capacitorFrame.Content = new CapacitorPage();
            cargoFrame.Content = new CargobayPage();
            counterFrame.Content = new CountermeasuresPage();
            droidFrame.Content = new DroidInterfacePage();
            engineFrame.Content = new EnginePage();
            ordinanceFrame.Content = new OrdinancePage();
            reactorFrame.Content = new ReactorPage();
            shieldFrame.Content = new ShieldPage();
            weaponFrame.Content = new WeaponPage();

            #endregion
        }
    }
}
