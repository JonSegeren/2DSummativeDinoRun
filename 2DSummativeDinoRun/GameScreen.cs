using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


 

//A way to restart once the game is over, (back to main screen)

//A way to pause/exit, (if you can). 

//Plays fullscreen without any window borders or mouse cursor visible.

//Must work with arcade controls as shown below. --this works for gs but not ms yet

namespace _2DSummativeDinoRun
{
    public partial class GameScreen : UserControl
    {

        #region global variables

        SolidBrush gameBrush = new SolidBrush(Color.SlateGray);
        List<Box> cactusList = new List<Box>();

        SoundPlayer fail = new SoundPlayer(Properties.Resources.collision);
        SoundPlayer jump = new SoundPlayer(Properties.Resources.score);

        Box player;
     
        int timerCount = 0;
        int xSpeed = 3;
        Random xGen = new Random();
        int genNewBox = 30;
        //key variables
        bool spaceDown;
        bool nDown;
        bool mDown;
        bool bDown;

        int jumpDuckX = 8;
        int jumpDuckY = 20;
        int jHeight = 9;
        int speedUp = 0;
        Font scoreFont = new Font("Segoe UI",16);

        bool gameOver = false;

        #endregion

        public GameScreen()
        {
            InitializeComponent();
            int screenScore = Form1.score;
            Restart();
        }

        #region Keys

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {    
            switch (e.KeyCode)
            {
                case Keys.N:
                    nDown = true;
                    jump.Play();
                    break;
                case Keys.Space:
                    spaceDown = true;
                    jump.Play();
                    break;
                case Keys.M:
                    mDown = true;
                    jump.Play();
                    break;
                case Keys.B:
                    bDown = true;
                    jump.Play();
                    break;
                case Keys.Escape:
                    ((Form1)this.TopLevelControl).Close();
                    break;
            }
        }
        #endregion

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timerCount++;
            Form1.score++;
            speedUp++;

            #region player movement

            if (nDown == true|| mDown == true || bDown == true|| spaceDown == true)
            {     
                player.Jump(jHeight);
                jHeight--;

                if (jHeight < -9)
                {
                    jHeight = 9;
                    nDown = false;
                    spaceDown = false;
                    mDown = false;
                    bDown = false;
                }
            }

            #endregion

            #region box movement


            foreach (Box b in cactusList)
            {
                b.Move(xSpeed);
            }

            //this increases the speed of boxes every 250 of points
            if (speedUp % 250 == 0)
            {
                speedUp = 0;
                xSpeed++;
            }

            if (timerCount % genNewBox == 0)
            {
                timerCount = 0;
                int boxHeight = xGen.Next(5, 30);
                int boxWidth = xGen.Next(5, 20);
                Box b2 = new Box(this.Width, this.Height/2+50 - boxHeight , boxWidth, boxHeight);

                cactusList.Add(b2);
                genNewBox = xGen.Next(20,100);
            }

            if (700 < Form1.score && Form1.score < 900)
            {
                gameBrush.Color = Color.WhiteSmoke;
                BackColor = Color.Black;
            }
            else
            {
                gameBrush.Color = Color.SlateGray;
                BackColor = Color.WhiteSmoke;
            }
            #endregion

            #region box collision

            
            foreach (Box b in cactusList)
            {
                if (player.Collision(b) == true)
                { 
                    EndGame();
                }
            }

            
            #endregion
           this.Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(gameBrush, 0, this.Height / 2 + 50, this.Width, 3);
            e.Graphics.FillRectangle(gameBrush, player.x, player.y, player.xSize, player.ySize);
            e.Graphics.DrawString(Form1.score +" ", scoreFont, gameBrush, 10, 10);

            foreach (Box b in cactusList)
            {
                e.Graphics.FillRectangle(gameBrush, b.x, b.y, b.xSize, b.ySize);
            }

            if (gameOver == true)
            {
                e.Graphics.DrawString("Game Over!", scoreFont, gameBrush, Width - 150, 10);
                e.Graphics.DrawString("Score: " + Form1.score, scoreFont, gameBrush, Width - 150, 30);
                e.Graphics.DrawString("Press m, b to exit", scoreFont, gameBrush, 50, Height / 3);
                e.Graphics.DrawString("Press n, space to restart", scoreFont, gameBrush, 50, Height / 3 + 20);
            }
        }


        private void Restart()
        {
            cactusList.Clear();
            Form1.score = 0;
            speedUp = 0;
            timerCount = 0;
            xSpeed = 3;
            player = new Box(50, Height / 2 + 30, jumpDuckX, jumpDuckY);
            Box b1 = new Box(Width, Height / 2 + 30, 8, 8);
            cactusList.Add(b1);
        }

        public void EndGame()
        {
            gameOver = true;
            fail.Play();
            gameTimer.Stop();

            if (spaceDown == true)
            {
                ((Form1)this.TopLevelControl).Close();
            }
        }
    }
}
