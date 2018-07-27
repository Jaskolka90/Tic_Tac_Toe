using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoKrzyzyk
{
    public enum Symbol
    {
        Circle, 
        Cross
    }

    public class GameManager
    {
        int draw;
        Player player1;
        Player player2;
        Player turnPlayer;

        public int Draw { get { return draw; } set { draw = value; } }
        public Player Player1 { get { return player1; } }
        public Player Player2 { get { return player2; } }
        public Player TurnPlayer { get { return turnPlayer; } }

        public GameManager()
        {
            this.player1 = new Player(Symbol.Circle);
            this.player2 = new Player(Symbol.Cross);
            this.turnPlayer = player1;
            this.draw = 0;
        }

        public void changeTurn()
        {
            if (turnPlayer == player1)
                turnPlayer = player2;
            else
                turnPlayer = player1;
        }

        internal bool CheckResult(Button[,] buttonTab)
        {
            //Check horizontally
            if ((buttonTab[0, 0].Text == buttonTab[0, 1].Text && buttonTab[0, 1].Text == buttonTab[0, 2].Text) && buttonTab[0,0].Text != "")
                return true;
            else if ((buttonTab[1, 0].Text == buttonTab[1, 1].Text && buttonTab[1, 1].Text == buttonTab[1, 2].Text) && buttonTab[1, 0].Text != "")
                return true;
            else if ((buttonTab[2, 0].Text == buttonTab[2, 1].Text && buttonTab[2, 1].Text == buttonTab[2, 2].Text) && buttonTab[2, 0].Text != "")
                return true;
            //Check vertically
            else if ((buttonTab[0, 0].Text == buttonTab[1, 0].Text && buttonTab[1, 0].Text == buttonTab[2, 0].Text) && buttonTab[0, 0].Text != "")
                return true;
            else if((buttonTab[0, 1].Text == buttonTab[1, 1].Text && buttonTab[1, 1].Text == buttonTab[2, 1].Text) && buttonTab[0, 1].Text != "")
                return true;
            else if((buttonTab[0, 2].Text == buttonTab[1, 2].Text && buttonTab[1, 2].Text == buttonTab[2, 2].Text) && buttonTab[0, 2].Text != "")
                return true;
            //Check diagonally
            else if ((buttonTab[0, 0].Text == buttonTab[1, 1].Text && buttonTab[1, 1].Text == buttonTab[2, 2].Text) && buttonTab[0, 0].Text != "")
                return true;
            else if ((buttonTab[2, 0].Text == buttonTab[1, 1].Text && buttonTab[1, 1].Text == buttonTab[0, 2].Text) && buttonTab[2, 0].Text != "")
                return true;

            return false;
        }
    }
}
