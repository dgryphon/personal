namespace GSFrontEnd
{
    partial class frmGame
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.tbMain = new System.Windows.Forms.TextBox();
            this.tbThoughts = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadLogFileToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solhavenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.icemuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.illistimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaalorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riversRestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourWindsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.AcceptsReturn = true;
            this.tbInput.Location = new System.Drawing.Point(12, 570);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(761, 20);
            this.tbInput.TabIndex = 0;
            // 
            // tbMain
            // 
            this.tbMain.BackColor = System.Drawing.SystemColors.ControlText;
            this.tbMain.ForeColor = System.Drawing.SystemColors.Window;
            this.tbMain.Location = new System.Drawing.Point(12, 127);
            this.tbMain.Multiline = true;
            this.tbMain.Name = "tbMain";
            this.tbMain.ReadOnly = true;
            this.tbMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMain.Size = new System.Drawing.Size(761, 440);
            this.tbMain.TabIndex = 1;
            // 
            // tbThoughts
            // 
            this.tbThoughts.BackColor = System.Drawing.SystemColors.ControlText;
            this.tbThoughts.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbThoughts.ForeColor = System.Drawing.SystemColors.Window;
            this.tbThoughts.Location = new System.Drawing.Point(12, 23);
            this.tbThoughts.Multiline = true;
            this.tbThoughts.Name = "tbThoughts";
            this.tbThoughts.ReadOnly = true;
            this.tbThoughts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbThoughts.Size = new System.Drawing.Size(761, 100);
            this.tbThoughts.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scriptsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogFileToolStripMenuItem,
            this.uploadLogFileToServerToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveLogFileToolStripMenuItem
            // 
            this.saveLogFileToolStripMenuItem.Name = "saveLogFileToolStripMenuItem";
            this.saveLogFileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveLogFileToolStripMenuItem.Text = "Save LogFile";
            // 
            // uploadLogFileToServerToolStripMenuItem
            // 
            this.uploadLogFileToServerToolStripMenuItem.Name = "uploadLogFileToServerToolStripMenuItem";
            this.uploadLogFileToServerToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.uploadLogFileToServerToolStripMenuItem.Text = "Upload LogFile to Server";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lToolStripMenuItem,
            this.solhavenToolStripMenuItem,
            this.icemuleToolStripMenuItem,
            this.illistimToolStripMenuItem,
            this.vaalorToolStripMenuItem,
            this.terasToolStripMenuItem,
            this.riversRestToolStripMenuItem,
            this.fourWindsToolStripMenuItem});
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // lToolStripMenuItem
            // 
            this.lToolStripMenuItem.Name = "lToolStripMenuItem";
            this.lToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lToolStripMenuItem.Text = "Landing";
            // 
            // solhavenToolStripMenuItem
            // 
            this.solhavenToolStripMenuItem.Name = "solhavenToolStripMenuItem";
            this.solhavenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.solhavenToolStripMenuItem.Text = "Solhaven";
            // 
            // icemuleToolStripMenuItem
            // 
            this.icemuleToolStripMenuItem.Name = "icemuleToolStripMenuItem";
            this.icemuleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.icemuleToolStripMenuItem.Text = "Icemule";
            // 
            // illistimToolStripMenuItem
            // 
            this.illistimToolStripMenuItem.Name = "illistimToolStripMenuItem";
            this.illistimToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.illistimToolStripMenuItem.Text = "Illistim";
            // 
            // vaalorToolStripMenuItem
            // 
            this.vaalorToolStripMenuItem.Name = "vaalorToolStripMenuItem";
            this.vaalorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vaalorToolStripMenuItem.Text = "Vaalor";
            // 
            // terasToolStripMenuItem
            // 
            this.terasToolStripMenuItem.Name = "terasToolStripMenuItem";
            this.terasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.terasToolStripMenuItem.Text = "Teras";
            // 
            // riversRestToolStripMenuItem
            // 
            this.riversRestToolStripMenuItem.Name = "riversRestToolStripMenuItem";
            this.riversRestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.riversRestToolStripMenuItem.Text = "River\'s Rest";
            // 
            // fourWindsToolStripMenuItem
            // 
            this.fourWindsToolStripMenuItem.Name = "fourWindsToolStripMenuItem";
            this.fourWindsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fourWindsToolStripMenuItem.Text = "Four Winds";
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 602);
            this.Controls.Add(this.tbThoughts);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGame";
            this.Text = "Gemstone IV - Playershop Information Gathering Tool";
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.TextBox tbMain;
        private System.Windows.Forms.TextBox tbThoughts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadLogFileToServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solhavenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem icemuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem illistimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaalorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem riversRestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fourWindsToolStripMenuItem;
    }
}