using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class CapacitorPage : Page
    {
        public CapacitorPage()
        {
            InitializeComponent();

            dg_capacitors.ItemsSource = Components.Capacitors;
        }

        private void Dg_capacitors_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            Capacitor cap = (Capacitor)dg_capacitors.SelectedItem;

            if (cap != null)
            {
                tb_Name.Text = cap.Name;
                tb_Armour.Text = cap.Armour.ToString();
                tb_Drain.Text = cap.Drain.ToString();
                tb_Mass.Text = cap.Mass.ToString();
                tb_Energy.Text = cap.Energy.ToString();
                tb_Recharge.Text = cap.RechargeRate.ToString();
            }
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_capacitors.SelectedIndex = -1;
            ClearControls();
        }

        private void ClearControls()
        {
            tb_Name.Text = "";
            tb_Armour.Text = "";
            tb_Drain.Text = "";
            tb_Mass.Text = "";
            tb_Energy.Text = "";
            tb_Recharge.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            Capacitor capacitor = new Capacitor
            {
                Name = tb_Name.Text,
                Armour = float.Parse(tb_Armour.Text),
                Drain = float.Parse(tb_Drain.Text),
                Mass = float.Parse(tb_Mass.Text),
                Energy = float.Parse(tb_Energy.Text),
                RechargeRate = float.Parse(tb_Recharge.Text)
            };

            if (dg_capacitors.SelectedIndex != -1)
            {
                capacitor.ID = Components.Capacitors[dg_capacitors.SelectedIndex].ID;

                Components.Capacitors[dg_capacitors.SelectedIndex] = capacitor;
            }
            else
            {
                capacitor.ID = Guid.NewGuid().ToString();

                Components.Capacitors.Add(capacitor);
            }

            SaveJSON();

            dg_capacitors.Items.Refresh();
        }

        //Serialise JSON directly into Filestream
        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/Capacitors.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.Capacitors);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_capacitors.SelectedIndex != -1)
            {
                Components.Capacitors.RemoveAt(dg_capacitors.SelectedIndex);

                SaveJSON();

                dg_capacitors.Items.Refresh();
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
            if (string.IsNullOrEmpty(tb_Energy.Text)) return false;
            if (string.IsNullOrEmpty(tb_Recharge.Text)) return false;

            return true;
        }
    }
}
