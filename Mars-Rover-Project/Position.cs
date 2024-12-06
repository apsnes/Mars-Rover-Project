using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project
{
    public class Position : BaseClass
    {
        private int _x;
        public int X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }
        private int _y;
        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
        private Direction _direction;
        public Direction Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                OnPropertyChanged(nameof(Direction));
            }
        }
        private PlateauSize plateauSize = PlateauSize.GetInstance();
        private string _positionString;
        public string PositionString
        {
            get => _positionString;
            set
            {
                _positionString = $"{X}, {Y}, {Direction}";
                OnPropertyChanged(nameof(PositionString));
                OnPropertyChanged(nameof(X));
                OnPropertyChanged(nameof(Y));
                OnPropertyChanged(nameof(Direction));
            }
        }

        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
            PositionString = $"{x}, {y}, {Direction}";
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
        public bool HasPositionNorth => (Y + 1 < plateauSize.Height);
        public bool HasPositionEast => (X + 1 < plateauSize.Width);
        public bool HasPositionSouth => (Y - 1 >= 0);
        public bool HasPositionWest => (X - 1 >= 0);
        public override string ToString()
        {
            return $"{X}, {Y}, {Direction}";
        }
    }
}
