namespace Snake
{
    partial class Snake
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
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxFileMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNewGameMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.uxLabelScore = new System.Windows.Forms.Label();
            this.uxScore = new System.Windows.Forms.Label();
            this.uxPictureBox = new System.Windows.Forms.PictureBox();
            this.uxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxFileMenuStrip});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Size = new System.Drawing.Size(587, 24);
            this.uxMenuStrip.TabIndex = 0;
            this.uxMenuStrip.Text = "menuStrip1";
            // 
            // uxFileMenuStrip
            // 
            this.uxFileMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxNewGameMenuStrip});
            this.uxFileMenuStrip.Name = "uxFileMenuStrip";
            this.uxFileMenuStrip.Size = new System.Drawing.Size(37, 20);
            this.uxFileMenuStrip.Text = "File";
            // 
            // uxNewGameMenuStrip
            // 
            this.uxNewGameMenuStrip.Name = "uxNewGameMenuStrip";
            this.uxNewGameMenuStrip.Size = new System.Drawing.Size(180, 22);
            this.uxNewGameMenuStrip.Text = "New Game";
            this.uxNewGameMenuStrip.Click += new System.EventHandler(this.uxNewGameMenuStrip_Click);
            // 
            // uxLabelScore
            // 
            this.uxLabelScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxLabelScore.BackColor = System.Drawing.Color.White;
            this.uxLabelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabelScore.Location = new System.Drawing.Point(451, 1);
            this.uxLabelScore.Name = "uxLabelScore";
            this.uxLabelScore.Size = new System.Drawing.Size(57, 23);
            this.uxLabelScore.TabIndex = 3;
            this.uxLabelScore.Text = "Score:";
            // 
            // uxScore
            // 
            this.uxScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxScore.BackColor = System.Drawing.Color.White;
            this.uxScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxScore.Location = new System.Drawing.Point(518, 0);
            this.uxScore.Name = "uxScore";
            this.uxScore.Size = new System.Drawing.Size(57, 23);
            this.uxScore.TabIndex = 4;
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.BackColor = System.Drawing.Color.Silver;
            this.uxPictureBox.Location = new System.Drawing.Point(3, 27);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(582, 442);
            this.uxPictureBox.TabIndex = 5;
            this.uxPictureBox.TabStop = false;
            this.uxPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.uxPictureBox_Paint);
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(587, 477);
            this.Controls.Add(this.uxPictureBox);
            this.Controls.Add(this.uxScore);
            this.Controls.Add(this.uxLabelScore);
            this.Controls.Add(this.uxMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.uxMenuStrip;
            this.Name = "Snake";
            this.Text = "Classic Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInterface_KeyDown);
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxFileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxNewGameMenuStrip;
        private System.Windows.Forms.Label uxLabelScore;
        private System.Windows.Forms.Label uxScore;
        private System.Windows.Forms.PictureBox uxPictureBox;
    }
}

