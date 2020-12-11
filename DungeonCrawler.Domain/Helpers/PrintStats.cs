using DungeonCrawler.Data.Models;
using System;

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
            
            if (player.Health > 0)
                Console.WriteLine(player + "\n");
            else
                Console.WriteLine($"\t{player.Name.ToUpper()} is DEAD!");

            if (monster is Goblin)
                Console.ForegroundColor = ConsoleColor.DarkRed;

            if (monster is Brute)
                Console.ForegroundColor = ConsoleColor.Red;

            if (monster is Witch)
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

            if (monster.Health <= 0)
                Console.WriteLine($"\t{monster.Name.ToUpper()} is DEAD! Good job!");
            else    
                Console.WriteLine(monster);
            
            Console.ResetColor();

        }        
    }
}
