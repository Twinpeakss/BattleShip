using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipConsole.Enums;

namespace BattleShipConsole.Models.Ships
{
    public class BattleShip : Ship
    {
        public BattleShip()
        {
            Name = "BattleShip";
            Width = 4;
            OccupationType = OccupationType.Battleship;
        }
    }
}