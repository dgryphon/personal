namespace Playershops
{
    partial class frmMain
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
            this.btnDoInventory = new System.Windows.Forms.Button();
            this.btnUpLoadInventory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoInventory
            // 
            this.btnDoInventory.Location = new System.Drawing.Point(47, 124);
            this.btnDoInventory.Name = "btnDoInventory";
            this.btnDoInventory.Size = new System.Drawing.Size(109, 23);
            this.btnDoInventory.TabIndex = 0;
            this.btnDoInventory.Text = "Do Inventory";
            this.btnDoInventory.UseVisualStyleBackColor = true;
            this.btnDoInventory.Click += new System.EventHandler(this.btnDoInventory_Click);
            // 
            // btnUpLoadInventory
            // 
            this.btnUpLoadInventory.Location = new System.Drawing.Point(48, 153);
            this.btnUpLoadInventory.Name = "btnUpLoadInventory";
            this.btnUpLoadInventory.Size = new System.Drawing.Size(108, 23);
            this.btnUpLoadInventory.TabIndex = 1;
            this.btnUpLoadInventory.Text = "Upload Inventory";
            this.btnUpLoadInventory.UseVisualStyleBackColor = true;
            this.btnUpLoadInventory.Click += new System.EventHandler(this.btnUpLoadInventory_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 397);
            this.Controls.Add(this.btnUpLoadInventory);
            this.Controls.Add(this.btnDoInventory);
            this.Name = "frmMain";
            this.Text = "Player Shops Inventory Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDoInventory;
        private System.Windows.Forms.Button btnUpLoadInventory;
    }
}

