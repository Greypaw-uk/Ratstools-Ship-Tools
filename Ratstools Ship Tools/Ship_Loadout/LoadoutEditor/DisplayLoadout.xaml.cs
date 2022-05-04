using System.Windows;
using System.Windows.Controls;
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
        }

        #region Reactor

        private void InitialiseReactor()
        {
            //Add Reactors to Combolist
            cb_reactor.ItemsSource = Components.Components.Reactors;

            //Load existing component (if any)
            if (ship.Reactor != null)
            {
                cb_reactor.SelectedItem = ship.Reactor;

                tb_reactorArmour.Text = ship.Reactor.Armour.ToString();
                tb_reactorMass.Text = ship.Reactor.Mass.ToString();
                tb_reactorGeneration.Text = ship.Reactor.Generation.ToString();
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
            }
        }

        #endregion

        #region Engine

        private void InitialiseEngine()
        {
            cb_engine.ItemsSource = Components.Components.Engines;

            //Load existing component (if any)
            if (ship.Engine != null)
            {
                cb_engine.SelectedItem = ship.Engine;

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
            }
        }

        #endregion

        #region Booster 

        private void InitialiseBooster()
        {
            cb_booster.ItemsSource = Components.Components.Boosters;

            //Load existing component (if any)
            if (ship.Booster != null)
            {
                cb_booster.SelectedItem = ship.Booster;

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
            }
        }

        #endregion

        #region Shield

        private void InitialiseShield()
        {
            cb_shield.ItemsSource = Components.Components.Shields;

            //Load existing component (if any)
            if (ship.Shield != null)
            {
                cb_shield.SelectedItem = ship.Shield;

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
            }
        }

        #endregion

        #region Armour

        private void InitialiseArmour()
        {
            cb_armourFront.ItemsSource = Components.Components.Armours;

            cb_armourRear.ItemsSource = Components.Components.Armours;

            //Load existing component (if any)
            if (ship.FrontArmour != null)
            {
                cb_armourFront.SelectedItem = ship.FrontArmour;

                tb_frontArmourArmour.Text = ship.FrontArmour.Armor.ToString();
                tb_frontArmourMass.Text = ship.FrontArmour.Mass.ToString();
            }

            if (ship.RearArmour != null)
            {
                cb_armourRear.SelectedItem = ship.RearArmour;

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
            }
        }

        #endregion

        #region Droid Interface

        private void InitialiseDI()
        {
            cb_droidInterface.ItemsSource = Components.Components.DroidInterfaces;

            //Load existing component (if any)
            if (ship.DroidInterface != null)
            {
                cb_droidInterface.SelectedItem = ship.DroidInterface;

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
            }
        }

        #endregion

        #region Capacitor

        private void InitialiseCapacitor()
        {
            cb_capacitor.ItemsSource = Components.Components.Capacitors;

            //Load existing component (if any)
            if (ship.Capacitor != null)
            {
                cb_capacitor.SelectedItem = ship.Capacitor;

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
            }
        }

        #endregion

        #region Ordinance

        private void InitialiseOrdinance()
        {
            switch (ship.Ordinance)
            {
                case 0:
                {
                    gd_ordOne.Visibility = Visibility.Collapsed;
                    gd_ordTwo.Visibility = Visibility.Collapsed;
                    gd_ordThree.Visibility = Visibility.Collapsed;

                    cb_ordOne.ItemsSource = null;
                    cb_ordTwo.ItemsSource = null;
                    cb_ordTwo.ItemsSource = null;
                }
                    break;

                case 1:
                {
                    gd_ordOne.Visibility = Visibility.Visible;
                    gd_ordTwo.Visibility = Visibility.Collapsed;
                    gd_ordThree.Visibility = Visibility.Collapsed;

                    cb_ordOne.ItemsSource = Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = null;
                    cb_ordTwo.ItemsSource = null;
                }
                    break;

                case 2:
                {
                    gd_ordOne.Visibility = Visibility.Visible;
                    gd_ordTwo.Visibility = Visibility.Visible;
                    gd_ordThree.Visibility = Visibility.Collapsed;

                    cb_ordOne.ItemsSource = Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = null;
                }
                    break;
                case 3:
                {
                    gd_ordOne.Visibility = Visibility.Visible;
                    gd_ordTwo.Visibility = Visibility.Visible;
                    gd_ordThree.Visibility = Visibility.Visible;

                    cb_ordOne.ItemsSource = Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = Components.Components.Ordinances;
                }
                    break;
            }

            //Load existing component (if any)
            if (ship.Ord1 != null)
            {
                cb_ordOne.SelectedItem = ship.Ord1;

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
                cb_ordTwo.SelectedItem = ship.Ord2;

                tb_ordTwoArmour.Text = ship.Ord2.Armour.ToString();
                tb_ordTwoDrain.Text = ship.Ord2.Drain.ToString();
                tb_ordTwoMass.Text = ship.Ord2.Mass.ToString();
                tb_ordTwoMinDam.Text = ship.Ord2.MinDam.ToString();
                tb_ordTwoMaxDam.Text = ship.Ord2.MaxDam.ToString();
                tb_ordTwoVsShield.Text = ship.Ord2.VShield.ToString();
                tb_ordTwoVsArmour.Text = ship.Ord2.VArmour.ToString();
                tb_ordTwoAmmo.Text = ship.Ord2.Ammo.ToString();
            }

            if (ship.Ord3 != null)
                cb_ordThree.SelectedItem = ship.Ord3;
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
            }
        }

        private void OrdinanceThreeChanged(object sender, SelectionChangedEventArgs e)
        {
            Ordinance ord = (Ordinance)cb_ordThree.SelectedItem;

            if (ord != null)
            {
                tb_ordThreeArmour.Text = ord.Armour.ToString();
                tb_ordThreeDrain.Text = ord.Drain.ToString();
                tb_ordThreeMass.Text = ord.Mass.ToString();
                tb_ordThreeMinDam.Text = ord.MinDam.ToString();
                tb_ordThreeMaxDam.Text = ord.MaxDam.ToString();
                tb_ordThreeVsShield.Text = ord.VShield.ToString();
                tb_ordThreeVsArmour.Text = ord.VArmour.ToString();
                tb_ordThreeAmmo.Text = ord.Ammo.ToString();

                ship.Ord3 = ord;
            }
        }

        #endregion

        #region Weapons

        private void InitialiseWeapons()
        {
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

                        cb_wepOne.ItemsSource = Components.Components.Weapons;
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

                        cb_wepOne.ItemsSource = Components.Components.Weapons;
                        cb_wepTwo.ItemsSource = Components.Components.Weapons;
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

                        cb_wepOne.ItemsSource = Components.Components.Weapons;
                        cb_wepTwo.ItemsSource = Components.Components.Weapons;
                        cb_wepThree.ItemsSource = Components.Components.Weapons;
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

                    cb_wepOne.ItemsSource = Components.Components.Weapons;
                    cb_wepTwo.ItemsSource = Components.Components.Weapons;
                    cb_wepThree.ItemsSource = Components.Components.Weapons;
                    cb_wepFour.ItemsSource = Components.Components.Weapons;
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

                    cb_wepOne.ItemsSource = Components.Components.Weapons;
                    cb_wepTwo.ItemsSource = Components.Components.Weapons;
                    cb_wepThree.ItemsSource = Components.Components.Weapons;
                    cb_wepFour.ItemsSource = Components.Components.Weapons;
                    cb_wepFive.ItemsSource = Components.Components.Weapons;
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

                    cb_wepOne.ItemsSource = Components.Components.Weapons;
                    cb_wepTwo.ItemsSource = Components.Components.Weapons;
                    cb_wepThree.ItemsSource = Components.Components.Weapons;
                    cb_wepFour.ItemsSource = Components.Components.Weapons;
                    cb_wepFive.ItemsSource = Components.Components.Weapons;
                    cb_wepSix.ItemsSource = Components.Components.Weapons;
                }
                    break;
            }

            //Load existing component (if any)
            if (ship.Weapon1 != null)
            {
                cb_wepOne.SelectedItem = ship.Weapon1;

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

                cb_wepTwo.SelectedItem = ship.Weapon2;
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

                cb_wepThree.SelectedItem = ship.Weapon3;
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

                cb_wepFour.SelectedItem = ship.Weapon4;
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

                cb_wepFive.SelectedItem = ship.Weapon5;
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

                cb_wepSix.SelectedItem = ship.Weapon6;
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
            }
        }

        #endregion

        #region Counter Measures

        private void InitialiseCountermeasures()
        {
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

                    cb_cmOne.ItemsSource = Components.Components.CounterMeasures;
                    cb_cmTwo.ItemsSource = null;
                }
                    break;
                case 2:
                {
                    gd_cmOne.Visibility = Visibility.Visible;
                    gd_cmTwo.Visibility = Visibility.Visible;

                    cb_cmOne.ItemsSource = Components.Components.CounterMeasures;
                    cb_cmTwo.ItemsSource = Components.Components.CounterMeasures;
                }
                    break;
            }

            //Load existing component (if any)
            if (ship.CM1 != null)
            {
                tb_cmOneArmour.Text = ship.CM1.Armour.ToString();
                tb_cmOneDrain.Text = ship.CM1.Drain.ToString();
                tb_cmOneMass.Text = ship.CM1.Mass.ToString();

                cb_cmOne.SelectedItem = ship.CM1;
            }

            if (ship.CM2 != null)
            {
                tb_cmTwoArmour.Text = ship.CM2.Armour.ToString();
                tb_cmTwoDrain.Text = ship.CM2.Drain.ToString();
                tb_cmTwoMass.Text = ship.CM2.Mass.ToString();

                cb_cmTwo.SelectedItem = ship.CM2;
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
            }
        }

        #endregion

        #region Turrets



        #endregion
    }
}
