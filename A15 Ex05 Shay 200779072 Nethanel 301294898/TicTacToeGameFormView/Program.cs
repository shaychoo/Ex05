using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGameFormView
{
    class Program
    {
        public static void Main(string[] args)
        {
            TicTacToeGameBoard ticTacToe = new TicTacToeGameBoard();
            ticTacToe.ShowDialog();
        }
    }
}
