using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class DroidInterfacePage : Page
    {
        public DroidInterfacePage()
        {
            InitializeComponent();

            dg_de.ItemsSource = Components.DroidInterfaces;
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_de.SelectedIndex = -1;
            ClearControls();
        }

        private void Dg_armour_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            var i = dg_de.SelectedIndex;

            if (i != -1)
            {
                tb_name.Text = Components.DroidInterfaces[i].Name;
                tb_armour.Text = Components.DroidInterfaces[i].Armour.ToString();
                tb_mass.Text = Components.DroidInterfaces[i].Mass.ToString();
                tb_speed.Text = Components.DroidInterfaces[i].Speed.ToString();
            }
        }

        private void ClearControls()
        {
            tb_name.Text = "";
            tb_armour.Text = "";
            tb_mass.Text = "";
            tb_speed.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            DroidInterface de = new DroidInterface
            {
                Name = tb_name.Text,
                Armour = float.Parse(tb_armour.Text),
                Mass = float.Parse(tb_mass.Text),
                Speed = float.Parse(tb_speed.Text)
            };

            if (dg_de.SelectedIndex != -1)
            {
                de.ID = Components.DroidInterfaces[dg_de.SelectedIndex].ID;

                Components.DroidInterfaces[dg_de.SelectedIndex] = de;
            }
            else
            {
                de.ID = Guid.NewGuid().ToString();

                Components.DroidInterfaces.Add(de);
            }

            SaveJSON();

            dg_de.Items.Refresh();
        }

        //Serialise JSON directly into Filestream
        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/DroidInterfaces.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.DroidInterfaces);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_de.SelectedIndex != -1)
            {
                Components.DroidInterfaces.RemoveAt(dg_de.SelectedIndex);

                SaveJSON();

                dg_de.Items.Refresh();
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
            if (string.IsNullOrEmpty(tb_mass.Text)) return false;
            if (string.IsNullOrEmpty(tb_armour.Text)) return false;
            if (string.IsNullOrEmpty(tb_speed.Text)) return false;

            return true;
        }
    }
}
