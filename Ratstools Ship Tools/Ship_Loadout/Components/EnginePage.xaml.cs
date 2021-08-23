using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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

            var i = dg_engine.SelectedIndex;

            if (i != -1)
            {
                tb_name.Text = Components.Engines[i].Name;
                tb_armour.Text = Components.Engines[i].Armour.ToString();
                tb_drain.Text = Components.Engines[i].Drain.ToString();
                tb_Mass.Text = Components.Engines[i].Mass.ToString();
                tb_pitch.Text = Components.Engines[i].Pitch.ToString();
                tb_yaw.Text = Components.Engines[i].Yaw.ToString();
                tb_roll.Text = Components.Engines[i].Roll.ToString();
                tb_speed.Text = Components.Engines[i].Speed.ToString();
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
            using (StreamWriter file = File.CreateText("Engines.json"))
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
    }
}
