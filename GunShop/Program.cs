using GunShop.Shooting_range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GunShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorVisible = false;
            Shop shop = new Shop();
            ShootingRange shootingRange = new ShootingRange(50, 100, 300, 500);

            Console.WriteLine("Welcome to the Gun Shop!");
            Thread.Sleep(1000);
            while (true)
            {
                Console.Clear();
                User.GetInstance().PrintBalance();
                Console.WriteLine("Choose action:");
                Console.WriteLine("1. Go to the counter with weapons");
                Console.WriteLine("2. Go to the shooting range");
                Console.WriteLine("3. Show inventory");
                Console.WriteLine("Backspace. Exit");
                ConsoleKeyInfo cKeyInfo = Console.ReadKey();
                switch (cKeyInfo.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        shop.JoinToShop();
                        continue;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        shootingRange.JoinShootingRange();
                        continue;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Clear();
                        User.GetInstance().ShowInventory();
                        continue;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        break;
                    default:
                        continue;
                }
                break;
            }
            Console.WriteLine("GoodBye!");

        }
    }
}
