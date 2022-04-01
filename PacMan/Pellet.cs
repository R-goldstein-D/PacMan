using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class Pellet
    {
        public int x, y, size;

        public Pellet(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }
    }
}
