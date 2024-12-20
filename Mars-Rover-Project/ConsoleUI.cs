﻿using Mars_Rover_Project.Logic;
using Mars_Rover_Project.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Mars_Rover_Project.Input;
using System.Collections.Specialized;

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
            while (plateau == null)
            {
                Console.WriteLine("Invalid plateau size. Please try again: ");
                x = Console.ReadLine();
                y = Console.ReadLine();
                plateau = InputParser.ParsePlateauSize(x, y);
            }

            Console.WriteLine("Preparing for mission start. What are your orders?");

            while (true)
            {
                _session.UpdatePlateau();
                PrintOptions();
                MainMenuOptions selectedOption = InputParser.ParseMenuOption(Console.ReadLine());
                if (selectedOption == MainMenuOptions.SetRover) SetRover();
                if (selectedOption == MainMenuOptions.AddRover) AddRover();
                if (selectedOption == MainMenuOptions.MoveRover) MoveRover();
                if (selectedOption == MainMenuOptions.Quit) break;
                if (selectedOption == MainMenuOptions.Error) Console.WriteLine("Invalid input. Please try again.");
            }           
        }
        internal void PrintOptions()
        {
            Console.WriteLine(" [0] - Set current rover to control");
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
            Console.WriteLine("Enter rover ID:");
            string id = Console.ReadLine();
            while (!int.TryParse(id, out int idInt) || _session.RoverExists(int.Parse(id)))
            {
                Console.WriteLine("Invalid id, please try again:");
                id = Console.ReadLine();
            }
            _session.AddRover(startingPosition, int.Parse(id));
        }
        internal void MoveRover()
        {
            Console.WriteLine("Enter instruction: ");
            Console.WriteLine(" L - Turn left");
            Console.WriteLine(" R - Turn right ");
            Console.WriteLine(" M - Move one position ");
            Instruction instruction = Instruction.Error;
            instruction = InputParser.ParseInstruction(Console.ReadLine());
            while (instruction == Instruction.Error)
            {
                Console.WriteLine("Invalid input. Please try again: ");
                instruction = InputParser.ParseInstruction(Console.ReadLine());
            }
            _session.CurrentRover.Instruct(instruction);
        }
        internal void SetRover()
        {
            if (_session.Rovers.Count == 0)
            {
                Console.WriteLine("No available rovers to control");
                return;
            }
            Console.WriteLine("Enter the ID of the rover you'd Like to control: ");
            string id = Console.ReadLine();
            while (!int.TryParse(id, out int idInt) || !_session.RoverExists(int.Parse(id)))
            {
                Console.WriteLine("Invalid id, please try again:");
                id = Console.ReadLine();
            }
            _session.SetCurrentRover(int.Parse(id));
        }
    }
}
