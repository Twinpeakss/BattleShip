using BattleShipConsole.Enums;
using BattleShipConsole.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsole
{
    public class FiringBoard : GameBoard
    {
        public List<Coordinates> GetOpenRandomCells()
        {
            return Cells.Where(x => x.OccupationType == OccupationType.Empty
                                    && x.IsRandomAvailable)
                                    .Select(x => x.Coordinates)
                                    .ToList();
        }

        public List<Coordinates> GetHitNeighbors()
        {
            var cells = new List<SingleCell>();
            var hits = Cells.Where(x => x.OccupationType == Enums.OccupationType.Hit);
            foreach (var hit in hits)
            {
                cells.AddRange(GetNeighbors(hit.Coordinates).ToList());
            }
            return cells.Distinct()
                         .Where(x => x.OccupationType ==
                                      OccupationType.Empty)
                         .Select(x => x.Coordinates)
                         .ToList();
        }

        public List<SingleCell> GetNeighbors(Coordinates coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            var cells = new List<SingleCell>();
            if (column > 1)
            {
                cells.Add(Cells.At(row, column - 1));
            }
            if (row > 1)
            {
                cells.Add(Cells.At(row - 1, column));
            }
            if (row < 10)
            {
                cells.Add(Cells.At(row + 1, column));
            }
            if (column < 10)
            {
                cells.Add(Cells.At(row, column + 1));
            }
            return cells;
        }
    }
}