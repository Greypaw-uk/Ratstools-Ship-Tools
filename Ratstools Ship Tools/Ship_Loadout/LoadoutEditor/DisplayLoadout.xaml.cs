using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ship_Loadout.Components;
using Ship_Loadout.LoadoutEditor.Components;
using Ship_Loadout.LoadoutEditor.LoadoutComponents;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class DisplayLoadout : Page
    {
        private Ship ship = LoadoutData.ShipList[LoadoutData.ShipListSelection];

        private ReactorComponent sc_reactor = new ReactorComponent();

        private WeaponComponent sc_weapon = new WeaponComponent();

        public DisplayLoadout()
        {
            InitializeComponent();

            InitialiseReactor();
            InitialiseEngine();
            InitialiseBooster();
            InitialiseShield();

            //InitialiseWeapons();
        }

        private void InitialiseReactor()
        {
            //Create title text boxes
            var tb_reactor = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = "Reactor",
                Foreground = new SolidColorBrush(Colors.Orange)
            };


            //Add Reactors to Combolist
            sc_reactor.ComboBox.ItemsSource = Ship_Loadout.Components.Components.Reactors;
            sc_reactor.ComboBox.DisplayMemberPath = "Name";
            sc_reactor.ComboBox.SelectionChanged += ReactorSelectionChanged;


            //Create Stackpanels and add sub-controls
            var sp_reactor = new StackPanel {Children = {tb_reactor, sc_reactor}};


            //Add Stackpanel to Wrap Panel
            WrapPanelOne.Children.Add(sp_reactor);
        }

        private void InitialiseEngine()
        {
            TextBlock tb_engine = new TextBlock();
            tb_engine.HorizontalAlignment = HorizontalAlignment.Center;
            tb_engine.Text = "Engine";
            tb_engine.Foreground = new SolidColorBrush(Colors.Orange);

            //ShipComponent sc_engine = new ShipComponent();

            StackPanel sp_engine = new StackPanel();
            sp_engine.Children.Add(tb_engine);
            //sp_engine.Children.Add(sc_engine);

            WrapPanelOne.Children.Add(sp_engine);
        }

        private void InitialiseBooster()
        {
            TextBlock tb_booster = new TextBlock();
            tb_booster.HorizontalAlignment = HorizontalAlignment.Center;
            tb_booster.Text = "Booster";
            tb_booster.Foreground = new SolidColorBrush(Colors.Orange);

            //ShipComponent sc_booster = new ShipComponent();

            StackPanel sp_booster = new StackPanel();
            sp_booster.Children.Add(tb_booster);
            //sp_booster.Children.Add(sc_booster);

            WrapPanelOne.Children.Add(sp_booster);
        }

        private void InitialiseShield()
        {
            TextBlock tb_shield = new TextBlock();
            tb_shield.HorizontalAlignment = HorizontalAlignment.Center;
            tb_shield.Text = "Shield";
            tb_shield.Foreground = new SolidColorBrush(Colors.Orange);

            //ShipComponent sc_shield = new ShipComponent();

            StackPanel sp_shield = new StackPanel();
            sp_shield.Children.Add(tb_shield);
            //sp_shield.Children.Add(sc_shield);

            WrapPanelOne.Children.Add(sp_shield);
        }

        private void InitialiseWeapons()
        {
            for (int i = 0; i < ship.Weapons; i++)
            {
                TextBlock tb_weapon = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = "Weapon " + (i + 1),
                    Foreground = new SolidColorBrush(Colors.Orange)
                };

                sc_weapon.ComboBox.ItemsSource = Ship_Loadout.Components.Components.Reactors;
                sc_weapon.ComboBox.DisplayMemberPath = "Name";
                sc_weapon.ComboBox.SelectionChanged += (WeaponSelectionChanged);

                var sp_weapon = new StackPanel { Children = { tb_weapon, sc_weapon } };

                WrapPanelTwo.Children.Add(sp_weapon);
            }
        }

        private void ReactorSelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox) sender;
            
            Ship_Loadout.Components.Components.ReactorCache = Ship_Loadout.Components.Components.Reactors[cmb.SelectedIndex];

            UpdateReactor();
        }

        private void UpdateReactor()
        {
            Reactor reactor = Ship_Loadout.Components.Components.ReactorCache;

            if (reactor != null)
            {
                sc_reactor.tb_armour.Text = reactor.Armour.ToString();
                sc_reactor.tb_mass.Text = reactor.Mass.ToString();
                sc_reactor.tb_gen.Text = reactor.Generation.ToString();
            }
        }

        private void WeaponSelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            Ship_Loadout.Components.Components.WeaponCache = Ship_Loadout.Components.Components.Weapons[cmb.SelectedIndex];

            UpdateWeapons();
        }

        private void UpdateWeapons()
        {
            Weapon weapon = Ship_Loadout.Components.Components.WeaponCache;

            if (weapon != null)
            {
                sc_weapon.tb_armour.Text = weapon.Armour.ToString();
                sc_weapon.tb_drain.Text = weapon.Drain.ToString();
                sc_weapon.tb_mass.Text = weapon.Mass.ToString();
                sc_weapon.tb_minDam.Text = weapon.MinD.ToString();
                sc_weapon.tb_maxDam.Text = weapon.MaxD.ToString();
                sc_weapon.tb_vsS.Text = weapon.VS.ToString();
                sc_weapon.tb_vsA.Text = weapon.VA.ToString();
                sc_weapon.tb_eps.Text = weapon.EPS.ToString();
                sc_weapon.tb_refire.Text = weapon.RR.ToString();
            }
        }
    }
}
