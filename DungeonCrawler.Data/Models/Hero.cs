using DungeonCrawler.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Hero : IFightConsequences
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
        public int Level { get; set; } = 1;

        public override string ToString()
        {
            return $"\t{Name}\n\tXP: {Expirience}\n\tLevel: {Level}\n\tHP: {Health}/{MaxHealth}";
        }
    }

    
}
