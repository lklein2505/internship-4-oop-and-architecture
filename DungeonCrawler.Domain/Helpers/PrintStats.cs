using DungeonCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DungeonCrawler.Domain.Helpers
{
    public class PrintStats
    {
        public static void PrintLiveStats (Hero player, Monster monster)
        {
            if (player is Warrior)
                Console.ForegroundColor = ConsoleColor.Green;

            if (player is Mage)
                Console.ForegroundColor = ConsoleColor.Cyan;

            if (player is Ranger)
                Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(player + "\n");

            if (monster is Goblin)
                Console.ForegroundColor = ConsoleColor.DarkRed;

            if (monster is Brute)
                Console.ForegroundColor = ConsoleColor.Red;

            if (monster is Witch)
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

            
            Console.WriteLine(monster);
            Console.ResetColor();

        }        
    }
}
