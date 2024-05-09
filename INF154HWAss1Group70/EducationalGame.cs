using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF154HWAss1Group70
{
    public partial class EducationalGame : Form
    {
        //Global Variables
        //Game Variables
        Random rnd = new Random();
        string[] Maths = { "Add", "Subtract", "Multiply" };
        string[] nameStorage = new string[10];
        int[] scoreStorage = new int [10];
        int total, userScore;
        string userName;
        int lives = 3;
        int ticks = 31;
        int index = 0;




        public EducationalGame()
        {
            InitializeComponent();    
        }


        //Maths Game Method
        private void SetUpGame()
        {
            //Variables
            int Num1 = rnd.Next(10, 21);
            int Num2 = rnd.Next(1, 11);

            //Input
            txtAnswer.Text = null;

            //Process | Calculates the correct answers for each sum displayed to user.
            switch (Maths[rnd.Next(0, Maths.Length)])
            {
                case "Add":
                    total = Num1 + Num2;
                    lblOperationSign.Text = "+";
                    lblOperationSign.ForeColor = Color.DarkGreen;
                    break;

                case "Subtract":
                    total = Num1 - Num2;
                    lblOperationSign.Text = "-";
                    lblOperationSign.ForeColor = Color.Maroon;
                    break;

                case "Multiply":
                    total = Num1 * Num2;
                    lblOperationSign.Text = "x";
                    lblOperationSign.ForeColor = Color.Purple;
                    break;
            }
            //Input | Updates Num variables
            lblNum1.Text = Num1.ToString();
            lblNum2.Text = Num2.ToString();
        }



        //Timer Method
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Input & Process | Decreases timer by 1 second a tick. Uses the lblTimer to display the remaining time
            ticks--;
            lblTimeLeft.Text = "Time Left: " + ticks.ToString();
            lblTimeLeft.ForeColor = Color.Gold;

            //Process | Stops the game when the timer reaches 0 and displays user score if user lives left are > 0
            if (ticks == 0)
            {
                timer1.Stop();
                MessageBox.Show("You have run out of time!\n\nYou had " + lives + " lives left. \n\nYour final score is: " + userScore);
            }
        }



        //Validates if the user entry has no errors or unaccepted characters
        private void CheckAnswer(object sender, EventArgs e)
        {
            //Process | Decision statement to check for numbers only in the txtAnswer textbox. If letters or symbols are used, if statement executed
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswer.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!");
                txtAnswer.Text = txtAnswer.Text.Remove(txtAnswer.Text.Length - 1);
            }
        }


        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            //Process | Determines whether user input is correct. Displays specific output based on user input.
            double userEntered = Convert.ToDouble(txtAnswer.Text);
            if (userEntered == total)
            {
                lblStatus.Text = "Correct!";
                lblStatus.ForeColor = Color.Lime;
                userScore += 1;
                lblScore.Text = "Score: " + userScore;
                SetUpGame();
            }
            else
            {
                lblStatus.Text = "Incorrect!";
                lblStatus.ForeColor = Color.Red;
                lives -= 1;
                lblLives.Text = "Lives: " + lives;
                SetUpGame();
            }

            //Process | If user answers incorrectly 3 times, game ends and output displayed.
            if (lives == 0)
            {
                MessageBox.Show("You have run out of lives! \nYour final score is: " + userScore);
                timer1.Stop();
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            userName = txtUsername.Text;
            nameStorage[index] = userName;
            scoreStorage[index] = userScore;
           
            lstLeaderboardOutput.Items.Add("Username: " + nameStorage[index] + "\t" + "\t" + "Score: " + scoreStorage[index]);
            index++;
        }







        //Buttons
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (ticks == 0 || lives == 0)
            {
                lives = 3;
                userScore = 0;
                ticks = 31;
                lblLives.Text = "Lives: " + lives;
                lblScore.Text = "Score: " + userScore;
                lblStatus.Text = "";
            }



            tabControl1.SelectTab(1);
            SetUpGame();
            timer1.Stop();
            timer1.Start();
        }

        private void btnMainMenu1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void btnMainMenu2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btnMainMenu3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
    }
}
