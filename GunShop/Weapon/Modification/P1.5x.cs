using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Weapon.Modification
{
    class P1_5x : BaseWeaponDecorator
    {
        public P1_5x(Gun gun) : base(gun, "P1.5x", 100, gun.DefDamage, gun.DefDistance, gun.DefMaxAmmo, gun.Ammo, gun.Name, gun.ModMaxAmmo, gun.ModDistance, 1.5, gun.Price + 100)
        {
        }
    }
}
