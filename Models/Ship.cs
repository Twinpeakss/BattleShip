using BattleShipConsole.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsole
{
    public class Ship
    {
        public string Name { get; set; }

        public int Width { get; set; }

        public int Hits { get; set; }

        public OccupationType OccupationType { get; set; }

        public bool IsSunk
        {
            get
            {
                return Hits >= Width;
            }
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Width = 2;
            OccupationType = OccupationType.Destroyer;
        }
    }

    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Width = 3;
            OccupationType = OccupationType.Submarine;
        }
    }

    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            Width = 3;
            OccupationType = OccupationType.Cruiser;
        }
    }

    public class BattleShip : Ship
    {
        public BattleShip()
        {
            Name = "BattleShip";
            Width = 4;
            OccupationType = OccupationType.Battleship;
        }
    }

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