using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Ship_Loadout.Components
{
    public static class Components
    {
        #region Component Lists

        public static List<Armour> Armours = new List<Armour>();
        public static List<Booster> Boosters = new List<Booster>();
        public static List<Capacitor> Capacitors = new List<Capacitor>();
        public static List<CargoBay> CargoBays = new List<CargoBay>();
        public static List<CounterMeasure> CounterMeasures = new List<CounterMeasure>();
        public static List<DroidInterface> DroidInterfaces = new List<DroidInterface>();
        public static List<Engine> Engines = new List<Engine>();
        public static List<Ordinance> Ordinances = new List<Ordinance>();
        public static List<Reactor> Reactors = new List<Reactor>();
        public static List<Shield> Shields = new List<Shield>();
        public static List<Weapon> Weapons = new List<Weapon>();

        #endregion

        #region Component Caches

        public static Armour ArmourCache;
        public static Booster BoosterCache;
        public static Capacitor CapacitorCache;
        public static CargoBay CargoCache;
        public static CounterMeasure CounterCache;
        public static DroidInterface DECache;
        public static Engine EngineCache;
        public static Ordinance OrdinanceCache;
        public static Reactor ReactorCache;
        public static Shield ShieldCache;
        public static Weapon WeaponCache;

        #endregion

        #region Populate Components

        public static void PopulateArmourList()
        {
            if (File.Exists("Components/Armour.json"))
            {
                var json = new StreamReader("Components/Armour.json").ReadToEnd();
                Armours = JsonConvert.DeserializeObject<List<Armour>>(json);
            }
        }

        public static void PopulateBoosterList()
        {
            if (File.Exists("Components/Boosters.json"))
            {
                var json = new StreamReader("Components/Boosters.json").ReadToEnd();
                Boosters = JsonConvert.DeserializeObject<List<Booster>>(json);
            }
        }

        public static void PopulateCapacitorList()
        {
            if (File.Exists("Components/Capacitors.json"))
            {
                var json = new StreamReader("Components/Capacitors.json").ReadToEnd();
                Capacitors = JsonConvert.DeserializeObject<List<Capacitor>>(json);
            }
        }

        public static void PopulateCargoList()
        {
            if (File.Exists("Components/Cargobays.json"))
            {
                var json = new StreamReader("Components/Cargobays.json").ReadToEnd();
                CargoBays = JsonConvert.DeserializeObject<List<CargoBay>>(json);
            }
        }

        public static void PopulateCounterMeasureList()
        {
            if (File.Exists("Components/CMeasures.json"))
            {
                var json = new StreamReader("Components/CMeasures.json").ReadToEnd();
                CounterMeasures = JsonConvert.DeserializeObject<List<CounterMeasure>>(json);
            }
        }

        public static void PopulateDroidInterfaces()
        {
            if (File.Exists("Components/DroidInterfaces.json"))
            {
                var json = new StreamReader("Components/DroidInterfaces.json").ReadToEnd();
                DroidInterfaces = JsonConvert.DeserializeObject<List<DroidInterface>>(json);
            }
        }

        public static void PopulateEngines()
        {
            if (File.Exists("Components/Engines.json"))
            {
                var json = new StreamReader("Components/Engines.json").ReadToEnd();
                Engines = JsonConvert.DeserializeObject<List<Engine>>(json);
            }
        }

        public static void PopulateOrdinance()
        {
            if (File.Exists("Components/Ordinance.json"))
            {
                var json = new StreamReader("Components/Ordinance.json").ReadToEnd();
                Ordinances = JsonConvert.DeserializeObject<List<Ordinance>>(json);
            }
        }

        public static void PopulateReactors()
        {
            if (File.Exists("Components/Reactors.json"))
            {
                var json = new StreamReader("Components/Reactors.json").ReadToEnd();
                Reactors = JsonConvert.DeserializeObject<List<Reactor>>(json);
            }
        }

        public static void PopulateShields()
        {
            if (File.Exists("Components/Shields.json"))
            {
                var json = new StreamReader("Components/Shields.json").ReadToEnd();
                Shields = JsonConvert.DeserializeObject<List<Shield>>(json);
            }
        }

        public static void PopulateWeapons()
        {
            if (File.Exists("Components/Weapons.json"))
            {
                var json = new StreamReader("Components/Weapons.json").ReadToEnd();
                Weapons = JsonConvert.DeserializeObject<List<Weapon>>(json);
            }
        }

        #endregion
    }

    #region Component Classes

    public class Armour
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armor { get; set; }
        public float Mass { get; set; }
    }

    public class Booster
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
        public float Energy { get; set; }
        public float Recharge { get; set; }
        public float Consumption { get; set; }
        public float Acceleration { get; set; }
        public float Speed { get; set; }
    }

    public class Capacitor
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
        public float Energy { get; set; }
        public float RechargeRate { get; set; }
    }

    public class CargoBay
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Mass { get; set; }
    }

    public class CounterMeasure
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
    }

    public class DroidInterface
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
        public float Speed { get; set; }
    }

    public class Engine
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
        public float Pitch { get; set; }
        public float Yaw { get; set; }
        public float Roll { get; set; }
        public float Speed { get; set; }
    }

    public class Ordinance
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
        public float MinDam { get; set; }
        public float MaxDam { get; set; }
        public float VShield { get; set; }
        public float VArmour { get; set; }
        public float Ammo { get; set; }
    }

    public class Reactor
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Mass { get; set; }
        public float Generation { get; set; }
    }

    public class Shield
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
        public float FHP { get; set; }
        public float RHP { get; set; }
        public float RR { get; set; }
        public int Adjust { get; set; }
    }

    public class Weapon
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
        public float MinD { get; set; }
        public float MaxD { get; set; }
        public float VS { get; set; }
        public float VA { get; set; }
        public float EPS { get; set; }
        public float RR { get; set; }
    }

    public class Turret
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Armour { get; set; }
        public float Drain { get; set; }
        public float Mass { get; set; }
        public float MinD { get; set; }
        public float MaxD { get; set; }
        public float VS { get; set; }
        public float VA { get; set; }
        public float EPS { get; set; }
        public float RR { get; set; }
    }

    #endregion
}
