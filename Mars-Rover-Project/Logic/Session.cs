using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project.Logic
{
    internal class Session
    {
        private static List<IVehicle> vehiclesOnMars = new();
        private PlateauSize plateauSize = PlateauSize.GetInstance();
    }
}
