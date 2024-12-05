using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project.Logic
{
    internal class Rover
    {
        public Position Position { get; set; }
        public Rover()
        {
            Position = new Position(0, 0, Direction.North);
        }
        public void Move()
        {
            Position.UpdatePosition();
        }
        public void ChangeDirection(string input)
        {
            Direction direction = InputParser.ParseDirection(input);
            Position.UpdateDirection(direction);
        }
    }
}
