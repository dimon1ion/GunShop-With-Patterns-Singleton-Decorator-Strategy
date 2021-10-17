using GunShop.Shooting_range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop
{
    public abstract class Gun : IShootableStrategy
    {
        protected Gun(int damage, int distance, int ammo, int maxAmmo, string name, int modMaxAmmo, double modDistance, double modDamage, int price)
        {
            DefDamage = damage;
            DefDistance = distance;
            DefMaxAmmo = maxAmmo;
            Ammo = ammo;
            Name = name;
            ModMaxAmmo = modMaxAmmo;
            ModDistance = modDistance;
            ModDamage = modDamage;
            Price = price;
        }
        #region Default

        public int DefDamage { get; set; }
        public int DefDistance { get; set; }
        public int DefMaxAmmo { get; set; }
        public int Ammo { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        #endregion
        public int Damage
        {
            get
            {
                return Convert.ToInt32(DefDamage * ModDamage);
            }
        }
        public double Distance
        {
            get
            {
                return DefDistance * ModDistance;
            }
        }
        public int MaxAmmo
        {
            get
            {
                if (ModMaxAmmo != 0)
                {
                    return ModMaxAmmo;
                }
                return DefMaxAmmo;
            }
        }
        #region Modification

        #endregion
        public int ModMaxAmmo { get; set; }
        public double ModDistance { get; set; }
        public double ModDamage { get; set; }

        public bool Fire(int distanceToTarget, out int damage)
        {
            damage = 0;
            if (Ammo > 0)
            {
                Ammo--;
                Random rnd = new Random();
                int procent = rnd.Next(0, 100);
                int maxprocent = Convert.ToInt32(Distance * 100 / distanceToTarget);
                if (procent <= maxprocent)
                {
                    damage = Damage;
                }
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Name:{Name}, Damage:{Damage}, Distance:{Distance}, Ammo:{Ammo}, Bullet Store:{MaxAmmo}, Price:{Price}";
        }
    }

}
