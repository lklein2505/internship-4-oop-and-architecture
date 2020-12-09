using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Hero
    {
        public Hero()
        {
            Console.WriteLine("Enter you character's name:");
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
            return $"{Name}\nXP: {Expirience}\nLevel: {Level}\nHP: {Health}/{MaxHealth}";
        }
    }

    
}
