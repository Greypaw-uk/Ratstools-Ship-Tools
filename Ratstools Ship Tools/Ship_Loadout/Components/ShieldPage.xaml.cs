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

            Shield shield = (Shield)dg_shield.SelectedItem;

            if (shield != null)
            {
                tb_name.Text = shield.Name;
                tb_armour.Text = shield.Armour.ToString();
                tb_Mass.Text = shield.Mass.ToString();
                tb_drain.Text = shield.Drain.ToString();
                tb_fHealth.Text = shield.FHP.ToString();
                tb_rHealth.Text = shield.RHP.ToString();
                tb_recharge.Text = shield.RR.ToString();

                cb_adjust.SelectedIndex = shield.Adjust;
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
            using (StreamWriter file = File.CreateText("Components/Shields.json"))
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
