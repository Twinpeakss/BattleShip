using BattleShipConsole.Enums;
using BattleShipConsole.Models.Ships;
using BattleShipConsole.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsole
{
    public class Player
    {
        public string Name { get; set; }

        public GameBoard GameBoard { get; set; }

        public FiringBoard FiringBoard { get; set; }

        public List<Ship> Ships { get; set; }

        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new BattleShip(),
                new Carrier()
            };

            GameBoard = new GameBoard();
            FiringBoard = new FiringBoard();
        }

        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                bool isOpen = true;
                while (isOpen)
                {
                    var startColumn = rand.Next(1, 11);
                    var startRow = rand.Next(1, 11);
                    int endRow = startRow, endColumn = startColumn;
                    var orientation = rand.Next(1, 101) % 2;

                    List<int> panelNumbers = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endRow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endColumn++;
                        }
                    }

                    if (endRow > 10 || endColumn > 10)
                    {
                        isOpen = true;
                        continue;
                    }

                    var affectedCells = GameBoard.Cells.Range(startRow,
                                                                  startColumn,
                                                                  endRow,
                                                                  endColumn);

                    if (affectedCells.Any(x => x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach (var cell in affectedCells)
                    {
                        cell.OccupationType = ship.OccupationType;
                    }

                    isOpen = false;
                }
            }
        }

        public void ShowBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                                Firing Board");

            for (int row = 1; row <= 10; row++)
            {
                for (int ownColumn = 0; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(GameBoard.Cells.At(row, ownColumn).Status + " ");
                }
                Console.Write("                    ");
                for (int firingColumn = 1; firingColumn <= 10; firingColumn++)
                {
                    Console.Write(FiringBoard.Cells.At(row, firingColumn).Status + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public Coordinates FireShot()
        {
            //If there are hits on the board with neighbors which don't have shots,
            //we should fire at those first.

            var hitNeighbors = FiringBoard.GetHitNeighbors();
            Coordinates coordinates;
            if (hitNeighbors.Any())
            {
                coordinates = SearchingShot();
            }
            else
            {
                coordinates = RandomShot();
            }

            Console.WriteLine(Name + " says: \"Firing shot at "
                              + coordinates.Row.ToString()
                              + ", " + coordinates.Column.ToString()
                              + "\"");
            return coordinates;
        }

        private Coordinates RandomShot()
        {
            var availablePanels = FiringBoard.GetOpenRandomCells();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var panelID = rand.Next(availablePanels.Count);
            return availablePanels[panelID];
        }

        private Coordinates SearchingShot()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var hitNeighbors = FiringBoard.GetHitNeighbors();
            var neighborID = rand.Next(hitNeighbors.Count);
            return hitNeighbors[neighborID];
        }

        public ShotResult ProcessShot(Coordinates coors)
        {
            //Locate the targeted panel(cell) on the GameBoard
            var cell = GameBoard.Cells.At(coors.Row, coors.Column);

            //If the panel is NOT occupied by a ship
            if (!cell.IsOccupied)
            {
                Console.WriteLine(Name + "says: \"Miss!\"");
                return ShotResult.Miss;
            }

            var ship = Ships.First(x => x.OccupationType == cell.OccupationType);

            ship.Hits++;

            Console.WriteLine(Name + " says: \"Hit!\"");

            if (ship.IsSunk)
            {
                Console.WriteLine(Name + " says: \"You sunk my " + ship.Name + "!\"");
            }

            return ShotResult.Hit;
        }

        public void ProcessShotResult(Coordinates coords, ShotResult result)
        {
            var cell = FiringBoard.Cells.At(coords.Row, coords.Column);
            switch (result)
            {
                case ShotResult.Hit:
                    cell.OccupationType = OccupationType.Hit;
                    break;

                default:
                    cell.OccupationType = OccupationType.Miss;
                    break;
            }
        }
    }
}