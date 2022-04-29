using System.Windows;
using System.Windows.Controls;
using Ship_Loadout.Components;
using Ship_Loadout.ShipEditor;

namespace Ship_Loadout.LoadoutEditor
{
    public partial class DisplayLoadout : Page
    {
        private Ship ship = LoadoutData.ShipList[LoadoutData.ShipListSelection];

        public DisplayLoadout()
        {
            InitializeComponent();

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
            cb_reactor.ItemsSource = Ship_Loadout.Components.Components.Reactors;
        }

        private void ReactorSelectionChanged(object sender, System.EventArgs e)
        {
            Reactor reactor = (Reactor)cb_reactor.SelectedItem;

            if (reactor != null)
            {
                tb_reactorArmour.Text = reactor.Armour.ToString();
                tb_reactorMass.Text = reactor.Mass.ToString();
                tb_reactorGeneration.Text = reactor.Generation.ToString();
            }
        }

        #endregion

        #region Engine

        private void InitialiseEngine()
        {
            cb_engine.ItemsSource = Ship_Loadout.Components.Components.Engines;
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
            }
        }

        #endregion

        #region Booster 

        private void InitialiseBooster()
        {
            cb_booster.ItemsSource = Ship_Loadout.Components.Components.Boosters;
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
            }
        }

        #endregion

        #region Shield

        private void InitialiseShield()
        {
            cb_shield.ItemsSource = Ship_Loadout.Components.Components.Shields;
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
            }
        }

        #endregion

        #region Armour

        private void InitialiseArmour()
        {
            cb_armourFront.ItemsSource = Ship_Loadout.Components.Components.Armours;

            cb_armourRear.ItemsSource = Ship_Loadout.Components.Components.Armours;
        }

        private void FrontArmourChanged(object sender, SelectionChangedEventArgs e)
        {
            Armour armour = (Armour)cb_armourFront.SelectedItem;

            if (armour != null)
            {
                tb_frontArmourArmour.Text = armour.Armor.ToString();
                tb_frontArmourMass.Text = armour.Mass.ToString();
            }
        }

        private void RearArmourChanged(object sender, SelectionChangedEventArgs e)
        {
            Armour armour = (Armour)cb_armourFront.SelectedItem;

            if (armour != null)
            {
                tb_rearArmourArmour.Text = armour.Armor.ToString();
                tb_rearArmourMass.Text = armour.Mass.ToString();
            }
        }

        #endregion

        #region Droid Interface

        private void InitialiseDI()
        {
            cb_droidInterface.ItemsSource = Ship_Loadout.Components.Components.DroidInterfaces;
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
            }
        }

        #endregion

        #region Capacitor

        private void InitialiseCapacitor()
        {
            cb_capacitor.ItemsSource = Ship_Loadout.Components.Components.Capacitors;
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

                    cb_ordOne.ItemsSource = Ship_Loadout.Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = null;
                    cb_ordTwo.ItemsSource = null;
                }
                    break;

                case 2:
                {
                    gd_ordOne.Visibility = Visibility.Visible;
                    gd_ordTwo.Visibility = Visibility.Visible;
                    gd_ordThree.Visibility = Visibility.Collapsed;

                    cb_ordOne.ItemsSource = Ship_Loadout.Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = Ship_Loadout.Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = null;
                }
                    break;
                case 3:
                {
                    gd_ordOne.Visibility = Visibility.Visible;
                    gd_ordTwo.Visibility = Visibility.Visible;
                    gd_ordThree.Visibility = Visibility.Visible;

                    cb_ordOne.ItemsSource = Ship_Loadout.Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = Ship_Loadout.Components.Components.Ordinances;
                    cb_ordTwo.ItemsSource = Ship_Loadout.Components.Components.Ordinances;
                }
                    break;
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

                        cb_wepOne.ItemsSource = Ship_Loadout.Components.Components.Weapons;
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

                        cb_wepOne.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                        cb_wepTwo.ItemsSource = Ship_Loadout.Components.Components.Weapons;
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

                        cb_wepOne.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                        cb_wepTwo.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                        cb_wepThree.ItemsSource = Ship_Loadout.Components.Components.Weapons;
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

                    cb_wepOne.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepTwo.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepThree.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepFour.ItemsSource = Ship_Loadout.Components.Components.Weapons;
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

                    cb_wepOne.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepTwo.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepThree.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepFour.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepFive.ItemsSource = Ship_Loadout.Components.Components.Weapons;
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

                    cb_wepOne.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepTwo.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepThree.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepFour.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepFive.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                    cb_wepSix.ItemsSource = Ship_Loadout.Components.Components.Weapons;
                }
                    break;
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

                    cb_cmOne.ItemsSource = Ship_Loadout.Components.Components.CounterMeasures;
                    cb_cmTwo.ItemsSource = null;
                }
                    break;
                case 2:
                {
                    gd_cmOne.Visibility = Visibility.Visible;
                    gd_cmTwo.Visibility = Visibility.Visible;

                    cb_cmOne.ItemsSource = Ship_Loadout.Components.Components.CounterMeasures;
                    cb_cmTwo.ItemsSource = Ship_Loadout.Components.Components.CounterMeasures;
                }
                    break;
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
            }
        }

        #endregion

        #region Turrets



        #endregion
    }
}
