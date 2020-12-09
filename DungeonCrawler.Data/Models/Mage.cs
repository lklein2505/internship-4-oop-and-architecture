using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Mage : Hero
    {
        public int MaxMana { get; set; }
        public int Mana { get; set; }

        public Mage()
        {            
            MaxHealth = 100;
            Health = MaxHealth;
            Damage = 25;
            MaxMana = 100;
            Mana = MaxMana;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nMana: {Mana}/{MaxMana}";
        }

        public void Respawn()
        {
            Health = MaxHealth;
            Mana = MaxMana;
        }
    }
}
