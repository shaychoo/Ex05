using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TicTacToeGameLogic;

namespace TicTacToeGameFormView
{
    public class BoardView : Form
    {
        private const int k_ButtonSize = 50;
        private const int k_SpaceBetweenButtons = 6;
        private const int k_PaddingSpace = 12;

        private readonly Size r_ButtonSize = new Size(k_ButtonSize, k_ButtonSize);

        private bool m_SecondPlayerIsHuman;
        private string m_FirstPlayerName;
        private string m_SecondPlayerName;
        private int m_BoardSize;

        private GameCellButton[,] m_BoardGameCells;
        private Label label1;
        private Label label2;
        private GameManager m_GameManager;

        public BoardView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initializeGameSettings();
            initializeBoard();
            initializeGame();
            m_GameManager.InitializeRound();
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
                ViewHelpers.RaiseErrorMessage(errorMessage);
            }
            m_GameManager.RoundIsOver += m_GameManager_OnRoundIsOver;
            m_GameManager.CellValueChanged += m_GameManager_CellValueChanged;
            updateLablesText();
        }

        void m_GameManager_CellValueChanged(GameCell i_SelectedGameCell)
        {
            m_BoardGameCells[i_SelectedGameCell.RowIndex, i_SelectedGameCell.ColumnIndex].CellValue =
                i_SelectedGameCell.Value;
        }

        void m_GameManager_OnRoundIsOver(Enums.eGameState i_FinalGameState)
        {
            MessageBox.Show(i_FinalGameState.ToString());
        }

        private void updateLablesText()
        {
            label1.Text = m_FirstPlayerName + " :" + m_GameManager.PlayerOnePoints;
            label2.Text = m_SecondPlayerName + " :" + m_GameManager.PlayerTwoPoints;
        }

        private void setPlayersTurns()
        {
            switch (m_GameManager.CurrentPlayerTurn)
            {
                case Enums.ePlayer.PlayerOne:
                case Enums.ePlayer.Player:
                    label1.Font = new Font(label1.Font, FontStyle.Bold);
                    label2.Font = new Font(label1.Font, FontStyle.Regular);
                    break;
                case Enums.ePlayer.PlayerTwo:
                case Enums.ePlayer.Computer:
                    label1.Font = new Font(label1.Font, FontStyle.Regular);
                    label2.Font = new Font(label1.Font, FontStyle.Bold);
                    break;
            }
        }

        private void initializeBoard()
        {
            int width = m_BoardSize * k_ButtonSize + (m_BoardSize - 1) * k_SpaceBetweenButtons + k_PaddingSpace * 2;
            int height = width + label1.Height + k_PaddingSpace * 2;

            int length = label1.Width + k_PaddingSpace + label2.Width;
            label1.Location = new Point((width / 2) - (length / 2), height - label1.Height - k_PaddingSpace);
            label2.Location = new Point(label1.Right + k_PaddingSpace, label1.Top);
            m_BoardGameCells = new GameCellButton[m_BoardSize, m_BoardSize];
            this.ClientSize = new Size(width, height);

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_BoardGameCells[i, j] == null)
                    {
                        Point currentButtonPoint = new Point(
                            k_PaddingSpace + i * (k_ButtonSize + k_SpaceBetweenButtons),
                            k_PaddingSpace + j * (k_ButtonSize + k_SpaceBetweenButtons));
                        GameCellButton gameCellButton = new GameCellButton(i, j, currentButtonPoint, r_ButtonSize);
                        gameCellButton.Click += boardButton_Click;
                        Controls.Add(gameCellButton);
                        m_BoardGameCells[i, j] = gameCellButton;
                    }
                }
            }
        }

        private void initializeGameSettings()
        {
            SettingsView settingsView = new SettingsView();
            DialogResult dialogResult = settingsView.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                closeGame();
            }
            else
            {
                m_SecondPlayerIsHuman = settingsView.SecondPlayerIsHuman;
                m_BoardSize = settingsView.BoardSize;
                m_FirstPlayerName = settingsView.FirstPlayerName;
                m_SecondPlayerName = settingsView.SecondPlayerName;
            }
        }

        private void closeGame()
        {
            MessageBox.Show("Goodbye!");
            this.Close();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(103, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(144, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BoardView
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BoardView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            GameCellButton clickedButton = sender as GameCellButton;

            if (clickedButton != null)
            {
                m_GameManager.SetNextMove(clickedButton.RowIndex, clickedButton.ColIndex);
            }
            setPlayersTurns();
        }
    }
}
