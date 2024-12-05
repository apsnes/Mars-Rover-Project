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
        private Rover currentRover = new();
        public void AddRover()
        {
            rovers.Add(new Rover());
        }
        public void Move()
        {
            currentRover.Move();
        }
        public void TurnLeft()
        {
            currentRover.Instruct("L");
        }
        public void TurnRight()
        {
            currentRover.Instruct("R");
        }
        public void SetCurrentRover(Rover rover)
        {
            currentRover = rover;
        }
    }
}
