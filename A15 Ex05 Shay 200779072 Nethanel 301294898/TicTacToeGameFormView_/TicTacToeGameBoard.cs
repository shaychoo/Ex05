using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TicTacToeGameFormView
{
    

    class TicTacToeGameBoard :Form
    {
    
        public TicTacToeGameBoard()
        {
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TicTacToeGameBoard
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "TicTacToeGameBoard";
            this.Text = "Tic Tac Toe";
            this.ResumeLayout(false);

        }
      
    }
}
