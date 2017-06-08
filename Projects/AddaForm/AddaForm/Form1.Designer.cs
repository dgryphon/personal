namespace AddaForm
{
    partial class Form1
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
            this.tbBAS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ddState = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPrint = new System.Windows.Forms.CheckBox();
            this.cbScreen = new System.Windows.Forms.CheckBox();
            this.cbPG = new System.Windows.Forms.CheckBox();
            this.tbLD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbScreenRead = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPER = new System.Windows.Forms.CheckBox();
            this.cbCRP = new System.Windows.Forms.CheckBox();
            this.cbSBS = new System.Windows.Forms.CheckBox();
            this.cbPTR = new System.Windows.Forms.CheckBox();
            this.cbFID = new System.Windows.Forms.CheckBox();
            this.cbEST = new System.Windows.Forms.CheckBox();
            this.cbTEX = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPrintNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbBAS
            // 
            this.tbBAS.Location = new System.Drawing.Point(41, 52);
            this.tbBAS.Name = "tbBAS";
            this.tbBAS.Size = new System.Drawing.Size(102, 20);
            this.tbBAS.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "BAS File(s)";
            // 
            // tbModule
            // 
            this.tbModule.Location = new System.Drawing.Point(41, 78);
            this.tbModule.Name = "tbModule";
            this.tbModule.Size = new System.Drawing.Size(100, 20);
            this.tbModule.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Module name (Will determine include file name and gosub name)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 36);
            this.button1.TabIndex = 19;
            this.button1.Text = "Create Form";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ddState
            // 
            this.ddState.FormattingEnabled = true;
            this.ddState.Location = new System.Drawing.Point(41, 25);
            this.ddState.Name = "ddState";
            this.ddState.Size = new System.Drawing.Size(100, 21);
            this.ddState.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "State";
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(258, 26);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(71, 20);
            this.tbYear.TabIndex = 2;
            this.tbYear.Text = "2009";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Year (4 digits)";
            // 
            // cbPrint
            // 
            this.cbPrint.AutoSize = true;
            this.cbPrint.Checked = true;
            this.cbPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrint.Location = new System.Drawing.Point(41, 216);
            this.cbPrint.Name = "cbPrint";
            this.cbPrint.Size = new System.Drawing.Size(249, 17);
            this.cbPrint.TabIndex = 15;
            this.cbPrint.Text = "Insert Print Routine Code (must have printpage)";
            this.cbPrint.UseVisualStyleBackColor = true;
            // 
            // cbScreen
            // 
            this.cbScreen.AutoSize = true;
            this.cbScreen.Checked = true;
            this.cbScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScreen.Location = new System.Drawing.Point(41, 239);
            this.cbScreen.Name = "cbScreen";
            this.cbScreen.Size = new System.Drawing.Size(283, 17);
            this.cbScreen.TabIndex = 16;
            this.cbScreen.Text = "Insert Screen Routine Code (requires screen listing file)";
            this.cbScreen.UseVisualStyleBackColor = true;
            // 
            // cbPG
            // 
            this.cbPG.AutoSize = true;
            this.cbPG.Checked = true;
            this.cbPG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPG.Location = new System.Drawing.Point(41, 262);
            this.cbPG.Name = "cbPG";
            this.cbPG.Size = new System.Drawing.Size(225, 17);
            this.cbPG.TabIndex = 17;
            this.cbPG.Text = "Use PG to determine variable assignments";
            this.cbPG.UseVisualStyleBackColor = true;
            // 
            // tbLD
            // 
            this.tbLD.Location = new System.Drawing.Point(41, 104);
            this.tbLD.Name = "tbLD";
            this.tbLD.Size = new System.Drawing.Size(286, 20);
            this.tbLD.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "LD Names (seperate multiples with ;)";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(41, 130);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(286, 20);
            this.tbPrice.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Pricing File Description (seperate mulitples with ;  match LD))";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(41, 158);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(279, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Screen Number (not required if screen read pasted below)";
            // 
            // tbScreenRead
            // 
            this.tbScreenRead.AcceptsReturn = true;
            this.tbScreenRead.AllowDrop = true;
            this.tbScreenRead.Location = new System.Drawing.Point(41, 304);
            this.tbScreenRead.Multiline = true;
            this.tbScreenRead.Name = "tbScreenRead";
            this.tbScreenRead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbScreenRead.Size = new System.Drawing.Size(535, 60);
            this.tbScreenRead.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(386, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Copy and paste your screen read below (will replace e= with number from above)";
            // 
            // cbPER
            // 
            this.cbPER.AutoSize = true;
            this.cbPER.Location = new System.Drawing.Point(228, 54);
            this.cbPER.Name = "cbPER";
            this.cbPER.Size = new System.Drawing.Size(48, 17);
            this.cbPER.TabIndex = 4;
            this.cbPER.Text = "PER";
            this.cbPER.UseVisualStyleBackColor = true;
            // 
            // cbCRP
            // 
            this.cbCRP.AutoSize = true;
            this.cbCRP.Location = new System.Drawing.Point(278, 54);
            this.cbCRP.Name = "cbCRP";
            this.cbCRP.Size = new System.Drawing.Size(48, 17);
            this.cbCRP.TabIndex = 5;
            this.cbCRP.Text = "CRP";
            this.cbCRP.UseVisualStyleBackColor = true;
            // 
            // cbSBS
            // 
            this.cbSBS.AutoSize = true;
            this.cbSBS.Location = new System.Drawing.Point(332, 54);
            this.cbSBS.Name = "cbSBS";
            this.cbSBS.Size = new System.Drawing.Size(47, 17);
            this.cbSBS.TabIndex = 6;
            this.cbSBS.Text = "SBS";
            this.cbSBS.UseVisualStyleBackColor = true;
            // 
            // cbPTR
            // 
            this.cbPTR.AutoSize = true;
            this.cbPTR.Location = new System.Drawing.Point(385, 54);
            this.cbPTR.Name = "cbPTR";
            this.cbPTR.Size = new System.Drawing.Size(48, 17);
            this.cbPTR.TabIndex = 7;
            this.cbPTR.Text = "PTR";
            this.cbPTR.UseVisualStyleBackColor = true;
            // 
            // cbFID
            // 
            this.cbFID.AutoSize = true;
            this.cbFID.Location = new System.Drawing.Point(439, 54);
            this.cbFID.Name = "cbFID";
            this.cbFID.Size = new System.Drawing.Size(43, 17);
            this.cbFID.TabIndex = 8;
            this.cbFID.Text = "FID";
            this.cbFID.UseVisualStyleBackColor = true;
            // 
            // cbEST
            // 
            this.cbEST.AutoSize = true;
            this.cbEST.Location = new System.Drawing.Point(488, 54);
            this.cbEST.Name = "cbEST";
            this.cbEST.Size = new System.Drawing.Size(47, 17);
            this.cbEST.TabIndex = 9;
            this.cbEST.Text = "EST";
            this.cbEST.UseVisualStyleBackColor = true;
            // 
            // cbTEX
            // 
            this.cbTEX.AutoSize = true;
            this.cbTEX.Location = new System.Drawing.Point(541, 54);
            this.cbTEX.Name = "cbTEX";
            this.cbTEX.Size = new System.Drawing.Size(47, 17);
            this.cbTEX.TabIndex = 10;
            this.cbTEX.Text = "TEX";
            this.cbTEX.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(155, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(306, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "PrintPage Number (make sure there\'s enough space for all LDs)";
            // 
            // tbPrintNumber
            // 
            this.tbPrintNumber.Location = new System.Drawing.Point(41, 184);
            this.tbPrintNumber.Name = "tbPrintNumber";
            this.tbPrintNumber.Size = new System.Drawing.Size(100, 20);
            this.tbPrintNumber.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbPrintNumber);
            this.Controls.Add(this.cbTEX);
            this.Controls.Add(this.cbEST);
            this.Controls.Add(this.cbFID);
            this.Controls.Add(this.cbPTR);
            this.Controls.Add(this.cbSBS);
            this.Controls.Add(this.cbCRP);
            this.Controls.Add(this.cbPER);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbScreenRead);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbLD);
            this.Controls.Add(this.cbPG);
            this.Controls.Add(this.cbScreen);
            this.Controls.Add(this.cbPrint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddState);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbModule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBAS);
            this.Name = "Form1";
            this.Text = "AddaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBAS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ddState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbPrint;
        private System.Windows.Forms.CheckBox cbScreen;
        private System.Windows.Forms.CheckBox cbPG;
        private System.Windows.Forms.TextBox tbLD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbScreenRead;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbPER;
        private System.Windows.Forms.CheckBox cbCRP;
        private System.Windows.Forms.CheckBox cbSBS;
        private System.Windows.Forms.CheckBox cbPTR;
        private System.Windows.Forms.CheckBox cbFID;
        private System.Windows.Forms.CheckBox cbEST;
        private System.Windows.Forms.CheckBox cbTEX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPrintNumber;
    }
}

