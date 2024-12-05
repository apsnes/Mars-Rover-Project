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
            try
            {
                List<string> input = ["5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"];
                InputParser.ParsePlateauSize("5", "5");
                Position startingPosition = InputParser.ParsePosition("1", "2", "N");
                Rover myRover = new Rover(startingPosition.X, startingPosition.Y, startingPosition.Direction);
                myRover.Instruct("L");
                myRover.Instruct("M");
                myRover.Instruct("L");
                myRover.Instruct("M");
                myRover.Instruct("L");
                myRover.Instruct("M");
                myRover.Instruct("L");
                myRover.Instruct("M");
                myRover.Instruct("M");

                Position yourStartingPosition = InputParser.ParsePosition("3", "3", "E");
                Rover yourRover = new Rover(yourStartingPosition.X, yourStartingPosition.Y, yourStartingPosition.Direction);
                yourRover.Instruct("M");
                yourRover.Instruct("M");
                yourRover.Instruct("R");
                yourRover.Instruct("M");
                yourRover.Instruct("M");
                yourRover.Instruct("R");
                yourRover.Instruct("M");
                yourRover.Instruct("R");
                yourRover.Instruct("R");
                yourRover.Instruct("M");

                Console.WriteLine($"{myRover.Position.X} {myRover.Position.Y} {myRover.Position.Direction}");
                Console.WriteLine($"{yourRover.Position.X} {yourRover.Position.Y} {yourRover.Position.Direction}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
