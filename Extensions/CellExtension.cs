using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsole.Tools
{
    public static class CellExtension
    {
        public static List<SingleCell> Range(this List<SingleCell> cells,
                                             int startRow,
                                             int startColumn,
                                             int endRow,
                                             int endColumn)
        {
            return cells.Where(x => x.Coordinates.Row >= startRow
                                    && x.Coordinates.Column >= startColumn
                                    && x.Coordinates.Row <= endRow
                                    && x.Coordinates.Column <= endColumn).ToList();
        }

        public static SingleCell At(this List<SingleCell> cells, int row, int col)
        {
            return cells.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == col).First();
        }
    }
}