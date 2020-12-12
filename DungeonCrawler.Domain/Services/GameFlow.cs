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

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nYou can choose between 3 different types of attack on enemy.\n" +
                "Your enemy also chooses one.\n\n" +
                "The rule is:\n" +
                "Direct attack wins against side attack\n" +
                "Side attack wins against counter attack\n" +
                "Counter attack wins against direct attack\n\n");
            Console.ResetColor();

            for (var i = 0; i < MonsterSpawnStore.SpawnMonsters.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tYour next opponent is {MonsterSpawnStore.SpawnMonsters[i].Name.ToUpper()}\n");
                Console.ResetColor();

                if (!skipQuestion)
                {
                    Console.WriteLine("\nDo you want to regenerate your HP using half of your XP?" +
                        $"\n1 - No, I want to move on with {choosenHero.Health} HP and {choosenHero.Expirience} XP!" +
                        "\n2 - Yes, regenerate my HP!");

                    while (!isChoosen)
                    {
                        var regenerateHealthChoiceString = Console.ReadLine();
                        int regenerateHealthChoice;
                        while (!int.TryParse(regenerateHealthChoiceString, out regenerateHealthChoice))
                        {
                            Console.WriteLine("\nYou have to choose between numbers '1' and '2'! Try again!" +
                                "\nEnter a number (1 or 2): ");
                            regenerateHealthChoiceString = Console.ReadLine();
                        }
                        
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

                while (MonsterSpawnStore.SpawnMonsters[i].Health > 0 && choosenHero.Health > 0)
                {
                    Fight.PlayerAttack(choosenHero, MonsterSpawnStore.SpawnMonsters[i]);
                    PrintStats.PrintLiveStats(choosenHero, MonsterSpawnStore.SpawnMonsters[i]);
                    
                    if (choosenHero is Mage mage && canRespawn && choosenHero.Health <= 0)
                    {
                        mage.Respawn();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n\tYOU RESPAWNED!\n");
                        Console.ResetColor();
                        canRespawn = false;
                    }               
                    
                    if (MonsterSpawnStore.SpawnMonsters[i] is Witch && MonsterSpawnStore.SpawnMonsters[i].Health < 0)                    
                        Witch.WitchMonsterSpawn(MonsterSpawnStore.SpawnMonsters[i]);     
                    
                    if (MonsterSpawnStore.SpawnMonsters[i].Health <= 0)
                    {
                        LevelAndExpirience.XpCalculator(MonsterSpawnStore.SpawnMonsters[i], choosenHero);
                        choosenHero.Health += (int)(0.25m * choosenHero.MaxHealth);
                        if (choosenHero.Health > choosenHero.MaxHealth)
                            choosenHero.Health = choosenHero.MaxHealth;
                    }
                }

                if (choosenHero.Health <= 0)
                {
                    EndPrint.PlayerLostPrint();
                    MonsterSpawnStore.SpawnMonsters.Clear();
                    break;
                }                               
            }
            if (choosenHero.Health > 0)
                EndPrint.PlayerWonPrint();
            MonsterSpawnStore.SpawnMonsters.Clear();
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
