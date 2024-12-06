using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Input;

namespace Mars_Rover_Project.Logic
{
    public class Session : BaseClass
    {
        public ObservableCollection<Rover> Rovers { get; set; } = new();
        private Rover _currentRover;
        public Rover CurrentRover
        {
            get => _currentRover; 
            set
            {
                _currentRover = value;
                OnPropertyChanged(nameof(CurrentRover));
            }
        }
        private static Session _session;
        public string[,] map;
        public PlateauSize Plateau = PlateauSize.GetInstance();
        private Session()
        {
            CurrentRover = new Rover(new Position(0, 0, Direction.North), 1);
            Clear();
        }
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
            int x = CurrentRover.Position.X;
            int y = CurrentRover.Position.Y;
            Direction dir = CurrentRover.Position.Direction;
            //if (!CurrentRover.Position.HasPositionNorth || (dir == Direction.North && map[y + 1, x] != " - ")) return;
            //if (!CurrentRover.Position.HasPositionEast || (dir == Direction.East && map[y, x + 1] != " - ")) return;
            //if (!CurrentRover.Position.HasPositionSouth || (dir == Direction.South && map[y - 1, x] != " - ")) return;
            //if (!CurrentRover.Position.HasPositionEast || (dir == Direction.North && map[y, x - 1] != " - ")) return;
            if (!CurrentRover.Position.HasPositionNorth && dir == Direction.North) return;
            if (!CurrentRover.Position.HasPositionEast && dir == Direction.East) return;
            if (!CurrentRover.Position.HasPositionSouth && dir == Direction.South) return;
            if (!CurrentRover.Position.HasPositionEast && dir == Direction.North) return;
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
            Plateau = PlateauSize.GetInstance();
            int width = Plateau.Width;
            int height = Plateau.Height;
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
            foreach (Rover rover in Rovers)
            {
                int xPosition = rover.Position.X;
                int yPosition = rover.Position.Y;
                yPosition = (Plateau.Height - 1 - yPosition);
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
            for (int rows = 0; rows < Plateau.Width; rows++)
            {
                for (int cols = 0; cols < Plateau.Height; cols++)
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
