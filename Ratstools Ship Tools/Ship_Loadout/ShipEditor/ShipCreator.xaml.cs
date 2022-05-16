using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.ShipEditor
{
    public partial class ShipCreator : Page
    {
        public List<Ship> ShipList = new List<Ship>();

        public ShipCreator()
        {
            InitializeComponent();

            PopulateShipList();
            dg_ships.ItemsSource = ShipList;
        }

        private void ClearControls()
        {
            cb_faction.SelectedIndex = -1;

            tb_name.Text = "";
            tb_mass.Text = "";
            tb_acceleration.Text = "";
            tb_deceleration.Text = "";
            tb_yaw.Text = "";
            tb_pitch.Text = "";
            tb_roll.Text = "";
            tb_speedHigh.Text = "";
            tb_speedLow.Text = "";
            tb_weapons.Text = "";
            tb_turrets.Text = "";
            tb_ordinance.Text = "";
            tb_counters.Text = "";
        }

        private void Dg_ships_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            if (dg_ships.SelectedIndex != -1)
            {
                var ship = ShipList[dg_ships.SelectedIndex];

                cb_faction.SelectedIndex = ship.Faction;

                tb_name.Text = ship.ChassisName;
                tb_mass.Text = ship.Mass.ToString();
                tb_acceleration.Text = ship.Acceleration.ToString();
                tb_deceleration.Text = ship.Deceleration.ToString();
                tb_yaw.Text = ship.Yaw.ToString();
                tb_pitch.Text = ship.Pitch.ToString();
                tb_roll.Text = ship.Roll.ToString();
                tb_speedHigh.Text = ship.SpeedTop.ToString();
                tb_speedLow.Text = ship.SpeedLow.ToString();
                tb_weapons.Text = ship.Weapons.ToString();
                tb_turrets.Text = ship.Turrets.ToString();
                tb_ordinance.Text = ship.Ordinance.ToString();
                tb_counters.Text = ship.Countermeasures.ToString();
            }
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            var ship = new Ship
            {
                Faction = cb_faction.SelectedIndex,

                ChassisName = tb_name.Text,
                Mass = int.Parse(tb_mass.Text),
                Acceleration = int.Parse(tb_acceleration.Text),
                Deceleration = int.Parse(tb_deceleration.Text),
                Yaw = int.Parse(tb_yaw.Text),
                Pitch = int.Parse(tb_pitch.Text),
                Roll = float.Parse(tb_roll.Text),
                SpeedTop = float.Parse(tb_speedHigh.Text),
                SpeedLow = float.Parse(tb_speedLow.Text),
                Weapons = int.Parse(tb_weapons.Text),
                Turrets = int.Parse(tb_turrets.Text),
                Ordinance = int.Parse(tb_ordinance.Text),
                Countermeasures = int.Parse(tb_counters.Text)
            };

            if (dg_ships.SelectedIndex != -1)
            {
                ship.ID = ShipList[dg_ships.SelectedIndex].ID;
                ShipList[dg_ships.SelectedIndex] = ship;
            }
            else
            {
                ship.ID = Guid.NewGuid().ToString();
                ShipList.Add(ship);
            }

            SaveJSON();

            dg_ships.Items.Refresh();

            ClearControls();
        }

        //Serialise JSON directly into Filestream
        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Ship_Data/Ships.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ShipList);
            }
        }

        private void PopulateShipList()
        {
            if (File.Exists("Ship_Data/Ships.json"))
            {
                var json = new StreamReader("Ship_Data/Ships.json").ReadToEnd();
                ShipList = JsonConvert.DeserializeObject<List<Ship>>(json);
            }
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_ships.SelectedIndex = -1;

            ClearControls();
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsValidated()
        {
            if (string.IsNullOrEmpty(tb_name.Text)) return false;
            if (string.IsNullOrEmpty(tb_mass.Text)) return false;
            if (string.IsNullOrEmpty(tb_acceleration.Text)) return false;
            if (string.IsNullOrEmpty(tb_deceleration.Text)) return false;
            if (string.IsNullOrEmpty(tb_yaw.Text)) return false;
            if (string.IsNullOrEmpty(tb_pitch.Text))  return false;
            if (string.IsNullOrEmpty(tb_roll.Text)) return false;
            if (string.IsNullOrEmpty(tb_speedHigh.Text)) return false;
            if (string.IsNullOrEmpty(tb_speedLow.Text)) return false;
            if (string.IsNullOrEmpty(tb_weapons.Text)) return false;
            if (string.IsNullOrEmpty(tb_turrets.Text)) return false;
            if (string.IsNullOrEmpty(tb_ordinance.Text)) return false;
            if (string.IsNullOrEmpty(tb_counters.Text)) return false;

            return true;
        }

        private void Tb_speedHigh_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_speedHigh.Text))
                if (!tb_speedHigh.Text.Contains("."))
                {
                    if (tb_speedHigh.Text.Equals("1"))
                        tb_speedHigh.Text = "1.0";
                    else
                        tb_speedHigh.Text = "0." + tb_speedHigh.Text;
                }
        }

        private void Tb_speedLow_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_speedLow.Text))
                if (!tb_speedLow.Text.Contains("."))
                {
                    if (tb_speedLow.Text.Equals("1"))
                        tb_speedLow.Text = "1.0";
                    else
                        tb_speedLow.Text = "0." + tb_speedLow.Text;
                }
        }

        private void Tb_roll_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_roll.Text))
                if (tb_roll.Text.Equals("375"))
                    tb_roll.Text = "37.5";
        }
    }
}
