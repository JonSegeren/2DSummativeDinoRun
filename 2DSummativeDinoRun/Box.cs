using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DSummativeDinoRun
{
    public class Box
    {
        public int x, y, xSize, ySize, xSpeed, ySpeed;

        public Box(int _x, int _y, int _xSize, int _ySize)
        {
            x = _x;
            y = _y;
            xSize = _xSize;
            ySize = _ySize;
        }

        public void Move(int speed)
        {
            x -= speed;
        }

        public void Duck(int xSize, int ySize)
        {
            int tempX = ySize;
            int tempY = xSize;

            xSize = tempX;
            ySize = tempY;
        }

        public void Jump(int jHeight)
        {
            y -= 2 * jHeight;
        }

        public bool Collision(Box b)
        {
            Rectangle rec1 = new Rectangle(b.x, b.y, b.xSize, b.ySize);
            Rectangle rec2 = new Rectangle(x, y, xSize, ySize);
            if (rec1.IntersectsWith(rec2))
            {
                return true;
            }
            return false;
        }
    }
}
