using System.Windows.Forms;

namespace TicTacToeGameFormUi
{
    internal static class ViewHelpers
    {
        internal static void RaiseErrorMessage(string i_ErrorMessage, string i_Caption)
        {
            MessageBox.Show(i_ErrorMessage, i_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static DialogResult RaiseYesNoQuestion(string i_Question, string i_Caption)
        {
            return MessageBox.Show(i_Question, i_Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
