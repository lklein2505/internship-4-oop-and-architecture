using DungeonCrawler.Data;
using DungeonCrawler.Data.Models;
using DungeonCrawler.Data.Services;
using DungeonCrawler.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Domain.Services
{
    public class GameFlow
    {
        public static void GameStart(Hero choosenHero)
        {
            Monster.RandomMonsterSpawn();
            var canRespawn = true;

            foreach (var monster in MonsterSpawnStore.SpawnMonsters)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tYour next opponent is {monster.Name.ToUpper()}\n");
                Console.ResetColor();
                while (monster.Health > 0 && choosenHero.Health > 0)
                {
                    Fight.PlayerAttack(choosenHero, monster);
                    PrintStats.PrintLiveStats(choosenHero, monster);
                    
                    while (choosenHero is Mage mage && canRespawn)
                    {
                        mage.Respawn();
                        canRespawn = false;
                    }               
                    
                    if (monster is Witch && monster.Health < 0)                    
                        Witch.WitchMonsterSpawn(monster);                      
                }

                if (choosenHero.Health <= 0)
                {
                    PlayerLost();
                    break;
                }                               
            }
            if (choosenHero.Health > 0)
                PlayerWon();
        }

        public static void PlayerWon()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tWELL DONE MY FRIEND, YOU HAVE BEATEN ALL MONSTERS AND THE TREASURE IS YOURS!");
            Console.ResetColor();
        }

        public static void PlayerLost()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tSORRY MY FRIEND, YOU LOST...BUT...THERE IS ALWAYS ANOTHER CHANCE!");
            Console.ResetColor();
        }        
    }        
}
