using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeGameLogic;

namespace TicTacToeGameFormUi
{
    public partial class BoardView : Form
    {
        private readonly SettingsView r_SettingsView = new SettingsView();
        private bool m_SecondPlayerIsHuman;
        private string m_FirstPlayerName;
        private string m_SecondPlayerName;
        private int m_BoardSize;

        private GameCellButton[,] m_BoardGameCells;
        private GameManager m_GameManager;

        public BoardView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs i_E)
        {
            base.OnLoad(i_E);
            DialogResult dialogResult = r_SettingsView.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                initializeSettings();
                initializeGame();
                initializeBoard();
                initializeRound();
            }
            else
            {
                Close();
            }
        }

        private void initializeRound()
        {
            m_GameManager.InitializeRound();
            setPlayersTurns();
            updateLablesText();
        }

        private void initializeGame()
        {
            m_GameManager = new GameManager();
            Enums.eGameType gameType = m_SecondPlayerIsHuman
                ? Enums.eGameType.PlayerVsPlayer
                : Enums.eGameType.PlayerVsComputer;
            string errorMessage = string.Empty;

            m_GameManager.InitializeGame(m_BoardSize, gameType, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewHelpers.RaiseErrorMessage(errorMessage, "Initialize Game Error!");
            }
            m_GameManager.RoundIsOver += m_GameManager_RoundIsOver;
            m_GameManager.CellValueChanged += m_GameManager_CellValueChanged;

        }

        private void updateLablesText()
        {
            int firstPlayerPoints = m_GameManager != null ? m_GameManager.PlayerOnePoints : 0;
            int secondPlayerPoints = m_GameManager != null ? m_GameManager.PlayerTwoPoints : 0;
            firstPlayerNameLabel.Text = m_FirstPlayerName + " :" + firstPlayerPoints.ToString();
            secondPlayerNameLabel.Text = m_SecondPlayerName + " :" + secondPlayerPoints.ToString();
        }

        private void setPlayersTurns()
        {
            switch (m_GameManager.CurrentPlayerTurn)
            {
                case Enums.ePlayer.PlayerOne:
                case Enums.ePlayer.Player:
                    firstPlayerNameLabel.Font = new Font(firstPlayerNameLabel.Font, FontStyle.Bold);
                    secondPlayerNameLabel.Font = new Font(secondPlayerNameLabel.Font, FontStyle.Regular);
                    break;
                case Enums.ePlayer.PlayerTwo:
                case Enums.ePlayer.Computer:
                    firstPlayerNameLabel.Font = new Font(firstPlayerNameLabel.Font, FontStyle.Regular);
                    secondPlayerNameLabel.Font = new Font(secondPlayerNameLabel.Font, FontStyle.Bold);
                    break;
            }
        }

        private void initializeBoard()
        {
            const int k_SpaceBetweenButtons = 6;
            const int k_PaddingSpace = 12;

            int clientSizeWidth = m_BoardSize * GameCellButton.k_ButtonSize + (m_BoardSize - 1) * k_SpaceBetweenButtons
                                  + k_PaddingSpace * 2;
            int clientSizeHeight = clientSizeWidth + firstPlayerNameLabel.Height + k_PaddingSpace * 2;
            ClientSize = new Size(clientSizeWidth, clientSizeHeight);

            int namesLabelsLength = firstPlayerNameLabel.Width + k_PaddingSpace + secondPlayerNameLabel.Width;

            firstPlayerNameLabel.Location = new Point((clientSizeWidth / 2) - (namesLabelsLength / 2),
                clientSizeHeight - firstPlayerNameLabel.Height - k_PaddingSpace);
            secondPlayerNameLabel.Location = new Point(firstPlayerNameLabel.Right + k_PaddingSpace,
                firstPlayerNameLabel.Top);

            createGameCellButtons(k_PaddingSpace, k_SpaceBetweenButtons);
        }

        private void createGameCellButtons(int i_PaddingSpace, int i_SpaceBetweenButtons)
        {
            m_BoardGameCells = new GameCellButton[m_BoardSize, m_BoardSize];
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_BoardGameCells[i, j] == null)
                    {
                        Point currentButtonPoint = new Point(
                            i_PaddingSpace + i * (GameCellButton.k_ButtonSize + i_SpaceBetweenButtons),
                            i_PaddingSpace + j * (GameCellButton.k_ButtonSize + i_SpaceBetweenButtons));
                        GameCellButton gameCellButton = new GameCellButton(i, j, currentButtonPoint);
                        gameCellButton.Click += gameCellButton_Click;
                        Controls.Add(gameCellButton);
                        m_BoardGameCells[i, j] = gameCellButton;
                    }
                }
            }
        }

        private void initializeSettings()
        {
            m_SecondPlayerIsHuman = r_SettingsView.SecondPlayerIsHuman;
            m_BoardSize = r_SettingsView.BoardSize;
            m_FirstPlayerName = r_SettingsView.FirstPlayerName;
            m_SecondPlayerName = r_SettingsView.SecondPlayerName;
            updateLablesText();
        }

        private void gameCellButton_Click(object i_Sender, EventArgs i_E)
        {
            GameCellButton clickedButton = i_Sender as GameCellButton;

            if (clickedButton != null)
            {
                m_GameManager.SetNextMove(clickedButton.RowIndex, clickedButton.ColIndex);
            }
            setPlayersTurns();
        }

        private void m_GameManager_CellValueChanged(GameCell i_SelectedGameCell)
        {
            m_BoardGameCells[i_SelectedGameCell.RowIndex, i_SelectedGameCell.ColumnIndex].CellValue =
                i_SelectedGameCell.Value;
        }

        private void m_GameManager_RoundIsOver(Enums.eGameState i_RoundState)
        {
            string messageToUser = string.Empty;

            switch (i_RoundState)
            {
                case Enums.eGameState.Tie:
                    messageToUser = "It's a tie";
                    break;
                case Enums.eGameState.FirstPlayerWon:
                    messageToUser = m_FirstPlayerName + " win";
                    break;
                case Enums.eGameState.SecondPlayerWon:
                    messageToUser = m_SecondPlayerName + " win";
                    break;
            }
            DialogResult roundOverDialogResult =
                ViewHelpers.RaiseYesNoQuestion(string.Format("{0}, do you want to play another round?", messageToUser),
                    "Round over!");

            if (roundOverDialogResult == DialogResult.Yes)
            {
                initializeRound();
            }
            else
            {
                Close();
            }
        }
    }
}
