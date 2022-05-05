using System.Windows;
using Ship_Loadout.Components;

namespace Ship_Loadout.ShipEditor
{
    public class Ship
    {
        public string ID { get; set; }
        public int Faction { get; set; }

        public string Name { get; set; }
        public string GivenName { get; set; }

        public float CurrentMass { get; set; }
        public float Mass { get; set; }
        public float RemainingMass { get; set; }

        public float CurrentEnergyDrain { get; set; }
        public float RemainingDrain { get; set; }

        public int ReactorOverride { get; set; }
        public float OverridenGeneration { get; set; }
        public int EngineOverride { get; set; }
        public int CapacitorOverride { get; set; }
        public int WeaponOverride { get; set; }

        public float Acceleration { get; set; }
        public float Deceleration { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public float Roll { get; set; }
        public float SpeedTop { get; set; }
        public float SpeedLow { get; set; }

        public Reactor Reactor { get; set; }
        public Engine Engine { get; set; }
        public Booster Booster { get; set; }
        public Shield Shield { get; set; }
        public Armour FrontArmour { get; set; }
        public Armour RearArmour { get; set; }
        public DroidInterface DroidInterface { get; set; }
        public Capacitor Capacitor { get; set; }

        public int Weapons { get; set; }
        public Weapon Weapon1 { get; set; }
        public Weapon Weapon2 { get; set; }
        public Weapon Weapon3 { get; set; }
        public Weapon Weapon4 { get; set; }
        public Weapon Weapon5 { get; set; }
        public Weapon Weapon6 { get; set; }

        public int Turrets { get; set; }
        public Weapon Turret1 { get; set; }
        public Weapon Turret2 { get; set; }
        public Weapon Turret3 { get; set; }
        public Weapon Turret4 { get; set; }
        public Weapon Turret5 { get; set; }
        public Weapon Turret6 { get; set; }

        public int Ordinance { get; set; }
        public Ordinance Ord1 { get; set; }
        public Ordinance Ord2 { get; set; }
        public Ordinance Ord3 { get; set; }

        public int Countermeasures { get; set; }
        public CounterMeasure CM1 { get; set; }
        public CounterMeasure CM2 { get; set; }
    }
}
