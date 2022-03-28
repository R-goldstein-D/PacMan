using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacMan
{
    internal class Character
    {
        public string direction;
        public int x, y, size, startAngle, speed, previousX, previousY;
        public SolidBrush colour;
        public Rectangle top, left, bottom, right;

        // pacman
        public Character(string _direction, int _x, int _y, int _size, int _startAngle, int _speed, SolidBrush _colour)
        {
            x = _x;
            y = _y;
            size = _size;
            direction = _direction;
            startAngle = _startAngle;
            speed = _speed;
            colour = _colour;
        }
        public void Move(string direction)
        {
            //track previous position in case of reset
            previousX = x;
            previousY = y;

            //move in current direction
            switch (direction)
            {
                case "up":
                    y -= speed;
                    break;
                case "left":
                    x -= speed;
                    break;
                case "down":
                    y += speed;
                    break;
                case "right":
                    x += speed;
                    break;
            }
        }
        public void WallCollision(Rectangle r)
        {
            switch (direction)
            {
                case "up":
                    top = new Rectangle(x, y, size, 10);
                    if (top.IntersectsWith(r))
                    {
                        PositionReset();
                    }
                    break;
                case "left":
                    left = new Rectangle(x, y, 10, size);
                    if (left.IntersectsWith(r))
                    {
                        PositionReset();
                    }
                    break;
                case "down":
                    bottom = new Rectangle(x, y + 15, size, 1);
                    if (bottom.IntersectsWith(r))
                    {
                        PositionReset();
                    }
                    break;
                case "right":
                    right = new Rectangle(x + 15, y, 1, 0);
                    if (right.IntersectsWith(r))
                    {
                        PositionReset();
                    }
                    break;
            }
        }
        //resets character to their previous position and set speed = 0
        public void PositionReset()
        {
            x = previousX;
            y = previousY;
            speed = 0;
        }
    }
}
