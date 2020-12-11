using System;

namespace DungeonCrawler.Domain.Helpers
{
    public class EndPrint
    {
        public static void PlayerWonPrint()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tWELL DONE MY FRIEND, YOU HAVE BEATEN ALL MONSTERS AND THE TREASURE IS YOURS!");
            Console.ResetColor();
        }

        public static void PlayerLostPrint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tSORRY MY FRIEND, YOU LOST...BUT...THERE IS ALWAYS ANOTHER CHANCE!");
            Console.ResetColor();
        }
    }
}
