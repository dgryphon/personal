using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GSFrontEnd
{
    public partial class frmLaunch : Form
    {
        public frmLaunch()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //lets you add an account or additional characters to an account
            Process p = new Process();
            //p.StartInfo.FileName = "C:\\Program Files\\SIMU\\launcher.exe";
            p.StartInfo.FileName = "C:\\Program Files\\SIMU\\launcher.exe";
            //p.StartInfo.Arguments = "/c dir *.cs";
             p.StartInfo.Arguments = "C:\\junk\\data\\SIMU\\gemstone\\wizard.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            string output = p.StandardOutput.ReadToEnd();

            //MessageBox.Show("Output:");
            MessageBox.Show(output);  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // loads a console window showing connection results
            // loads game window
            this.Hide();
            frmGame gmWindow = new frmGame();
            gmWindow.ShowDialog();
            this.Show();
        }
    }
}
