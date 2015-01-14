using System.Drawing;
using System.Windows.Forms;
using TicTacToeGameLogic;

namespace TicTacToeGameFormUi
{
    internal class GameCellButton : Button
    {
        internal const int k_ButtonSize = 50;

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
        internal int RowIndex { get; set; }
        internal int ColIndex { get; set; }

        internal GameCellButton(int i_RowIndex, int i_ColIndex, Point i_Location)
        {
            RowIndex = i_RowIndex;
            ColIndex = i_ColIndex;
            Location = i_Location;
            initializeComponent();
        }

        private void initializeComponent()
        {
            Size = new Size(k_ButtonSize, k_ButtonSize);
            Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, ((177)));
        }
    }
}
