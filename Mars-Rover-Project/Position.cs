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
        private int _x;
        private int _y;
        private Direction _direction;
        private PlateauSize plateauSize = PlateauSize.GetInstance();
        public Position(int x, int y, Direction direction)
        {
            _x = x;
            _y = y;
            _direction = direction;
        }
        public void UpdatePosition()
        {
            switch (_direction)
            {
                case Direction.North:
                    if (HasPositionNorth) _y++;
                    break;
                case Direction.South:
                    if (HasPositionSouth) _y--;
                    break;
                case Direction.East:
                    if (HasPositionEast) _x++;
                    break;
                case Direction.West:
                    if (HasPositionWest) _x--;
                    break;
                default: throw new Exception("Invalid location");
            }
        }
        public void UpdateDirection(Direction direction)
        {
            _direction = direction;
        }
        private bool HasPositionNorth => (_y + 1 < plateauSize.Height);
        private bool HasPositionEast => (_x + 1 < plateauSize.Width);
        private bool HasPositionSouth => (_y - 1 >= 0);
        private bool HasPositionWest => (_x - 1 >= 0);
    }
}
