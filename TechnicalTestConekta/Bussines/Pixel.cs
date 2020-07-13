using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Color { get; set; }

        public Pixel(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Clear();
        }

        public void ChangeColor(char color)
        {
            this.Color = color;
        }

        public void Clear()
        {
            this.Color = 'O';
        }
    }
}

