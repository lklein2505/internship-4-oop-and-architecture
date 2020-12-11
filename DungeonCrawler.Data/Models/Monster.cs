using System;

namespace DungeonCrawler.Data.Models
{
    public class Monster
    {
        public Monster()
        {
            MonsterSpawnStore.SpawnMonsters.Add(this);
        }
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Expirience { get; set; }

        public override string ToString()
        {
            return $"\t{Name}\n\tXP worth: {Expirience}\n\tHP: {Health}/{MaxHealth}\n\tDamage: {Damage}\n";
        }

        public static void RandomMonsterSpawn()
        {           
            for (var i = 0; i < 10; i++)
            {
                Random random = new Random();
                var generatedNumber = random.Next(1, 101);
                if (generatedNumber < 60)
                    new Goblin();
                if (generatedNumber > 60 && generatedNumber < 90)
                    new Brute();
                if (generatedNumber > 90)
                    new Witch();
            }            
        }
    }
}
