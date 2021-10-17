using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Weapon.Modification
{
    class BulletStore45 : BaseWeaponDecorator
    {
        public BulletStore45(Gun gun) : base(gun, "Bullet Store 45 Ammo", 100, gun.DefDamage, gun.DefDistance, gun.DefMaxAmmo, gun.Ammo, gun.Name, 45, gun.ModDistance, gun.ModDamage, gun.Price + 100)
        {

        }
    }
}
