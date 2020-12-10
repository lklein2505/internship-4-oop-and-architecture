using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Ranger : Hero
    {
        public int CriticalStrike { get; set; }
        public int CriticalStrikeChance { get; set; }
        public int StunChance { get; set; }
        public Ranger()
        {            
            MaxHealth = 150;
            Health = MaxHealth;
            Damage = 15;
            CriticalStrike = 2 * Damage;
            CriticalStrikeChance = 10;
            StunChance = 20;
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}
