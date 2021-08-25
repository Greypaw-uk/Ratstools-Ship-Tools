using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace Ship_Loadout.ShipLoadout
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

                tb_name.Text = ship.Name;
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
            var ship = new Ship
            {
                Name = tb_name.Text,
                Mass = int.Parse(tb_mass.Text),
                Acceleration = int.Parse(tb_acceleration.Text),
                Deceleration = int.Parse(tb_deceleration.Text),
                Yaw = int.Parse(tb_yaw.Text),
                Pitch = int.Parse(tb_pitch.Text),
                Roll = int.Parse(tb_roll.Text),
                SpeedTop = float.Parse(tb_speedHigh.Text),
                SpeedLow = float.Parse(tb_speedLow.Text),
                Weapons = int.Parse(tb_weapons.Text),
                Turrets = int.Parse(tb_weapons.Text),
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
        }

        //Serialise JSON directly into Filestream
        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Ships.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ShipList);
            }
        }

        private void PopulateShipList()
        {
            if (File.Exists("Ships.json"))
            {
                var json = new StreamReader("Ships.json").ReadToEnd();
                ShipList = JsonConvert.DeserializeObject<List<Ship>>(json);
            }
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_ships.SelectedIndex = -1;

            ClearControls();
        }
    }
}
