using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TicTacToeGameFormView
{
    public class SettingsView : Form
    {
        private const string k_SecondUserComputerName = "[Computer]";
        private Label label1;
        private Label label2;
        private CheckBox secondPlayerIsHumanCheckBox;
        private Label label3;
        private NumericUpDown rowsNumericUpDown;
        private Label label4;
        private NumericUpDown colsNumericUpDown;
        private Label label5;
        private TextBox playerOneTextBox;
        private TextBox playerTwoTextBox;
        private Button startButton;
    
        public SettingsView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            setSecondPlayerComputer();
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

       

        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.secondPlayerIsHumanCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.colsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.playerOneTextBox = new System.Windows.Forms.TextBox();
            this.playerTwoTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(15, 147);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(193, 27);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 1:";
            // 
            // secondPlayerIsHumanCheckBox
            // 
            this.secondPlayerIsHumanCheckBox.AutoSize = true;
            this.secondPlayerIsHumanCheckBox.Location = new System.Drawing.Point(23, 60);
            this.secondPlayerIsHumanCheckBox.Name = "secondPlayerIsHumanCheckBox";
            this.secondPlayerIsHumanCheckBox.Size = new System.Drawing.Size(67, 17);
            this.secondPlayerIsHumanCheckBox.TabIndex = 3;
            this.secondPlayerIsHumanCheckBox.Text = "Player 2:";
            this.secondPlayerIsHumanCheckBox.UseVisualStyleBackColor = true;
            this.secondPlayerIsHumanCheckBox.CheckedChanged += new System.EventHandler(this.secondPlayerCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Board Size:";
            // 
            // rowsNumericUpDown
            // 
            this.rowsNumericUpDown.Location = new System.Drawing.Point(65, 113);
            this.rowsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rowsNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.rowsNumericUpDown.Name = "rowsNumericUpDown";
            this.rowsNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.rowsNumericUpDown.TabIndex = 7;
            this.rowsNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.rowsNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rows:";
            // 
            // colsNumericUpDown
            // 
            this.colsNumericUpDown.Location = new System.Drawing.Point(162, 113);
            this.colsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.colsNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.colsNumericUpDown.Name = "colsNumericUpDown";
            this.colsNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.colsNumericUpDown.TabIndex = 9;
            this.colsNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.colsNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cols:";
            // 
            // playerOneTextBox
            // 
            this.playerOneTextBox.Location = new System.Drawing.Point(88, 32);
            this.playerOneTextBox.Name = "playerOneTextBox";
            this.playerOneTextBox.Size = new System.Drawing.Size(124, 20);
            this.playerOneTextBox.TabIndex = 2;
            // 
            // playerTwoTextBox
            // 
            this.playerTwoTextBox.Location = new System.Drawing.Point(88, 58);
            this.playerTwoTextBox.Name = "playerTwoTextBox";
            this.playerTwoTextBox.Size = new System.Drawing.Size(124, 20);
            this.playerTwoTextBox.TabIndex = 4;
            // 
            // SettingsView
            // 
            this.AcceptButton = this.startButton;
            this.ClientSize = new System.Drawing.Size(224, 188);
            this.Controls.Add(this.playerTwoTextBox);
            this.Controls.Add(this.playerOneTextBox);
            this.Controls.Add(this.colsNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rowsNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secondPlayerIsHumanCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void secondPlayerCheckBox_CheckedChanged(object sender, EventArgs e)
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

        public bool SecondPlayerIsHuman { get { return secondPlayerIsHumanCheckBox.Checked; } }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender == rowsNumericUpDown)
            {
                colsNumericUpDown.Value = rowsNumericUpDown.Value;
            }
            else
            {
                rowsNumericUpDown.Value = colsNumericUpDown.Value;
            }
        }
    }
}
