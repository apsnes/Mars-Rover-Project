using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Input;

namespace Mars_Rover_Project.Logic
{
    public class Session : BaseClass
    {
        public List<Rover> Rovers = new();
        public Rover CurrentRover = new();
        private static Session _session;
        private string[,] map;
        private PlateauSize plateau = PlateauSize.GetInstance();
        private Session()
        {      }
        public static Session GetInstance()
        {
            if (_session == null) _session = new Session();
            return _session;
        }
        public void AddRover(Position position)
        {
            Rovers.Add(new Rover(position));
        }
        public void Move()
        {
            CurrentRover.Move();
        }
        public void TurnLeft()
        {
            CurrentRover.Instruct("L");
        }
        public void TurnRight()
        {
            CurrentRover.Instruct("R");
        }
        public void SetCurrentRover(Rover rover)
        {
            CurrentRover = rover;
        }
        internal void Run()
        {
            Clear();
            UpdateRovers();
            while (true)
            {
                UpdatePlateau();
            }
        }
        internal void Clear()
        {
            int width = plateau.Width;
            int height = plateau.Height;
            map = new string[width, height];
            for (int rows = 0; rows < width; rows++)
            {
                for (int cols = 0; cols < height; cols++)
                {
                    map[rows, cols] = " - ";
                }
            }
        }
        internal void UpdateRovers()
        {
            foreach (Rover rover in _session.Rovers)
            {
                int xPosition = rover.Position.X;
                int yPosition = rover.Position.Y;
                yPosition = (plateau.Height - yPosition);
                map[xPosition, yPosition] = "-R-";
            }
        }
        internal void UpdatePlateau()
        {
            Clear();
            UpdateRovers();
            PrintPlateau();
            Thread.Sleep(500);
        }
        internal void PrintPlateau()
        {
            for (int rows = 0; rows < plateau.Width; rows++)
            {
                for (int cols = 0; cols < plateau.Height; cols++)
                {
                    Console.WriteLine(map[rows, cols]);
                }
            }
        }
    }
}
