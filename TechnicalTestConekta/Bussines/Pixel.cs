using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class Pixel
    {
        private int X { get; set;}
        private int Y { get; set;}
        private string Color { get; set;}
        

        public Pixel(int x, int y)
        {
            this.X= x;
            this.Y = y;
            this.Clear();
        }

        public void ChangeColor(string color)
        {
            this.Color = color;
        }
       
        public void Clear()
        {
            this.Color = "O";
        }
    }
}
