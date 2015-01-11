using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TicTacToeGameFormView
{
    public class BoardView : Form
    {
    
        public BoardView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initializeGameSettings();
            
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
                //
            }
        }

        private void closeGame()
        {
            MessageBox.Show("Goodbye!");
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BoardView
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BoardView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}
