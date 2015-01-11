using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TicTacToeGameFormView
{
    internal static class ViewHelpers
    {
       internal static void RaiseErrorMessage(string i_ErrorMessage)
       {
           MessageBox.Show(i_ErrorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
    }
}
