using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create guess variable to track what part of the pattern the user is at
        public static int patternNum;
        public static int playerGuess;
       
        int rand = 0;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.patternList.Clear();
            Refresh();
            Thread.Sleep(500);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            rand = Form1.randNum.Next(0, 4);
            Form1.patternList.Add(rand);
         
            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.patternList.Count; i++)
            {
                if (Form1.patternList[i] == 0)
                {

                    greenButton.BackColor = Color.Lime;
                    SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.green);
                    soundPlayer.Play();
                    Refresh();
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                    Thread.Sleep(600);
                }
                else if (Form1.patternList[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.red);
                    soundPlayer.Play();
                    Refresh();
                    Thread.Sleep(500);
                    redButton.BackColor = Color.DarkRed;
                    Thread.Sleep(600);
                }
                else if (Form1.patternList[i] == 2)
                {
                    yellowButton.BackColor = Color.Yellow;
                    SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.yellow);
                    soundPlayer.Play();
                    Refresh();
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                    Thread.Sleep(600);
                }
                else if (Form1.patternList[i] == 3)
                {
                      blueButton.BackColor = Color.Blue;
                    SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.blue);
                    soundPlayer.Play();
                    Refresh();
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.DarkBlue;
                    Thread.Sleep(600);
                }


            }
            //TODO: get guess index value back to 0
            playerGuess = 0;
        }

        public void GameOver()
        {
            //TODO: Play a game over sound
            SoundPlayer overSound = new SoundPlayer(Properties.Resources.red);
            overSound.Play();
            //TODO: close this screen and open the GameOverScreen
            Form1.ChangeScreen(this, new GameOverScreen());      
        }

        //TODO: create one of these event methods for each button

        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value at current guess index equal to a green. If so:
            // light up button, play sound, and pause
            // set button colour back to original
            // add one to the guess index
            // check to see if we are at the end of the pattern. If so:
            // call ComputerTurn() method
            // else call GameOver method

            if (Form1.patternList[playerGuess] == 0)
            {
                greenButton.BackColor = Color.Lime;
                SoundPlayer greenLightSound = new SoundPlayer(Properties.Resources.green);
                greenLightSound.Play();
                Refresh();
                Thread.Sleep(500);
                greenButton.BackColor = Color.ForestGreen;
                Refresh();
                Thread.Sleep(500);
                playerGuess++;
            }
            else
            {
                GameOver();
            }

            if (playerGuess == Form1.patternList.Count())
            {
                ComputerTurn();
            }

        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[playerGuess] == 1)
            {
                redButton.BackColor = Color.Red;
                SoundPlayer greenLightSound = new SoundPlayer(Properties.Resources.red);
                greenLightSound.Play();
                Refresh();
                Thread.Sleep(500);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                Thread.Sleep(500);
                playerGuess++;
            }

            else
            {
                GameOver();
            }

            if (playerGuess == Form1.patternList.Count())
            {
                ComputerTurn();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[playerGuess] == 2)
            {
                yellowButton.BackColor = Color.Yellow;
                SoundPlayer greenLightSound = new SoundPlayer(Properties.Resources.yellow);
                greenLightSound.Play();
                Refresh();
                Thread.Sleep(500);
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                Thread.Sleep(500);
                playerGuess++;
            }

            else
            {
                GameOver();
            }

            if (playerGuess == Form1.patternList.Count())
            {
                ComputerTurn();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[playerGuess] == 3)
            {
                blueButton.BackColor = Color.Blue;
                SoundPlayer greenLightSound = new SoundPlayer(Properties.Resources.blue);
                greenLightSound.Play();
                Refresh();
                Thread.Sleep(500);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                Thread.Sleep(500);
                playerGuess++;
            }

            else
            {
                GameOver();
            }

            if (playerGuess == Form1.patternList.Count())
            {
                ComputerTurn();
            }
        }
    }
}
