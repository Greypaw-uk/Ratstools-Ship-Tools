using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public partial class EnginePage : Page
    {
        public EnginePage()
        {
            InitializeComponent();

            dg_engine.ItemsSource = Components.Engines;
        }

        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            dg_engine.SelectedIndex = -1;

            ClearControls();
        }

        private void Dg_armour_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();

            Engine engine = (Engine)dg_engine.SelectedItem;

            if (engine != null)
            {
                tb_name.Text = engine.Name;
                tb_armour.Text = engine.Armour.ToString();
                tb_drain.Text = engine.Drain.ToString();
                tb_Mass.Text = engine.Mass.ToString();
                tb_pitch.Text = engine.Pitch.ToString();
                tb_yaw.Text = engine.Yaw.ToString();
                tb_roll.Text = engine.Roll.ToString();
                tb_speed.Text = engine.Speed.ToString();
            }
        }

        private void ClearControls()
        {
            tb_name.Text = "";
            tb_armour.Text = "";
            tb_drain.Text = "";
            tb_Mass.Text = "";
            tb_pitch.Text = "";
            tb_yaw.Text = "";
            tb_roll.Text = "";
            tb_speed.Text = "";
        }

        private void Btn_save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Please ensure all attributes have a value.");
                return;
            }

            Engine engine = new Engine
            {
                Name = tb_name.Text,
                Armour = float.Parse(tb_armour.Text),
                Drain = float.Parse(tb_drain.Text),
                Mass =  float.Parse(tb_Mass.Text),
                Pitch = float.Parse(tb_pitch.Text),
                Yaw = float.Parse(tb_yaw.Text),
                Roll = float.Parse(tb_roll.Text),
                Speed = float.Parse(tb_speed.Text)
            };

            if (dg_engine.SelectedIndex != -1)
            {
                engine.ID = Components.Engines[dg_engine.SelectedIndex].ID;

                Components.Engines[dg_engine.SelectedIndex] = engine;
            }
            else
            {
                engine.ID = Guid.NewGuid().ToString();

                Components.Engines.Add(engine);
            }

            SaveJSON();

            dg_engine.Items.Refresh();
        }

        private void SaveJSON()
        {
            using (StreamWriter file = File.CreateText("Components/Engines.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Components.Engines);
            }
        }

        private void Btn_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dg_engine.SelectedIndex != -1)
            {
                Components.Engines.RemoveAt(dg_engine.SelectedIndex);

                SaveJSON();

                dg_engine.Items.Refresh();
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"/^\d*\.?\d*$/");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsValidated()
        {
            if (string.IsNullOrEmpty(tb_name.Text)) return false;
            if (string.IsNullOrEmpty(tb_armour.Text)) return false;
            if (string.IsNullOrEmpty(tb_drain.Text)) return false;
            if (string.IsNullOrEmpty(tb_Mass.Text)) return false;
            if (string.IsNullOrEmpty(tb_pitch.Text)) return false;
            if (string.IsNullOrEmpty(tb_yaw.Text)) return false;
            if (string.IsNullOrEmpty(tb_roll.Text)) return false;
            if (string.IsNullOrEmpty(tb_speed.Text)) return false;

            return true;
        }
    }
}
