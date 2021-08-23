using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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

            var i = dg_cargo.SelectedIndex;

            if (i != -1)
            {
                tb_Name.Text = Components.CargoBays[i].Name;
                tb_Armour.Text = Components.CargoBays[i].Armour.ToString();
                tb_Mass.Text = Components.CargoBays[i].Mass.ToString();
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
            using (StreamWriter file = File.CreateText("Cargobays.json"))
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
    }
}
