using Mars_Rover_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project
{
    public class Position
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
                    break;
                case Direction.South:
                    if (HasPositionSouth) Y--;
                    break;
                case Direction.East:
                    if (HasPositionEast) X++;
                    break;
                case Direction.West:
                    if (HasPositionWest) X--;
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
