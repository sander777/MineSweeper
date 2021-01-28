using System.Windows.Forms;
using System;
using System.Drawing;

namespace MyMineSweeper
{
    partial class MineSweeperForm
    {

        Label timerText = new Label();

        Label flagToMine = new Label();
        ToolStrip menu = new ToolStrip();
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
            this.Name = "MineSweeperForm";
            this.Text = "MineSweeperForm";

            this.timerText.Text = "0:0:0";
            this.timerText.ForeColor = Color.Red;
            this.timerText.Size = new System.Drawing.Size(200, 80);
            this.timerText.Font = new Font("Arial", 24, FontStyle.Bold); ;
            this.Controls.Add(timerText);

            this.flagToMine.Text = $"0\\{M}";
            this.flagToMine.ForeColor = Color.Red;
            this.flagToMine.Size = new System.Drawing.Size(100, 80);
            this.flagToMine.Font = new Font("Arial", 22, FontStyle.Bold); ;
            this.Controls.Add(flagToMine);

            ToolStripMenuItem changeSize = new ToolStripMenuItem("Change Size");
            changeSize.Click += ChangeSizeHandler;
            menu.Items.Add(changeSize);
            this.Controls.Add(menu);


            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        #endregion
    }
}

