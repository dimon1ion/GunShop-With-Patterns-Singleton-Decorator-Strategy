using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Weapon.Modification
{
    class Aim4x : BaseWeaponDecorator
    {
        public Aim4x(Gun gun) : base(gun, "Aim 4x", 200, gun.DefDamage, gun.DefDistance, gun.DefMaxAmmo, gun.Ammo, gun.Name, gun.ModMaxAmmo, 4, gun.ModDamage, gun.Price + 200)
        {

        }
    }
}
