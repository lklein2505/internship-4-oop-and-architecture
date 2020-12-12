using System;

namespace DungeonCrawler.Data.Models
{
    public class Hero
    {
        public Hero()
        {
            Console.WriteLine("\nEnter you character's name:");
            Name = Console.ReadLine();
        }

        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Expirience { get; set; } = 0;
        public int MaxExpirience { get; set; } = 50;
        public int Level { get; set; } = 1;

        public override string ToString()
        {
            return $"\t{Name}\n\tXP: {Expirience}/{MaxExpirience}\n\t" +
                $"Level: {Level}\n\tHP: {Health}/{MaxHealth}\n\tDamage: {Damage}";
        }
    }

    
}
