using DungeonCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Abstractions
{
    public interface IFightConsequences
    {
        int Damage { get; set; }
        int Health { get; set; }
        int Expirience { get; set; }         
    }
}
