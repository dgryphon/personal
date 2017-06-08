using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

//using System.Reflection;

namespace DecryptMaster
{
    public partial class Form1 : Form
    {
        DirectoryInfo curDir;
        FileInfo[] theFiles;
        DateTime lastdate;

        public Form1()
        {
            InitializeComponent();

        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {

            string fileName = "";
            string SSN = "";

            if (tbDirectory.Text.Trim().Equals(""))
            {
                if (fBrowser.ShowDialog() == DialogResult.OK)
                {
                    this.tbDirectory.Text = fBrowser.SelectedPath;
                    this.tbDirectory.Refresh();
                }
            }
            // directory is still empty
            if (tbDirectory.Text.Trim().Equals(""))
            {
                MessageBox.Show("No directory selected!");
            }
            else
            {
                // cleanup text box 
                if (!(this.tbDirectory.Text.Trim().EndsWith("\\")))
                {
                    this.tbDirectory.Text = this.tbDirectory.Text+"\\";
                    this.tbDirectory.Refresh();
                }


                curDir = new DirectoryInfo(this.tbDirectory.Text);

                //MessageBox.Show(curDir.ToString());
                //Create the OleDocumentProperties object.
                DSOFile.OleDocumentProperties dso = new DSOFile.OleDocumentProperties();
                
                theFiles = curDir.GetFiles("*.D*9", SearchOption.AllDirectories);

                //MessageBox.Show(theFiles.ToString());

                int total = theFiles.Count();
                int current = 0;
                
                foreach (FileInfo fi in theFiles)
                {
                    //MessageBox.Show(fi.Directory.ToString());

                    current += 1;
                    //MessageBox.Show(fi.ToString());
                    fileName = @"" + fi.Directory.ToString()+"//" + fi.ToString().Trim();
                    lastdate = fi.LastWriteTime;
                    //fileName = @"" + this.tbDirectory.Text + fi.ToString().Trim();
                    //Open the file for writing if we can. If not we will get an exception.
                    try
                    {
                        dso.Open(fileName, false, DSOFile.dsoFileOpenOptions.dsoOptionOpenReadOnlyIfNoWriteAccess);
                    }
                    catch
                    {
                        MessageBox.Show("Threw an exception " + fileName);
                    }

                    lblResults.Text = "Current File Name:  "+fi.ToString();
                    lblResults.Refresh();
                    lblTime.Text = "File " + System.Convert.ToString(current) + " of " + System.Convert.ToString(total);
                    lblTime.Refresh();

                    // truncate the file name
                    fileName = fi.ToString().Substring(0, 8);

                    // convert to an SSN
                    SSN = getSSN(fileName);

                    //Set the summary properties that you want.
                    dso.SummaryProperties.Title = SSN;                    
                    //lastdate = dso.SummaryProperties.DateLastSaved.ToString();
                    
                    //dso.SummaryProperties.Title = "dog";
                    //Save the Summary information.
                    dso.Save();
                    //Close the file.
                    dso.Close(false);
                    fi.LastWriteTime = lastdate;
                }

                lblResults.Text = "Finished";
                lblResults.Refresh();

            }
        }

        /*private void getFileName()
        {
            int ssnVal = Convert.ToInt32(SSN);
            ssnVal += 235;
            string tmpName = String.Format("{0:x}", ssnVal);
            tmpName = this.Reverse(tmpName) + "00000000";
            fileName = tmpName.Substring(0, 8);
        }*/

        private string getSSN(string fileName)
        {
            //MessageBox.Show("file name is " + fileName);
            string tmpName = this.Reverse(fileName);
            string tmpSSN ="";
            int ssnVal = Convert.ToInt32(tmpName, 16);
            ssnVal -= 235;
            tmpSSN = ssnVal.ToString();
            tmpSSN = tmpSSN.PadLeft(9, '0');
            return tmpSSN;
        }

        public string Reverse(string str)
        {
            // convert the string to char array
            char[] charArray = str.ToCharArray();
            int len = str.Length - 1;

            for (int i = 0; i < len; i++, len--)
            {
                // XOR for the win!!!
                charArray[i] ^= charArray[len];
                charArray[len] ^= charArray[i];
                charArray[i] ^= charArray[len];
            }
            return new string(charArray);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName ="";

            if (tbDirectory.Text.Trim().Equals(""))
            {
                if (fBrowser.ShowDialog() == DialogResult.OK)
                {
                    this.tbDirectory.Text = fBrowser.SelectedPath;
                    this.tbDirectory.Refresh();
                }
            }
            // directory is still empty
            if (tbDirectory.Text.Trim().Equals(""))
            {
                MessageBox.Show("No directory selected!");
            }
            else
            {
                // cleanup text box 
                if (!(this.tbDirectory.Text.Trim().EndsWith("\\")))
                {
                    this.tbDirectory.Text = this.tbDirectory.Text + "\\";
                    this.tbDirectory.Refresh();
                }


                curDir = new DirectoryInfo(this.tbDirectory.Text);

                //MessageBox.Show(curDir.ToString());
                //Create the OleDocumentProperties object.
                DSOFile.OleDocumentProperties dso = new DSOFile.OleDocumentProperties();

                theFiles = curDir.GetFiles("*.D*9", SearchOption.AllDirectories);

                int total = theFiles.Count();
                int current = 0;

                foreach (FileInfo fi in theFiles)
                {
                    //MessageBox.Show(fi.Directory.ToString());

                    current += 1;
                    lastdate = fi.LastWriteTime;
                    //MessageBox.Show(fi.ToString());
                    fileName = @"" + fi.Directory.ToString() + "//" + fi.ToString().Trim();
                    //fileName = @"" + this.tbDirectory.Text + fi.ToString().Trim();
                    //Open the file for writing if we can. If not we will get an exception.
                    try
                    {
                        dso.Open(fileName, false, DSOFile.dsoFileOpenOptions.dsoOptionOpenReadOnlyIfNoWriteAccess);
                    }
                    catch
                    {
                        MessageBox.Show("Threw an exception " + fileName);
                    }

                    lblResults.Text = "Current File Name:  " + fi.ToString();
                    lblResults.Refresh();
                    lblTime.Text = "File " + System.Convert.ToString(current) + " of " + System.Convert.ToString(total);
                    lblTime.Refresh();

                    // truncate the file name
                    fileName = fi.ToString().Substring(0, 8);

                    // convert to an SSN
                    getSSN(fileName);

                    //Set the summary properties that you want.
                    dso.SummaryProperties.Title = "";
                    //dso.SummaryProperties.Title = "dog";
                    //Save the Summary information.
                    dso.Save();
                    //Close the file.
                    dso.Close(false);
                    fi.LastWriteTime = lastdate;                    
                }

                lblResults.Text = "Finished";
                lblResults.Refresh();

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // find the dosfile and launch if not found
            if (!Directory.Exists("c:\\dsofile"))
            {
                MessageBox.Show("doin this");
                System.Diagnostics.Process.Start("O:\\TaxDev\\State2\\Private\\Derrick\\dsofile.exe");
            }
        }
    }
}
