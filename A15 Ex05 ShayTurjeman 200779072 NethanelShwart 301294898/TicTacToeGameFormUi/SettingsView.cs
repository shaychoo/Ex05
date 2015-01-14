using System;
using System.Windows.Forms;

namespace TicTacToeGameFormUi
{
    public partial class SettingsView : Form
    {
        private const string k_SecondUserComputerName = "Computer";

        public bool SecondPlayerIsHuman
        {
            get { return secondPlayerIsHumanCheckBox.Checked; }
        }

        public string FirstPlayerName
        {
            get
            {
                return playerOneTextBox.Text;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return playerTwoTextBox.Text;
            }
        }

        public int BoardSize
        {
            get
            {
                return (int)rowsNumericUpDown.Value;
            }
        }

        public SettingsView()
        {
            InitializeComponent();
            setSecondPlayerComputer();
        }

        private void secondPlayerCheckBox_CheckedChanged(object i_Sender, EventArgs i_E)
        {
            if (SecondPlayerIsHuman)
            {
                setSecondPlayerHuman();
            }
            else
            {
                setSecondPlayerComputer();
            }
        }

        private void numericUpDown_ValueChanged(object i_Sender, EventArgs i_E)
        {
            if (i_Sender == rowsNumericUpDown)
            {
                colsNumericUpDown.Value = rowsNumericUpDown.Value;
            }
            else
            {
                rowsNumericUpDown.Value = colsNumericUpDown.Value;
            }
        }

        private void startButton_Click(object i_Sender, EventArgs i_E)
        {
            string errorMessage;
            if (validateNamesInput(out errorMessage))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ViewHelpers.RaiseErrorMessage(errorMessage, "Name Error!");
            }
        }

        private void setSecondPlayerComputer()
        {
            playerTwoTextBox.Enabled = false;
            playerTwoTextBox.Text = k_SecondUserComputerName;
        }

        private void setSecondPlayerHuman()
        {
            playerTwoTextBox.Enabled = true;
            playerTwoTextBox.Text = string.Empty;
        }

        private bool validateNamesInput(out string o_ErrorMessage)
        {
            bool result = true;
            o_ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(playerOneTextBox.Text.Trim()))
            {
                result = false;
                o_ErrorMessage = "Please enter first player name";
            }
            else if (SecondPlayerIsHuman && string.IsNullOrEmpty(playerTwoTextBox.Text.Trim()))
            {
                result = false;
                o_ErrorMessage = "Please enter second player name";
            }

            return result;
        }
    }
}
