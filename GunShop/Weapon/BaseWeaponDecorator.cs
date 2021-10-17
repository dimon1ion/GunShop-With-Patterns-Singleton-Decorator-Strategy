using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Weapon
{
    public abstract class BaseWeaponDecorator : Gun
    {
        public Gun Gun { get; set; }
        public string ModName { get; set; }
        public int ModPrice { get; set; }
        public BaseWeaponDecorator(Gun gun, string modName, int modPrice, int damage, int distance, int maxAmmo, int ammo, string name, int modMaxAmmo, double modDistance, double modDamage, int price)
            : base(damage, distance, ammo, maxAmmo, name, modMaxAmmo, modDistance, modDamage, price)
        {
            ModName = modName;
            ModPrice = modPrice;
            Gun = gun;
        }
    }
}
