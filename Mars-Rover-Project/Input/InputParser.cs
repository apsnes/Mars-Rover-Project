using Mars_Rover_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project.Input
{
    internal static class InputParser
    {
        internal static Direction ParseDirection(string input)
        {
            switch (input)
            {
                case "N": return Direction.North;
                case "E": return Direction.East;
                case "S": return Direction.South;
                case "W": return Direction.West;
                default: throw new ArgumentException("Invalid direction input");
            }
        }
        internal static Instruction ParseInstruction(string input)
        {
            switch (input)
            {
                case "L": return Instruction.L;
                case "R": return Instruction.R;
                case "M": return Instruction.M;
                default: throw new ArgumentException("Invalid Instruction input");
            }
        }
        internal static PlateauSize ParsePlateauSize(string inputWidth, string inputHeight)
        {
            if (!int.TryParse(inputWidth, out int width) || !int.TryParse(inputHeight, out int height) || width < 1 || height < 1 || width > 100 || height > 100)
            {
                throw new ArgumentException("Invalid width input");
            }
            return new PlateauSize(width, height);
        }
        internal static Position ParsePosition(string xString, string yString, string direction)
        {
            if (!int.TryParse(xString, out int x))
            {
                throw new ArgumentException("Invalid x coordinate");
            }
            if (!int.TryParse(yString, out int y))
            {
                throw new ArgumentException("Invalid x coordinate");
            }
            return new Position(x, y, ParseDirection(direction));
        }
    }
}
