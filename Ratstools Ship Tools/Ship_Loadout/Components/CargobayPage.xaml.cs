﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class CargobayPage : Page
    {
        public CargobayPage()
        {
            InitializeComponent();

            dg_cargo.ItemsSource = Components.CargoBays;
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_cargo.SelectedIndex = -1;
            ClearControls();
        }

        private void Dg_cargo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            CargoBay cb = (CargoBay)dg_cargo.SelectedItem;

            if (cb != null)
            {
                tb_Name.Text = cb.Name;
                tb_Armour.Text = cb.Armour.ToString();
                tb_Mass.Text = cb.Mass.ToString();
            }
        }

        private void ClearControls()
        {
            tb_Name.Text = "";
            tb_Armour.Text = "";
            tb_Mass.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            CargoBay cargo = new CargoBay
            {
                Name = tb_Name.Text,
                Armour = float.Parse(tb_Armour.Text),
                Mass = float.Parse(tb_Mass.Text)
            };

            if (dg_cargo.SelectedIndex != -1)
            {
                cargo.ID = Components.CargoBays[dg_cargo.SelectedIndex].ID;

                Components.CargoBays[dg_cargo.SelectedIndex] = cargo;
            }
            else
            {
                cargo.ID = Guid.NewGuid().ToString();

                Components.CargoBays.Add(cargo);
            }

            SaveJSON();

            dg_cargo.Items.Refresh();
        }

        //Serialise JSON directly into Filestream
        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/Cargobays.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.CargoBays);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_cargo.SelectedIndex != -1)
            {
                Components.CargoBays.RemoveAt(dg_cargo.SelectedIndex);

                SaveJSON();

                dg_cargo.Items.Refresh();
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"/^\d*\.?\d*$/");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsValidated()
        {
            if (string.IsNullOrEmpty(tb_Name.Text)) return false;
            if (string.IsNullOrEmpty(tb_Armour.Text)) return false;
            if (string.IsNullOrEmpty(tb_Mass.Text)) return false;

            return true;
        }
    }
}
