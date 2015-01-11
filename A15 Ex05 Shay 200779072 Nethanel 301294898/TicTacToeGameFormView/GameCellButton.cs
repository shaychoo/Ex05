using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TicTacToeGameLogic;

namespace TicTacToeGameFormView
{
    internal class GameCellButton : Button
    {
        internal Enums.eCellValue CellValue
        {
            set
            {
                switch (value)
                {
                    case Enums.eCellValue.Blank:
                        Text = string.Empty;
                        Enabled = true;
                        break;
                    case Enums.eCellValue.X:
                    case Enums.eCellValue.O:
                        Text = value.ToString();
                        Enabled = false;
                        break;
                }
            }
        }

        internal int RowIndex { get; private set; }
        internal int ColIndex { get; private set; }

        internal GameCellButton(int i_RowIndex, int i_ColIndex, Point i_Point,Size i_Size)
        {
            RowIndex = i_RowIndex;
            ColIndex = i_ColIndex;
            Location = i_Point;
            Size = i_Size;
            initializeComponent();
        }

        private void initializeComponent()
        {
            Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, ((177)));
            UseVisualStyleBackColor = true;
        }
    }
}
