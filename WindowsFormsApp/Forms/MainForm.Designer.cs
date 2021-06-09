
namespace WindowsFormsApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ptintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miChoosePrintType = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.ddlGroupResults = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlPlayersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFavouritePlayersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTest = new System.Windows.Forms.Label();
            this.pnlRankedPlayerContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRankedStadiumContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.ptintToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // ptintToolStripMenuItem
            // 
            this.ptintToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChoosePrintType,
            this.miPreviewPrint,
            this.miPrint});
            this.ptintToolStripMenuItem.Name = "ptintToolStripMenuItem";
            resources.ApplyResources(this.ptintToolStripMenuItem, "ptintToolStripMenuItem");
            // 
            // miChoosePrintType
            // 
            this.miChoosePrintType.Name = "miChoosePrintType";
            resources.ApplyResources(this.miChoosePrintType, "miChoosePrintType");
            this.miChoosePrintType.Click += new System.EventHandler(this.MiChoosePrintType_Click);
            // 
            // miPreviewPrint
            // 
            this.miPreviewPrint.Name = "miPreviewPrint";
            resources.ApplyResources(this.miPreviewPrint, "miPreviewPrint");
            this.miPreviewPrint.Click += new System.EventHandler(this.MiPreviewPrint_Click);
            // 
            // miPrint
            // 
            this.miPrint.Name = "miPrint";
            resources.ApplyResources(this.miPrint, "miPrint");
            this.miPrint.Click += new System.EventHandler(this.MiPrint_Click);
            // 
            // ddlGroupResults
            // 
            this.ddlGroupResults.AllowDrop = true;
            this.ddlGroupResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGroupResults.FormattingEnabled = true;
            resources.ApplyResources(this.ddlGroupResults, "ddlGroupResults");
            this.ddlGroupResults.Name = "ddlGroupResults";
            this.ddlGroupResults.SelectedIndexChanged += new System.EventHandler(this.DdlGroupResults_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInfo.Name = "lblInfo";
            resources.ApplyResources(this.lblInfo, "lblInfo");
            // 
            // pnlPlayersContainer
            // 
            this.pnlPlayersContainer.AllowDrop = true;
            resources.ApplyResources(this.pnlPlayersContainer, "pnlPlayersContainer");
            this.pnlPlayersContainer.Name = "pnlPlayersContainer";
            // 
            // pnlFavouritePlayersContainer
            // 
            this.pnlFavouritePlayersContainer.AllowDrop = true;
            resources.ApplyResources(this.pnlFavouritePlayersContainer, "pnlFavouritePlayersContainer");
            this.pnlFavouritePlayersContainer.Name = "pnlFavouritePlayersContainer";
            // 
            // lblTest
            // 
            resources.ApplyResources(this.lblTest, "lblTest");
            this.lblTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTest.Name = "lblTest";
            // 
            // pnlRankedPlayerContainer
            // 
            resources.ApplyResources(this.pnlRankedPlayerContainer, "pnlRankedPlayerContainer");
            this.pnlRankedPlayerContainer.Name = "pnlRankedPlayerContainer";
            // 
            // pnlRankedStadiumContainer
            // 
            resources.ApplyResources(this.pnlRankedStadiumContainer, "pnlRankedStadiumContainer");
            this.pnlRankedStadiumContainer.Name = "pnlRankedStadiumContainer";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlRankedStadiumContainer);
            this.Controls.Add(this.pnlRankedPlayerContainer);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.pnlFavouritePlayersContainer);
            this.Controls.Add(this.pnlPlayersContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ddlGroupResults);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ComboBox ddlGroupResults;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayersContainer;
        private System.Windows.Forms.FlowLayoutPanel pnlFavouritePlayersContainer;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.FlowLayoutPanel pnlRankedPlayerContainer;
        private System.Windows.Forms.FlowLayoutPanel pnlRankedStadiumContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem ptintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miChoosePrintType;
        private System.Windows.Forms.ToolStripMenuItem miPrint;
        private System.Windows.Forms.Label label5;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.ToolStripMenuItem miPreviewPrint;
    }
}