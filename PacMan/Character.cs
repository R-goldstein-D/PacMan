﻿using System;
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
        Color origionalColour;

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
    }
}
