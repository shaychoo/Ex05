namespace TicTacToeGameFormUi
{
    partial class BoardView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstPlayerNameLabel = new System.Windows.Forms.Label();
            this.secondPlayerNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstPlayerNameLabel
            // 
            this.firstPlayerNameLabel.AutoSize = true;
            this.firstPlayerNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.firstPlayerNameLabel.Location = new System.Drawing.Point(103, 240);
            this.firstPlayerNameLabel.Name = "firstPlayerNameLabel";
            this.firstPlayerNameLabel.Size = new System.Drawing.Size(35, 13);
            this.firstPlayerNameLabel.TabIndex = 0;
            this.firstPlayerNameLabel.Text = "label1";
            this.firstPlayerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondPlayerNameLabel
            // 
            this.secondPlayerNameLabel.AutoSize = true;
            this.secondPlayerNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.secondPlayerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.secondPlayerNameLabel.Location = new System.Drawing.Point(144, 240);
            this.secondPlayerNameLabel.Name = "secondPlayerNameLabel";
            this.secondPlayerNameLabel.Size = new System.Drawing.Size(41, 13);
            this.secondPlayerNameLabel.TabIndex = 1;
            this.secondPlayerNameLabel.Text = "label2";
            this.secondPlayerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BoardView
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.secondPlayerNameLabel);
            this.Controls.Add(this.firstPlayerNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BoardView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label secondPlayerNameLabel;
        private System.Windows.Forms.Label firstPlayerNameLabel;
    }
}