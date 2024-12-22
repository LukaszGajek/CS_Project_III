using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statki
{
    internal class ship
    {
        public int x;
        public int y;
        public int lenght;
        public int direction; //1 dol, 2 prawo

        public ship(int x, int y, int lenght, int direction)
        {
            this.x = x;
            this.y = y;
            this.lenght = lenght;
            this.direction = direction;
        }
        public void draw(Graphics g)
        {
            int x1 = 40*x;
            int y1 = 40*y;
            for (int i = 0; i < lenght; i++)
            {
                g.FillRectangle(Brushes.Yellow, x1, y1, 40, 40);
                if (direction == 1)
                {
                    y1 += 40;
                }
                if (direction == 2)
                {
                    x1 += 40;
                }
            }

        }
    }

}
