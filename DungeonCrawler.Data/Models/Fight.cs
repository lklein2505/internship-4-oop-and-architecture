using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
    public class Fight
    {
        public static void PlayerAttack()
        {
            Console.WriteLine("\n You can choose between 3 different types of attacking the enemy. Your enemy also chooses one.\n" +
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
                    Duel(playerAttack);
                }                    
                else
                    Console.WriteLine("You have to choose between numbers '1', '2' and '3'! Try again!\n");
            }                       
        }

        public static void Duel(int playerAttack)
        {            
            Random random = new Random();
            var enemyAttack = random.Next(1, 3);            
        }
    }
}
