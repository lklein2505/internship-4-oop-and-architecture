using DungeonCrawler.Data.Abstractions;
using DungeonCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Domain.Services
{
    public class RoundCosts
    {
        public List<IFightConsequences> Costs { get; set; }

        public static void PlayerWins()
        {
            
        }
    }
}
