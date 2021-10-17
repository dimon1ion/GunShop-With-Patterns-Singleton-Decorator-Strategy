using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Weapon.Modification
{
    class BulletStore60 : BaseWeaponDecorator
    {
        public BulletStore60(Gun gun) : base(gun, "Bullet Store 60 Ammo", 200, gun.DefDamage, gun.DefDistance, gun.DefMaxAmmo, gun.Ammo, gun.Name, 60, gun.ModDistance, gun.ModDamage, gun.Price + 200)
        {

        }
    }
}
