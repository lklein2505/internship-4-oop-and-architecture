using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Warrior : Hero
    {
        public int RageAttack { get; set; }
        public Warrior()
        {            
            MaxHealth = 200;
            Health = MaxHealth;
            Damage = 10;
            RageAttack = 2 * Damage;
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}
