using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ship_Loadout.Components;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class DisplayLoadout : Page
    {
        private Ship ship;

        public DisplayLoadout(Ship _ship)
        {
            InitializeComponent();

            ship = _ship;

            InitialiseReactor();
            InitialiseEngine();
            InitialiseBooster();
            InitialiseShield();
            InitialiseArmour();

            InitialiseDI();
            InitialiseCapacitor();

            InitialiseOrdinance();

            InitialiseWeapons();

            InitialiseCountermeasures();

            InitialiseTurrets();

            InitialiseCargobay();

            InitialiseShipDetails();

            InitialiseOverloads();

            CalculateCurrentMass();
            ChangeReactorStats();
        }

        #region Reactor

        private void InitialiseReactor()
        {
            var reactors = Components.Components.Reactors;
            if (reactors.Count > 0 && (!string.IsNullOrEmpty(reactors.FirstOrDefault().Name)))
                reactors.Insert(0, new Reactor());
            cb_reactor.ItemsSource = reactors;

            //Load existing component (if any)
            if (ship.Reactor != null)
            {
                cb_reactor.Text = ship.Reactor.Name;

                tb_reactorArmour.Text = ship.Reactor.Armour.ToString();
                tb_reactorMass.Text = ship.Reactor.Mass.ToString();
                tb_reactorGeneration.Text = ship.Reactor.Generation.ToString();

                tb_currentGeneration.Text = $"{ship.Reactor.Generation}";
            }
        }

        private void ReactorSelectionChanged(object sender, System.EventArgs e)
        {
            Reactor reactor = (Reactor)cb_reactor.SelectedItem;

            if (reactor != null)
            {
                tb_reactorArmour.Text = reactor.Armour.ToString();
                tb_reactorMass.Text = reactor.Mass.ToString();
                tb_reactorGeneration.Text = reactor.Generation.ToString();

                ship.Reactor = reactor;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
            else
            {
                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        // Updates reactor stats text colour
        // Updates reactor stats text box text
        private void ChangeReactorStats()
        {
            if (ship == null)
                return; 

            // Set text colours
            if (ship.RemainingDrain < 0)
                tb_remainingDrain.Foreground = Brushes.Red;
            else
                tb_remainingDrain.Foreground = Brushes.Orange;

            // Update textboxes
            tb_currentDrain.Text = ship.CurrentEnergyDrain.ToString();
            tb_remainingDrain.Text = ship.RemainingDrain.ToString();
            tb_currentGeneration.Text = ship.OverridenGeneration.ToString();
        }

        private void ReactorOverloadChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ship != null)
                ship.ReactorOverride = cb_reactorOverload.SelectedIndex;

            PerformReactorFunctions();
        }

        private void PerformReactorFunctions()
        {
            if (ship != null)
            {
                ship.CurrentEnergyDrain = CalculateCurrentDrain();
                ship.OverridenGeneration = ReactorOverloadCalculation();


                if (ship.Reactor != null)
                    ship.RemainingDrain = ship.OverridenGeneration - ship.CurrentEnergyDrain;
                else
                    ship.RemainingDrain = 0 - ship.CurrentEnergyDrain;

                ChangeReactorStats();
                HighlightDisabledComponents();
            }
        }

        private float ReactorOverloadCalculation()
        {
            if (ship.Reactor == null)
                return 0;

            // Reactor Override calculation
            var multiplier = 0f;
            switch (ship.ReactorOverride)
            {
                case 0: { multiplier = 0f; } break;
                case 1: { multiplier = 1.09f; } break;
                case 2: { multiplier = 1.29f; } break;
                case 3: { multiplier = 1.59f; } break;
                case 4: { multiplier = 1.89f; } break;
            }

            if (multiplier > 0)
                return ship.Reactor.Generation * multiplier;

            return ship.Reactor.Generation;
        }

        private float CalculateCurrentDrain()
        {
            if (ship == null)
                return 0;

            float drain = 0f;

            if (ship.Engine != null)
                drain += UpdateEngineDrain(ship.Engine.Drain);

            if (ship.Booster != null)
                drain += ship.Booster.Drain;

            if (ship.Shield != null)
                drain += ship.Shield.Drain;

            if (ship.DroidInterface != null)
                drain += ship.DroidInterface.Drain;

            if (ship.Capacitor != null)
                drain += ship.Capacitor.Drain;

            if (ship.Ord1 != null)
                drain += ship.Ord1.Drain;

            if (ship.Ord2 != null)
                drain += ship.Ord2.Drain;

            if (ship.Weapon1 != null)
                drain += ship.Weapon1.Drain;

            if (ship.Weapon2 != null)
                drain += ship.Weapon2.Drain;

            if (ship.Weapon3 != null)
                drain += ship.Weapon3.Drain;

            if (ship.Weapon4 != null)
                drain += ship.Weapon4.Drain;

            if (ship.Weapon5 != null)
                drain += ship.Weapon5.Drain;

            if (ship.Weapon6 != null)
                drain += ship.Weapon6.Drain;

            if (ship.Turret1 != null)
                drain += ship.Turret1.Drain;

            if (ship.Turret2 != null)
                drain += ship.Turret2.Drain;

            if (ship.Turret3 != null)
                drain += ship.Turret3.Drain;

            if (ship.Turret4 != null)
                drain += ship.Turret4.Drain;

            if (ship.Turret5 != null)
                drain += ship.Turret5.Drain;

            if (ship.Turret6 != null)
                drain += ship.Turret6.Drain;

            if (ship.CM1 != null)
                drain += ship.CM1.Drain;

            if (ship.CM2 != null)
                drain += ship.CM2.Drain;

            return drain;
        }

        private void HighlightDisabledComponents()
        {
            float drain = 0f;

            if (ship.Engine != null)
            {
                drain += ship.Engine.Drain;

                border_engine.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Shield != null)
            {
                drain += ship.Shield.Drain;
                border_shield.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Capacitor != null)
            {
                drain += ship.Capacitor.Drain;
                border_capacitor.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Booster != null)
            {
                drain += ship.Booster.Drain;
                border_booster.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.DroidInterface != null)
            {
                drain += ship.DroidInterface.Drain;
                border_di.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Weapon1 != null)
            {
                drain += ship.Weapon1.Drain;
                gd_WepOne.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Weapon2 != null)
            {
                drain += ship.Weapon2.Drain;
                gd_WepTwo.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Weapon3 != null)
            {
                drain += ship.Weapon3.Drain;
                gd_WepThree.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Weapon4 != null)
            {
                drain += ship.Weapon4.Drain;
                gd_WepFour.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Weapon5 != null)
            {
                drain += ship.Weapon5.Drain;
                gd_WepFive.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Weapon6 != null)
            {
                drain += ship.Weapon6.Drain;
                gd_WepSix.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Turret1 != null)
            {
                drain += ship.Turret1.Drain;
                gd_turretOne.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Turret2 != null)
            {
                drain += ship.Turret2.Drain;
                gd_turretTwo.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Turret3 != null)
            {
                drain += ship.Turret3.Drain;
                gd_turretThree.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Turret4 != null)
            {
                drain += ship.Turret4.Drain;
                gd_turretFour.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Turret5 != null)
            {
                drain += ship.Turret5.Drain;
                gd_turretFive.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Turret6 != null)
            {
                drain += ship.Turret6.Drain;
                gd_turretSix.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Ord1 != null)
            {
                drain += ship.Ord1.Drain;
                gd_ordOne.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.Ord2 != null)
            {
                drain += ship.Ord2.Drain;
                gd_ordTwo.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.CM1 != null)
            {
                drain += ship.CM1.Drain;
                gd_cmOne.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }

            if (ship.CM2 != null)
            {
                drain += ship.CM2.Drain;
                gd_cmTwo.BorderBrush = drain > ship?.OverridenGeneration ? Brushes.Red : Brushes.Orange;
            }
        }

        #endregion

        #region Engine

        private void InitialiseEngine()
        {
            var engines = Components.Components.Engines;
            if (engines.Count > 0 && !string.IsNullOrEmpty(engines.FirstOrDefault().Name))
                engines.Insert(0, new Engine());

            cb_engine.ItemsSource = engines;

            //Load existing component (if any)
            if (ship.Engine != null)
            {
                cb_engine.Text = ship.Engine.Name;

                tb_engineArmour.Text = ship.Engine.Armour.ToString();
                tb_engineDrain.Text = ship.Engine.Drain.ToString();
                tb_engineMass.Text = ship.Engine.Mass.ToString();
                tb_enginePitch.Text = ship.Engine.Pitch.ToString();
                tb_engineYaw.Text = ship.Engine.Yaw.ToString();
                tb_engineRoll.Text = ship.Engine.Roll.ToString();
                tb_engineSpeed.Text = ship.Engine.Speed.ToString();
            }
        }

        private void EngineSelectionChanged(object sender, System.EventArgs e)
        {
            Engine engine = (Engine)cb_engine.SelectedItem;

            if (engine != null)
            {
                tb_engineArmour.Text = engine.Armour.ToString();
                tb_engineDrain.Text = engine.Drain.ToString();
                tb_engineMass.Text = engine.Mass.ToString();
                tb_enginePitch.Text = engine.Pitch.ToString();
                tb_engineYaw.Text = engine.Yaw.ToString();
                tb_engineRoll.Text = engine.Roll.ToString();
                tb_engineSpeed.Text = engine.Speed.ToString();

                ship.Engine = engine;

                CalculateCurrentMass();
                PerformReactorFunctions();
                UpdateShipManoeuvreStats();
            }
        }

        private void EngineOverloadChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ship != null)
            {
                ship.EngineOverride = cb_engineOverload.SelectedIndex;
                UpdateShipManoeuvreStats();
            }

            PerformReactorFunctions();
        }

        private void UpdateShipManoeuvreStats()
        {
            var _pitch = ship?.Pitch ?? 0f;
            var _yaw = ship?.Yaw ?? 0f;
            var _roll = ship?.Roll ?? 0f;
            var _speedLow = ship?.SpeedLow ?? 0f;
            var _speedTop = ship?.SpeedTop ?? 0f;
            
            var _engineSpeed = ship?.Engine?.Speed ?? 0f;

            var overload = GetEngineOverload(cb_engineOverload.SelectedIndex);

            tb_shipPitch.Text = $"{Math.Round( _pitch * overload, 1)}";
            tb_shipYaw.Text = $"{Math.Round(_yaw * overload, 1)}";
            tb_shipRoll.Text = $"{Math.Round(_roll * overload, 1)}";
            tb_shipSpeed.Text = $"{Math.Round(10 * _engineSpeed * _speedLow * overload, 0)}" +
                                $"/{Math.Round(10 * _engineSpeed * _speedTop * overload), 0}";
        }

        private float UpdateEngineDrain(float drain)
        {
            //float drain = 0f;
            int overload = cb_engineOverload.SelectedIndex;

            switch (overload)
            {
                case 0: drain = drain * 1; break;
                case 1: drain = drain * 1.25f; break;
                case 2: drain = drain * 1.67f; break;
                case 3: drain = drain * 3.33f; break;
                case 4: drain = drain * 10f; break;
            }

            return drain;
        }

        private float GetEngineOverload(int overloadLevel)
        {
            var modifier = 0f; 

            switch (overloadLevel)
            {
                case 0: { modifier = 1; } break;
                case 1: { modifier = 1.1f; } break;
                case 2: { modifier = 1.2f; } break;
                case 3: { modifier = 1.3f; } break;
                case 4: { modifier = 1.4f; } break;
            }

            return modifier;
        }

        #endregion

        #region Booster 

        private void InitialiseBooster()
        {
            var boosters = Components.Components.Boosters;
            if (boosters.Count > 0 && !string.IsNullOrEmpty(boosters.FirstOrDefault().Name))
                boosters.Insert(0, new Booster());
            cb_booster.ItemsSource = boosters;

            //Load existing component (if any)
            if (ship.Booster != null)
            {
                cb_booster.Text = ship.Booster.Name;

                tb_boosterArmour.Text = ship.Booster.Armour.ToString();
                tb_boosterDrain.Text = ship.Booster.Drain.ToString();
                tb_boosterMass.Text = ship.Booster.Mass.ToString();
                tb_boosterEnergy.Text = ship.Booster.Energy.ToString();
                tb_boosterRecharge.Text = ship.Booster.Recharge.ToString();
                tb_boosterConsumption.Text = ship.Booster.Consumption.ToString();
                tb_BoosterAcceleration.Text = ship.Booster.Acceleration.ToString();
                tb_BoosterSpeed.Text = ship.Booster.Speed.ToString();
            }
        }

        private void BoosterSelectionChanged(object sender, System.EventArgs e)
        {
            Booster booster = (Booster)cb_booster.SelectedItem;

            if (booster != null)
            {
                tb_boosterArmour.Text = booster.Armour.ToString();
                tb_boosterDrain.Text = booster.Drain.ToString();
                tb_boosterMass.Text = booster.Mass.ToString();
                tb_boosterEnergy.Text = booster.Energy.ToString();
                tb_boosterRecharge.Text = booster.Recharge.ToString();
                tb_boosterConsumption.Text = booster.Consumption.ToString();
                tb_BoosterAcceleration.Text = booster.Acceleration.ToString();
                tb_BoosterSpeed.Text = booster.Speed.ToString();

                ship.Booster = booster;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        #endregion

        #region Shield

        private void InitialiseShield()
        {
            var shields = Components.Components.Shields;
            if (shields.Count > 0 && !string.IsNullOrEmpty(shields.FirstOrDefault().Name))
                shields.Insert(0, new Shield());
            cb_shield.ItemsSource = shields;

            //Load existing component (if any)
            if (ship.Shield != null)
            {
                cb_shield.Text = ship.Shield.Name;

                tb_shieldArmour.Text = ship.Shield.Armour.ToString();
                tb_shieldDrain.Text = ship.Shield.Drain.ToString();
                tb_shieldMass.Text = ship.Shield.Mass.ToString();
                tb_shieldFront.Text = ship.Shield.FHP.ToString();
                tb_shieldRear.Text = ship.Shield.RHP.ToString();
                tb_shieldRecharge.Text = ship.Shield.RR.ToString();
                tb_shieldAdjust.Text = ship.Shield.Adjust.ToString();
            }
        }

        private void ShieldSelectionChanged(object sender, System.EventArgs e)
        {
            Shield shield = (Shield)cb_shield.SelectedItem;

            if (shield != null)
            {
                tb_shieldArmour.Text = shield.Armour.ToString();
                tb_shieldDrain.Text = shield.Drain.ToString();
                tb_shieldMass.Text = shield.Mass.ToString();
                tb_shieldFront.Text = shield.FHP.ToString();
                tb_shieldRear.Text = shield.RHP.ToString();
                tb_shieldRecharge.Text = shield.RR.ToString();
                tb_shieldAdjust.Text = shield.Adjust.ToString();

                ship.Shield = shield;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        #endregion

        #region Armour

        private void InitialiseArmour()
        {
            var armour = Components.Components.Armours;
            if (armour.Count > 0 && !string.IsNullOrEmpty(armour.FirstOrDefault().Name))
                armour.Insert(0, new Armour());
            cb_armourFront.ItemsSource = armour;
            cb_armourRear.ItemsSource = armour;

            //Load existing component (if any)
            if (ship.FrontArmour != null)
            {
                cb_armourFront.Text = ship.FrontArmour.Name;

                tb_frontArmourArmour.Text = ship.FrontArmour.Armor.ToString();
                tb_frontArmourMass.Text = ship.FrontArmour.Mass.ToString();
            }

            if (ship.RearArmour != null)
            {
                cb_armourRear.Text = ship.RearArmour.Name;

                tb_frontArmourArmour.Text = ship.RearArmour.Armor.ToString();
                tb_frontArmourMass.Text = ship.RearArmour.Mass.ToString();
            }
        }

        private void FrontArmourChanged(object sender, SelectionChangedEventArgs e)
        {
            Armour armour = (Armour)cb_armourFront.SelectedItem;

            if (armour != null)
            {
                tb_frontArmourArmour.Text = armour.Armor.ToString();
                tb_frontArmourMass.Text = armour.Mass.ToString();

                ship.FrontArmour = armour;

                CalculateCurrentMass();
            }
        }

        private void RearArmourChanged(object sender, SelectionChangedEventArgs e)
        {
            Armour armour = (Armour)cb_armourFront.SelectedItem;

            if (armour != null)
            {
                tb_rearArmourArmour.Text = armour.Armor.ToString();
                tb_rearArmourMass.Text = armour.Mass.ToString();

                ship.RearArmour = armour;

                CalculateCurrentMass();
            }
        }

        #endregion

        #region Droid Interface

        private void InitialiseDI()
        {
            var dI = Components.Components.DroidInterfaces;
            if (dI.Count > 0 && !string.IsNullOrEmpty(dI.FirstOrDefault().Name))
                dI.Insert(0, new DroidInterface());
            cb_droidInterface.ItemsSource = dI;

            //Load existing component (if any)
            if (ship.DroidInterface != null)
            {
                cb_droidInterface.Text = ship.DroidInterface.Name;

                tb_diArmour.Text = ship.DroidInterface.Armour.ToString();
                tb_diDrain.Text = ship.DroidInterface.Drain.ToString();
                tb_diMass.Text = ship.DroidInterface.Mass.ToString();
                tb_diSpeed.Text = ship.DroidInterface.Speed.ToString();
            }
        }

        private void DISelectionChanged(object sender, System.EventArgs e)
        {
            DroidInterface di = (DroidInterface)cb_droidInterface.SelectedItem;

            if (di != null)
            {
                tb_diArmour.Text = di.Armour.ToString();
                tb_diDrain.Text = di.Drain.ToString();
                tb_diMass.Text = di.Mass.ToString();
                tb_diSpeed.Text = di.Speed.ToString();

                ship.DroidInterface = di;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        #endregion

        #region Capacitor

        private void InitialiseCapacitor()
        {
            var capacitors = Components.Components.Capacitors;
            if (capacitors.Count > 0 && !string.IsNullOrEmpty(capacitors.FirstOrDefault().Name))
                capacitors.Insert(0, new Capacitor());
            cb_capacitor.ItemsSource = capacitors;

            //Load existing component (if any)
            if (ship.Capacitor != null)
            {
                cb_capacitor.Text = ship.Capacitor.Name;

                tb_capArmour.Text = ship.Capacitor.Armour.ToString();
                tb_capDrain.Text = ship.Capacitor.Drain.ToString();
                tb_capMass.Text = ship.Capacitor.Mass.ToString();
                tb_capEnergy.Text = ship.Capacitor.Energy.ToString();
                tb_capRecharge.Text = ship.Capacitor.RechargeRate.ToString();
            }
        }

        private void CapacitorSelectionChanged(object sender, System.EventArgs e)
        {
            Capacitor cap = (Capacitor)cb_capacitor.SelectedItem;

            if (cap != null)
            {
                tb_capArmour.Text = cap.Armour.ToString();
                tb_capDrain.Text = cap.Drain.ToString();
                tb_capMass.Text = cap.Mass.ToString();
                tb_capEnergy.Text = cap.Energy.ToString();
                tb_capRecharge.Text = cap.RechargeRate.ToString();

                ship.Capacitor = cap;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void CapacitorOverloadChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ship != null)
                ship.CapacitorOverride = cb_capacitorOverload.SelectedIndex;
            CalculateCurrentDrain();
        }

        #endregion

        #region Ordinance

        private void InitialiseOrdinance()
        {
            var ordinance = Components.Components.Ordinances;
            if (ordinance.Count > 0 && !string.IsNullOrEmpty(ordinance.FirstOrDefault().Name))
                ordinance.Insert(0, new Ordinance());

            switch (ship.Ordinance)
            {
                case 0:
                {
                    gd_ordOne.Visibility = Visibility.Collapsed;
                    gd_ordTwo.Visibility = Visibility.Collapsed;

                    cb_ordOne.ItemsSource = null;
                    cb_ordTwo.ItemsSource = null;
                }
                    break;

                case 1:
                {
                    gd_ordOne.Visibility = Visibility.Visible;
                    gd_ordTwo.Visibility = Visibility.Collapsed;

                    cb_ordOne.ItemsSource = ordinance;
                    cb_ordTwo.ItemsSource = null;
                }
                    break;

                case 2:
                {
                    gd_ordOne.Visibility = Visibility.Visible;
                    gd_ordTwo.Visibility = Visibility.Visible;

                    cb_ordOne.ItemsSource = ordinance;
                    cb_ordTwo.ItemsSource = ordinance;
                }
                    break;
            }

            //Load existing component (if any)
            if (ship.Ord1 != null)
            {
                cb_ordOne.Text = ship.Ord1.Name;

                tb_ordOneArmour.Text = ship.Ord1.Armour.ToString();
                tb_ordOneDrain.Text = ship.Ord1.Drain.ToString();
                tb_ordOneMass.Text = ship.Ord1.Mass.ToString();
                tb_ordOneMinDam.Text = ship.Ord1.MinDam.ToString();
                tb_ordOneMaxDam.Text = ship.Ord1.MaxDam.ToString();
                tb_ordOneVsShield.Text = ship.Ord1.VShield.ToString();
                tb_ordOneVsArmour.Text = ship.Ord1.VArmour.ToString();
                tb_ordOneAmmo.Text = ship.Ord1.Ammo.ToString();
            }

            if (ship.Ord2 != null)
            {
                cb_ordTwo.Text = ship.Ord2.Name;

                tb_ordTwoArmour.Text = ship.Ord2.Armour.ToString();
                tb_ordTwoDrain.Text = ship.Ord2.Drain.ToString();
                tb_ordTwoMass.Text = ship.Ord2.Mass.ToString();
                tb_ordTwoMinDam.Text = ship.Ord2.MinDam.ToString();
                tb_ordTwoMaxDam.Text = ship.Ord2.MaxDam.ToString();
                tb_ordTwoVsShield.Text = ship.Ord2.VShield.ToString();
                tb_ordTwoVsArmour.Text = ship.Ord2.VArmour.ToString();
                tb_ordTwoAmmo.Text = ship.Ord2.Ammo.ToString();
            }
        }

        private void OrdinanceOneChanged(object sender, SelectionChangedEventArgs e)
        {
            Ordinance ord = (Ordinance)cb_ordOne.SelectedItem;

            if (ord != null)
            {
                tb_ordOneArmour.Text = ord.Armour.ToString();
                tb_ordOneDrain.Text = ord.Drain.ToString();
                tb_ordOneMass.Text = ord.Mass.ToString();
                tb_ordOneMinDam.Text = ord.MinDam.ToString();
                tb_ordOneMaxDam.Text = ord.MaxDam.ToString();
                tb_ordOneVsShield.Text = ord.VShield.ToString();
                tb_ordOneVsArmour.Text = ord.VArmour.ToString();
                tb_ordOneAmmo.Text = ord.Ammo.ToString();

                ship.Ord1 = ord;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void OrdinanceTwoChanged(object sender, SelectionChangedEventArgs e)
        {
            Ordinance ord = (Ordinance)cb_ordTwo.SelectedItem;

            if (ord != null)
            {
                tb_ordTwoArmour.Text = ord.Armour.ToString();
                tb_ordTwoDrain.Text = ord.Drain.ToString();
                tb_ordTwoMass.Text = ord.Mass.ToString();
                tb_ordTwoMinDam.Text = ord.MinDam.ToString();
                tb_ordTwoMaxDam.Text = ord.MaxDam.ToString();
                tb_ordTwoVsShield.Text = ord.VShield.ToString();
                tb_ordTwoVsArmour.Text = ord.VArmour.ToString();
                tb_ordTwoAmmo.Text = ord.Ammo.ToString();

                ship.Ord2 = ord;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        #endregion

        #region Weapons

        private void InitialiseWeapons()
        {
            var weapons = Components.Components.Weapons;
            if (weapons.Count > 0 && !string.IsNullOrEmpty(weapons.FirstOrDefault().Name))
                weapons.Insert(0, new Weapon());

            switch (ship.Weapons)
            {
                case 0:
                    {
                        gd_WepOne.Visibility = Visibility.Collapsed;
                        gd_WepTwo.Visibility = Visibility.Collapsed;
                        gd_WepThree.Visibility = Visibility.Collapsed;
                        gd_WepFour.Visibility = Visibility.Collapsed;
                        gd_WepFive.Visibility = Visibility.Collapsed;
                        gd_WepSix.Visibility = Visibility.Collapsed;

                        cb_wepOne.ItemsSource = null;
                        cb_wepTwo.ItemsSource = null;
                        cb_wepThree.ItemsSource = null;
                        cb_wepFour.ItemsSource = null;
                        cb_wepFive.ItemsSource = null;
                        cb_wepSix.ItemsSource = null;
                    }
                    break;

                case 1:
                    {
                        gd_WepOne.Visibility = Visibility.Visible;
                        gd_WepTwo.Visibility = Visibility.Collapsed;
                        gd_WepThree.Visibility = Visibility.Collapsed;
                        gd_WepFour.Visibility = Visibility.Collapsed;
                        gd_WepFive.Visibility = Visibility.Collapsed;
                        gd_WepSix.Visibility = Visibility.Collapsed;

                        cb_wepOne.ItemsSource = weapons;
                        cb_wepTwo.ItemsSource = null;
                        cb_wepThree.ItemsSource = null;
                        cb_wepFour.ItemsSource = null;
                        cb_wepFive.ItemsSource = null;
                        cb_wepSix.ItemsSource = null;
                    }
                    break;

                case 2:
                    {
                        gd_WepOne.Visibility = Visibility.Visible;
                        gd_WepTwo.Visibility = Visibility.Visible;
                        gd_WepThree.Visibility = Visibility.Collapsed;
                        gd_WepFour.Visibility = Visibility.Collapsed;
                        gd_WepFive.Visibility = Visibility.Collapsed;
                        gd_WepSix.Visibility = Visibility.Collapsed;

                        cb_wepOne.ItemsSource = weapons;
                        cb_wepTwo.ItemsSource = weapons;
                        cb_wepThree.ItemsSource = null;
                        cb_wepFour.ItemsSource = null;
                        cb_wepFive.ItemsSource = null;
                        cb_wepSix.ItemsSource = null;
                    }
                    break;
                case 3:
                    {
                        gd_WepOne.Visibility = Visibility.Visible;
                        gd_WepTwo.Visibility = Visibility.Visible;
                        gd_WepThree.Visibility = Visibility.Visible;
                        gd_WepFour.Visibility = Visibility.Collapsed;
                        gd_WepFive.Visibility = Visibility.Collapsed;
                        gd_WepSix.Visibility = Visibility.Collapsed;

                        cb_wepOne.ItemsSource = weapons;
                        cb_wepTwo.ItemsSource = weapons;
                        cb_wepThree.ItemsSource = weapons;
                        cb_wepFour.ItemsSource = null;
                        cb_wepFive.ItemsSource = null;
                        cb_wepSix.ItemsSource = null;
                    }
                    break;
                case 4:
                {
                    gd_WepOne.Visibility = Visibility.Visible;
                    gd_WepTwo.Visibility = Visibility.Visible;
                    gd_WepThree.Visibility = Visibility.Visible;
                    gd_WepFour.Visibility = Visibility.Visible;
                    gd_WepFive.Visibility = Visibility.Collapsed;
                    gd_WepSix.Visibility = Visibility.Collapsed;

                    cb_wepOne.ItemsSource = weapons;
                    cb_wepTwo.ItemsSource = weapons;
                    cb_wepThree.ItemsSource = weapons;
                    cb_wepFour.ItemsSource = weapons;
                    cb_wepFive.ItemsSource = null;
                    cb_wepSix.ItemsSource = null;
                }
                    break;
                case 5:
                {
                    gd_WepOne.Visibility = Visibility.Visible;
                    gd_WepTwo.Visibility = Visibility.Visible;
                    gd_WepThree.Visibility = Visibility.Visible;
                    gd_WepFour.Visibility = Visibility.Visible;
                    gd_WepFive.Visibility = Visibility.Visible;
                    gd_WepSix.Visibility = Visibility.Collapsed;

                    cb_wepOne.ItemsSource = weapons;
                    cb_wepTwo.ItemsSource = weapons;
                    cb_wepThree.ItemsSource = weapons;
                    cb_wepFour.ItemsSource = weapons;
                    cb_wepFive.ItemsSource = weapons;
                    cb_wepSix.ItemsSource = null;
                }
                    break;
                case 6:
                {
                    gd_WepOne.Visibility = Visibility.Visible;
                    gd_WepTwo.Visibility = Visibility.Visible;
                    gd_WepThree.Visibility = Visibility.Visible;
                    gd_WepFour.Visibility = Visibility.Visible;
                    gd_WepFive.Visibility = Visibility.Visible;
                    gd_WepSix.Visibility = Visibility.Visible;

                    cb_wepOne.ItemsSource = weapons;
                    cb_wepTwo.ItemsSource = weapons;
                    cb_wepThree.ItemsSource = weapons;
                    cb_wepFour.ItemsSource = weapons;
                    cb_wepFive.ItemsSource = weapons;
                    cb_wepSix.ItemsSource = weapons;
                }
                    break;
            }

            //Load existing component (if any)
            if (ship.Weapon1 != null)
            {
                cb_wepOne.Text = ship.Weapon1.Name;

                tb_wepOneArmour.Text = ship.Weapon1.Armour.ToString();
                tb_wepOneDrain.Text = ship.Weapon1.Drain.ToString();
                tb_wepOneMass.Text = ship.Weapon1.Mass.ToString();
                tb_wepOneMinDam.Text = ship.Weapon1.MinD.ToString();
                tb_wepOneMaxDam.Text = ship.Weapon1.MaxD.ToString();
                tb_wepOneVsShield.Text = ship.Weapon1.VS.ToString();
                tb_wepOneVsArmour.Text = ship.Weapon1.VA.ToString();
                tb_wepOneEPS.Text = ship.Weapon1.EPS.ToString();
                tb_wepOneRR.Text = ship.Weapon1.RR.ToString();
            }

            if (ship.Weapon2 != null)
            {
                tb_wepTwoArmour.Text = ship.Weapon2.Armour.ToString();
                tb_wepTwoDrain.Text = ship.Weapon2.Drain.ToString();
                tb_wepTwoMass.Text = ship.Weapon2.Mass.ToString();
                tb_wepTwoMinDam.Text = ship.Weapon2.MinD.ToString();
                tb_wepTwoMaxDam.Text = ship.Weapon2.MaxD.ToString();
                tb_wepTwoVsShield.Text = ship.Weapon2.VS.ToString();
                tb_wepTwoVsArmour.Text = ship.Weapon2.VA.ToString();
                tb_wepTwoEPS.Text = ship.Weapon2.EPS.ToString();
                tb_wepTwoRR.Text = ship.Weapon2.RR.ToString();

                cb_wepTwo.Text = ship.Weapon2.Name;
            }

            if (ship.Weapon3 != null)
            {
                tb_wepThreeArmour.Text = ship.Weapon3.Armour.ToString();
                tb_wepThreeDrain.Text = ship.Weapon3.Drain.ToString();
                tb_wepThreeMass.Text = ship.Weapon3.Mass.ToString();
                tb_wepThreeMinDam.Text = ship.Weapon3.MinD.ToString();
                tb_wepThreeMaxDam.Text = ship.Weapon3.MaxD.ToString();
                tb_wepThreeVsShield.Text = ship.Weapon3.VS.ToString();
                tb_wepThreeVsArmour.Text = ship.Weapon3.VA.ToString();
                tb_wepThreeEPS.Text = ship.Weapon3.EPS.ToString();
                tb_wepThreeRR.Text = ship.Weapon3.RR.ToString();

                cb_wepThree.Text = ship.Weapon3.Name;
            }

            if (ship.Weapon4 != null)
            {
                tb_wepFourArmour.Text = ship.Weapon4.Armour.ToString();
                tb_wepFourDrain.Text = ship.Weapon4.Drain.ToString();
                tb_wepFourMass.Text = ship.Weapon4.Mass.ToString();
                tb_wepFourMinDam.Text = ship.Weapon4.MinD.ToString();
                tb_wepFourMaxDam.Text = ship.Weapon4.MaxD.ToString();
                tb_wepFourVsShield.Text = ship.Weapon4.VS.ToString();
                tb_wepFourVsArmour.Text = ship.Weapon4.VA.ToString();
                tb_wepFourEPS.Text = ship.Weapon4.EPS.ToString();
                tb_wepFourRR.Text = ship.Weapon4.RR.ToString();

                cb_wepFour.Text = ship.Weapon4.Name;
            }

            if (ship.Weapon5 != null)
            {
                tb_wepFiveArmour.Text = ship.Weapon5.Armour.ToString();
                tb_wepFiveDrain.Text = ship.Weapon5.Drain.ToString();
                tb_wepFiveMass.Text = ship.Weapon5.Mass.ToString();
                tb_wepFiveMinDam.Text = ship.Weapon5.MinD.ToString();
                tb_wepFiveMaxDam.Text = ship.Weapon5.MaxD.ToString();
                tb_wepFiveVsShield.Text = ship.Weapon5.VS.ToString();
                tb_wepFiveVsArmour.Text = ship.Weapon5.VA.ToString();
                tb_wepFiveEPS.Text = ship.Weapon5.EPS.ToString();
                tb_wepFiveRR.Text = ship.Weapon5.RR.ToString();

                cb_wepFive.Text = ship.Weapon5.Name;
            }

            if (ship.Weapon6 != null)
            {
                tb_wepSixArmour.Text = ship.Weapon6.Armour.ToString();
                tb_wepSixDrain.Text = ship.Weapon6.Drain.ToString();
                tb_wepSixMass.Text = ship.Weapon6.Mass.ToString();
                tb_wepSixMinDam.Text = ship.Weapon6.MinD.ToString();
                tb_wepSixMaxDam.Text = ship.Weapon6.MaxD.ToString();
                tb_wepSixVsShield.Text = ship.Weapon6.VS.ToString();
                tb_wepSixVsArmour.Text = ship.Weapon6.VA.ToString();
                tb_wepSixEPS.Text = ship.Weapon6.EPS.ToString();
                tb_wepSixRR.Text = ship.Weapon6.RR.ToString();

                cb_wepSix.Text = ship.Weapon6.Name;
            }
        }

        private void WeaponOneChanged(object sender, System.EventArgs e)
        {
            Weapon weapon = (Weapon)cb_wepOne.SelectedItem;

            if (weapon != null)
            {
                tb_wepOneArmour.Text = weapon.Armour.ToString();
                tb_wepOneDrain.Text = weapon.Drain.ToString();
                tb_wepOneMass.Text = weapon.Mass.ToString();
                tb_wepOneMinDam.Text = weapon.MinD.ToString();
                tb_wepOneMaxDam.Text = weapon.MaxD.ToString();
                tb_wepOneVsShield.Text = weapon.VS.ToString();
                tb_wepOneVsArmour.Text = weapon.VA.ToString();
                tb_wepOneEPS.Text = weapon.EPS.ToString();
                tb_wepOneRR.Text = weapon.RR.ToString();

                ship.Weapon1 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void WeaponTwoChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_wepTwo.SelectedItem;

            if (weapon != null)
            {
                tb_wepTwoArmour.Text = weapon.Armour.ToString();
                tb_wepTwoDrain.Text = weapon.Drain.ToString();
                tb_wepTwoMass.Text = weapon.Mass.ToString();
                tb_wepTwoMinDam.Text = weapon.MinD.ToString();
                tb_wepTwoMaxDam.Text = weapon.MaxD.ToString();
                tb_wepTwoVsShield.Text = weapon.VS.ToString();
                tb_wepTwoVsArmour.Text = weapon.VA.ToString();
                tb_wepTwoEPS.Text = weapon.EPS.ToString();
                tb_wepTwoRR.Text = weapon.RR.ToString();

                ship.Weapon2 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void WeaponThreeChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_wepThree.SelectedItem;

            if (weapon != null)
            {
                tb_wepThreeArmour.Text = weapon.Armour.ToString();
                tb_wepThreeDrain.Text = weapon.Drain.ToString();
                tb_wepThreeMass.Text = weapon.Mass.ToString();
                tb_wepThreeMinDam.Text = weapon.MinD.ToString();
                tb_wepThreeMaxDam.Text = weapon.MaxD.ToString();
                tb_wepThreeVsShield.Text = weapon.VS.ToString();
                tb_wepThreeVsArmour.Text = weapon.VA.ToString();
                tb_wepThreeEPS.Text = weapon.EPS.ToString();
                tb_wepThreeRR.Text = weapon.RR.ToString();

                ship.Weapon3 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void WeaponFourChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_wepFour.SelectedItem;

            if (weapon != null)
            {
                tb_wepFourArmour.Text = weapon.Armour.ToString();
                tb_wepFourDrain.Text = weapon.Drain.ToString();
                tb_wepFourMass.Text = weapon.Mass.ToString();
                tb_wepFourMinDam.Text = weapon.MinD.ToString();
                tb_wepFourMaxDam.Text = weapon.MaxD.ToString();
                tb_wepFourVsShield.Text = weapon.VS.ToString();
                tb_wepFourVsArmour.Text = weapon.VA.ToString();
                tb_wepFourEPS.Text = weapon.EPS.ToString();
                tb_wepFourRR.Text = weapon.RR.ToString();

                ship.Weapon4 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void WeaponFiveChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_wepFive.SelectedItem;

            if (weapon != null)
            {
                tb_wepFiveArmour.Text = weapon.Armour.ToString();
                tb_wepFiveDrain.Text = weapon.Drain.ToString();
                tb_wepFiveMass.Text = weapon.Mass.ToString();
                tb_wepFiveMinDam.Text = weapon.MinD.ToString();
                tb_wepFiveMaxDam.Text = weapon.MaxD.ToString();
                tb_wepFiveVsShield.Text = weapon.VS.ToString();
                tb_wepFiveVsArmour.Text = weapon.VA.ToString();
                tb_wepFiveEPS.Text = weapon.EPS.ToString();
                tb_wepFiveRR.Text = weapon.RR.ToString();

                ship.Weapon5 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void WeaponSixChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_wepSix.SelectedItem;

            if (weapon != null)
            {
                tb_wepSixArmour.Text = weapon.Armour.ToString();
                tb_wepSixDrain.Text = weapon.Drain.ToString();
                tb_wepSixMass.Text = weapon.Mass.ToString();
                tb_wepSixMinDam.Text = weapon.MinD.ToString();
                tb_wepSixMaxDam.Text = weapon.MaxD.ToString();
                tb_wepSixVsShield.Text = weapon.VS.ToString();
                tb_wepSixVsArmour.Text = weapon.VA.ToString();
                tb_wepSixEPS.Text = weapon.EPS.ToString();
                tb_wepSixRR.Text = weapon.RR.ToString();
                
                ship.Weapon5 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void WeaponOverloadChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ship != null)
                ship.WeaponOverride = cb_weaponOverload.SelectedIndex;
            
            CalculateCurrentDrain();
        }

        #endregion

        #region Counter Measures

        private void InitialiseCountermeasures()
        {
            var countermeasures = Components.Components.CounterMeasures;
            if (countermeasures.Count > 0 && !string.IsNullOrEmpty(countermeasures.FirstOrDefault().Name))
                countermeasures.Insert(0, new CounterMeasure());

            switch (ship.Countermeasures)
            {
                case 0:
                {
                    gd_cmOne.Visibility = Visibility.Collapsed;
                    gd_cmTwo.Visibility = Visibility.Collapsed;

                    cb_cmOne.ItemsSource = null;
                    cb_cmTwo.ItemsSource = null;
                }
                    break;

                case 1:
                {
                    gd_cmOne.Visibility = Visibility.Visible;
                    gd_cmTwo.Visibility = Visibility.Collapsed;

                    cb_cmOne.ItemsSource = countermeasures;
                    cb_cmTwo.ItemsSource = null;
                }
                    break;
                case 2:
                {
                    gd_cmOne.Visibility = Visibility.Visible;
                    gd_cmTwo.Visibility = Visibility.Visible;

                    cb_cmOne.ItemsSource = countermeasures;
                    cb_cmTwo.ItemsSource = countermeasures;
                }
                    break;
            }

            //Load existing component (if any)
            if (ship.CM1 != null)
            {
                tb_cmOneArmour.Text = ship.CM1.Armour.ToString();
                tb_cmOneDrain.Text = ship.CM1.Drain.ToString();
                tb_cmOneMass.Text = ship.CM1.Mass.ToString();

                cb_cmOne.Text = ship.CM1.Name;
            }

            if (ship.CM2 != null)
            {
                tb_cmTwoArmour.Text = ship.CM2.Armour.ToString();
                tb_cmTwoDrain.Text = ship.CM2.Drain.ToString();
                tb_cmTwoMass.Text = ship.CM2.Mass.ToString();

                cb_cmTwo.Text = ship.CM2.Name;
            }
        }

        private void CMOneChanged(object sender, SelectionChangedEventArgs e)
        {
            CounterMeasure cm = (CounterMeasure)cb_cmOne.SelectedItem;

            if (cm != null)
            {
                tb_cmOneArmour.Text = cm.Armour.ToString();
                tb_cmOneDrain.Text = cm.Drain.ToString();
                tb_cmOneMass.Text = cm.Mass.ToString();

                ship.CM1 = cm;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void CMTwoChanged(object sender, SelectionChangedEventArgs e)
        {
            CounterMeasure cm = (CounterMeasure)cb_cmTwo.SelectedItem;

            if (cm != null)
            {
                tb_cmTwoArmour.Text = cm.Armour.ToString();
                tb_cmTwoDrain.Text = cm.Drain.ToString();
                tb_cmTwoMass.Text = cm.Mass.ToString();

                ship.CM2 = cm;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        #endregion

        #region Turrets

        private void InitialiseTurrets()
        {
            var turrets = Components.Components.Weapons;
            if (turrets.Count > 0 && !string.IsNullOrEmpty(turrets.FirstOrDefault().Name))
                turrets.Insert(0, new Weapon());

            if (ship.Turrets > 0)
            {
                gd_turrets.Visibility = Visibility.Visible;

                switch (ship.Turrets)
                {
                    case 1:
                    {
                        gd_turretOne.Visibility = Visibility.Visible;
                        gd_turretTwo.Visibility = Visibility.Collapsed;
                        gd_turretThree.Visibility = Visibility.Collapsed;
                        gd_turretFour.Visibility = Visibility.Collapsed;
                        gd_turretFive.Visibility = Visibility.Collapsed;
                        gd_turretSix.Visibility = Visibility.Collapsed;

                        cb_turretOne.ItemsSource = turrets;
                        cb_turretTwo.ItemsSource = null;
                        cb_turretThree.ItemsSource = null;
                        cb_turretFour.ItemsSource = null;
                        cb_turretFive.ItemsSource = null;
                        cb_turretSix.ItemsSource = null;
                    }
                        break;

                    case 2:
                    {
                        gd_turretOne.Visibility = Visibility.Visible;
                        gd_turretTwo.Visibility = Visibility.Visible;
                        gd_turretThree.Visibility = Visibility.Collapsed;
                        gd_turretFour.Visibility = Visibility.Collapsed;
                        gd_turretFive.Visibility = Visibility.Collapsed;
                        gd_turretSix.Visibility = Visibility.Collapsed;

                        cb_turretOne.ItemsSource = turrets;
                        cb_turretTwo.ItemsSource = turrets;
                        cb_turretThree.ItemsSource = null;
                        cb_turretFour.ItemsSource = null;
                        cb_turretFive.ItemsSource = null;
                        cb_turretSix.ItemsSource = null;
                    }
                        break;
                    case 3:
                    {
                        gd_turretOne.Visibility = Visibility.Visible;
                        gd_turretTwo.Visibility = Visibility.Visible;
                        gd_turretThree.Visibility = Visibility.Visible;
                        gd_turretFour.Visibility = Visibility.Collapsed;
                        gd_turretFive.Visibility = Visibility.Collapsed;
                        gd_turretSix.Visibility = Visibility.Collapsed;

                        cb_turretOne.ItemsSource = turrets;
                        cb_turretTwo.ItemsSource = turrets;
                        cb_turretThree.ItemsSource = turrets;
                        cb_turretFour.ItemsSource = null;
                        cb_turretFive.ItemsSource = null;
                        cb_turretSix.ItemsSource = null;
                    }
                        break;
                    case 4:
                    {
                        gd_turretOne.Visibility = Visibility.Visible;
                        gd_turretTwo.Visibility = Visibility.Visible;
                        gd_turretThree.Visibility = Visibility.Visible;
                        gd_turretFour.Visibility = Visibility.Visible;
                        gd_turretFive.Visibility = Visibility.Collapsed;
                        gd_turretSix.Visibility = Visibility.Collapsed;

                        cb_turretOne.ItemsSource = turrets;
                        cb_turretTwo.ItemsSource = turrets;
                        cb_turretThree.ItemsSource = turrets;
                        cb_turretFour.ItemsSource = turrets;
                        cb_turretFive.ItemsSource = null;
                        cb_turretSix.ItemsSource = null;
                    }
                        break;
                    case 5:
                    {
                        gd_turretOne.Visibility = Visibility.Visible;
                        gd_turretTwo.Visibility = Visibility.Visible;
                        gd_turretThree.Visibility = Visibility.Visible;
                        gd_turretFour.Visibility = Visibility.Visible;
                        gd_turretFive.Visibility = Visibility.Visible;
                        gd_turretSix.Visibility = Visibility.Collapsed;

                        cb_turretOne.ItemsSource = turrets;
                        cb_turretTwo.ItemsSource = turrets;
                        cb_turretThree.ItemsSource = turrets;
                        cb_turretFour.ItemsSource = turrets;
                        cb_turretFive.ItemsSource = turrets;
                        cb_turretSix.ItemsSource = null;
                    }
                        break;
                    case 6:
                    {
                        gd_turretOne.Visibility = Visibility.Visible;
                        gd_turretTwo.Visibility = Visibility.Visible;
                        gd_turretThree.Visibility = Visibility.Visible;
                        gd_turretFour.Visibility = Visibility.Visible;
                        gd_turretFive.Visibility = Visibility.Visible;
                        gd_turretSix.Visibility = Visibility.Visible;

                        cb_turretOne.ItemsSource = turrets;
                        cb_turretTwo.ItemsSource = turrets;
                        cb_turretThree.ItemsSource = turrets;
                        cb_turretFour.ItemsSource = turrets;
                        cb_turretFive.ItemsSource = turrets;
                        cb_turretSix.ItemsSource = turrets;
                    }
                        break;
                }

                // Load existing turrets if any
                if (ship.Turret1 != null)
                {
                    cb_turretOne.Text = ship.Turret1.Name;

                    tb_turretOneArmour.Text = ship.Turret1.Armour.ToString();
                    tb_turretOneDrain.Text = ship.Turret1.Drain.ToString();
                    tb_turretOneMass.Text = ship.Turret1.Mass.ToString();
                    tb_turretOneMinDam.Text = ship.Turret1.MinD.ToString();
                    tb_turretOneMaxDam.Text = ship.Turret1.MaxD.ToString();
                    tb_turretOneVsShield.Text = ship.Turret1.VS.ToString();
                    tb_turretOneVsArmour.Text = ship.Turret1.VA.ToString();
                    tb_turretOneEPS.Text = ship.Turret1.EPS.ToString();
                    tb_turretOneRR.Text = ship.Turret1.RR.ToString();
                }

                if (ship.Turret2 != null)
                {
                    cb_turretTwo.Text = ship.Turret2.Name;

                    tb_turretTwoArmour.Text = ship.Turret2.Armour.ToString();
                    tb_turretTwoDrain.Text = ship.Turret2.Drain.ToString();
                    tb_turretTwoMass.Text = ship.Turret2.Mass.ToString();
                    tb_turretTwoMinDam.Text = ship.Turret2.MinD.ToString();
                    tb_turretTwoMaxDam.Text = ship.Turret2.MaxD.ToString();
                    tb_turretTwoVsShield.Text = ship.Turret2.VS.ToString();
                    tb_turretTwoVsArmour.Text = ship.Turret2.VA.ToString();
                    tb_turretTwoEPS.Text = ship.Turret2.EPS.ToString();
                    tb_turretTwoRR.Text = ship.Turret2.RR.ToString();
                }

                if (ship.Turret3 != null)
                {
                    cb_turretThree.Text = ship.Turret3.Name;

                    tb_turretOneArmour.Text = ship.Turret3.Armour.ToString();
                    tb_turretOneDrain.Text = ship.Turret3.Drain.ToString();
                    tb_turretOneMass.Text = ship.Turret3.Mass.ToString();
                    tb_turretOneMinDam.Text = ship.Turret3.MinD.ToString();
                    tb_turretOneMaxDam.Text = ship.Turret3.MaxD.ToString();
                    tb_turretOneVsShield.Text = ship.Turret3.VS.ToString();
                    tb_turretOneVsArmour.Text = ship.Turret3.VA.ToString();
                    tb_turretOneEPS.Text = ship.Turret3.EPS.ToString();
                    tb_turretOneRR.Text = ship.Turret3.RR.ToString();
                }

                if (ship.Turret4 != null)
                {
                    cb_turretFour.Text = ship.Turret4.Name;

                    tb_turretFourArmour.Text = ship.Turret4.Armour.ToString();
                    tb_turretFourDrain.Text = ship.Turret4.Drain.ToString();
                    tb_turretFourMass.Text = ship.Turret4.Mass.ToString();
                    tb_turretFourMinDam.Text = ship.Turret4.MinD.ToString();
                    tb_turretFourMaxDam.Text = ship.Turret4.MaxD.ToString();
                    tb_turretFourVsShield.Text = ship.Turret4.VS.ToString();
                    tb_turretFourVsArmour.Text = ship.Turret4.VA.ToString();
                    tb_turretFourEPS.Text = ship.Turret4.EPS.ToString();
                    tb_turretFourRR.Text = ship.Turret4.RR.ToString();
                }

                if (ship.Turret5 != null)
                {
                    cb_turretFive.Text = ship.Turret5.Name;

                    tb_turretFiveArmour.Text = ship.Turret5.Armour.ToString();
                    tb_turretFiveDrain.Text = ship.Turret5.Drain.ToString();
                    tb_turretFiveMass.Text = ship.Turret5.Mass.ToString();
                    tb_turretFiveMinDam.Text = ship.Turret5.MinD.ToString();
                    tb_turretFiveMaxDam.Text = ship.Turret5.MaxD.ToString();
                    tb_turretFiveVsShield.Text = ship.Turret5.VS.ToString();
                    tb_turretFiveVsArmour.Text = ship.Turret5.VA.ToString();
                    tb_turretFiveEPS.Text = ship.Turret5.EPS.ToString();
                    tb_turretFiveRR.Text = ship.Turret5.RR.ToString();
                }

                if (ship.Turret6 != null)
                {
                    cb_turretSix.Text = ship.Turret6.Name;

                    tb_turretSixArmour.Text = ship.Turret6.Armour.ToString();
                    tb_turretSixDrain.Text = ship.Turret6.Drain.ToString();
                    tb_turretSixMass.Text = ship.Turret6.Mass.ToString();
                    tb_turretSixMinDam.Text = ship.Turret6.MinD.ToString();
                    tb_turretSixMaxDam.Text = ship.Turret6.MaxD.ToString();
                    tb_turretSixVsShield.Text = ship.Turret6.VS.ToString();
                    tb_turretSixVsArmour.Text = ship.Turret6.VA.ToString();
                    tb_turretSixEPS.Text = ship.Turret6.EPS.ToString();
                    tb_turretSixRR.Text = ship.Turret6.RR.ToString();
                }
            }
            else
            {
                gd_turrets.Visibility = Visibility.Collapsed;
            }
        }

        private void TurretOneChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_turretOne.SelectedItem;

            if (weapon != null)
            {
                tb_turretOneArmour.Text = weapon.Armour.ToString();
                tb_turretOneDrain.Text = weapon.Drain.ToString();
                tb_turretOneMass.Text = weapon.Mass.ToString();
                tb_turretOneMinDam.Text = weapon.MinD.ToString();
                tb_turretOneMaxDam.Text = weapon.MaxD.ToString();
                tb_turretOneVsShield.Text = weapon.VS.ToString();
                tb_turretOneVsArmour.Text = weapon.VA.ToString();
                tb_turretOneEPS.Text = weapon.EPS.ToString();
                tb_turretOneRR.Text = weapon.RR.ToString();

                ship.Turret1 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void TurretTwoChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_turretTwo.SelectedItem;

            if (weapon != null)
            {
                tb_turretTwoArmour.Text = weapon.Armour.ToString();
                tb_turretTwoDrain.Text = weapon.Drain.ToString();
                tb_turretTwoMass.Text = weapon.Mass.ToString();
                tb_turretTwoMinDam.Text = weapon.MinD.ToString();
                tb_turretTwoMaxDam.Text = weapon.MaxD.ToString();
                tb_turretTwoVsShield.Text = weapon.VS.ToString();
                tb_turretTwoVsArmour.Text = weapon.VA.ToString();
                tb_turretTwoEPS.Text = weapon.EPS.ToString();
                tb_turretTwoRR.Text = weapon.RR.ToString();

                ship.Turret2 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void TurretThreeChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_turretThree.SelectedItem;

            if (weapon != null)
            {
                tb_turretThreeArmour.Text = weapon.Armour.ToString();
                tb_turretThreeDrain.Text = weapon.Drain.ToString();
                tb_turretThreeMass.Text = weapon.Mass.ToString();
                tb_turretThreeMinDam.Text = weapon.MinD.ToString();
                tb_turretThreeMaxDam.Text = weapon.MaxD.ToString();
                tb_turretThreeVsShield.Text = weapon.VS.ToString();
                tb_turretThreeVsArmour.Text = weapon.VA.ToString();
                tb_turretThreeEPS.Text = weapon.EPS.ToString();
                tb_turretThreeRR.Text = weapon.RR.ToString();

                ship.Turret3 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void TurretFourChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_turretFour.SelectedItem;

            if (weapon != null)
            {
                tb_turretFourArmour.Text = weapon.Armour.ToString();
                tb_turretFourDrain.Text = weapon.Drain.ToString();
                tb_turretFourMass.Text = weapon.Mass.ToString();
                tb_turretFourMinDam.Text = weapon.MinD.ToString();
                tb_turretFourMaxDam.Text = weapon.MaxD.ToString();
                tb_turretFourVsShield.Text = weapon.VS.ToString();
                tb_turretFourVsArmour.Text = weapon.VA.ToString();
                tb_turretFourEPS.Text = weapon.EPS.ToString();
                tb_turretFourRR.Text = weapon.RR.ToString();

                ship.Turret4 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void TurretFiveChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_turretFive.SelectedItem;

            if (weapon != null)
            {
                tb_turretFiveArmour.Text = weapon.Armour.ToString();
                tb_turretFiveDrain.Text = weapon.Drain.ToString();
                tb_turretFiveMass.Text = weapon.Mass.ToString();
                tb_turretFiveMinDam.Text = weapon.MinD.ToString();
                tb_turretFiveMaxDam.Text = weapon.MaxD.ToString();
                tb_turretFiveVsShield.Text = weapon.VS.ToString();
                tb_turretFiveVsArmour.Text = weapon.VA.ToString();
                tb_turretFiveEPS.Text = weapon.EPS.ToString();
                tb_turretFiveRR.Text = weapon.RR.ToString();

                ship.Turret5 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        private void TurretSixChanged(object sender, SelectionChangedEventArgs e)
        {
            Weapon weapon = (Weapon)cb_turretSix.SelectedItem;

            if (weapon != null)
            {
                tb_turretSixArmour.Text = weapon.Armour.ToString();
                tb_turretSixDrain.Text = weapon.Drain.ToString();
                tb_turretSixMass.Text = weapon.Mass.ToString();
                tb_turretSixMinDam.Text = weapon.MinD.ToString();
                tb_turretSixMaxDam.Text = weapon.MaxD.ToString();
                tb_turretSixVsShield.Text = weapon.VS.ToString();
                tb_turretSixVsArmour.Text = weapon.VA.ToString();
                tb_turretSixEPS.Text = weapon.EPS.ToString();
                tb_turretSixRR.Text = weapon.RR.ToString();

                ship.Turret6 = weapon;

                CalculateCurrentMass();
                PerformReactorFunctions();
            }
        }

        #endregion

        #region Cargobay

        private void InitialiseCargobay()
        {
            var cargobays = Components.Components.CargoBays;

            if (cargobays.Count > 0 && !string.IsNullOrEmpty(cargobays.FirstOrDefault().Name))
                cargobays.Insert(0, new CargoBay());

            cb_cargobays.ItemsSource = cargobays;

            //Load existing component (if any)
            if (ship.Cargobay != null)
            {
                cb_cargobays.Text = ship.Cargobay.Name;

                tb_cargobayArmour.Text = ship.Cargobay.Armour.ToString();
                tb_cargobayMass.Text = ship.Cargobay.Mass.ToString();
            }
        }

        private void CargobayChanged(object sender, SelectionChangedEventArgs e)
        {
            CargoBay cBay = (CargoBay)cb_cargobays.SelectedItem;

            if (cBay != null)
            {
                tb_cargobayArmour.Text = cBay.Armour.ToString();
                tb_cargobayMass.Text = cBay.Mass.ToString();

                ship.Cargobay = cBay;

                CalculateCurrentMass();
            }
        }

        #endregion

        #region Ship Details

        private void InitialiseShipDetails()
        {
            tb_ChassisName.Text = ship.ChassisName;
            tb_givenName.Text = ship.GivenName;

            switch (ship.Faction)
            {
                case 0: { tb_factionName.Text = "Rebel"; } break;
                case 1: { tb_factionName.Text = "Imperial"; } break;
                case 2: { tb_factionName.Text = "Freelance"; } break;
                case 3: { tb_factionName.Text = "Special"; } break;
            }

            tb_currentMass.Text = ship.CurrentMass.ToString();
            tb_maxMass.Text = ship.Mass.ToString();

            tb_currentDrain.Text = ship.CurrentEnergyDrain.ToString();

            // Maneuverability
            UpdateShipManoeuvreStats();
        }

        private void InitialiseOverloads()
        {
            if (ship != null)
            {
                if (ship.ReactorOverride != null)
                    cb_reactorOverload.SelectedIndex = ship.ReactorOverride;

                if (ship.EngineOverride != null)
                    cb_engineOverload.SelectedIndex = ship.EngineOverride;

                if (ship.WeaponOverride != null)
                    cb_weaponOverload.SelectedIndex = ship.WeaponOverride;

                if (ship.CapacitorOverride != null)
                    cb_capacitorOverload.SelectedIndex = ship.CapacitorOverride;
            }
        }

        private void Tb_givenName_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ship.GivenName = tb_givenName.Text;
        }

        private void Tb_maxMass_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ship.Mass = float.Parse(tb_maxMass.Text);
            CalculateCurrentMass();
        }

        private void CalculateCurrentMass()
        {
            float mass = 0f;

            if (ship.Reactor != null)
                mass += ship.Reactor.Mass;

            if (ship.Engine != null)
                mass += ship.Engine.Mass;

            if (ship.Booster != null)
                mass += ship.Booster.Mass;

            if (ship.Shield != null)
                mass += ship.Shield.Mass;

            if (ship.FrontArmour != null)
                mass += ship.FrontArmour.Mass;

            if (ship.RearArmour != null)
                mass += ship.RearArmour.Mass;

            if (ship.DroidInterface != null)
                mass += ship.DroidInterface.Mass;

            if (ship.Capacitor != null)
                mass += ship.Capacitor.Mass;

            if (ship.Ord1 != null)
                mass += ship.Ord1.Mass;

            if (ship.Ord2 != null)
                mass += ship.Ord2.Mass;

            if (ship.Weapon1 != null)
                mass += ship.Weapon1.Mass;

            if (ship.Weapon2 != null)
                mass += ship.Weapon2.Mass;

            if (ship.Weapon3 != null)
                mass += ship.Weapon3.Mass;

            if (ship.Weapon4 != null)
                mass += ship.Weapon4.Mass;

            if (ship.Weapon5 != null)
                mass += ship.Weapon5.Mass;

            if (ship.Weapon6 != null)
                mass += ship.Weapon6.Mass;

            if (ship.Turret1 != null)
                mass += ship.Turret1.Mass;

            if (ship.Turret2 != null)
                mass += ship.Turret2.Mass;

            if (ship.Turret3 != null)
                mass += ship.Turret3.Mass;

            if (ship.Turret4 != null)
                mass += ship.Turret4.Mass;

            if (ship.Turret5 != null)
                mass += ship.Turret5.Mass;

            if (ship.Turret6 != null)
                mass += ship.Turret6.Mass;

            if (ship.CM1 != null)
                mass += ship.CM1.Mass;

            if (ship.CM2 != null)
                mass += ship.CM2.Mass;

            ship.CurrentMass = mass;
            ship.RemainingMass = ship.Mass - ship.CurrentMass;

            if (ship.RemainingMass < 0)
                tb_remainingMass.Foreground = Brushes.Red;
            else
                tb_remainingMass.Foreground = Brushes.Orange;

            tb_currentMass.Text = mass.ToString();
            tb_remainingMass.Text = Math.Round(ship.RemainingMass, 2).ToString();
        }

        #endregion
    }
}
