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
            ConsoleUI ui = ConsoleUI.GetInstance();
            ui.Start();
        }
    }
}
