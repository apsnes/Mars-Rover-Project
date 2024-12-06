using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Project
{
    public class PlateauSize
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
            return instance;
        }
        public static PlateauSize SetInstance(int width, int height)
        {
            instance = new PlateauSize(width, height);
            return instance;
        }
    }
}
