using Ship_Loadout.Components;

namespace Ship_Loadout.ShipLoadout
{
    public class Ship
    {
        public string ID { get; set; }
        public int Faction { get; set; }

        public string Name { get; set; }
        public int Mass { get; set; }

        public int Weapons { get; set; }
        public Weapon Weapon1 { get; set; }
        public Weapon Weapon2 { get; set; }
        public Weapon Weapon3 { get; set; }
        public Weapon Weapon4 { get; set; }

        public int Turrets { get; set; }
        public Turret Turret1 { get; set; }
        public Turret Turret2 { get; set; }
        public Turret Turret3 { get; set; }
        public Turret Turret4 { get; set; }
        public Turret Turret5 { get; set; }
        public Turret Turret6 { get; set; }

        public int Ordinance { get; set; }
        public Ordinance Ord1 { get; set; }
        public Ordinance Ord2 { get; set; }
        public Ordinance Ord3 { get; set; }

    public int Countermeasures { get; set; }
        public CounterMeasure CM1 { get; set; }
        public CounterMeasure CM2 { get; set; }

        public int Acceleration { get; set; }
        public int Deceleration { get; set; }
        public int Yaw { get; set; }
        public int Pitch { get; set; }
        public float Roll { get; set; }
        public float SpeedTop { get; set; }
        public float SpeedLow { get; set; }
    }
}
