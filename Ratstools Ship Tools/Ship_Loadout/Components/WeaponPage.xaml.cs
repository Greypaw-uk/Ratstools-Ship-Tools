using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class WeaponPage : Page
    {
        public WeaponPage()
        {
            InitializeComponent();

            dg_weapon.ItemsSource = Components.Weapons;
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_weapon.SelectedIndex = -1;

            ClearControls();
        }

        private void Dg_shield_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            Weapon weapon = (Weapon)dg_weapon.SelectedItem;

            if (weapon != null)
            {
                tb_name.Text = weapon.Name;
                tb_armour.Text = weapon.Armour.ToString();
                tb_drain.Text = weapon.Drain.ToString();
                tb_Mass.Text = weapon.Mass.ToString();
                tb_minDam.Text = weapon.MinD.ToString();
                tb_maxDam.Text = weapon.MaxD.ToString();
                tb_vShield.Text = weapon.VS.ToString();
                tb_vArmour.Text = weapon.VA.ToString();
                tb_eps.Text = weapon.EPS.ToString();
                tb_refire.Text = weapon.RR.ToString();
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
            tb_eps.Text = "";
            tb_refire.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            Weapon weapon = new Weapon
            {
                Name = tb_name.Text,
                Armour = float.Parse(tb_armour.Text),
                Drain = float.Parse(tb_drain.Text),
                Mass = float.Parse(tb_Mass.Text),
                MinD = float.Parse(tb_minDam.Text),
                MaxD = float.Parse(tb_maxDam.Text),
                VS = float.Parse(tb_vShield.Text),
                VA = float.Parse(tb_vArmour.Text),
                EPS = float.Parse(tb_eps.Text),
                RR = float.Parse(tb_refire.Text)
            };

            if (dg_weapon.SelectedIndex != -1)
            {
                weapon.ID = Components.Weapons[dg_weapon.SelectedIndex].ID;

                Components.Weapons[dg_weapon.SelectedIndex] = weapon;
            }
            else
            {
                weapon.ID = Guid.NewGuid().ToString();

                Components.Weapons.Add(weapon);
            }

            SaveJSON();

            dg_weapon.Items.Refresh();
        }

        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/Weapons.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.Weapons);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_weapon.SelectedIndex != -1)
            {
                Components.Weapons.RemoveAt(dg_weapon.SelectedIndex);

                SaveJSON();

                dg_weapon.Items.Refresh();
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
            if (string.IsNullOrEmpty(tb_eps.Text)) return false;
            if (string.IsNullOrEmpty(tb_refire.Text)) return false;

            return true;
        }

        private void Tb_vShield_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_vShield.Text))
            {
                if (!tb_vShield.Text.Contains("."))
                {
                    tb_vShield.Text = "0." + tb_vShield.Text;
                }
            }
        }

        private void Tb_vArmour_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_armour.Text))
            {
                if (!tb_armour.Text.Contains("."))
                {
                    tb_armour.Text = "0." + tb_armour.Text;
                }
            }
        }

        private void Tb_eps_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_eps.Text))
            {
                if (!tb_eps.Text.Contains("."))
                {
                    tb_eps.Text = "0." + tb_eps.Text;
                }
            }
        }

        private void Tb_refire_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_refire.Text))
            {
                if (!tb_refire.Text.Contains("."))
                {
                    tb_refire.Text = "0." + tb_refire.Text;
                }
            }
        }
    }
}
