using System.Windows.Forms;

namespace MyMIneSweeper
{
    partial class ChangeSizeForm
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
            this.WBox = new System.Windows.Forms.ComboBox();
            this.HBox = new System.Windows.Forms.ComboBox();
            this.MBox = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WBox
            // 
            this.HBox.FormattingEnabled = true;
            this.HBox.Location = new System.Drawing.Point(31, 65);
            this.HBox.Name = "HBox";
            this.HBox.Size = new System.Drawing.Size(62, 21);
            this.HBox.TabIndex = 0;
            
            // 
            // HBox
            // 
            this.WBox.FormattingEnabled = true;
            this.WBox.Location = new System.Drawing.Point(121, 65);
            this.WBox.Name = "WBox";
            this.WBox.Size = new System.Drawing.Size(63, 21);
            this.WBox.TabIndex = 1;

            this.MBox.FormattingEnabled = true;
            this.MBox.Location = new System.Drawing.Point(72, 40);
            this.MBox.Name = "MBox";
            this.MBox.Size = new System.Drawing.Size(63, 21);
            this.MBox.TabIndex = 0;
            for (int i = 1; i < 4; i++)
            {
                MBox.Items.Add(i);
            }
            for (int i = 4; i < 21; i++)
            {
                WBox.Items.Add(i);
                HBox.Items.Add(i);
                MBox.Items.Add(i);
            }
            for (int i = 21; i < 100; i++)
            {
                MBox.Items.Add(i);
            }
            this.WBox.SelectedIndex = this.W - 4;
            this.HBox.SelectedIndex = this.H - 4;
            this.MBox.SelectedIndex = this.M - 1;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(67, 116);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ChangeSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 230);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.HBox);
            this.Controls.Add(this.WBox);
            this.Controls.Add(this.MBox);
            this.Name = "ChangeSizeForm";
            this.Text = "ChangeSizeForm";
            this.ResumeLayout(false);

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        #endregion

        private System.Windows.Forms.ComboBox WBox;
        private System.Windows.Forms.ComboBox HBox;
        private System.Windows.Forms.ComboBox MBox;
        private System.Windows.Forms.Button OkButton;
    }
}