namespace TicTacToeGameLogic
{
    public delegate void CellValueChangedHandler(GameCell i_SelectedGameCell);
    public class GameCell
    {
        private Enums.eCellValue m_Value;

        public event CellValueChangedHandler CellValueChanged;
        internal GameCell(int i_RowIndex, int i_ColumnIndex)
        {
            RowIndex = i_RowIndex;
            ColumnIndex = i_ColumnIndex;
        }

        public int RowIndex { get; private set; }
        public int ColumnIndex { get; private set; }

        internal bool IsFree
        {
            get { return Value == Enums.eCellValue.Blank; }
        }

        public Enums.eCellValue Value
        {
            get { return m_Value; }
            internal set
            {
                m_Value = value;
                if (CellValueChanged != null)
                {
                    CellValueChanged.Invoke(this);
                }
            }
        }
    }
}