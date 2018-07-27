using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoKrzyzyk
{
    public partial class Form1 : Form
    {
        int offset = 80;
        int marginX = 40;
        int marginY = 40;
        int width = 80;
        int height = 80;
        Button[,] buttonTab; 
        Label lblTurnInfo;
        Label lblPlayer1;
        Label lblPlayer2;
        Label lblDraw;
        Label lblPlayer1Count;
        Label lblPlayer2Count;
        Label lblDrawCount;
        GameManager gameManager;

        public Form1(GameManager gameManager)
        {
            InitializeComponent();
            this.gameManager = gameManager;

            #region Initialization of controls
            this.lblTurnInfo = new Label();
            this.lblPlayer1 = new Label();
            this.lblPlayer2 = new Label();
            this.lblDraw = new Label();
            this.lblPlayer1Count = new Label();
            this.lblPlayer2Count = new Label();
            this.lblDrawCount = new Label();

            lblPlayer1.SetBounds(marginX, marginY + 10 + offset * 3, 80, 30);
            lblPlayer1.Font = new Font((lblPlayer1).Font.FontFamily, 14);
            lblPlayer1.Text = string.Format("Player1");
            lblDraw.SetBounds(marginX + offset, marginY + 10 + offset * 3, 80, 30);
            lblDraw.Font = new Font((lblDraw).Font.FontFamily, 14);
            lblDraw.Text = string.Format("Draw");
            lblPlayer2.SetBounds(marginX + offset * 2, marginY + 10 + offset * 3, 80, 30);
            lblPlayer2.Font = new Font((lblPlayer2).Font.FontFamily, 14);
            lblPlayer2.Text = string.Format("Player2");
            lblPlayer1Count.SetBounds(marginX, marginY + 40 + offset * 3, 80, 30);
            lblPlayer1Count.Font = new Font((lblPlayer1Count).Font.FontFamily, 12);
            lblPlayer2Count.SetBounds(marginX + offset*2, marginY + 40 + offset * 3, 80, 30);
            lblPlayer2Count.Font = new Font((lblPlayer2Count).Font.FontFamily, 12);
            lblDrawCount.SetBounds(marginX + offset, marginY + 40 + offset * 3, 80, 30);
            lblDrawCount.Font = new Font((lblDrawCount).Font.FontFamily, 12);

            this.Controls.Add(lblTurnInfo);
            this.Controls.Add(lblPlayer1);
            this.Controls.Add(lblPlayer2);
            this.Controls.Add(lblDraw);
            this.Controls.Add(lblPlayer1Count);
            this.Controls.Add(lblPlayer2Count);
            this.Controls.Add(lblDrawCount);
            #endregion

            ToldTurn();
            ResultGame();

            //Initialize buttons
            this.buttonTab = new Button[3, 3];
            for (int i = 0; i < buttonTab.GetLength(0); i++)
            {
                for (int j = 0; j < buttonTab.GetLength(1); j++)
                {
                    buttonTab[i, j] = new Button();
                    buttonTab[i, j].Font = new Font(Font.FontFamily, 24);
                    buttonTab[i, j].SetBounds(marginX+offset*i, marginY+offset*j, width, height);
                    buttonTab[i, j].Click += ShowTurn;
                    this.Controls.Add(buttonTab[i, j]);
                }
            }
        }

        private void ToldTurn()
        {
            lblTurnInfo.SetBounds(marginX, 10, 240, 30);
            lblTurnInfo.Font = new Font((lblTurnInfo).Font.FontFamily, 14);
            lblTurnInfo.Text = string.Format("Turn: {0}", gameManager.TurnPlayer.ToString());
        }

        private void ResultGame()
        {
            lblPlayer1Count.Text = gameManager.Player1.Score.ToString();
            lblPlayer2Count.Text = gameManager.Player2.Score.ToString();
            lblDrawCount.Text = gameManager.Draw.ToString();
        }

        private void ShowTurn(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = SystemColors.ControlLight;            
            ((Button)sender).Text = gameManager.TurnPlayer.ToString();
            ((Button)sender).Enabled = false;

            if (gameManager.CheckResult(buttonTab))
            {
                gameManager.TurnPlayer.Score++;
                ResultGame();
                foreach (Button b in buttonTab)
                {
                    b.Enabled = false;  
                }
                MessageBox.Show(string.Format("The winner is: {0}!", gameManager.TurnPlayer.ToString()));
                ResetGame();
            }
            else
            {
                bool allButtonsFull = true;
                foreach (Button b in buttonTab)
                {
                    if (string.IsNullOrEmpty(b.Text))
                    {
                        allButtonsFull = false;
                    }
                }
                if (allButtonsFull)
                {                
                    gameManager.Draw++;
                    ResultGame();
                    MessageBox.Show("Is Draw!");
                    ResetGame();
                }
            }
            gameManager.changeTurn();
            ToldTurn();
        }

        private void ResetGame()
        {
            foreach (Button b in buttonTab)
            {
                b.Text = "";
                b.Enabled = true;
                ToldTurn();
            }
        }
    }
}