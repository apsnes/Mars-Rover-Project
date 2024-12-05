using Mars_Rover_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project
{
    internal class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }
        private PlateauSize plateauSize = PlateauSize.GetInstance();
        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        public void UpdatePosition()
        {
            switch (Direction)
            {
                case Direction.North:
                    if (HasPositionNorth) Y++;
                    else throw new InvalidOperationException("Invalid location");
                    break;
                case Direction.South:
                    if (HasPositionSouth) Y--;
                    else throw new InvalidOperationException("Invalid location");
                    break;
                case Direction.East:
                    if (HasPositionEast) X++;
                    else throw new InvalidOperationException("Invalid location");
                    break;
                case Direction.West:
                    if (HasPositionWest) X--;
                    else throw new InvalidOperationException("Invalid location");
                    break;
                default: throw new InvalidOperationException("Invalid location");
            }
        }
        public void UpdateDirection(Direction direction)
        {
            Direction = direction;
        }
        private bool HasPositionNorth => (Y + 1 < plateauSize.Height);
        private bool HasPositionEast => (X + 1 < plateauSize.Width);
        private bool HasPositionSouth => (Y - 1 >= 0);
        private bool HasPositionWest => (X - 1 >= 0);
    }
}
