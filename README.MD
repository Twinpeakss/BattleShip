# BattleShip game


I decided to use 2 boards: 
one for placing ships, the second for marking the coordinates of the shots.

Ship class created for decription for ship on the board. 
It has "width" field that's means how many cells occupy ship, and hits fild that count hits on ship.

Each ship type inherits from the parent ship's main class.
Game Board consist of 10 x 10 single cells

One cell contains coordinates, ship type, statistics. 
Each game continues until one of the players loses or the game starts again.