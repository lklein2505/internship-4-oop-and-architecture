using DungeonCrawler.Data.Models;
using System.Collections.Generic;

namespace DungeonCrawler.Data
{
    public static class MonsterSpawnStore
    {
        public static List<Monster> SpawnMonsters { get; } = new List<Monster>();
    }
}
