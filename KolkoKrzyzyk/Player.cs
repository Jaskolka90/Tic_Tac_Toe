using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoKrzyzyk
{
    public class Player
    {
        int score;
        Symbol symbol;

        public int Score { get { return score; } set { score = value; } }
        public Symbol Symbol { get { return symbol; } set { symbol = value; } }

        public Player(Symbol s)
        {
            this.score = 0;
            this.symbol = s; 
        }

        public override string ToString()
        {
            return (symbol == Symbol.Circle) ? "O" : "X";
        }
    }
}
