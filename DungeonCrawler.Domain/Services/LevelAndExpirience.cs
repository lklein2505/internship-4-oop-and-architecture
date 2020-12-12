using DungeonCrawler.Data.Models;
using System;

namespace DungeonCrawler.Domain.Services
{
    public class LevelAndExpirience
    {
        public static void XpCalculator(Monster monster, Hero choosenHero)
        {
            choosenHero.Expirience += monster.Expirience;
            if (choosenHero.Expirience >= choosenHero.MaxExpirience)
            {
                choosenHero.Expirience -= choosenHero.MaxExpirience;
                choosenHero.Level += 1;
                choosenHero.MaxHealth += 15;
                choosenHero.Damage += 5;
                choosenHero.MaxExpirience += 25;

                if (choosenHero is Mage mage)
                    mage.MaxMana += 15;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tYOU LEVELED UP!\n");
                Console.ResetColor();
            }
        }
    }
}
