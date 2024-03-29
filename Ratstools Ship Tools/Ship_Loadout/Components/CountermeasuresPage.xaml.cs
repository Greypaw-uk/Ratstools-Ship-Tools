﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class CountermeasuresPage : Page
    {
        public CountermeasuresPage()
        {
            InitializeComponent();

            dg_counter.ItemsSource = Components.CounterMeasures;
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_counter.SelectedIndex = -1;
            ClearControls();
        }

        private void Dg_counter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            CounterMeasure cm = (CounterMeasure)dg_counter.SelectedItem;

            if (cm != null)
            {
                tb_Name.Text = cm.Name;
                tb_Armour.Text = cm.Armour.ToString();
                tb_Drain.Text = cm.Drain.ToString();
                tb_Mass.Text = cm.Mass.ToString();
            }
        }

        private void ClearControls()
        {
            tb_Name.Text = "";
            tb_Armour.Text = "";
            tb_Drain.Text = "";
            tb_Mass.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            CounterMeasure cm = new CounterMeasure()
            {
                Name = tb_Name.Text,
                Armour = float.Parse(tb_Armour.Text),
                Drain = float.Parse(tb_Drain.Text),
                Mass = float.Parse(tb_Mass.Text)
            };

            if (dg_counter.SelectedIndex != -1)
            {
                cm.ID = Components.CounterMeasures[dg_counter.SelectedIndex].ID;

                Components.CounterMeasures[dg_counter.SelectedIndex] = cm;
            }
            else
            {
                cm.ID = Guid.NewGuid().ToString();

                Components.CounterMeasures.Add(cm);
            }

            SaveJSON();

            dg_counter.Items.Refresh();
        }

        //Serialise JSON directly into Filestream
        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/CMeasures.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.CounterMeasures);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_counter.SelectedIndex != -1)
            {
                Components.CounterMeasures.RemoveAt(dg_counter.SelectedIndex);

                SaveJSON();

                dg_counter.Items.Refresh();
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
            if (string.IsNullOrEmpty(tb_Drain.Text)) return false;
            if (string.IsNullOrEmpty(tb_Mass.Text)) return false;

            return true;
        }
    }
}
