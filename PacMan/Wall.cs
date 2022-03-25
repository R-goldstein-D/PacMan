using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class Wall
    {
        public int height = 10;
        public int width = 30;
        public int x, y;

        public Wall(int _x, int _y, int _height, int _width)
        {
            x = _x;
            y = _y;
            height = _height;
            width = _width;
        }
    }
}
