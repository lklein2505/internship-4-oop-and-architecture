using DungeonCrawler.Data;
using DungeonCrawler.Data.Models;
using DungeonCrawler.Domain.Helpers;
using System;

namespace DungeonCrawler.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMenu();            
        }

        static void StartMenu()
        {
            Console.WriteLine("\t\n WELCOME TO A DUNGEON-CRAWLER GAME\n\n"); 
            var quitTheGame = false;
            while (!quitTheGame)
            {                
                Console.WriteLine("\n" +                    
                    "1 - Start the game\n" +
                    "2 - Quit the game\n" +
                    "Pick an option my friend:");
                var startChoice = int.Parse(Console.ReadLine());
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
                            Console.WriteLine("You have to choose between numbers '1', '2' and '3'! Try again!\n");    
                    }                        
                    Monster.RandomMonsterSpawn();
                    PrintStats.PrintLiveStats(choosenHero, MonsterSpawnStore.SpawnMonsters[0]);
                    Fight.PlayerAttack();                    
                    break;
                }
                else if (startChoice == 2)
                    quitTheGame = true;
                else                
                    Console.WriteLine("You have to choose between numbers '1' and '2'! Try again!\n");                                                 
            }
        }

        static Hero ChampionSelect()
        {
            Console.WriteLine("\n" +
                "1 - Warrior (Deals less damage but has more HP)\n" +
                "2 - Mage (Deals more damage but has less HP)\n" +
                "3 - Ranger (Deals medium damage and has medium HP)\n" +
                "Pick a type of your champion:");
            var championPick = int.Parse(Console.ReadLine());

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
