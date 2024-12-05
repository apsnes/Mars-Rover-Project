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
        private List<Rover> rovers = new();
        public Rover CurrentRover = new();
        public void AddRover()
        {
            rovers.Add(new Rover());
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
    }
}
