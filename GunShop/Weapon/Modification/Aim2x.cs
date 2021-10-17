using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Weapon.Modification
{
    class Aim2x : BaseWeaponDecorator
    {
        public Aim2x(Gun gun) : base(gun, "Aim 2x", 100, gun.DefDamage, gun.DefDistance, gun.DefMaxAmmo, gun.Ammo, gun.Name, gun.ModMaxAmmo, 2, gun.ModDamage, gun.Price + 100)
        {

        }
    }
}
