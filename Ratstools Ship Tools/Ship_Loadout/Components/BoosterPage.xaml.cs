using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class BoosterPage : Page
    {
        public BoosterPage()
        {
            InitializeComponent();

            dg_booster.ItemsSource = Components.Boosters;
        }

        private void Dg_booster_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            Booster booster = (Booster)dg_booster.SelectedItem;

            if (booster != null)
            {
                tb_BoosterName.Text = booster.Name;
                tb_BoosterArmour.Text = booster.Armour.ToString();
                tb_BoosterDrain.Text = booster.Drain.ToString();
                tb_BoosterMass.Text = booster.Mass.ToString();
                tb_BoosterEnergy.Text = booster.Energy.ToString();
                tb_BoosterRecharge.Text = booster.Recharge.ToString();
                tb_BoosterConsumption.Text = booster.Consumption.ToString();
                tb_BoosterAcceleration.Text = booster.Acceleration.ToString();
                tb_BoosterSpeed.Text = booster.Speed.ToString();
            }
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_booster.SelectedIndex = -1;
            ClearControls();
        }

        private void ClearControls()
        {
            tb_BoosterName.Text = "";
            tb_BoosterArmour.Text = "";
            tb_BoosterDrain.Text = "";
            tb_BoosterMass.Text = "";
            tb_BoosterEnergy.Text = "";
            tb_BoosterRecharge.Text = "";
            tb_BoosterConsumption.Text = "";
            tb_BoosterAcceleration.Text = "";
            tb_BoosterSpeed.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            Booster booster = new Booster
            {
                Name = tb_BoosterName.Text,
                Armour = float.Parse(tb_BoosterArmour.Text),
                Drain = float.Parse(tb_BoosterDrain.Text),
                Mass = float.Parse(tb_BoosterMass.Text),
                Energy = float.Parse(tb_BoosterEnergy.Text),
                Recharge = float.Parse(tb_BoosterRecharge.Text),
                Consumption = float.Parse(tb_BoosterConsumption.Text),
                Acceleration = float.Parse(tb_BoosterAcceleration.Text),
                Speed = float.Parse(tb_BoosterSpeed.Text) 
            };

            if (dg_booster.SelectedIndex != -1)
            {
                booster.ID = Components.Boosters[dg_booster.SelectedIndex].ID;

                Components.Boosters[dg_booster.SelectedIndex] = booster;
            }
            else
            {
                booster.ID = Guid.NewGuid().ToString();

                Components.Boosters.Add(booster);
            }

            SaveJSON();

            dg_booster.Items.Refresh();
        }

        //Serialise JSON directly into Filestream
        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/Boosters.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.Boosters);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_booster.SelectedIndex != -1)
            {
                Components.Boosters.RemoveAt(dg_booster.SelectedIndex);

                SaveJSON();

                dg_booster.Items.Refresh();
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsValidated()
        {
            if (string.IsNullOrEmpty(tb_BoosterName.Text)) return false;
            if (string.IsNullOrEmpty(tb_BoosterArmour.Text)) return false;
            if (string.IsNullOrEmpty(tb_BoosterDrain.Text)) return false;
            if (string.IsNullOrEmpty(tb_BoosterMass.Text)) return false;
            if (string.IsNullOrEmpty(tb_BoosterEnergy.Text)) return false;
            if (string.IsNullOrEmpty(tb_BoosterRecharge.Text)) return false;
            if (string.IsNullOrEmpty(tb_BoosterConsumption.Text)) return false;
            if (string.IsNullOrEmpty(tb_BoosterAcceleration.Text)) return false;
            if (string.IsNullOrEmpty(tb_BoosterSpeed.Text)) return false;

            return true;
        }
    }
}
