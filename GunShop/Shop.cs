using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GunShop.Weapon;
using GunShop.Weapon.Modification;

namespace GunShop
{
    public class Shop
    {
        public List<Gun> Weapons { get; set; }
        public List<BaseWeaponDecorator> Modifications { get; set; }
        private int _priceOneBullet;
        public Shop()
        {
            _priceOneBullet = 1;
        }
        public void JoinToShop()
        {
            while (true)
            {
                Console.Clear();
                User.GetInstance().PrintBalance();
                Console.WriteLine("Choose action:");
                Console.WriteLine("1. Buy weapon");
                Console.WriteLine("2. Modify weapon");
                Console.WriteLine("3. Buy ammo for weapon");
                Console.WriteLine("Backspace. Back");
                ConsoleKeyInfo cKeyInfo = Console.ReadKey();
                switch (cKeyInfo.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        BuyWeapon();
                        continue;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        ChooseModification();
                        continue;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Clear();
                        BuyAmmo();
                        continue;

                    case ConsoleKey.Backspace:
                        Console.Clear();
                        return;

                    default:
                        continue;
                }

            }
        }
        public void BuyWeapon()
        {
            Weapons = new List<Gun>() { new AK47(43, 50, 0, 30, "AK-47", 0, 1, 1, 400), new M4A4(30, 70, 0, 30, "M4A4", 0, 1, 1, 300) };
            int numOfWeapon;
            int choice;
            while (true)
            {
                numOfWeapon = 0;
                User.GetInstance().PrintBalance();
                Console.WriteLine("Choose a weapon:");
                for (; numOfWeapon < Weapons.Count; numOfWeapon++)
                {
                    Console.WriteLine($"{numOfWeapon + 1}. {Weapons[numOfWeapon].ToString()}");
                }
                Console.WriteLine($"{numOfWeapon + 1}. Exit");
                Console.Write("Enter num => ");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    choice--;
                }
                catch (Exception)
                {
                    Console.Clear();
                    continue;
                }
                if (0 <= choice && choice < numOfWeapon)
                {
                    User.GetInstance().Weapons.Add(Weapons[choice]);
                    User.GetInstance().Money -= Weapons[choice].Price;
                }
                else if (choice != numOfWeapon)
                {
                    continue;
                }
                break;
            }
            Console.Clear();
        }

        public void ChooseModification()
        {
            int choiceModification;
            int numOfModification;
            int choiceWeapon;
            if ((choiceWeapon = User.GetInstance().ChoiceWeapon()) == -1)
            {
                return;
            }
            
            Modifications = new List<BaseWeaponDecorator>() { new Aim2x(User.GetInstance().Weapons[choiceWeapon]), new Aim4x(User.GetInstance().Weapons[choiceWeapon]), new BulletStore45(User.GetInstance().Weapons[choiceWeapon]),
                new BulletStore60(User.GetInstance().Weapons[choiceWeapon]), new P1_5x(User.GetInstance().Weapons[choiceWeapon])};
            
            while (true)
            {
                numOfModification = 0;
                User.GetInstance().PrintBalance();
                Console.WriteLine($"Choose modification for {User.GetInstance().Weapons[choiceWeapon].ToString()}");
                for (; numOfModification < Modifications.Count; numOfModification++)
                {
                    Console.WriteLine($"{numOfModification + 1}. Name:{Modifications[numOfModification].ModName} Price:{Modifications[numOfModification].ModPrice}");
                }
                Console.WriteLine($"{numOfModification + 1}. Back");
                Console.Write("Enter num => ");
                try
                {
                    choiceModification = Int32.Parse(Console.ReadLine());
                    choiceModification--;
                }
                catch (Exception)
                {
                    Console.Clear();
                    continue;
                }

                if (choiceModification < 0 || numOfModification < choiceModification)
                {
                    Console.Clear();
                    continue;
                }
                else if (choiceModification == numOfModification)
                {
                    Console.Clear();
                    return;
                }
                User.GetInstance().Weapons[choiceWeapon] = Modifications[choiceModification];
                User.GetInstance().Money -= Modifications[choiceWeapon].ModPrice;
                break;
            }
        }

        public void BuyAmmo()
        {
            int choiceWeapon;
            if ((choiceWeapon = User.GetInstance().ChoiceWeapon()) == -1)
            {
                return;
            }
            if (User.GetInstance().Weapons[choiceWeapon].Ammo == User.GetInstance().Weapons[choiceWeapon].MaxAmmo)
            {
                Console.WriteLine("This weapon doesn't need ammunition!");
                Thread.Sleep(1000);
                return;
            }
            while (true)
            {
                Console.Clear();
                int priceAmmo = _priceOneBullet * (User.GetInstance().Weapons[choiceWeapon].MaxAmmo - User.GetInstance().Weapons[choiceWeapon].Ammo);
                Console.WriteLine(User.GetInstance().Weapons[choiceWeapon].ToString());
                Console.WriteLine($"Ammunition costs {priceAmmo}" +
                    $"\n1. Buy ammo" +
                    $"\nBackspace. Back");
                ConsoleKeyInfo cKeyInfo = Console.ReadKey();
                switch (cKeyInfo.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        User.GetInstance().Weapons[choiceWeapon].Ammo = User.GetInstance().Weapons[choiceWeapon].MaxAmmo;
                        User.GetInstance().Money -= priceAmmo;
                        break;
                    case ConsoleKey.Backspace:
                        return;
                    default:
                        continue;
                }
                break;
            }
            
        }

    }
}
