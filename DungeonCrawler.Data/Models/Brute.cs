using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Brute : Monster
    {
        public int MaxHealthAttack { get; set; }
        public Brute()
        {
            Name = "Brute";
            MaxHealth = 120;
            Health = MaxHealth;
            Damage = 15;
            Expirience = 40;            
        }
    }
}
