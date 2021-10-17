using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GunShop.Shooting_range
{
    class ShootingRange
    {
        private int[] _distances;
        private int _selectedDistance { get; set; }
        public IShootableStrategy Gun { get; set; }
        public Statistics Statistics { get; set; }
        public int Distance
        {
            get
            {
                return _distances[_selectedDistance];
            }
        }
        public ShootingRange(params int[] distances)
        {
            this._distances = distances;
            this._selectedDistance = 0;
        }
        public void JoinShootingRange()
        {
            int choiceWeapon;
            if ((choiceWeapon = User.GetInstance().ChoiceWeapon()) == -1)
            {
                return;
            }
            Statistics = new Statistics(User.GetInstance().Weapons[choiceWeapon].Name);
            Gun = User.GetInstance().Weapons[choiceWeapon];
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Statistics.ToString());
                Console.WriteLine($"\n1. Distance target: {Distance}" +
                    $"\n2. Fire" +
                    $"\nBackspace. Exit");
                ConsoleKeyInfo cKeyInfo = Console.ReadKey();
                if (Console.CursorLeft > 0)
                {
                    Console.CursorLeft--;
                    Console.Write(" ");
                }
                switch (cKeyInfo.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        if (_selectedDistance + 1 == _distances.Length)
                        {
                            _selectedDistance = 0;
                        }
                        else
                        {
                            _selectedDistance++;
                        }
                        continue;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        if (!Gun.Fire(Distance, out Statistics.Damage))
                        {
                            Console.WriteLine("Weapon can't fire!");
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            if (Statistics.Damage > 0)
                            {
                                Statistics.Hits++;
                            }
                            Statistics.MaxShots++;
                        }
                        continue;
                    case ConsoleKey.Backspace:
                        return;
                }
            }
        }
    }
}
