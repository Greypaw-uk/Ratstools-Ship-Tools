﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class ArmourPage : Page
    {
        public ArmourPage()
        {
            InitializeComponent();

            dg_armour.ItemsSource = Components.Armours;
        }

        private void Btn_addOnClick(object sender, RoutedEventArgs e)
        {
            dg_armour.SelectedIndex = -1;
            ClearControls();
        }

        private void Dg_booster_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            var i = dg_armour.SelectedIndex;

            if (i != -1)
            {
                tb_armourName.Text = Components.Armours[i].Name;
                tb_armourArmour.Text = Components.Armours[i].Armor.ToString();
                tb_armourMass.Text = Components.Armours[i].Mass.ToString();
            }
        }

        private void ClearControls()
        {
            tb_armourName.Text = "";
            tb_armourArmour.Text = "";
            tb_armourMass.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            Armour armour = new Armour
            {
                Name = tb_armourName.Text,
                Armor = float.Parse(tb_armourArmour.Text),
                Mass = float.Parse(tb_armourMass.Text)
            };

            if (dg_armour.SelectedIndex != -1)
            {
                armour.ID = Components.Armours[dg_armour.SelectedIndex].ID;

                Components.Armours[dg_armour.SelectedIndex] = armour;
            }
            else
            {
                armour.ID = Guid.NewGuid().ToString();

                Components.Armours.Add(armour);
            }

            SaveJSON();

            dg_armour.Items.Refresh();
        }

        //Serialise JSON directly into Filestream
        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Armour.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.Armours);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_armour.SelectedIndex != -1)
            {
                Components.Armours.RemoveAt(dg_armour.SelectedIndex);

                SaveJSON();

                dg_armour.Items.Refresh();
            }
        }
    }
}
