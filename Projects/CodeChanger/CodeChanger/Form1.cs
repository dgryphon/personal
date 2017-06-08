using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CodeChanger
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // If nothing has been indicated for the state, do nothing
            if (stateTB.Text.Length != 0) {

                string ST = stateTB.Text.Trim();
                string CurLine = "";
                
                DirectoryInfo di = new DirectoryInfo("h:/source09/state/" + ST + "/");
                //DirectoryInfo di = new DirectoryInfo("c:/test/" + ST + "/");
                FileInfo[] Incfiles = di.GetFiles("*.inc");
                FileInfo[] Basfiles = di.GetFiles("*.bas");
                List<string> LList = new List<string>();
                /*
                string tmp2 = "dog";
                MessageBox.Show("dog " + tmp2);
                tmp2 = tmp2.Replace("dog", "cat");
                MessageBox.Show("dog " + tmp2);

                if (tmp2!= null) {return;}
                */
                //process bas files
                foreach (FileInfo fi in Basfiles)
                {
                    //List<string> LList = new List<string>();
                    //MessageBox.Show("on file " + fi.ToString());

                    //Open the file to read from
                    StreamReader thsb = fi.OpenText();
                    while ((CurLine = thsb.ReadLine()) != null)
                    {
                        LList.Add(CurLine);          // put line into vector
                    }
                    thsb.Close();

                    //process data - routine to cleanse file
                    ProcFiles(LList);

                    StreamWriter outth = fi.CreateText();
                    foreach (string outLine in LList)
                    {
                        outth.WriteLine(outLine);
                    }
                    //write out all lines
                    outth.Close();
                    LList.Clear();

                }
                MessageBox.Show("finished with bas files");

                //process include files
                foreach (FileInfo fi in Incfiles)
                {
                    //MessageBox.Show("on file " + fi.ToString());

                    //Open the file to read from
                    StreamReader thsb = fi.OpenText();

                    while ((CurLine = thsb.ReadLine()) != null)
                    {
                        LList.Add(CurLine);          // put line into vector
                    }
                    thsb.Close();

                    //process data - routine to cleanse file
                    ProcFiles(LList);

                    StreamWriter outth = fi.CreateText();
                    foreach (string outLine in LList)
                    {
                        outth.WriteLine(outLine);
                    }
                    //write out all lines
                    outth.Close();

                    LList.Clear();

                }

                MessageBox.Show("finished with includes");
            }
                
        }
        public void ProcFiles(List<string> theList)
        {
            string temp;
            string ST = stateTB.Text.Trim();
            string itm;
            int SubLine = -1;           //location of sub line
            int comLine = -1;           //location of commoni1 line


            // process the string            
            for (int i = 1;i<theList.Count;i++)
            {
                //find sub line
                if (theList[i].ToUpper().Contains("SUB "+ST) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    //MessageBox.Show("first item"+theList[i].ToUpper().TrimStart().Substring(0, 1));
                    //MessageBox.Show("whole item"+theList[i].ToUpper().TrimStart());
                    SubLine = i;
                }

                //find common line
                if (theList[i].ToUpper().Contains("source09\\IB\\COMMONI1") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    comLine = i;
                }

                itm = "%PER";
                if (theList[i].ToUpper().Contains("#IF "+itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#IF "+itm, "#IF %DEF("+itm+")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("#ELSEIF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#ELSEIF " + itm, "#ELSEIF %DEF("+itm+")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("OR "+itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("OR " + itm, "OR %DEF("+itm+")");
                    theList[i] = theList[i] + temp;
                }

                itm = "%CRP";
                if (theList[i].ToUpper().Contains("#IF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#IF " + itm, "#IF %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("#ELSEIF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#ELSEIF " + itm, "#ELSEIF %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("OR " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("OR " + itm, "OR %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }

                itm = "%SBS";
                if (theList[i].ToUpper().Contains("#IF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#IF " + itm, "#IF %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("#ELSEIF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#ELSEIF " + itm, "#ELSEIF %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("OR " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("OR " + itm, "OR %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }

                itm = "%PTR";
                if (theList[i].ToUpper().Contains("#IF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#IF " + itm, "#IF %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("#ELSEIF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#ELSEIF " + itm, "#ELSEIF %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("OR " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("OR " + itm, "OR %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }

                itm = "%FID";
                if (theList[i].ToUpper().Contains("#IF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#IF " + itm, "#IF %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("#ELSEIF " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("#ELSEIF " + itm, "#ELSEIF %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("OR " + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("OR " + itm, "OR %DEF(" + itm + ")");
                    theList[i] = theList[i] + temp;
                }


                if (theList[i].ToUpper().Contains("GOSUB PRINTRECORD255") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("GOSUB PRINTRECORD255", "PRINTREC255(STREC, DNAME$, DID$)");
                    theList[i] = theList[i] + temp;
                }


                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\ESTIMATE") && theList[i].ToUpper().TrimStart().Substring(0, 1)!="'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    //MessageBox.Show("estimate before " + theList[i]);
                    theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\ESTIMATE.BAS", "SOURCE09\\IB\\FDST\\EFINFO\\ESTIMATE.INC");
                    theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\ESTIMATE", "SOURCE09\\IB\\FDST\\EFINFO\\ESTIMATE.INC");
                    //MessageBox.Show("estimate after- " + theList[i]);
                    theList[i] = theList[i] + temp;
                }

                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\EFLINK") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\EFLINK", "SOURCE09\\IB\\FDST\\EFINFO\\EFLINK");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\ST255") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\ST255", "SOURCE09\\IB\\FDST\\EFINFO\\ST255");
                    theList[i] = theList[i] + temp;
                }
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\BUSINFO") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "      '" + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\BUSINFO", "SOURCE09\\IB\\FDST\\EFINFO\\BUSINFO");
                    theList[i] = theList[i] + temp;
                }

                //Remove references to...
                itm = "STOREPER";
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\"+itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    //theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\"+itm, "SOURCE09\\IB\\FDST\\EFINFO\\"+itm);
                    //theList[i] = theList[i] + temp;
                }

                itm = "STORECRP";
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\" + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    //theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\"+itm, "SOURCE09\\IB\\FDST\\EFINFO\\"+itm);
                    //theList[i] = theList[i] + temp;
                }
                itm = "STORESBS";
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\" + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    //theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\"+itm, "SOURCE09\\IB\\FDST\\EFINFO\\"+itm);
                    //theList[i] = theList[i] + temp;
                }
                itm = "STOREPTR";
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\" + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    //theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\"+itm, "SOURCE09\\IB\\FDST\\EFINFO\\"+itm);
                    //theList[i] = theList[i] + temp;
                }
                itm = "STOREFID";
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\" + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    //theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\"+itm, "SOURCE09\\IB\\FDST\\EFINFO\\"+itm);
                    //theList[i] = theList[i] + temp;
                }
                itm = "STORETEX";
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\" + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    //theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\"+itm, "SOURCE09\\IB\\FDST\\EFINFO\\"+itm);
                    //theList[i] = theList[i] + temp;
                }
                itm = "STOREEST";
                if (theList[i].ToUpper().Contains("SOURCE09\\IB\\" + itm) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    //theList[i] = theList[i].ToUpper().Replace("SOURCE09\\IB\\"+itm, "SOURCE09\\IB\\FDST\\EFINFO\\"+itm);
                    //theList[i] = theList[i] + temp;
                }

                if (theList[i].ToUpper().Contains("SETDDINFO") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("SETDDINFO", "DEPOSIT_INFO");
                    if (!theList[i].ToUpper().Contains(":")) { theList[i] = theList[i].ToUpper().Replace(") ", ", STREC)"); }
                    theList[i] = theList[i] + temp;
                    theList.Insert(i+1, "STREC.DD=IIF$(STDEPOSIT, \"Y\", \"N\")");
                    return;
                }

                if (theList[i].ToUpper().Contains("SETPMTINFO") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("SETPMTINFO", "DEBIT_INFO");
                    if (!theList[i].ToUpper().Contains(":")) {theList[i] = theList[i].ToUpper().Replace(") ", ", STREC)"); }
                    theList[i] = theList[i] + temp;
                    theList.Insert(i + 1, "STREC.PMT=IIF$(STDEBIT, \"Y\", \"N\")");
                    return;
                }

                if (theList[i].ToUpper().Contains("BUSINFO") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    //theList[i] = theList[i].ToUpper().Replace("BUSINFO", "DEPOSIT_INFO");
                    if (!theList[i].ToUpper().Contains(":")) { theList[i] = theList[i].ToUpper().Replace(")", ", STREC)"); }
                    theList[i] = theList[i] + temp;
                    theList.Insert(i + 1, "STREC.DD=IIF$(STDEPOSIT, \"Y\", \"N\")");
                    theList.Insert(i + 2, "STREC.PMT=IIF$(STDEBIT, \"Y\", \"N\")");
                    return;
                }


                if (theList[i].ToUpper().Contains("STORETOTINCOME") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("STORETOTINCOME", "STREC.AGI=");
                    theList[i] = theList[i] + temp;
                }

                if (theList[i].ToUpper().Contains("STORETAXINCOME") && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace("STORETAXINCOME", "STREC.TAXABLE=");
                    theList[i] = theList[i] + temp;
                }

                //tax type stuff
                itm = "StRec.Tax1Desc";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec.TaxDesc");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.SpecFormcode1";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec.SpecFormcode");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Tax1DueDate";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec.TaxDueDate");
                    theList[i] = theList[i] + temp;
                }

                //tax 2 stuff
                itm = "StRec.Tax2Desc";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxDesc");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.SpecFormcode2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.SpecFormcode");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Tax2DueDate";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxDueDate");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Tax2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.Tax");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Overpayment2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.Overpayment");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.applied2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.applied");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Penalty2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.penalty");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Refund2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.Refund");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Baldue2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.Baldue");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.ExtInd2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.ExtInd");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.AmdInd2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.AmdInd");
                    theList[i] = theList[i] + temp;
                }                
                itm = "StRec.Tax2ES1";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxES1");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Tax2ES2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxES2");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax2ES3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxES3");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax2ES4";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxES4");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax2OP1";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxOP1");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax2OP2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxOP2");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax2OP3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxOP3");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax2OP4";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxOP4");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.TranMethod2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TranMethod");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.EffTaxRate2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.EffTaxRate");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.TaxRate2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.TaxRate");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.FormNum2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec2.FormNum");
                    theList[i] = theList[i] + temp;
                }

                //Tax type 3

                itm = "StRec.Refund3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.Refund");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Baldue3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.Baldue");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.ExtInd3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.ExtInd");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.AmdInd3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.AmdInd");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Tax3Desc";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxDesc");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.SpecFormcode3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.SpecFormcode");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Tax3DueDate";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxDueDate");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Tax3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.Tax");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Overpayment3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.Overpayment");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.applied3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.applied");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Penalty3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.penalty");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax3ES1";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxES1");
                    theList[i] = theList[i] + temp;
                }

                itm = "StRec.Tax3ES2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxES2");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax3ES3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxES3");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax3ES4";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxES4");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax3OP1";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxOP1");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax3OP2";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxOP2");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax3OP3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxOP3");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.Tax3OP4";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxOP4");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.TranMethod3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TranMethod");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.EffTaxRate3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.EffTaxRate");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.TaxRate3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.TaxRate");
                    theList[i] = theList[i] + temp;
                }
                itm = "StRec.FormNum3";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "StRec3.FormNum");
                    theList[i] = theList[i] + temp;
                }

                itm = "STORETOTTAX";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.TAX=");
                    theList[i] = theList[i] + temp;
                }

                itm = "STOREREFUND";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.REFUND=");
                    theList[i] = theList[i] + temp;
                }
                itm = "STOREBALDUE";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.BALDUE=");
                    theList[i] = theList[i] + temp;
                }
                itm = "STOREOVERPYMT";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.OVERPAYMENT=");
                    theList[i] = theList[i] + temp;
                }
                itm = "STOREPENALTY";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.PENALTY=");
                    theList[i] = theList[i] + temp;
                }
                itm = "STOREAPPLIED";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.APPLIED=");
                    theList[i] = theList[i] + temp;
                }
                itm = "STOREXREFUND";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.XREFUND=");
                    theList[i] = theList[i] + temp;
                }
                itm = "STOREXBALDUE";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.XBALDUE=");
                    theList[i] = theList[i] + temp;
                }

                itm = "STOREGROSSINCOME";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.INCOMEB4=");
                    theList[i] = theList[i] + temp;
                }
                itm = "STORETAXINCOME";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.TAXABLE=");
                    theList[i] = theList[i] + temp;
                }
                itm = "STOREINCOMETAX";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    temp = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                    theList[i] = theList[i].ToUpper().Replace(itm.ToUpper(), "STREC.TAX=");
                    theList[i] = theList[i] + temp;
                }

                itm = "STOREELIGIBLE";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                }

                itm = "STOREOTHERTAX";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                }

                itm = "STOREPYMTMETHOD";
                if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                {
                    theList[i] = "' " + theList[i] + "       REPLACED BY CODECHANGER";
                }

                /*
                //insert "#INCLUDE\\source09\\IB\\FDST\\EFINFO\\MAKEAROW.INC" above sub line
                if (SubLine!=-1) {
                    itm = "SOURCE09\\IB\\ST255";
                    if (theList[i].ToUpper().Contains(itm.ToUpper()) && theList[i].ToUpper().TrimStart().Substring(0, 1) != "'")
                    {
                        theList[i] = "' " + theList[i] + "       MOVED TO SUB BY CODECHANGER";
                        theList.Insert(SubLine - 1, theList[i]);
                        //theList[i] = theList[i].ToUpper().Replace("SETDDINFO", "DEPOSIT_INFO");
                        //if (!theList[i].ToUpper().Contains(":")) { theList[i] = theList[i].ToUpper().Replace(")", ", STREC)"); }
                        //theList[i] = theList[i] + temp;
                        //theList.Insert(i + 1, "STREC.DD=IIF$(STDEPOSIT, \"Y\", \"N\")");
                    }
                }
                */
            }

        }

    }
}
