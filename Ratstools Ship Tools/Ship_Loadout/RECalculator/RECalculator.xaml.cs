using System;
using System.Windows;
using System.Windows.Controls;

namespace Ship_Loadout
{
    public partial class RECalculator : Page
    {
        public RECalculator()
        {
            InitializeComponent();
        }

        //Multiplier is the RE bonus awarded via expertise parts and varies by the level of the parts being REed
        float GetMultiplier(float selectedIndex)
        {
            var multiplier = 0f;

            switch (selectedIndex)
            {
                case 0: //Level One
                    multiplier = 1.02f;
                    break;
                case 1: //Level Two/Three
                    multiplier = 1.03f;
                    break;
                case 2: //Level Four/Five
                    multiplier = 1.04f;
                    break;
                case 3: //Level Six/Seven
                    multiplier = 1.05f;
                    break;
                case 4: //Level Eight
                    multiplier = 1.06f;
                    break;
                case 5: //Level Nine/Ten
                    multiplier = 1.07f;
                    break;
            }

            return multiplier;
        }

        #region Reactor

        private void BtnArmourCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var multiplier = GetMultiplier(cb_reactorLevel.SelectedIndex);

            try //Armour
            {
                if (!string.IsNullOrEmpty(tb_reactorArmourInput.Text))
                {
                    var result = float.Parse(tb_reactorArmourInput.Text) * multiplier;
                    tb_reactorArmourOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_reactorArmourOutput.Text = "Invalid";
            }

            try //Mass
            {
                if (!string.IsNullOrEmpty(tb_reactorMassInput.Text))
                {
                    var result = float.Parse(tb_reactorMassInput.Text) / multiplier;
                    tb_reactorMassOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_reactorMassOutput.Text = "Invalid";
            }

            try //Generation
            {
                if (!string.IsNullOrEmpty(tb_reactorGenerationInput.Text))
                {
                    var result = float.Parse(tb_reactorGenerationInput.Text) * multiplier;
                    tb_reactorGenerationOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_reactorGenerationOutput.Text = "Invalid";
            }
        }

        private void BtnArmourCancel_OnClick(object sender, RoutedEventArgs e)
        {
            tb_reactorArmourInput.Text = "";
            tb_reactorArmourOutput.Text = "";

            tb_reactorGenerationInput.Text = "";
            tb_reactorArmourOutput.Text = "";

            tb_reactorMassInput.Text = "";
            tb_reactorMassOutput.Text = "";
        }

        #endregion

        #region Engine

        private void BtnEngineCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var multiplier = GetMultiplier(cb_engineLevel.SelectedIndex);

            try //Armour
            {
                if (!string.IsNullOrEmpty(tb_engineArmourInput.Text))
                {
                    var result = float.Parse(tb_engineArmourInput.Text) * multiplier;
                    tb_engineArmourOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_engineArmourOutput.Text = "Invalid";
            }

            try //Drain
            {
                if (!string.IsNullOrEmpty(tb_engineDrainInput.Text))
                {
                    var result = float.Parse(tb_engineDrainInput.Text) / multiplier;
                    tb_engineDrainOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_engineDrainOutput.Text = "Invalid";
            }

            try //Mass
            {
                if (!string.IsNullOrEmpty(tb_engineMassInput.Text))
                {
                    var result = float.Parse(tb_engineMassInput.Text) / multiplier;
                    tb_engineMassOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_engineMassOutput.Text = "Invalid";
            }

            try //Pitch
            {
                if (!string.IsNullOrEmpty(tb_enginePitchInput.Text))
                {
                    var result = float.Parse(tb_enginePitchInput.Text) * multiplier;
                    tb_enginePitchOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_enginePitchOutput.Text = "Invalid";
            }

            try //Yaw
            {
                if (!string.IsNullOrEmpty(tb_engineYawInput.Text))
                {
                    var result = float.Parse(tb_engineYawInput.Text) * multiplier;
                    tb_engineYawOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_engineYawOutput.Text = "Invalid";
            }

            try //Roll
            {
                if (!string.IsNullOrEmpty(tb_engineRollInput.Text))
                {
                    var result = float.Parse(tb_engineRollInput.Text) * multiplier;
                    tb_engineRollOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_engineRollOutput.Text = "Invalid";
            }

            try //Speed
            {
                if (!string.IsNullOrEmpty(tb_engineSpeedInput.Text))
                {
                    var result = float.Parse(tb_engineSpeedInput.Text) * multiplier;
                    tb_engineSpeedOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_engineSpeedOutput.Text = "Invalid";
            }
        }

        private void BtnEngineCancel_OnClick(object sender, RoutedEventArgs e)
        {
            tb_engineArmourInput.Text = "";
            tb_engineArmourOutput.Text = "";

            tb_engineDrainInput.Text = "";
            tb_engineDrainOutput.Text = "";

            tb_engineMassInput.Text = "";
            tb_engineMassOutput.Text = "";

            tb_enginePitchInput.Text = "";
            tb_enginePitchOutput.Text = "";

            tb_engineYawInput.Text = "";
            tb_engineYawOutput.Text = "";

            tb_engineRollInput.Text = "";
            tb_engineRollOutput.Text = "";

            tb_engineSpeedInput.Text = "";
            tb_engineSpeedOutput.Text = "";
        }

        #endregion

        #region Booster

        private void BtnBoosterCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var multiplier = GetMultiplier(cb_boosterLevel.SelectedIndex);

            try //Armour
            {
                if (!string.IsNullOrEmpty(tb_boosterArmourInput.Text))
                {
                    var result = float.Parse(tb_engineArmourInput.Text) * multiplier;
                    tb_boosterArmourOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_boosterArmourOutput.Text = "Invalid";
            }

            try //Drain
            {
                if (!string.IsNullOrEmpty(tb_boosterDrainInput.Text))
                {
                    var result = float.Parse(tb_boosterDrainInput.Text) / multiplier;
                    tb_boosterDrainOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_boosterDrainOutput.Text = "Invalid";
            }

            try //Mass
            {
                if (!string.IsNullOrEmpty(tb_boosterMassInput.Text))
                {
                    var result = float.Parse(tb_boosterMassInput.Text) / multiplier;
                    tb_boosterMassOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_boosterMassOutput.Text = "Invalid";
            }

            try //Energy
            {
                if (!string.IsNullOrEmpty(tb_boosterEnergyInput.Text))
                {
                    var result = float.Parse(tb_boosterEnergyInput.Text) * multiplier;
                    tb_boosterEnergyOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_boosterEnergyOutput.Text = "Invalid";
            }

            try //Recharge
            {
                if (!string.IsNullOrEmpty(tb_boosterRechargeInput.Text))
                {
                    var result = float.Parse(tb_boosterRechargeInput.Text) * multiplier;
                    tb_boosterRechargeOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_boosterRechargeOutput.Text = "Invalid";
            }

            try //Consumption
            {
                if (!string.IsNullOrEmpty(tb_boosterConsumptionInput.Text))
                {
                    var result = float.Parse(tb_boosterConsumptionInput.Text) / multiplier;
                    tb_boosterConsumptionOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_boosterConsumptionOutput.Text = "Invalid";
            }

            try //Acceleration
            {
                if (!string.IsNullOrEmpty(tb_boosterAccelerationInput.Text))
                {
                    var result = float.Parse(tb_boosterAccelerationInput.Text) * multiplier;
                    tb_boosterAccelerationOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_boosterAccelerationOutput.Text = "Invalid";
            }

            try //Speed
            {
                if (!string.IsNullOrEmpty(tb_boosterSpeedInput.Text))
                {
                    var result = float.Parse(tb_boosterSpeedInput.Text) * multiplier;
                    tb_boosterSpeedOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_boosterSpeedOutput.Text = "Invalid";
            }
        }

        private void BtnBoosterCancel_OnClick(object sender, RoutedEventArgs e)
        {
            tb_boosterArmourInput.Text = "";
            tb_boosterArmourOutput.Text = "";

            tb_boosterDrainInput.Text = "";
            tb_boosterDrainOutput.Text = "";

            tb_boosterMassInput.Text = "";
            tb_boosterMassOutput.Text = "";

            tb_boosterEnergyInput.Text = "";
            tb_boosterEnergyOutput.Text = "";

            tb_boosterRechargeInput.Text = "";
            tb_boosterRechargeOutput.Text = "";

            tb_boosterConsumptionInput.Text = "";
            tb_boosterConsumptionOutput.Text = "";

            tb_boosterAccelerationInput.Text = "";
            tb_boosterAccelerationOutput.Text = "";

            tb_boosterSpeedInput.Text = "";
            tb_boosterSpeedOutput.Text = "";
        }

        #endregion

        #region Shield

        private void BtnShieldCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var multiplier = GetMultiplier(cb_shieldLevel.SelectedIndex);

            try //Armour
            {
                if (!string.IsNullOrEmpty(tb_shieldArmourInput.Text))
                {
                    var result = float.Parse(tb_shieldArmourInput.Text) * multiplier;
                    tb_shieldArmourOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_shieldArmourOutput.Text = "Invalid";
            }

            try //Drain
            {
                if (!string.IsNullOrEmpty(tb_shieldDrainInput.Text))
                {
                    var result = float.Parse(tb_shieldDrainInput.Text) / multiplier;
                    tb_shieldDrainOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_shieldDrainOutput.Text = "Invalid";
            }

            try //Mass
            {
                if (!string.IsNullOrEmpty(tb_shieldMassInput.Text))
                {
                    var result = float.Parse(tb_shieldMassInput.Text) / multiplier;
                    tb_shieldMassOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_shieldMassOutput.Text = "Invalid";
            }

            try //Front HP
            {
                if (!string.IsNullOrEmpty(tb_shieldFrontHPInput.Text))
                {
                    var result = float.Parse(tb_shieldFrontHPInput.Text) * multiplier;
                    tb_shieldFrontHPOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_shieldFrontHPOutput.Text = "Invalid";
            }

            try //Rear HP
            {
                if (!string.IsNullOrEmpty(tb_shieldRearHPInput.Text))
                {
                    var result = float.Parse(tb_shieldRearHPInput.Text) * multiplier;
                    tb_shieldRearHPOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_shieldRearHPOutput.Text = "Invalid";
            }

            try //Recharge
            {
                if (!string.IsNullOrEmpty(tb_shieldRechargeInput.Text))
                {
                    var result = float.Parse(tb_shieldRechargeInput.Text) * multiplier;
                    tb_shieldRechargeOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_shieldRechargeOutput.Text = "Invalid";
            }
        }

        private void BtnShieldCancel_OnClick(object sender, RoutedEventArgs e)
        {
            tb_shieldArmourInput.Text = "";
            tb_shieldArmourOutput.Text = "";

            tb_shieldDrainInput.Text = "";
            tb_shieldDrainOutput.Text = "";

            tb_shieldMassInput.Text = "";
            tb_shieldMassOutput.Text = "";

            tb_shieldFrontHPInput.Text = "";
            tb_shieldFrontHPOutput.Text = "";

            tb_shieldRearHPInput.Text = "";
            tb_shieldRearHPOutput.Text = "";

            tb_shieldRechargeInput.Text = "";
            tb_shieldRechargeOutput.Text = "";
        }

        #endregion

        #region Armour

        private void BtnarmourCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var multiplier = GetMultiplier(cb_shieldLevel.SelectedIndex);

            try //Armour
            {
                if (!string.IsNullOrEmpty(tb_armourArmourInput.Text))
                {
                    var result = float.Parse(tb_armourArmourInput.Text) * multiplier;
                    tb_armourArmourOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_armourArmourOutput.Text = "Invalid";
            }

            try //Mass
            {
                if (!string.IsNullOrEmpty(tb_armourMassInput.Text))
                {
                    var result = float.Parse(tb_armourMassInput.Text) / multiplier;
                    tb_armourMassOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_armourMassOutput.Text = "Invalid";
            }
        }

        private void BtnarmourCancel_OnClick(object sender, RoutedEventArgs e)
        {
            tb_armourArmourInput.Text = "";
            tb_armourArmourOutput.Text = "";

            tb_armourMassInput.Text = "";
            tb_armourMassOutput.Text = "";
        }

        #endregion

        #region Droid Interface

        private void BtndiCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var multiplier = GetMultiplier(cb_diLevel.SelectedIndex);

            try //Armour
            {
                if (!string.IsNullOrEmpty(tb_diArmourInput.Text))
                {
                    var result = float.Parse(tb_diArmourInput.Text) * multiplier;
                    tb_diArmourOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_diArmourOutput.Text = "Invalid";
            }

            try //Drain
            {
                if (!string.IsNullOrEmpty(tb_diDrainInput.Text))
                {
                    var result = float.Parse(tb_diDrainInput.Text) * multiplier;
                    tb_diDrainOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_diDrainOutput.Text = "Invalid";
            }

            try //Mass
            {
                if (!string.IsNullOrEmpty(tb_diMassInput.Text))
                {
                    var result = float.Parse(tb_diMassInput.Text) * multiplier;
                    tb_diMassOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_diMassOutput.Text = "Invalid";
            }

            try //Speed
            {
                if (!string.IsNullOrEmpty(tb_diSpeedInput.Text))
                {
                    var result = float.Parse(tb_diSpeedInput.Text) * multiplier;
                    tb_diSpeedOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_diSpeedOutput.Text = "Invalid";
            }
        }

        private void BtndiCancel_OnClick(object sender, RoutedEventArgs e)
        {
            tb_diArmourInput.Text = "";
            tb_diArmourOutput.Text = "";

            tb_diDrainInput.Text = "";
            tb_diDrainOutput.Text = "";

            tb_diMassInput.Text = "";
            tb_diMassOutput.Text = "";

            tb_diSpeedInput.Text = "";
            tb_diSpeedOutput.Text = "";
        }

        #endregion

        #region Capacitor

        private void BtncapCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var multiplier = GetMultiplier(cb_capLevel.SelectedIndex);

            try //Armour
            {
                if (!string.IsNullOrEmpty(tb_capArmourInput.Text))
                {
                    var result = float.Parse(tb_capArmourInput.Text) * multiplier;
                    tb_capArmourOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_capArmourOutput.Text = "Invalid";
            }

            try //Drain
            {
                if (!string.IsNullOrEmpty(tb_capDrainInput.Text))
                {
                    var result = float.Parse(tb_capDrainInput.Text) / multiplier;
                    tb_capDrainOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_capDrainOutput.Text = "Invalid";
            }

            try //Mass
            {
                if (!string.IsNullOrEmpty(tb_capMassInput.Text))
                {
                    var result = float.Parse(tb_capMassInput.Text) / multiplier;
                    tb_capMassOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_capMassOutput.Text = "Invalid";
            }

            try //Energy
            {
                if (!string.IsNullOrEmpty(tb_capEnergyInput.Text))
                {
                    var result = float.Parse(tb_capEnergyInput.Text) * multiplier;
                    tb_capEnergyOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_capEnergyOutput.Text = "Invalid";
            }

            try //Recharge
            {
                if (!string.IsNullOrEmpty(tb_capRechargeInput.Text))
                {
                    var result = float.Parse(tb_capRechargeInput.Text) * multiplier;
                    tb_capRechargeOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_capRechargeOutput.Text = "Invalid";
            }
        }

        private void BtncapCancel_OnClick(object sender, RoutedEventArgs e)
        {
            tb_capArmourInput.Text = "";
            tb_capArmourOutput.Text = "";

            tb_capDrainInput.Text = "";
            tb_capDrainOutput.Text = "";

            tb_capMassInput.Text = "";
            tb_capMassOutput.Text = "";

            tb_capEnergyInput.Text = "";
            tb_capEnergyOutput.Text = "";

            tb_capRechargeInput.Text = "";
            tb_capRechargeOutput.Text = "";
        }

        #endregion

        #region Weapon

        private void BtnwepCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var multiplier = GetMultiplier(cb_wepLevel.SelectedIndex);

            try //Armour
            {
                if (!string.IsNullOrEmpty(tb_wepArmourInput.Text))
                {
                    var result = float.Parse(tb_wepArmourInput.Text) * multiplier;
                    tb_wepArmourOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_wepArmourOutput.Text = "Invalid";
            }

            try //Drain
            {
                if (!string.IsNullOrEmpty(tb_wepDrainInput.Text))
                {
                    var result = float.Parse(tb_wepDrainInput.Text) / multiplier;
                    tb_wepDrainOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_wepDrainOutput.Text = "Invalid";
            }

            try //Mass
            {
                if (!string.IsNullOrEmpty(tb_wepMassInput.Text))
                {
                    var result = float.Parse(tb_wepMassInput.Text) / multiplier;
                    tb_wepMassOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_wepMassOutput.Text = "Invalid";
            }

            try //MinDamage
            {
                if (!string.IsNullOrEmpty(tb_wepMinInput.Text))
                {
                    var result = float.Parse(tb_wepMinInput.Text) * multiplier;
                    tb_wepMinOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_wepMinOutput.Text = "Invalid";
            }

            try //MaxDamage
            {
                if (!string.IsNullOrEmpty(tb_wepMaxInput.Text))
                {
                    var result = float.Parse(tb_wepMaxInput.Text) * multiplier;
                    tb_wepMaxOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_wepMaxOutput.Text = "Invalid";
            }

            try //Vs Shield
            {
                if (!string.IsNullOrEmpty(tb_wepVShieldInput.Text))
                {
                    var result = float.Parse(tb_wepVShieldInput.Text) * multiplier;
                    tb_wepVShieldOutput.Text = result.ToString("0.000");
                }
            }
            catch (Exception)
            {
                tb_wepVShieldOutput.Text = "Invalid";
            }

            try //Vs Armour
            {
                if (!string.IsNullOrEmpty(tb_wepVArmourInput.Text))
                {
                    var result = float.Parse(tb_wepVArmourInput.Text) * multiplier;
                    tb_wepVArmourOutput.Text = result.ToString("0.000");
                }
            }
            catch (Exception)
            {
                tb_wepVArmourOutput.Text = "Invalid";
            }

            try //EPS
            {
                if (!string.IsNullOrEmpty(tb_wepEPSInput.Text))
                {
                    var result = float.Parse(tb_wepEPSInput.Text) / multiplier;
                    tb_wepEPSOutput.Text = result.ToString("0.0");
                }
            }
            catch (Exception)
            {
                tb_wepEPSOutput.Text = "Invalid";
            }

            try //Refire
            {
                if (!string.IsNullOrEmpty(tb_wepRefireInput.Text))
                {
                    var result = float.Parse(tb_wepRefireInput.Text) / multiplier;
                    tb_wepRefireOutput.Text = result.ToString("0.000");
                }
            }
            catch (Exception)
            {
                tb_wepRefireOutput.Text = "Invalid";
            }
        }

        private void BtnwepCancel_OnClick(object sender, RoutedEventArgs e)
        {
            tb_wepArmourInput.Text = "";
            tb_wepArmourOutput.Text = "";

            tb_wepDrainInput.Text = "";
            tb_wepDrainOutput.Text = "";

            tb_wepMassInput.Text = "";
            tb_wepMassOutput.Text = "";

            tb_wepMinInput.Text = "";
            tb_wepMinOutput.Text = "";

            tb_wepMaxInput.Text = "";
            tb_wepMaxOutput.Text = "";

            tb_wepVShieldInput.Text = "";
            tb_wepVShieldOutput.Text = "";

            tb_wepVArmourInput.Text = "";
            tb_wepVArmourOutput.Text = "";
        }

        #endregion
    }
}
