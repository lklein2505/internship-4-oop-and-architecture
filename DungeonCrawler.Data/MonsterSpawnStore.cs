using DungeonCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data
{
    public static class MonsterSpawnStore
    {
        public static List<Monster> SpawnMonsters { get; } = new List<Monster>();
    }
}
