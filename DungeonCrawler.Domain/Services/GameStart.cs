using DungeonCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Domain.Services
{
    public class GameStart
    {
        public static void StartMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\tDUNGEON-CRAWLER GAME\n\n");

            Console.WriteLine("\tWELCOME hero! \n\n- You were sent on a special mission: " +
                "to find a treasure hidden in depths of this long and stinky dungeons full of creepy monsters!\n" +
                "- You will have to fight against (at least) 10 monsters hungry for your blood! " +
                "GOBLINS, BRUTES AND WITCHES are waiting for you just around the corner!\n" +
                "- You can choose one type of hero...WARRIOR, MAGE OR RANGER!\n");
            Console.ResetColor();

            var quitTheGame = false;
            while (!quitTheGame)
            {
                Console.WriteLine("\n\n" +
                    "1 - Start the game\n" +
                    "2 - Quit the game\n" +
                    "Pick an option my friend:");
                var startChoiceString = Console.ReadLine();
                int startChoice;
                while (!int.TryParse(startChoiceString, out startChoice))
                {
                    Console.WriteLine("\nYou have to choose between numbers '1' and '2'! Try again:");
                    startChoiceString = Console.ReadLine();
                }

                Hero choosenHero = null;
                if (startChoice == 1)
                {
                    var isChoosen = false;
                    while (!isChoosen)
                    {
                        choosenHero = ChampionSelect();
                        if (choosenHero != null)
                            isChoosen = true;
                        else
                            Console.WriteLine("\nYou have to choose between numbers '1', '2' and '3'! Try again:");
                    }
                    GameFlow.GameStart(choosenHero);

                    Console.WriteLine("\nYou played well! Would you like to play one more time?\n" +
                    "Enter '1' again if you do! Let's have a great time!");
                }
                else if (startChoice == 2)
                    quitTheGame = true;
                else
                    Console.WriteLine("\nYou have to choose between numbers '1' and '2'! Try again:");
            }
        }

        public static Hero ChampionSelect()
        {
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n" +
                    "1 - Warrior (Deals less damage but has more HP --- Special abilities: Rage attack)\n" +
                    "2 - Mage (Deals more damage but has less HP --- Special abilities: One extra life, healing with mana)\n" +
                    "3 - Ranger (Deals medium damage and has medium HP --- Special abilities: Critical Strike, stun)\n" +
                    "Pick a type of your champion:");
                Console.ResetColor();

                var championPickString = Console.ReadLine();
                int championPick;

                while (!int.TryParse(championPickString, out championPick))
                {
                    Console.WriteLine("\nYou have to choose between numbers '1', '2' and '3'! Try again:");
                    championPickString = Console.ReadLine();
                }

                switch (championPick)
                {
                    case 1:
                        return new Warrior();
                    case 2:
                        return new Mage();
                    case 3:
                        return new Ranger();
                    default:
                        return null;
                }
            }
        }
    }
}
