using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project.Logic
{
    public class Rover : BaseClass, IVehicle
    {
        public Position Position { get; set; }
        public Rover(int x, int y, Direction direction)
        {
            Position = new Position(x, y, direction);
        }
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
        public void ChangeDirection(Direction direction)
        {
            Position.UpdateDirection(direction);
        }
        public void Instruct(string input)
        {
            Instruction instruction = InputParser.ParseInstruction(input);
            switch (instruction)
            {
                case Instruction.L:
                    if (Position.Direction == Direction.North) ChangeDirection(Direction.West);
                    else if (Position.Direction == Direction.East) ChangeDirection(Direction.North);
                    else if (Position.Direction == Direction.South) ChangeDirection(Direction.East);
                    else if (Position.Direction == Direction.West) ChangeDirection(Direction.South);
                    break;
                case Instruction.R:
                    if (Position.Direction == Direction.North) ChangeDirection(Direction.East);
                    else if (Position.Direction == Direction.East) ChangeDirection(Direction.South);
                    else if (Position.Direction == Direction.South) ChangeDirection(Direction.West);
                    else if (Position.Direction == Direction.West) ChangeDirection(Direction.North);
                    break;
                case Instruction.M:
                    Move();
                    break;
                default: throw new ArgumentException("Invalid input");
            }
        }
    }
}
