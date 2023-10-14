using Pract4C;
using System;
using System.Data;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test
{
    static public partial class ZXC
    {
        static public DateTime dateTime = DateTime.Now;
        static public List<Note> MenuQ = new List<Note>()
        {
            new Note{ Name = "  1. Пойти поспать", Description = "Примерно часов 10", date = ZXC.dateTime},
            new Note{ Name = "  2. Пойти поесть", Description = "Максимально сытно и вкусно", date = ZXC.dateTime},
            new Note{ Name = "  3. Пойти погулять", Description = "До часу ночи желательно", date = ZXC.dateTime},
            new Note{ Name = "  1. Пойти поспать", Description = "Часов 5 или чаасов 15", date = ZXC.dateTime.AddDays(1)},
            new Note{ Name = "  1. Выгулять собаку", Description = "На улицу, недолго", date = ZXC.dateTime.AddDays(-1)}
        };
    }

    class qwe
    {
        static void Main()
        {
            menu(ZXC.dateTime);
        }
        static void menu(DateTime date)
        {
            ConsoleKeyInfo UserButton;
            var position = 1;
            Console.WriteLine(date);
            MenuText(date);
            while (true)
            {
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                UserButton = Console.ReadKey(true);
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                if (UserButton.Key == ConsoleKey.Enter)
                {
                    Opis(date, position);
                }
                else if (UserButton.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (UserButton.Key == ConsoleKey.UpArrow && position != 1)
                {
                    position--;
                }
                else if (UserButton.Key == ConsoleKey.DownArrow && position != 4)
                {
                    position++;
                }
                else if (UserButton.Key == ConsoleKey.LeftArrow | UserButton.Key == ConsoleKey.RightArrow)
                {
                    Console.Clear();
                    ChangeDate(UserButton, date);
                }
            }

        }
        static void Opis(DateTime date, int position)
        {
            ConsoleKeyInfo UserButton;
            Console.Clear();
            try
            {
                Console.WriteLine(ZXC.MenuQ.Where(x => x.date.Date == date.Date).ToArray()[position - 1].date);
                Console.Clear();    
                Console.WriteLine("Дата заметки: ");
                Console.WriteLine(ZXC.MenuQ.Where(x => x.date.Date == date.Date).ToArray()[position - 1].date);
                Console.WriteLine("   ");
                Console.WriteLine("Название заметки: ");
                Console.WriteLine(ZXC.MenuQ.Where(x => x.date.Date == date.Date).ToArray()[position - 1].Name);
                Console.WriteLine("   ");
                Console.WriteLine("Описание заметки: ");
                Console.WriteLine(ZXC.MenuQ.Where(x => x.date.Date == date.Date).ToArray()[position - 1].Description);
            }
            catch 
            {
                AddZam(date);
            }
            do
            {
                UserButton = Console.ReadKey();
            } while (UserButton.Key != ConsoleKey.Enter);
            Console.Clear();
            menu(date);
        }
        static void ChangeDate(ConsoleKeyInfo a, DateTime b)
        {
            if (a.Key == ConsoleKey.LeftArrow)
            {
                b = b.AddDays(-1);
                menu(b);
            }
            else if (a.Key == ConsoleKey.RightArrow)
            {
                b = b.AddDays(1);
                menu(b);
            }
        }
        static void AddZam(DateTime x)
        {
            Console.WriteLine("Введите название заметки");
            string NameZ;
            NameZ = "  " + Console.ReadLine();
            Console.WriteLine("Введите описание заметки");
            string OpisZ;
            OpisZ = "  " + Console.ReadLine();
            Note X;
            X = new Note { Name = NameZ, Description = OpisZ, date = x };
            ZXC.MenuQ.Add(X);
            Console.Clear();
            menu(x);
        }
        static void MenuText(DateTime a)
        {
            var toThisDay = ZXC.MenuQ.Where(x => x.date.Date == a.Date).ToArray();
            foreach (var item in toThisDay)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
