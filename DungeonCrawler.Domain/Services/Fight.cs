using DungeonCrawler.Data.Enums;
using System;
using DungeonCrawler.Data;
using System.Collections.Generic;
using System.Text;
using DungeonCrawler.Data.Models;
using DungeonCrawler.Domain.Helpers;
using DungeonCrawler.Domain.Services;

namespace DungeonCrawler.Data.Services
{
    public class Fight
    {
        public static void PlayerAttack(Hero choosenHero, Monster monster)
        {
            Console.WriteLine("\nYou can choose between 3 different types of attacking the enemy.\n" +
                "Your enemy also chooses one.\n" +
                "\tThe rule is:\n" +
                "\tDirect attack wins against side attack\n" +
                "\tSide attack wins against counter attack\n" +
                "\tCounter attack wins against direct attack\n\n");

            var isAttackChoosen = false;
            while (!isAttackChoosen)
            {                
                Console.WriteLine(
                "CHOOSE THE NUMBER OF YOUR ATTACK:\n" +
                "1 - Direct attack\n" +
                "2 - Side attack\n" +
                "3 - Counter attack");
                var playerAttack = int.Parse(Console.ReadLine());
                if (playerAttack > 0 && playerAttack < 4)
                {
                    isAttackChoosen = true;
                    Random random = new Random();
                    var enemyAttack = random.Next(1, 4);
                    Duel(playerAttack, enemyAttack, choosenHero, monster);
                }                    
                else
                    Console.WriteLine("You have to choose between numbers '1', '2' and '3'! Try again!\n");
            }                       
        }

        public static void Duel(int playerAttack, int enemyAttack, Hero choosenHero, Monster monster)
        {
            if (playerAttack == (int)AttackType.DirectAttack && enemyAttack == (int)AttackType.SideAttack ||
                playerAttack == (int)AttackType.SideAttack && enemyAttack == (int)AttackType.CounterAttack ||
                playerAttack == (int)AttackType.CounterAttack && enemyAttack == (int)AttackType.DirectAttack)
                PlayerWins.CalculateCosts(choosenHero, monster);
            else if (playerAttack == (int)AttackType.DirectAttack && enemyAttack == (int)AttackType.CounterAttack ||
                playerAttack == (int)AttackType.SideAttack && enemyAttack == (int)AttackType.DirectAttack ||
                playerAttack == (int)AttackType.CounterAttack && enemyAttack == (int)AttackType.SideAttack)
                MonsterWins.CalculateCosts(choosenHero, monster);
            else
                Console.WriteLine("\nIt's a tie!");
        }
               
    }
}
