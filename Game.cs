using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsole
{
    public class Game
    {
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Game()
        {
            Player1 = new Player("Obiwan");
            Player2 = new Player("Anakin");

            Player1.PlaceShips();
            Player2.PlaceShips();

            Player1.ShowBoards();
            Player2.ShowBoards();
        }

        //Simulate one shot from each player
        public void PlayRound()
        {
            var coordinates = Player1.FireShot();
            var result = Player2.ProcessShot(coordinates);
            Player1.ProcessShotResult(coordinates, result);

            if (!Player2.HasLost)
            {
                coordinates = Player2.FireShot();
                result = Player1.ProcessShot(coordinates);
                Player2.ProcessShotResult(coordinates, result);
            }
        }

        public void PlayToEnd()
        {
            while (!Player1.HasLost && !Player2.HasLost)
            {
                PlayRound();
            }

            Player1.ShowBoards();
            Player2.ShowBoards();

            if (Player1.HasLost)
            {
                Console.WriteLine(Player2.Name + " has won the game!");
            }
            else if (Player2.HasLost)
            {
                Console.WriteLine(Player1.Name + " has won the game!");
            }
        }
    }
}