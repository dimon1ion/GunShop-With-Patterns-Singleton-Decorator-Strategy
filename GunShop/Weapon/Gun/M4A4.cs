using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop
{
    class M4A4 : Gun
    {
        public M4A4(int damage, int distance, int ammo, int maxAmmo, string name, int modMaxAmmo, double modDistance, double modDamage, int price)
            : base(damage, distance, ammo, maxAmmo, name, modMaxAmmo, modDistance, modDamage, price)
        {

        }
    }
}
