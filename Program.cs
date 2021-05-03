using BattleShipConsole.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int player1WIns = 0, player2Wins = 0;
            Game game;

            Console.WriteLine("How many games u wanna simulate?");
            var numGames = int.Parse(Console.ReadLine());

            for (int i = 0; i < numGames; i++)
            {
                game = new Game();
                game.PlayToEnd();
                if (game.Player1.HasLost)
                {
                    player2Wins++;
                }
                else
                {
                    player1WIns++;
                }
            }

            Console.WriteLine("Player 1 wins " + player1WIns.ToString());
            Console.WriteLine("Player 2 wins " + player2Wins.ToString());
            Console.ReadKey();
        }
    }
}