using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class GameScreen : UserControl
    {
        Size screenSize;

        List<Rectangle> walls = new List<Rectangle>();

        //brushes
        SolidBrush wallBrush = new SolidBrush(Color.DarkGreen);

        //game variables
        public static int score;

        //player control variables
        public static bool upArrowDown;
        public static bool leftArrowDown;
        public static bool downArrowDown;
        public static bool rightArrowDown;

        public static bool aDown;
        public static bool wDown;
        public static bool sDown;
        public static bool dDown;

        //characters
        Character pacMan;
        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }
        public void InitializeGame()
        {
            SetWalls();

            screenSize = new Size(this.Width, this.Height);

            score = 0;

            //set up Pac-Man
            pacMan = new Character("right", 215, 320, 20, 45, 3, Form1.pacManBrush);


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pacMan.Move();
            Refresh();

            //check for collision with wall in current direction
            foreach (Rectangle w in walls)
            {
                pacMan.WallCollision(w);
            }

            //check if pacman touches the end of a tunnel
            pacMan.TunnelTeleport(this.Width);
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw walls
            for (int i = 0; i < walls.Count(); i++)
            {
                e.Graphics.FillRectangle(wallBrush, walls[i]);
            }

            //draw pacman
            e.Graphics.FillPie(pacMan.colour, pacMan.x, pacMan.y, pacMan.size, pacMan.size, pacMan.startAngle, 270);
        }
        public void SetWalls()
        {
            int outsideWall = 5;
            //outside walls from the top counterclockwise (around in the left direction)
            walls.Add(new Rectangle(5, 35, this.Width - 10, outsideWall)); //top
            walls.Add(new Rectangle(5, 35, outsideWall, 130));
            walls.Add(new Rectangle(5, 160, 75, outsideWall));
            walls.Add(new Rectangle(75, 160, outsideWall, 45));
            walls.Add(new Rectangle(0, 205, 80, outsideWall)); //left top tunnel wall
            walls.Add(new Rectangle(0, 240, 80, outsideWall)); //left bottom tunnel wall
            walls.Add(new Rectangle(75, 240, outsideWall, 45));
            walls.Add(new Rectangle(5, 285, 75, outsideWall));
            walls.Add(new Rectangle(5, 285, outsideWall, 160));
            walls.Add(new Rectangle(5, this.Height - 10 , this.Width - 10, outsideWall)); //bottom
            walls.Add(new Rectangle(this.Width - 10, 285, outsideWall, 160));
            walls.Add(new Rectangle(this.Width - 80, 285, 75, outsideWall));
            walls.Add(new Rectangle(this.Width - 80, 240, outsideWall, 45));
            walls.Add(new Rectangle(this.Width - 80, 240, 80, outsideWall)); //right bottom tunnel wall
            walls.Add(new Rectangle(this.Width - 80, 205, 80, outsideWall)); //right top tunnel wall
            walls.Add(new Rectangle(this.Width - 80, 160, outsideWall, 45));
            walls.Add(new Rectangle(this.Width - 80, 160, 75, outsideWall));
            walls.Add(new Rectangle(this.Width - 10, 35, outsideWall, 130));

            int insideWall = 10;
            //R corner
            walls.Add(new Rectangle(20, 60, 60, insideWall)); 
            walls.Add(new Rectangle(20, 60, insideWall, 80));
            walls.Add(new Rectangle(20, 90, 60, insideWall));
            walls.Add(new Rectangle(80, 60, insideWall, 40));
            walls.Add(new Rectangle(60, 100, insideWall, 40));

            //E corner
            walls.Add(new Rectangle(840, 60, insideWall, 80));
            walls.Add(new Rectangle(795, 60, 45, insideWall));
            walls.Add(new Rectangle(795, 95, 45, insideWall));
            walls.Add(new Rectangle(795, 130, 45, insideWall));

            //I corner
            walls.Add(new Rectangle(40, 320, insideWall, 80));

            //D corner
            walls.Add(new Rectangle(840, 320, insideWall, 80));
            walls.Add(new Rectangle(800, 320, 45, insideWall));
            walls.Add(new Rectangle(790, 330, 10, 10));
            walls.Add(new Rectangle(800, 390, 45, insideWall));
            walls.Add(new Rectangle(790, 380, 10, 10));
            walls.Add(new Rectangle(780, 340, insideWall, 40));

            //r quadrant
            walls.Add(new Rectangle(110, 80, 100, insideWall)); //top T
            walls.Add(new Rectangle(150, 80, insideWall, 45));
            walls.Add(new Rectangle(110, 120, insideWall, 88)); //left horizontal T
            walls.Add(new Rectangle(110, 160, 70, insideWall));
            walls.Add(new Rectangle(310, 120, insideWall, 88)); //right horizontal T
            walls.Add(new Rectangle(250, 160, 70, insideWall));
            walls.Add(new Rectangle(150, 200, 130, insideWall)); //bottom T
            walls.Add(new Rectangle(210, 200, insideWall, 50));
            walls.Add(new Rectangle(250, 100, 28, 28)); //square 
            walls.Add(new Rectangle(210, 120, insideWall, 55)); // middle vertical

            //e quadrant
            walls.Add(new Rectangle(570, 80, 100, insideWall)); //top T
            walls.Add(new Rectangle(610, 80, insideWall, 45));
            walls.Add(new Rectangle(560, 120, insideWall, 88)); //left horizontal T
            walls.Add(new Rectangle(560, 160, 70, insideWall));
            walls.Add(new Rectangle(760, 120, insideWall, 88)); //right horizontal T
            walls.Add(new Rectangle(700, 160, 70, insideWall));
            walls.Add(new Rectangle(600, 200, 130, insideWall)); //bottom T
            walls.Add(new Rectangle(660, 200, insideWall, 50));
            walls.Add(new Rectangle(700, 100, 28, 28)); //square 
            walls.Add(new Rectangle(660, 120, insideWall, 55)); // middle vertical

            //i quadrant
            walls.Add(new Rectangle(70, 400, 100, insideWall)); //bottom T
            walls.Add(new Rectangle(150, 370, insideWall, 35));
            walls.Add(new Rectangle(110, 260, insideWall, 88)); //left horizontal T
            walls.Add(new Rectangle(110, 300, 70, insideWall));
            walls.Add(new Rectangle(310, 260, insideWall, 88)); //right horizontal T
            walls.Add(new Rectangle(250, 300, 70, insideWall));
            walls.Add(new Rectangle(250, 350, 28, 28)); //square 
            walls.Add(new Rectangle(200, 330, insideWall, 55)); // middle vertical

            //d quadrant 
            walls.Add(new Rectangle(520, 400, 100, insideWall)); //bottom T
            walls.Add(new Rectangle(600, 370, insideWall, 35));
            walls.Add(new Rectangle(560, 260, insideWall, 88)); //left horizontal T
            walls.Add(new Rectangle(560, 300, 70, insideWall));
            walls.Add(new Rectangle(760, 260, insideWall, 88)); //right horizontal T
            walls.Add(new Rectangle(700, 300, 70, insideWall));
            walls.Add(new Rectangle(700, 350, 28, 28)); //square 
            walls.Add(new Rectangle(650, 330, insideWall, 55)); // middle vertical

            //r - e
            walls.Add(new Rectangle(350, 80, 180, insideWall));
            walls.Add(new Rectangle(350, 120, 180, insideWall));
            walls.Add(new Rectangle(350, 160, 180, insideWall));

            //i - d
            walls.Add(new Rectangle(350, 280, 180, insideWall));
            walls.Add(new Rectangle(350, 320, 180, insideWall));
            walls.Add(new Rectangle(350, 360, 180, insideWall));
            //ghost house
            walls.Add(new Rectangle(380, 200, 130, 48));
        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                //second key controls
                case Keys.W:
                    wDown = true;
                    pacMan.direction = "up";
                    break;
                case Keys.A:
                    aDown = true;
                    pacMan.direction = "left";
                    break;
                case Keys.S:
                    sDown = true;
                    pacMan.direction = "down";
                    break;
                case Keys.D:
                    dDown = true;
                    pacMan.direction = "right";
                    break;
                //regular arrow keys
                case Keys.Up:
                    upArrowDown = true;
                    pacMan.direction = "up";
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    pacMan.direction = "left";
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    pacMan.direction = "down";
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    pacMan.direction = "right";
                    break;
            }
        }
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //second key controls
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
               //regular arrow keys
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
    }
}
