namespace TicTacToeGameLogic
{
    public class GameManager
    {
        private GameLogic m_GameLogic;

        public Enums.eGameState GameState
        {
            get { return m_GameLogic.GameState; }
        }

        public Enums.eGameState FinalGameState
        {
            get { return m_GameLogic.FinalGameState; }
        }

        public Enums.eGameType GameType
        {
            get { return m_GameLogic.GameType; }
        }

        public GameCell LastSelectedCell
        {
            get { return m_GameLogic.LastSelectedCell; }
        }

        public int BoardSize
        {
            get { return m_GameLogic.BoradSize; }
        }

        public GameCell[,] BoardGameCells
        {
            get { return m_GameLogic.BoradGameCells; }
        }

        public int PlayerOnePoints
        {
            get { return m_GameLogic.FirstPlayerPoints; }
        }

        public int PlayerTwoPoints
        {
            get { return m_GameLogic.SecondePlayerPoints; }
        }

        public Enums.ePlayer CurrentPlayerTurn
        {
            get { return m_GameLogic.CurrentPlayerTurn; }
        }

        public void InitializeGame(int i_BoardSize, Enums.eGameType i_GameType, ref string io_ErrorMessage)
        {
            if (i_BoardSize < GameLogic.k_MinimumBoardSize || i_BoardSize > GameLogic.k_MaximumBoardSize)
            {
                io_ErrorMessage = "Board size is illegal!";
            }
            else if (i_GameType != Enums.eGameType.PlayerVsComputer
                     && i_GameType != Enums.eGameType.PlayerVsPlayer)
            {
                io_ErrorMessage = "Game type is illegal!";
            }
            else
            {
                m_GameLogic = new GameLogic(i_BoardSize, i_GameType);
                m_GameLogic.RoundOver += m_GameLogic_RoundOver;
                m_GameLogic.CellValueChanged += m_GameLogic_CellValueChanged;

            }
        }



        public void InitializeRound()
        {
            m_GameLogic.InitializeRound();
        }

        public void SetNextMove(int i_RowIndex, int i_ColumnIndex)
        {
            GameCell wantedGameCell = BoardGameCells[i_RowIndex, i_ColumnIndex];
            m_GameLogic.NextPlayerMove(wantedGameCell);
        }

        public void UserQuit()
        {
            m_GameLogic.UserQuit();
        }

        public event RoundIsOverHandler RoundIsOver;

        protected virtual void OnRoundIsOver(Enums.eGameState i_RoundState)
        {
            if (RoundIsOver != null)
            {
                RoundIsOver.Invoke(i_RoundState);
            }
        }

        private void m_GameLogic_RoundOver(Enums.eGameState i_FinalGameState)
        {
            OnRoundIsOver(i_FinalGameState);
        }

        public event CellValueChangedHandler CellValueChanged;

        protected virtual void OnCellValueChanged(GameCell i_GameCell)
        {
            if (CellValueChanged != null)
            {
                CellValueChanged.Invoke(i_GameCell);
            }
        }

        private void m_GameLogic_CellValueChanged(GameCell i_SelectedGameCell)
        {
            OnCellValueChanged(i_SelectedGameCell);
        }
    }
}