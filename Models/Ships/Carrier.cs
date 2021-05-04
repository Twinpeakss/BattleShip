using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipConsole.Enums;

namespace BattleShipConsole.Models.Ships
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier ";
            Width = 5;
            OccupationType = OccupationType.Carrier;
        }
    }
}