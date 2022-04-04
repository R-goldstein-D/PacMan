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
        public Rectangle player, entireCharacter;

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
        public void Move()
        {
            //track previous position in case of reset
            previousX = x;
            previousY = y;

            //move in current direction, change pac man mouth direaction too
            switch (direction)
            {
                case "up":
                    y -= speed;
                    startAngle = 315;
                    break;
                case "left":
                    x -= speed;
                    startAngle = 225;
                    break;
                case "down":
                    y += speed;
                    startAngle = 135;
                    break;
                case "right":
                    x += speed;
                    startAngle = 45;
                    break;
            }
        }
        public void WallCollision(Rectangle r)
        {
            player = new Rectangle(x, y, size, size);
            if (player.IntersectsWith(r))
            {
                PositionReset();
            }

        }
        //resets character to their previous position and set speed = 0
        public void PositionReset()
        {
            x = previousX;
            y = previousY;
            direction = "";
        }

        //tunnel teleport
        public void TunnelTeleport(int width)
        {
            if (x <= -5)
            {
                x = width - size - 5;
            }
            else if (x >= width - 7)
            {
                x = 5;
            }
        }
        public bool PelletCollision(Pellet p)
        {
            //rectangles for collision
            entireCharacter = new Rectangle(x, y, size, size);
            Rectangle pRec = new Rectangle(p.x, p.y, p.size, p.size);

            //check collision
            if (entireCharacter.IntersectsWith(pRec)) //collision with  pellet
            {
                GameScreen.collision.Play();
                GameScreen.score += 10;
                return (true);
            }
            else //no collision
            {
                return (false);
            }
        }
    }
}
