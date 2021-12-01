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
        private EngineComponent sc_engine = new EngineComponent();
        private BoosterComponent sc_booster = new BoosterComponent();
        private ShieldComponent sc_shield = new ShieldComponent();
        private DIComponent sc_di = new DIComponent();
        private CapacitorComponent sc_cap = new CapacitorComponent();


        public DisplayLoadout()
        {
            InitializeComponent();

            InitialiseReactor();
            InitialiseEngine();
            InitialiseBooster();
            InitialiseShield();

            InitialiseDI();
            InitialiseCapacitor();

            InitialiseWeapons();
        }

        #region Reactor

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
            var sp_reactor = new StackPanel { Children = { tb_reactor, sc_reactor } };


            //Add Stackpanel to Wrap Panel
            WrapPanelOne.Children.Add(sp_reactor);
        }

        private void ReactorSelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            Ship_Loadout.Components.Components.ReactorCache = Ship_Loadout.Components.Components.Reactors[cmb.SelectedIndex];

            Reactor reactor = Ship_Loadout.Components.Components.ReactorCache;

            if (reactor != null)
            {
                sc_reactor.tb_armour.Text = reactor.Armour.ToString();
                sc_reactor.tb_armour.TextAlignment = TextAlignment.Right;

                sc_reactor.tb_mass.Text = reactor.Mass.ToString();
                sc_reactor.tb_mass.TextAlignment = TextAlignment.Right;

                sc_reactor.tb_gen.Text = reactor.Generation.ToString();
                sc_reactor.tb_gen.TextAlignment = TextAlignment.Right;
            }
        }

        #endregion

        #region Engine

        private void InitialiseEngine()
        {
            sc_engine.ComboBox.ItemsSource = Ship_Loadout.Components.Components.Engines;
            sc_engine.ComboBox.DisplayMemberPath = "Name";
            sc_engine.ComboBox.SelectionChanged += EngineSelectionChanged;

            TextBlock tb_engine = new TextBlock();
            tb_engine.HorizontalAlignment = HorizontalAlignment.Center;
            tb_engine.Text = "Engine";
            tb_engine.Foreground = new SolidColorBrush(Colors.Orange);

            StackPanel sp_engine = new StackPanel();
            sp_engine.Children.Add(tb_engine);
            sp_engine.Children.Add(sc_engine);

            WrapPanelOne.Children.Add(sp_engine);
        }

        private void EngineSelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            Ship_Loadout.Components.Components.EngineCache =
                Ship_Loadout.Components.Components.Engines[cmb.SelectedIndex];

            Engine engine = Ship_Loadout.Components.Components.EngineCache;

            if (engine != null)
            {
                sc_engine.tb_armour.Text = engine.Armour.ToString();
                sc_engine.tb_drain.Text = engine.Drain.ToString();
                sc_engine.tb_mass.Text = engine.Mass.ToString();
                sc_engine.tb_pitch.Text = engine.Pitch.ToString();
                sc_engine.tb_yaw.Text = engine.Yaw.ToString();
                sc_engine.tb_roll.Text = engine.Roll.ToString();
                sc_engine.tb_speed.Text = engine.Speed.ToString();
            }
        }

        #endregion

        #region Booster 

        private void InitialiseBooster()
        {
            sc_booster.ComboBox.ItemsSource = Ship_Loadout.Components.Components.Boosters;
            sc_booster.ComboBox.DisplayMemberPath = "Name";
            sc_booster.ComboBox.SelectionChanged += BoosterSelectionChanged;

            TextBlock tb_booster = new TextBlock();
            tb_booster.HorizontalAlignment = HorizontalAlignment.Center;
            tb_booster.Text = "Booster";
            tb_booster.Foreground = new SolidColorBrush(Colors.Orange);

            StackPanel sp_booster = new StackPanel();
            sp_booster.Children.Add(tb_booster);
            sp_booster.Children.Add(sc_booster);

            WrapPanelOne.Children.Add(sp_booster);
        }

        private void BoosterSelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            Ship_Loadout.Components.Components.BoosterCache =
                Ship_Loadout.Components.Components.Boosters[cmb.SelectedIndex];

            Booster booster = Ship_Loadout.Components.Components.BoosterCache;

            if (booster != null)
            {
                sc_booster.tb_armour.Text = booster.Armour.ToString();
                sc_booster.tb_drain.Text = booster.Drain.ToString();
                sc_booster.tb_mass.Text = booster.Mass.ToString();
                sc_booster.tb_energy.Text = booster.Energy.ToString();
                sc_booster.tb_recharge.Text = booster.Recharge.ToString();
                sc_booster.tb_consumption.Text = booster.Consumption.ToString();
                sc_booster.tb_acceleration.Text = booster.Acceleration.ToString();
                sc_booster.tb_speed.Text = booster.Speed.ToString();
            }
        }

        #endregion

        #region Shield

        private void InitialiseShield()
        {
            sc_shield.ComboBox.ItemsSource = Ship_Loadout.Components.Components.Shields;
            sc_shield.ComboBox.DisplayMemberPath = "Name";
            sc_shield.ComboBox.SelectionChanged += ShieldSelectionChanged;

            TextBlock tb_shield = new TextBlock();
            tb_shield.HorizontalAlignment = HorizontalAlignment.Center;
            tb_shield.Text = "Shield";
            tb_shield.Foreground = new SolidColorBrush(Colors.Orange);



            StackPanel sp_shield = new StackPanel();
            sp_shield.Children.Add(tb_shield);
            sp_shield.Children.Add(sc_shield);

            WrapPanelOne.Children.Add(sp_shield);
        }

        private void ShieldSelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            Ship_Loadout.Components.Components.ShieldCache =
                Ship_Loadout.Components.Components.Shields[cmb.SelectedIndex];

            Shield shield = Ship_Loadout.Components.Components.ShieldCache;

            if (shield != null)
            {
                sc_shield.tb_armour.Text = shield.Armour.ToString();
                sc_shield.tb_drain.Text = shield.Drain.ToString();
                sc_shield.tb_mass.Text = shield.Mass.ToString();
                sc_shield.tb_frontHP.Text = shield.FHP.ToString();
                sc_shield.tb_rearHP.Text = shield.RHP.ToString();
                sc_shield.tb_recharge.Text = shield.RR.ToString();
            }
        }

        #endregion

        #region Armour


        #endregion

        #region Droid Interface

        private void InitialiseDI()
        {
            sc_di.ComboBox.ItemsSource = Ship_Loadout.Components.Components.DroidInterfaces;
            sc_di.ComboBox.DisplayMemberPath = "Name";
            sc_di.ComboBox.SelectionChanged += DISelectionChanged;

            TextBlock tb_DI = new TextBlock();
            tb_DI.HorizontalAlignment = HorizontalAlignment.Center;
            tb_DI.Text = "Droid Interface";
            tb_DI.Foreground = new SolidColorBrush(Colors.Orange);


            StackPanel sp_DI = new StackPanel();
            sp_DI.Children.Add(tb_DI);
            sp_DI.Children.Add(sc_di);

            WrapPanelOne.Children.Add(sp_DI);
        }

        private void DISelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            Ship_Loadout.Components.Components.DECache =
                Ship_Loadout.Components.Components.DroidInterfaces[cmb.SelectedIndex];

            DroidInterface di = Ship_Loadout.Components.Components.DECache;

            if (di != null)
            {
                sc_di.tb_armour.Text = di.Armour.ToString();
                sc_di.tb_drain.Text = di.Drain.ToString();
                sc_di.tb_mass.Text = di.Mass.ToString();
                sc_di.tb_speed.Text = di.Speed.ToString();
            }
        }

        #endregion

        #region Capacitor

        private void InitialiseCapacitor()
        {
            sc_cap.ComboBox.ItemsSource = Ship_Loadout.Components.Components.Capacitors;
            sc_cap.ComboBox.DisplayMemberPath = "Name";
            sc_cap.ComboBox.SelectionChanged += CapacitorSelectionChanged;

            TextBlock tb_Cap = new TextBlock();
            tb_Cap.HorizontalAlignment = HorizontalAlignment.Center;
            tb_Cap.Text = "Capacitor";
            tb_Cap.Foreground = new SolidColorBrush(Colors.Orange);


            StackPanel sp_cap = new StackPanel();
            sp_cap.Children.Add(tb_Cap);
            sp_cap.Children.Add(sc_cap);

            WrapPanelOne.Children.Add(sp_cap);
        }

        private void CapacitorSelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            Ship_Loadout.Components.Components.CapacitorCache =
                Ship_Loadout.Components.Components.Capacitors[cmb.SelectedIndex];

            Capacitor cap = Ship_Loadout.Components.Components.CapacitorCache;

            if (cap != null)
            {
                sc_cap.tb_armour.Text = cap.Armour.ToString();
                sc_cap.tb_drain.Text = cap.Drain.ToString();
                sc_cap.tb_mass.Text = cap.Mass.ToString();
                sc_cap.tb_energy.Text = cap.Energy.ToString();
                sc_cap.tb_recharge.Text = cap.RechargeRate.ToString();
            }
        }

        #endregion

        #region Ordinance


        #region Turrets



        #endregion

        #endregion

        #region Weapons

        private void InitialiseWeapons()
        {
            for (int i = 0; i < ship.Weapons; i++)
            {
                WeaponComponent sc_weapon = new WeaponComponent();

                TextBlock tb_weapon = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = "Weapon " + (i + 1),
                    Foreground = new SolidColorBrush(Colors.Orange)
                };

                sc_weapon.ComboBox.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                sc_weapon.ComboBox.DisplayMemberPath = "Name";
                sc_weapon.ComboBox.SelectionChanged += (WeaponSelectionChanged);

                var sp_weapon = new StackPanel { Children = { tb_weapon, sc_weapon } };

                WrapPanelTwo.Children.Add(sp_weapon);
            }
        }

        private void WeaponSelectionChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            var parent = cmb.Parent;

            Ship_Loadout.Components.Components.WeaponCache = Ship_Loadout.Components.Components.Weapons[cmb.SelectedIndex];

            //UpdateWeapons(sender, e);

            Weapon weapon = Ship_Loadout.Components.Components.WeaponCache;
            if (weapon != null)
            {
                WeaponComponent sc_weapon = new WeaponComponent();

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

        #endregion

        #region Counter Measures

        

        #endregion
    }
}
