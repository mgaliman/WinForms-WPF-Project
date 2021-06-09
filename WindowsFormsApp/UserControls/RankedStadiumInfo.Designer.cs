
namespace WindowsFormsApp
{
    partial class RankedStadiumInfo
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
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblVisitors = new System.Windows.Forms.Label();
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(57, 26);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(44, 13);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "location";
            // 
            // lblVisitors
            // 
            this.lblVisitors.AutoSize = true;
            this.lblVisitors.Location = new System.Drawing.Point(180, 26);
            this.lblVisitors.Name = "lblVisitors";
            this.lblVisitors.Size = new System.Drawing.Size(39, 13);
            this.lblVisitors.TabIndex = 2;
            this.lblVisitors.Text = "visitors";
            // 
            // lblHomeTeam
            // 
            this.lblHomeTeam.AutoSize = true;
            this.lblHomeTeam.Location = new System.Drawing.Point(57, 49);
            this.lblHomeTeam.Name = "lblHomeTeam";
            this.lblHomeTeam.Size = new System.Drawing.Size(60, 13);
            this.lblHomeTeam.TabIndex = 3;
            this.lblHomeTeam.Text = "homeTeam";
            // 
            // lblAwayTeam
            // 
            this.lblAwayTeam.AutoSize = true;
            this.lblAwayTeam.Location = new System.Drawing.Point(180, 49);
            this.lblAwayTeam.Name = "lblAwayTeam";
            this.lblAwayTeam.Size = new System.Drawing.Size(59, 13);
            this.lblAwayTeam.TabIndex = 4;
            this.lblAwayTeam.Text = "awayTeam";
            // 
            // RankedStadiumInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.Controls.Add(this.lblAwayTeam);
            this.Controls.Add(this.lblHomeTeam);
            this.Controls.Add(this.lblVisitors);
            this.Controls.Add(this.lblLocation);
            this.Name = "RankedStadiumInfo";
            this.Size = new System.Drawing.Size(296, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblVisitors;
        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.Label lblAwayTeam;
    }
}
