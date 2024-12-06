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
        public Rover CurrentRover = new Rover(new Position(0, 0, Direction.North), 0);
        private static Session _session;
        private string[,] map;
        private PlateauSize plateau;
        private Session()
        {      }
        public static Session GetInstance()
        {
            if (_session == null) _session = new Session();
            return _session;
        }
        public void AddRover(Position position, int id)
        {
            Rovers.Add(new Rover(position, id));
        }
        public void Move()
        {
            CurrentRover.Move();
        }
        public void TurnLeft()
        {
            CurrentRover.Instruct(Instruction.L);
        }
        public void TurnRight()
        {
            CurrentRover.Instruct(Instruction.R);
        }
        public void SetCurrentRover(int id)
        {
            CurrentRover = Rovers.First(r => r.ID == id);        
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
            plateau = PlateauSize.GetInstance();
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
                yPosition = (plateau.Height - 1 - yPosition);
                map[yPosition, xPosition] = $" {rover.ID} ";
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
                    Console.Write(map[rows, cols]);
                }
                Console.WriteLine("\n");
            }
        }
        internal bool RoverExists(int id)
        {
            foreach(Rover rover in Rovers)
            {
                if (rover.ID == id) return true;
            }
            return false;
        }
    }
}
