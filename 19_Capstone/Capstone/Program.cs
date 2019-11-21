using Capstone.Models;
using Capstone.Views;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            LogTxt.LogPath = @"..\..\..\..\log.txt";
            Machine machine = new Machine();
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            MainMenu mm = new MainMenu(machine);
            mm.Run();

            Console.ReadKey();
        }
    }
}
