using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Shooting_range
{
    public class Statistics
    {
        public string Name { get; set; }
        public int Hits { get; set; }
        public int MaxShots { get; set; }

        public int Damage;
        public Statistics(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"---Statistics---" +
                $"\n Weapon Name: {Name}" +
                $"\n Hits: {Hits}/{MaxShots}" +
                $"\n Damage: {Damage}" +
                $"\n----------------";
        }
    }
}
