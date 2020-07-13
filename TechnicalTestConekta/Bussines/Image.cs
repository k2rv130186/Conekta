using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class Image
    {
        private int M { get; set; }
        private int N { get; set; }
        private List<Pixel> Pixels { get; set; }

        public Image(int m, int n)
        {
            this.M = m;
            this.N = n;
            this.InitializeImage();
        }

        private void InitializeImage()
        {
            this.Pixels = new List<Pixel>();

            for (int x = 1; x <= M; x++)
            {
                for (int y = 1; y <= N; y++)
                {
                    Pixel pix = new Pixel(x, y);
                    Pixels.Add(pix);
                }
            }
        }

        public void Clear()
        {
            foreach (Pixel pix in Pixels)
            {
                pix.Clear();
            }
        }

        public void ColorPixel(int x, int y, string color)
        {
            Pixel pix = this.Pixels.Where(p => p.X == x && p.Y == y).FirstOrDefault();
            pix.ChangeColor(color);
        }

        public void DrawVertical(int x, int y1, int y2, string color)//V X Y1 Y2 C
        {
            List<Pixel> lstPixels = this.Pixels.Where(p => p.X == x && (p.Y >= y1 && p.Y <= y2)).ToList();

            foreach (Pixel pix in lstPixels)
            {
                pix.ChangeColor(color);
            }
        }

        public void DrawHorizontal(int x1, int x2, int y, string color)//H X1 X2 Y C
        {
            List<Pixel> lstPixels = this.Pixels.Where(p => p.Y == y && (p.X >= x1 && p.X <= x2)).ToList();

            foreach (Pixel pix in lstPixels)
            {
                pix.ChangeColor(color);
            }
        }

        public void Recursive(Pixel pix, string originalColor, string newColor)
        {
            int newX,newY;
            Pixel newPixel;

            if( pix.Color== originalColor)
            {
                pix.ChangeColor(newColor);
            }

            newX = pix.X - 1;
            if(newX>=1)
            {
                newPixel = Pixels.Where(p => p.X == newX && p.Y == pix.Y).FirstOrDefault();

                if(newPixel.Color==originalColor)
                {
                    Recursive(newPixel,originalColor,newColor);
                }
            }

            newX = pix.X + 1;
            if (newX <= M)
            {
                newPixel = Pixels.Where(p => p.X == newX && p.Y == pix.Y).FirstOrDefault();

                if (newPixel.Color == originalColor)
                {
                    Recursive(newPixel, originalColor, newColor);
                }
            }

            newY = pix.Y - 1;
            if (newY >= 1)
            {
                newPixel = Pixels.Where(p => p.X == pix.X && p.Y == newY).FirstOrDefault();

                if (newPixel.Color == originalColor)
                {
                    Recursive(newPixel, originalColor, newColor);
                }
            }

            newY = pix.Y + 1;
            if (newY <= N)
            {
                newPixel = Pixels.Where(p => p.X == pix.X && p.Y == newY).FirstOrDefault();

                if (newPixel.Color == originalColor)
                {
                    Recursive(newPixel, originalColor, newColor);
                }
            }


        }

        public void Region(int x, int y, string color)//F X Y C
        {
            string originalColor = string.Empty;

            Pixel pix = Pixels.Where(p => p.X == x && p.Y == y).FirstOrDefault();

            originalColor = pix.Color;

            Recursive(pix, originalColor);

        }

        public void Show()
        {
            string matriz = string.Empty;

            for (int y = 1; y <= N; y++)
            {
                List<Pixel> lstPixels = this.Pixels.Where(p => p.Y == y).OrderBy(p => p.X).ToList();

                matriz = matriz + string.Join(string.Empty, lstPixels)+ Environment.NewLine;
            }
        }

    }
}

