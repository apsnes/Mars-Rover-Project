using Mars_Rover_Project.Logic;
using Mars_Rover_Project.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Mars_Rover_Project.Input;

namespace Mars_Rover_Project
{
    internal class ConsoleUI
    {
        private Session _session = Session.GetInstance();
        private static ConsoleUI consoleUI = ConsoleUI.GetInstance();
        PlateauSize plateau;
        private ConsoleUI() { }
        public static ConsoleUI GetInstance()
        {
            if (consoleUI == null) consoleUI = new ConsoleUI();
            return consoleUI;
        }

        internal void Start()
        {
            Console.WriteLine("Enter the size of the plateau we'll be exploring today:");
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            plateau = InputParser.ParsePlateauSize(x, y);

            Console.WriteLine("Preparing for mission start. What are your orders?");

            while (true)
            {
                PrintOptions();
                MainMenuOptions selectedOption = InputParser.ParseMenuOption(Console.ReadLine());

                if (selectedOption == MainMenuOptions.AddRover) AddRover();
                if (selectedOption == MainMenuOptions.MoveRover) MoveRover();
                if (selectedOption == MainMenuOptions.Quit) break;
            }           
        }
        internal void PrintOptions()
        {
            Console.WriteLine(" [1] - Add a rover");
            Console.WriteLine(" [2] - Move a rover");
            Console.WriteLine(" [3] - Quit and return to Earth");
        }
        internal void AddRover()
        {
            Console.WriteLine("Enter starting x coordinate: ");
            string x = Console.ReadLine();
            Console.WriteLine("Enter starting y coordinate: ");
            string y = Console.ReadLine();
            Console.WriteLine("Enter starting direction: ");
            string direction = Console.ReadLine();
            Position startingPosition = InputParser.ParsePosition(x, y, direction);
            _session.AddRover(startingPosition);
        }
        internal void MoveRover()
        {
            Console.WriteLine("Enter instruction: ");
            Console.WriteLine(" L - Turn left");
            Console.WriteLine(" R - Turn right ");
            Console.WriteLine(" M - Move one position ");
            Instruction instruction = InputParser.ParseInstruction(Console.ReadLine());
            _session.CurrentRover.Instruct(instruction);
        }
    }
}
