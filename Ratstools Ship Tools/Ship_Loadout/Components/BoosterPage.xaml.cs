using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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

            var i = dg_booster.SelectedIndex;

            if (i != -1)
            {
                tb_BoosterName.Text = Components.Boosters[i].Name;
                tb_BoosterArmour.Text = Components.Boosters[i].Armour.ToString();
                tb_BoosterDrain.Text = Components.Boosters[i].Drain.ToString();
                tb_BoosterMass.Text = Components.Boosters[i].Mass.ToString();
                tb_BoosterEnergy.Text = Components.Boosters[i].Energy.ToString();
                tb_BoosterRecharge.Text = Components.Boosters[i].Recharge.ToString();
                tb_BoosterConsumption.Text = Components.Boosters[i].Consumption.ToString();
                tb_BoosterAcceleration.Text = Components.Boosters[i].Acceleration.ToString();
                tb_BoosterSpeed.Text = Components.Boosters[i].Speed.ToString();
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
            using (StreamWriter file = File.CreateText("Boosters.json"))
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
    }
}
