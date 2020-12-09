using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Witch : Monster
    {
        public Witch()
        {
            Name = "Witch";
            MaxHealth = 150;
            Health = MaxHealth;
            Damage = 20;
            Expirience = 80;            
        }        
    }
}
