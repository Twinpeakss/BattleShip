using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsole
{
    public class GameBoard
    {
        public List<SingleCell> Cells { get; set; }

        //For rows and column will use integers, as it makes several calculations easier.
        public GameBoard()
        {
            Cells = new List<SingleCell>();
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    Cells.Add(new SingleCell(i, j));
                }
            }
        }
    }
}