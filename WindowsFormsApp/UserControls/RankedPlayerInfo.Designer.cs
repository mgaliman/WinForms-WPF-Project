
namespace WindowsFormsApp
{
    partial class RankedPlayerInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblGoals = new System.Windows.Forms.Label();
            this.lblYellowCards = new System.Windows.Forms.Label();
            this.pbRankedPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRankedPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(16, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(33, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "name";
            // 
            // lblGoals
            // 
            this.lblGoals.AutoSize = true;
            this.lblGoals.Location = new System.Drawing.Point(16, 47);
            this.lblGoals.Name = "lblGoals";
            this.lblGoals.Size = new System.Drawing.Size(32, 13);
            this.lblGoals.TabIndex = 2;
            this.lblGoals.Text = "goals";
            // 
            // lblYellowCards
            // 
            this.lblYellowCards.AutoSize = true;
            this.lblYellowCards.Location = new System.Drawing.Point(74, 47);
            this.lblYellowCards.Name = "lblYellowCards";
            this.lblYellowCards.Size = new System.Drawing.Size(33, 13);
            this.lblYellowCards.TabIndex = 3;
            this.lblYellowCards.Text = "cards";
            // 
            // pbRankedPlayer
            // 
            this.pbRankedPlayer.Location = new System.Drawing.Point(213, 5);
            this.pbRankedPlayer.Name = "pbRankedPlayer";
            this.pbRankedPlayer.Size = new System.Drawing.Size(80, 80);
            this.pbRankedPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRankedPlayer.TabIndex = 5;
            this.pbRankedPlayer.TabStop = false;
            // 
            // RankedPlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.Controls.Add(this.pbRankedPlayer);
            this.Controls.Add(this.lblYellowCards);
            this.Controls.Add(this.lblGoals);
            this.Controls.Add(this.lblName);
            this.Name = "RankedPlayerInfo";
            this.Size = new System.Drawing.Size(296, 88);
            ((System.ComponentModel.ISupportInitialize)(this.pbRankedPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGoals;
        private System.Windows.Forms.Label lblYellowCards;
        private System.Windows.Forms.PictureBox pbRankedPlayer;
    }
}
