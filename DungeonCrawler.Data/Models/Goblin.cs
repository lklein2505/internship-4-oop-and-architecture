using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Goblin";
            MaxHealth = 50;
            Health = MaxHealth;
            Damage = 5;
            Expirience = 20;            
        }
    }
}
