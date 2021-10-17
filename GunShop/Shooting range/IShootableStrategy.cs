using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Shooting_range
{
    interface IShootableStrategy
    {
        bool Fire(int distanceToTarget, out int damage);
    }
}
