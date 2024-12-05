using System.Reflection.Metadata.Ecma335;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Input;
using Mars_Rover_Project.Logic;

namespace Mars_Rover_Project
{
    internal class Program
    {
        static void Main()
        {
            List<string> input = ["5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"];
            InputParser.ParsePlateauSize("5", "5");
            Position startingPosition = InputParser.ParsePosition("1", "2", "N");
            Rover myRover = new Rover(startingPosition.X, startingPosition.Y, startingPosition.Direction);
            //myRover.ChangeDirection;

        }
    }
}
