using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GunShop
{
    public class User
    {
        public int Money { get; set; }
        public List<Gun> Weapons { get; set; }
        private static User instance;
        public User()
        {
            Money = 1000;
            Weapons = new List<Gun>();
        }
        public static User GetInstance()
        {
            if (instance == null)
            {
                instance = new User();
            }
            return instance;
        }
        public void PrintBalance()
        {
            Console.WriteLine($"\t\tYour balance is {Money}!");
        }
        public void ShowInventory()
        {
            if (Weapons.Count > 0)
            {
                while (true)
                {
                    Console.Clear();
                    PrintBalance();
                    for (int i = 0; i < Weapons.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {Weapons[i].ToString()}");
                    }
                    Console.WriteLine("Backspace. Exit");
                    ConsoleKeyInfo cKeyInfo = Console.ReadKey();
                    if (cKeyInfo.Key == ConsoleKey.Backspace)
                    {
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("You don't have any weapon");
                Thread.Sleep(1000);
            }
        }
        public int ChoiceWeapon()
        {
            int numOfUserWeapon;
            int choiceWeapon;

            if (Weapons.Count <= 0)
            {
                Console.WriteLine("You don't have weapon");
                Thread.Sleep(1000);
                return -1;
            }
            else if (Weapons.Count > 1)
            {
                while (true)
                {
                    numOfUserWeapon = 0;
                    Console.WriteLine("Choose a weapon from your inventory:");
                    for (; numOfUserWeapon < Weapons.Count; numOfUserWeapon++)
                    {
                        Console.WriteLine($"{numOfUserWeapon + 1}. {Weapons[numOfUserWeapon].ToString()}");
                    }
                    Console.WriteLine($"{numOfUserWeapon + 1}. Exit");
                    Console.Write("Enter num => ");
                    try
                    {
                        choiceWeapon = Int32.Parse(Console.ReadLine());
                        choiceWeapon--;
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        continue;
                    }
                    if (choiceWeapon < 0 || numOfUserWeapon < choiceWeapon)
                    {
                        Console.Clear();
                        continue;
                    }
                    else if (choiceWeapon == numOfUserWeapon)
                    {
                        Console.Clear();
                        return -1;
                    }
                    Console.Clear();
                    break;
                }
            }
            else
            {
                choiceWeapon = 0;
            }
            return choiceWeapon;
        }
    }
}
