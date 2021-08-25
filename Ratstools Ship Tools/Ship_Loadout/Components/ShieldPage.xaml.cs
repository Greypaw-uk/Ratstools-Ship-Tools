using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class ShieldPage : Page
    {
        public ShieldPage()
        {
            InitializeComponent();

            dg_shield.ItemsSource = Components.Shields;
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_shield.SelectedIndex = -1;

            ClearControls();
        }

        private void Dg_shield_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            var i = dg_shield.SelectedIndex;

            if (i != -1)
            {
                tb_name.Text = Components.Shields[i].Name;
                tb_armour.Text = Components.Shields[i].Armour.ToString();
                tb_Mass.Text = Components.Shields[i].Mass.ToString();
                tb_drain.Text = Components.Shields[i].Drain.ToString();
                tb_fHealth.Text = Components.Shields[i].FHP.ToString();
                tb_rHealth.Text = Components.Shields[i].RHP.ToString();
                tb_recharge.Text = Components.Shields[i].RR.ToString();

                cb_adjust.SelectedIndex = Components.Shields[i].Adjust;
            }
        }

        private void ClearControls()
        {
            tb_name.Text = "";
            tb_armour.Text = "";
            tb_Mass.Text = "";
            tb_drain.Text = "";
            tb_fHealth.Text = "";
            tb_rHealth.Text = "";
            tb_recharge.Text = "";

            cb_adjust.SelectedIndex = -1;
        }


        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            Shield shield = new Shield
            {
                Name = tb_name.Text,
                Armour = float.Parse(tb_armour.Text),
                Mass = float.Parse(tb_Mass.Text),
                Drain = float.Parse(tb_drain.Text),
                FHP = float.Parse(tb_fHealth.Text),
                RHP = float.Parse(tb_rHealth.Text),
                RR = float.Parse(tb_recharge.Text),

                Adjust = cb_adjust.SelectedIndex
            };

            if (dg_shield.SelectedIndex != -1)
            {
                shield.ID = Components.Shields[dg_shield.SelectedIndex].ID;

                Components.Shields[dg_shield.SelectedIndex] = shield;
            }
            else
            {
                shield.ID = Guid.NewGuid().ToString();

                Components.Shields.Add(shield);
            }

            SaveJSON();

            dg_shield.Items.Refresh();
        }

        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Shields.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.Shields);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_shield.SelectedIndex != -1)
            {
                Components.Shields.RemoveAt(dg_shield.SelectedIndex);

                SaveJSON();

                dg_shield.Items.Refresh();
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsValidated()
        {
            if (string.IsNullOrEmpty(tb_name.Text)) return false;
            if (string.IsNullOrEmpty(tb_armour.Text)) return false;
            if (string.IsNullOrEmpty(tb_Mass.Text)) return false;
            if (string.IsNullOrEmpty(tb_drain.Text)) return false;
            if (string.IsNullOrEmpty(tb_fHealth.Text)) return false;
            if (string.IsNullOrEmpty(tb_rHealth.Text)) return false;
            if (string.IsNullOrEmpty(tb_recharge.Text)) return false;

            return true;
        }
    }
}
