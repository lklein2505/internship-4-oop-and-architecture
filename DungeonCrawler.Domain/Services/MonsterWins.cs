using DungeonCrawler.Data;
using DungeonCrawler.Data.Models;
using System;

namespace DungeonCrawler.Domain.Services
{
    public class MonsterWins
    {
        public static void CalculateCosts(Hero choosenHero, Monster monster)
        {
            Console.WriteLine("\n\tYOU LOST THE ROUND\n");

            if (monster is Goblin goblin)
                choosenHero.Health -= goblin.Damage;

            if (monster is Brute brute)
            {
                Random random = new Random();
                var generatedNumber = random.Next(1, 101);

                if (generatedNumber <= brute.MaxHealthAttack)
                {
                    choosenHero.Health -= (int)(0.15 * choosenHero.MaxHealth);
                    Console.WriteLine("\nOh no, he used his special ability!");
                }
                else
                    choosenHero.Health -= brute.Damage;
            }

            if (monster is Witch witch)
            {
                Random random = new Random();
                var generatedNumber = random.Next(1, 101);

                if (generatedNumber <= witch.ConfusionAttack)
                {
                    Console.WriteLine("\nOh no, the witch used her special ability - CONFUSION attack!" +
                        " Your health and health of monsters to come has been changed!\n");

                    foreach (var monsterToCome in MonsterSpawnStore.SpawnMonsters)
                    {
                        Random randMonster = new Random();
                        var newHealth = randMonster.Next(1, monsterToCome.MaxHealth);
                        monsterToCome.Health = newHealth;
                    }

                    Random randHero = new Random();
                    var newHeroHealth = randHero.Next(1, choosenHero.MaxHealth);
                    choosenHero.Health = newHeroHealth;
                }
                else
                    choosenHero.Health -= witch.Damage;
            }
        }
    }
}
