using DungeonCrawler.Data;
using DungeonCrawler.Data.Models;
using DungeonCrawler.Data.Services;
using DungeonCrawler.Domain.Helpers;
using System;

namespace DungeonCrawler.Domain.Services
{
    public class GameFlow
    {
        public static void GameStart(Hero choosenHero)
        {
            Monster.RandomMonsterSpawn();
            var canRespawn = true;
            var skipQuestion = true;
            var isChoosen = false;

            foreach (var monster in MonsterSpawnStore.SpawnMonsters)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tYour next opponent is {monster.Name.ToUpper()}\n");
                Console.ResetColor();

                if (!skipQuestion)
                {
                    Console.WriteLine("\nDo you want to regenerate your HP using half of your XP?" +
                        $"\n1 - No, I want to move on with {choosenHero.Health} HP and {choosenHero.Expirience} XP!" +
                        "\n2 - Yes, regenerate my HP!");

                    while (!isChoosen)
                    {
                        var regenerateHealthChoice = int.Parse(Console.ReadLine());
                        if (regenerateHealthChoice == 1 || regenerateHealthChoice == 2)
                        {
                            HealthRegenerationChoice(regenerateHealthChoice, choosenHero);
                            isChoosen = true;
                        }                           
                        else                        
                            Console.WriteLine("\nYou have to choose between numbers '1' and '2'! Try again!" +
                                "\nEnter a number (1 or 2): ");                        
                    }
                    isChoosen = false;
                }                                      
                skipQuestion = false;                             

                while (monster.Health > 0 && choosenHero.Health > 0)
                {
                    Fight.PlayerAttack(choosenHero, monster);
                    PrintStats.PrintLiveStats(choosenHero, monster);
                    
                    while (choosenHero is Mage mage && canRespawn)
                    {
                        mage.Respawn();
                        Console.WriteLine("\n\tYOU RESPAWNED!\n");
                        canRespawn = false;
                    }               
                    
                    if (monster is Witch && monster.Health < 0)                    
                        Witch.WitchMonsterSpawn(monster);     
                    
                    if (monster.Health <= 0)
                    {
                        LevelAndExpirience.XpCalculator(monster, choosenHero);
                        choosenHero.Health += (int)(0.25m * choosenHero.MaxHealth);
                        if (choosenHero.Health > choosenHero.MaxHealth)
                            choosenHero.Health = choosenHero.MaxHealth;
                    }
                }

                if (choosenHero.Health <= 0)
                {
                    EndPrint.PlayerLostPrint();
                    break;
                }                               
            }
            if (choosenHero.Health > 0)
                EndPrint.PlayerWonPrint();
        }        

        public static void HealthRegenerationChoice(int regenerateHealthChoice, Hero choosenHero)
        {
            var isChoosen = false;
            while (!isChoosen)
            {
                if (regenerateHealthChoice == 1)
                    isChoosen = true;
                else if (regenerateHealthChoice == 2)
                {
                    choosenHero.Expirience /= 2;
                    choosenHero.Health = choosenHero.MaxHealth;
                    isChoosen = true;
                }                
            }            
        }
    }        
}
