using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project
{
    internal class PlateauSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private static PlateauSize instance;
        private PlateauSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public static PlateauSize GetInstance()
        {
            if (instance == null) instance = new PlateauSize(5, 5);
            return instance;
        }
        public static PlateauSize GetInstance(int width, int height)
        {
            if (instance == null) instance = new PlateauSize(width, height);
            return instance;
        }
    }
}
