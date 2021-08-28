using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class OrdinancePage : Page
    {
        public OrdinancePage()
        {
            InitializeComponent();

            dg_ordinance.ItemsSource = Components.Ordinances;
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_ordinance.SelectedIndex = -1;

            ClearControls();
        }

        private void Dg_ordinance_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            var i = dg_ordinance.SelectedIndex;

            if (i != -1)
            {
                tb_name.Text = Components.Ordinances[i].Name;
                tb_armour.Text = Components.Ordinances[i].Armour.ToString();
                tb_drain.Text = Components.Ordinances[i].Drain.ToString();
                tb_Mass.Text = Components.Ordinances[i].Mass.ToString(); 
                tb_minDam.Text = Components.Ordinances[i].MinDam.ToString(); 
                tb_maxDam.Text = Components.Ordinances[i].Mass.ToString(); 
                tb_vShield.Text = Components.Ordinances[i].VShield.ToString(); 
                tb_vArmour.Text = Components.Ordinances[i].VArmour.ToString(); 
                tb_ammo.Text = Components.Ordinances[i].Ammo.ToString();
            }
        }

        private void ClearControls()
        {
            tb_name.Text = "";
            tb_armour.Text = "";
            tb_drain.Text = "";
            tb_Mass.Text = "";
            tb_minDam.Text = "";
            tb_maxDam.Text = "";
            tb_vShield.Text = "";
            tb_vArmour.Text = "";
            tb_ammo.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            Ordinance ordinance = new Ordinance
            {
                Name = tb_name.Text,
                Armour = float.Parse(tb_armour.Text),
                Drain = float.Parse(tb_drain.Text),
                Mass = float.Parse(tb_Mass.Text),
                MinDam = float.Parse(tb_minDam.Text),
                MaxDam = float.Parse(tb_maxDam.Text),
                VShield = float.Parse(tb_vShield.Text),
                VArmour = float.Parse(tb_vShield.Text),
                Ammo = float.Parse(tb_ammo.Text)
            };

            if (dg_ordinance.SelectedIndex != -1)
            {
                ordinance.ID = Components.Ordinances[dg_ordinance.SelectedIndex].ID;

                Components.Ordinances[dg_ordinance.SelectedIndex] = ordinance;
            }
            else
            {
                ordinance.ID = Guid.NewGuid().ToString();

                Components.Ordinances.Add(ordinance);
            }

            SaveJSON();

            dg_ordinance.Items.Refresh();
        }

        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/Ordinance.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.Ordinances);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_ordinance.SelectedIndex != -1)
            {
                Components.Ordinances.RemoveAt(dg_ordinance.SelectedIndex);

                SaveJSON();

                dg_ordinance.Items.Refresh();
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
            if (string.IsNullOrEmpty(tb_drain.Text)) return false;
            if (string.IsNullOrEmpty(tb_Mass.Text)) return false;
            if (string.IsNullOrEmpty(tb_minDam.Text)) return false;
            if (string.IsNullOrEmpty(tb_maxDam.Text)) return false;
            if (string.IsNullOrEmpty(tb_vShield.Text)) return false;
            if (string.IsNullOrEmpty(tb_vArmour.Text)) return false;
            if (string.IsNullOrEmpty(tb_ammo.Text)) return false;

            return true;
        }
    }
}
