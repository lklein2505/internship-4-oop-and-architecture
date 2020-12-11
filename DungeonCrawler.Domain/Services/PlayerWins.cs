using DungeonCrawler.Data.Models;
using DungeonCrawler.Domain.Helpers;
using System;

namespace DungeonCrawler.Domain.Services
{
    public class PlayerWins
    {
        public static void CalculateCosts(Hero choosenHero, Monster monster)
        {
            if (choosenHero is Warrior warrior)
            {
                var isChoosen = false;
                while (!isChoosen)
                {
                    Console.WriteLine("\n\tYOU WON THE ROUND\n" +
                    "1 - Regular attack\n" +
                    "2 - Rage attack (Deal double damage but lose 15% of your health)\n" +
                    "Choose the type of the attack:");
                    var attackChoice = int.Parse(Console.ReadLine());

                    if (attackChoice == 1)
                    {
                        monster.Health -= warrior.Damage;
                        isChoosen = true;
                    }
                    else if (attackChoice == 2)
                    {
                        monster.Health -= warrior.RageAttack;
                        warrior.Health -= (int)(0.15m * warrior.Health);
                        isChoosen = true;
                    }
                    else
                    {
                        Console.WriteLine("You have to choose between numbers '1' and '2'! Try again!\n");
                    }
                }
            }

            if (choosenHero is Mage mage)
            {
                if (mage.Mana < 30)
                {
                    mage.Mana = mage.MaxMana;
                    Console.WriteLine("\n\tYOU WON THE ROUND\n" +
                        "\tYour mana has been restored!");
                }
                else
                {
                    var isChoosen = false;
                    while (!isChoosen)
                    {
                        Console.WriteLine("\n\tYOU WON THE ROUND\n" +
                        "1 - Regular attack\n" +
                        "2 - Restore HP (Lose 40% of your mana)\n" +
                        "Choose an action: ");
                        var attackChoice = int.Parse(Console.ReadLine());

                        if (attackChoice == 1)
                        {
                            monster.Health -= mage.Damage;
                            mage.Mana -= 30;
                            isChoosen = true;
                        }
                        else if (attackChoice == 2)
                        {
                            mage.Health = mage.MaxHealth;
                            mage.Mana -= (int)(0.4m * mage.Mana);
                            isChoosen = true;
                        }
                        else
                        {
                            Console.WriteLine("You have to choose between numbers '1' and '2'! Try again!\n");
                        }
                    }                
                }
            }

            if (choosenHero is Ranger ranger)
            {
                Console.WriteLine("\n\tYOU WON THE ROUND\n");
                var isStuned = true;
                while (isStuned && monster.Health > 0)
                {
                    Random random = new Random();
                    var generatedNumber = random.Next(1, 101);

                    if (generatedNumber <= ranger.CriticalStrikeChance)
                    {
                        monster.Health -= ranger.CriticalStrike;
                        isStuned = false;
                        Console.WriteLine("\n\tYou dealt critical damage!\n");
                    }
                    if (generatedNumber > ranger.CriticalStrikeChance && generatedNumber <= ranger.StunChance)
                    {
                        monster.Health -= ranger.Damage;
                        PrintStats.PrintLiveStats(ranger, monster);
                        Console.WriteLine("\n\tYou stuned the monster!\n");
                    }
                    if (generatedNumber > ranger.StunChance)
                    {
                        monster.Health -= ranger.Damage;
                        isStuned = false;
                    }
                }
            }
        }
    }
}
