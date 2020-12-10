using System;
using DungeonCrawler.Data;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Witch : Monster
    {
        public int ConfusionAttack { get; set; }
        public Witch()
        {
            Name = "Witch";
            MaxHealth = 150;
            Health = MaxHealth;
            Damage = 20;
            Expirience = 80;
            ConfusionAttack = 15;
        }

        public static void WitchMonsterSpawn(Monster monster)
        {
            Console.WriteLine("\nYou did it, she is dead! But...she spawned another two monsters: ");
            for (var i = 0; i < 2; i++)
            {
                Random random = new Random();
                var generatedNumber = random.Next(1, 91);
                if (generatedNumber < 60)
                {
                    MonsterSpawnStore.SpawnMonsters.Insert(MonsterSpawnStore.SpawnMonsters.IndexOf(monster) + 1, new Goblin());
                    Console.WriteLine("Goblin\n");
                }   
                
                if (generatedNumber > 60 && generatedNumber < 90)
                {
                    MonsterSpawnStore.SpawnMonsters.Insert(MonsterSpawnStore.SpawnMonsters.IndexOf(monster) + 1, new Brute());                    
                    Console.WriteLine("Brute\n");
                }              

                if (generatedNumber > 90)
                {
                    MonsterSpawnStore.SpawnMonsters.Insert(MonsterSpawnStore.SpawnMonsters.IndexOf(monster) + 1, new Witch());                    
                    Console.WriteLine("Another witch!\n");
                }
            }            
        }
    }
}
