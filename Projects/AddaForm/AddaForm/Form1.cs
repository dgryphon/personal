using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AddaForm
{
    public partial class Form1 : Form
    {
        DirectoryInfo di;        
        List<SourceFile> FileList;
        int screenE;
        int printE;
        string screenID;

        public Form1()
        {
            InitializeComponent();
            ddState.Items.Add("AL");
            ddState.Items.Add("RI");
            ddState.Items.Add("TX");
            ddState.Items.Add("CO");
            ddState.Items.Add("DE");
            ddState.Items.Add("LA");
            ddState.Items.Add("NJ");
            ddState.Items.Add("CT");
            ddState.Items.Add("VT");
        }

        //=================Button click==========================//
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("first thing" + ddState.Text.Trim());

            if (ValidateFailed()) { return; }       //User missed entering something important

            MakeAssignments();         //Makes list of files to work with
            makePrint();            //edits printPage and adds entry for forms
            makeFileList();         //edits filelist and adds entry for forms
            //makeScreen();           //edits screen file and adds entry for forms
            //makePriceList();        //pricing file - adds to priceline file
            makeInclude();
            CreateReminders();      //Prints list of reminders for user to do
        }

        //=================validate all forms data================//
        private bool ValidateFailed() 
        {

            if (tbPrintNumber.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Missing a print Number");
                return true;
            }

            //State
            if (ddState.Text.Trim() == "")
            {
                MessageBox.Show("Enter a state!");
                return true;
            }

            //year
            if (tbYear.Text.Trim() == "")
            {
                MessageBox.Show("Enter a year!");
                return true;
            }
            //Bas files
            if (tbBAS.Text.Trim() == "")
            {
                MessageBox.Show("Enter a BAS File Name - Needed to insure includes entered!");
                return true;
            }
            //No module name
            if (tbModule.Text.Trim() == "")
            {
                MessageBox.Show("Enter a module name!");
                return true;
            }

            //No package selected - required for pricing
            if (!(cbPER.Checked || cbCRP.Checked || cbSBS.Checked || cbPTR.Checked || cbFID.Checked || cbTEX.Checked || cbEST.Checked))
            {
                MessageBox.Show("Must Have at least one package selected!");
                return true;
            }

            return false;

        }

        //=================Print List of Reminders for user========// 
        private void CreateReminders()
        {
            //reminder section
            // still need to put gosub label into your code
            MessageBox.Show("You still need to add a GOSUB call to your Files");
            // still need to make assignments and calculations
            MessageBox.Show("You still need to make your assignments for your calculations in the new include file.");
            // still need to add test track entries
            MessageBox.Show("You still need to make any required testtrack entries.");
        }

        //=================Make list of files to use==============//        
        private void MakeAssignments()
        {

            printE = System.Convert.ToInt32(tbPrintNumber.Text.ToString().Trim());
            //file list            
            di = new DirectoryInfo("h:/source09/state/" + ddState.Text.Trim() + "/");
            //di = new DirectoryInfo("c:/test/" + ddState.Text.Trim() + "/");
            FileInfo[] Incfiles = di.GetFiles("*.inc");
            FileInfo[] Srcfiles = di.GetFiles("*.bas");
            //SourceFile[] FileList = new SourceFile()[Incfiles.Count + Srcfiles.Count];

            FileList = new List<SourceFile>();

            //myFileList = new FileInfo(di.ToString() + "ld/filelist");
            //FileInfo msgPage = new FileInfo("F:/drake09/st/" + ddState.Text.Trim());
            //FileInfo msgPageB = new FileInfo("F:/drake09/st/" + ddState.Text.Trim());
            //FileInfo menu = new FileInfo(di.ToString() + "ld/filelist");

            //add pricing file
            //FileList.Add(new SourceFile(pricing));

            // adds include files
            foreach (FileInfo fi in Incfiles)
            {
                FileList.Add(new SourceFile(fi));
            }

            //adds source files
            foreach (FileInfo fi in Srcfiles)
            {
                FileList.Add(new SourceFile(fi));
            }

            //put include statements into BAS Files
            foreach (SourceFile sf in FileList)
            {
                string temp = sf.ToString().ToUpper().Replace(".BAS", "");
                if (tbBAS.Text.ToUpper().Contains(temp.ToUpper()))
                {
                    int numLine = sf.findFirst("IB\\TRAILER");
                    if (numLine != -1)
                    {
                        sf.add("#INCLUDE \"" + tbModule.Text.Trim().ToUpper() + ".INC\"", numLine);
                    }
                    sf.Write();
                }
            }

        }

        //***********************NOT WORKING*********************//
        //======================modify Pricelist===================//
        private void makePriceList()
        {

            /*
TYPE udtPriceRec
    FormName     AS STRING * 16      'Short Name
    Description  AS STRING * 64      'Long Description for Statement/Bill
    PerItem      AS CUR              'Per Item Charge
    PerForm      AS CUR              'Per Form Charge
    OrderMain    AS INTEGER          '(Added by Jody 6/15/2004) Sort Order for forms - General
    OrderSetEF   AS INTEGER          '(Added by Jody 6/15/2004) Sort Order for forms - EF Signature Set
    OrderSetEst  AS INTEGER          '(Added by Jody 6/15/2004) Sort Order for forms - Est/Ext Set
    Pages        AS STRING * 1       'Number of Pages
    DUPLEX       AS STRING * 1       'Allow Duplexing of Form
    SignCopy     AS STRING * 1       'Number of Estimate Copies
    EstCopy      AS STRING * 1       'Number of Estimate Copies
    ClientCopy   AS STRING * 1       'Number of Client Copies
    PrepCopy     AS STRING * 1       'Number of Preparer Copies
    FedCopy      AS STRING * 1       'Number of Federal Copies
    StateCopy    AS STRING * 1       'Number of State Copies
    FastCopy     AS STRING * 1       'this is used to store the number of copies when the user uses the plus and minus keys on the form selector.
    StMainForm   AS STRING * 1       'Extra Record Length
    OrderClient  AS INTEGER          '(Added by Jody 6/15/2004) Sort Order for forms - Client Set
    OrderPrep    AS INTEGER          '(Added by Jody 6/15/2004) Sort Order for forms - Preparer Set
    OrderFedSt   AS INTEGER          '(Added by Jody 6/15/2004) Sort Order for forms - Federal/State Set
    BillInclude  AS BYTE             '(Added by Jody 6/15/2004) Flag to indicate this item should print on the bill
    AllowPerItem AS BYTE             '(Added by Jody 6/15/2004) Flag to indicate that a form allows 'per item' pricing
    'Extra       AS STRING * 16      '(Original) Extra Record Length
    OrderK1      AS INTEGER          '(Added by Jody 10/14/2008) Sort Order for forms - K1 Set
    Category     AS BYTE             '(Added by Jody 10/14/2008) Reserved
    K1Copy       AS STRING * 1       '(Added by Jody 10/14/2008) Number of K1 copies
    DocType      AS STRING * 1       '(Added by Bill 6/22/2009 ) Category for setup>pricing
    Extra       AS STRING * 3        '(Modified by Jody 6/15/2004) Extra Record Length
END TYPE

            */






            //open file list
            //close file list
            //open for writing
            //write out all that was read in
            //find the last line of file list

            if (tbPrice.Text.Trim() != "")
            {
                //FileInfo pricing = new FileInfo(di.ToString() + "F:/drake09/st/" + ddState.Text.Trim());
                // open binary file for writing based on state and package
                //ddState.Text.ToString();
                if (cbPER.Checked) 
                { /*do this*/

/*
                    string price = "";
                    FileStream fs = File.OpenRead("c:/test/PR/" + ddState.Text.Trim() + ".PER");
                    BinaryReader br = new BinaryReader(fs);

                    price += br.ReadString();


                    MessageBox.Show(price);
*/

                    FileStream readStream;
                    string desc;
                    string form;
                    string price;
                    string msg = "";
                    string curLine = "";
                    try
                    {
                        readStream = new FileStream("c:/test/PR/" + ddState.Text.Trim() + ".PER", FileMode.Open);
                        BinaryReader readBinary = new BinaryReader(readStream);
                        while (curLine != null)
                        {
                            try
                            {
                                //curLine = readBinary.ReadString();
                                //MessageBox.Show("did that");
                                


                            }
                            catch (Exception ex)
                            {
                                //do nothing
                                curLine = null;
                            }
                            if (curLine != null) { msg += curLine; }
                            MessageBox.Show(curLine);
                        }
                        MessageBox.Show(msg);
                        readStream.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    //Response.Write(br.ReadInt32());
                    //Response.Write(br.ReadDecimal());
                    //Response.Write(br.ReadString());

                   // br.Close();
                   // fs.Close(); 


                    //FileStream fs = File.Create("c:/test/PR/" + ddState.Text.Trim()+".PER");
                    //BinaryWriter bw = new BinaryWriter(fs); 

                }
                if (cbSBS.Checked) { /*do this*/}
                if (cbCRP.Checked) { /*do this*/}
                if (cbPTR.Checked) { /*do this*/}
                if (cbFID.Checked) { /*do this*/}
                if (cbEST.Checked) { /*do this*/}
                if (cbTEX.Checked) { /*do this*/}
            }
        }

        //=================modify FileList========================//
        private void makeFileList()
        {
            //Opens state file list and appends list of LDs to the end
            using (StreamWriter writer = new StreamWriter(di.ToString() + "ld/filelist", true))
            {                                
                string[] LD = tbLD.Text.ToString().Split(';');
                for (int i = 0; i < LD.Length; i++)
                {
                    if (LD[i].Length != 0)
                    {
                        writer.WriteLine(LD[i].ToUpper().Trim());
                    }
                    else
                    {
                        MessageBox.Show("LD was empty, nothing written");
                    }
                }                
            }
        }

        //=================modify PrintPage=======================//
        private void makePrint()
        {
            MessageBox.Show("In print routine");

            //find the printpage if it exists
            //insert entry for this form
            //return errors if no printpage found
            //print routine - adds to printfile file
            if (cbPrint.Checked)
            {
                string[] tbbas = tbBAS.Text.ToString().Split(';');        //text box source files
                List<SourceFile> printFiles = new List<SourceFile>();
                List<SourceFile> finalPrintFiles = new List<SourceFile>();

                // find source files with printpage references
                foreach (SourceFile matchbas in FileList)
                {
                    if (matchbas.findFirst("PrintPage:")>0)
                    {
                        // add current file to the print list
                        printFiles.Add(matchbas);
                    }
                }
                                
                //search through source files for bas files
                foreach(SourceFile curBas in FileList)
                {
                    //search tb bas files
                    for (int j = 0; j < tbbas.Length; j++)
                    {                        
                        //Found a BAS File we need
                        if (tbbas[j].Equals(curBas.ToString()))
                        {
                            //Make a list of print files that need to be edited
                            foreach (SourceFile tmp in printFiles)
                            {
                                //Include reference found on a line
                                //Save the print file for editing later
                                //Must not already be included in the final print list
                                if (curBas.findFirst(tmp.ToString()) > 0 && !finalPrintFiles.Contains(tmp))
                                {
                                    finalPrintFiles.Add(tmp);
                                    MessageBox.Show("added this file to print files to edit: " + tmp.ToString());
                                }
                            }
                        }
                    }
                }

                // search through files that were found for 
                // equate flags %PER, %CRP, %SBS, etc
                // then down until an acceptable insertion point
                // is found

                string[] LD = tbLD.Text.ToString().Split(';');
                string printStatement = "";
                string tmp2 = "";
                for (int i = 0;i<LD.Length;i++)
                {                    
                    if (LD[i].Length != 0)
                    {
                        tmp2 = LD[i].ToUpper().Trim();
                        tmp2 = tmp2.Replace(".LD", ".PG");
                        if (tmp2.EndsWith(".PG"))
                        {
                            tmp2 = tmp2.Replace(".PG", "");
                        }
                        //outth.WriteLine("\tC$=\"" + tmp2 + "\" : GoSub PrintPage");
                        printStatement += "\t CASE \"" + tmp2 + "\"    : E%=" + Convert.ToString(printE + i + 1000) + "\n";
                    }
                    else
                    {
                        MessageBox.Show("LD was empty, nothing written");
                    }

                }

                foreach (SourceFile curBas in finalPrintFiles)
                {
                    int ELine = 0;
                    bool addedsomething = false;

                    if (cbPER.Checked) 
                    { 
                        addedsomething = getEInsert("PER", printStatement, curBas);
                    }
                    if (cbSBS.Checked) 
                    { 
                        addedsomething = getEInsert("SBS", printStatement, curBas);
                    }
                    if (cbCRP.Checked) 
                    { 
                        addedsomething = getEInsert("CRP", printStatement, curBas);
                    }
                    if (cbPTR.Checked) 
                    {
                        addedsomething = getEInsert("PTR", printStatement, curBas);
                    }
                    if (cbFID.Checked) 
                    { 
                        addedsomething = getEInsert("FID", printStatement, curBas);

                    }
                    if (cbEST.Checked) 
                    { 
                        addedsomething = getEInsert("EST", printStatement, curBas);                        
                    }
                    if (cbTEX.Checked) 
                    { 
                        addedsomething = getEInsert("TEX", printStatement, curBas);
                    }

                    if (!addedsomething)
                    {
                        // nothing package specific in this file
                        // find first evalue and insert
                        addedsomething = getEInsert("ALL", printStatement, curBas);
                        if (addedsomething)
                        {
                            curBas.add(printStatement, ELine);
                        }
                        else
                        {
                            MessageBox.Show("Could not locate a suitable place to insert E%= statement into printpage file "+curBas.ToString());
                        }
                    }                    
                }                
            }
        }

        //===========Create Screen Read in include File===========//
        private string makeScreen()
        {
            string newScreen = "";
            //screen section - adds to screen file 
            if (cbScreen.Checked && tbScreenRead.Text.Length!=0)
            {
                //Load string from textbox
                newScreen = tbScreenRead.Text.ToString();
                string temp;
                screenID = tbModule.Text.ToString() + "SCR% : ";

                temp = newScreen.Substring(newScreen.IndexOf("e=") + 2, 3).Trim();
                newScreen = newScreen.Replace(temp, screenID);   //create the screen identifier
                temp = temp.Replace(":", "").Trim();

                screenE = Convert.ToInt32(temp);        // get the screen number

                MessageBox.Show("screen number "+screenE.ToString());

                //Find E= statement - record value, replace with E=ModuleName
                //Replace all V$ and Y( with A$ and A(
                newScreen = newScreen.Replace("V$", "A$");
                newScreen = newScreen.Replace("Y(", "A(");
                newScreen = newScreen.Replace("RETURN", "");    //remove return statement
                temp = newScreen.Substring(newScreen.IndexOf("GetScreen_"), 14); // locate getscreen and replace with ""
                //MessageBox.Show("string was " + newScreen+" and replacing with "+temp);
                newScreen = newScreen.Replace(temp, "OS=1");   //remove getscreen statement
                //MessageBox.Show("string is now " + newScreen);
                newScreen = newScreen.Replace("MID$", "MID2$");
                int i = 1;
                while (newScreen.Contains("bf$") && i>=1)
                {
                    i = newScreen.IndexOf("bf$,");
                    if (i >= 1)
                    {
                        temp = newScreen.Substring(i, 8).Trim(); // locate getscreen and replace with ""
                        newScreen = newScreen.Replace(temp, "BF$, OS,");   //remove getscreen statement
                        //MessageBox.Show(newScreen);
                    }
                }
                newScreen = newScreen.Replace("\n", "\n\t");
            }
            return newScreen;

        }

        //=================make Include File======================//
        private void makeInclude() {

            MessageBox.Show("Creating include file "+di);

            StreamWriter outth = new StreamWriter(di+tbModule.Text.Trim()+".INC");
            outth.WriteLine("");

            // heading
            outth.WriteLine("'*************************************************************************");
            outth.WriteLine("'* File:         "+tbModule.Text.Trim()+".inc                                             *");
            outth.WriteLine("'* Description:  "+tbPrice.Text.Trim()+"*");
            outth.WriteLine("'* Owner:        D. Grooms                                               *");
            outth.WriteLine("'*                                                                       *");
            outth.WriteLine("'* -Name-         -Date-    -Change-                                     *");
            outth.WriteLine("'* D. Grooms(prog) "+System.DateTime.Today.ToString()+"  Created                        *");
            outth.WriteLine("'*                                                                       *");
            outth.WriteLine("'*************************************************************************");
            outth.WriteLine();
            outth.WriteLine();
            outth.WriteLine();
            outth.WriteLine();
            outth.WriteLine();
            outth.WriteLine("'----------------------------------------------");
            outth.WriteLine(tbModule.Text.Trim() + ":");
            outth.WriteLine();
            outth.WriteLine("\tGOSUB ACLEAR");
            //create screen read
            outth.WriteLine("'-----------------Screen Read------------------");
            outth.WriteLine(makeScreen());
            //create calc/assignment section
            outth.WriteLine("'-----------------Calc Section-------------");
            outth.WriteLine("'-----------------Print Section-------------");
            
            string[] LD = tbLD.Text.ToString().Split(';');
            string tmp2="";
            for (int i = 0; i < LD.Length; i++)
            {
                if (LD[i].Length != 0)
                {
                    tmp2 = LD[i].ToUpper().Trim();
                    tmp2 = tmp2.Replace(".LD", ".PG");
                    if (tmp2.EndsWith(".PG"))
                    {
                        tmp2 = tmp2.Replace(".PG", "");
                    }
                    outth.WriteLine("\tC$=\"" + tmp2 + "\" : GoSub PrintPage");                    
                }
                else
                {
                    MessageBox.Show("LD was empty, nothing written");
                }
            }                


            //outth.WriteLine("'-----------------2D/Print Section-------------");
            //create print section

            outth.WriteLine("\tGOSUB ARESTORE");
            outth.WriteLine();
            outth.WriteLine("RETURN");
            outth.Close();
        }

        // Finds an E% section of a printfile specific to the package sent
        public bool getEInsert(string package, string printStat, SourceFile thi)
        {
            string equate = "%" + package;
            string caseValue = "\"" + package + "\"";
            List<int> equatePositions = thi.findAll(equate);
            List<int> casePositions = thi.findAll(caseValue);
            //List<int> returnPoints = thi.findAll("RETURN");
            List<int> beginSelects = thi.findAll("SELECT CASE");
            List<int> endSelects = thi.findAll("END SELECT");
            List<int> EValues = thi.findAll("E%");
            List<int> equateEND = thi.findAll("#END");
            List<int> equateELSEIF = thi.findAll("#ELSEIF");
            List<int> SpecificE = thi.findAll(Convert.ToString(printE-1+1000));
            bool returnVal = false;


            // There was an instance of the string found in this file
            // something needs to be done
            if ((equatePositions.Count + casePositions.Count) > 0)
            {
                // searching for equates
                if (equatePositions.Count > 0 && casePositions.Count < 1)
                // search for next equate - obtained from equateEND/equate ELSEIF list
                // range is distance between found and next equate
                // if E% between two points, bingo
                // find E% 
                {
                    for (int i = 0; i < equatePositions.Count; i++)
                    {
                        int endPoint = -1;
                        int nextEquate = -1;
                        if (i + 1 <= equatePositions.Count) { nextEquate = equatePositions[i + 1]; }
                        // have position of equate we're interested in equatePositions[i]
                        // need to look through equateEND and equateELSEIF for soonest matching
                        // closing statement
                        for (int j = 0; j < equateEND.Count; j++)
                        {
                            if (equateEND[j]>equatePositions[i] && ((equateEND[j]<nextEquate && nextEquate!=-1) || nextEquate==-1))
                            {
                                endPoint = equateEND[j];
                            }
                        }
                        for (int j = 0; j < equateELSEIF.Count; j++)
                        {
                            if (equateELSEIF[j] > equatePositions[i] && ((equateELSEIF[j] < nextEquate && nextEquate != -1) || nextEquate == -1))
                            {
                                if ((equateELSEIF[j] < endPoint && endPoint!=-1) || endPoint==-1)
                                {
                                    endPoint = equateELSEIF[j];
                                }
                            }
                        }

                        // Found a valid endpoint to insert to
                        // make sure there is an E% value between equatePositions and endpoint
                        // if so, make sure it matches E% assignments
                        // if so, then insert the string into the file
                        for (int j = 0; j < SpecificE.Count; j++)
                        {
                            if (SpecificE[j] > equatePositions[i] && SpecificE[j] < endPoint && EValues.Contains(SpecificE[j]))
                            {
                                thi.add(printStat, SpecificE[j] + 1);
                                thi.Write();
                            }
                        }
                        
                    }

                }
                // searching for case statements
                else if (equatePositions.Count < 1 && casePositions.Count > 0)
                {
                    // we already have the case positions
                    // need to trace down and find the first end select
                    //***************tired so assuming it will always be correct***********
                    for (int i = 0; i < casePositions.Count; i++)
                    {
                        int endPoint = -1;
                        int nextEquate = -1;
                        if (i + 1 < casePositions.Count) { nextEquate = casePositions[i + 1]; }
                        // have position of equate we're interested in equatePositions[i]
                        // need to look through equateEND and equateELSEIF for soonest matching
                        // closing statement
                        for (int j = 0; j < endSelects.Count; j++)
                        {
                            if (endSelects[j] > casePositions[i] && ((endSelects[j] < nextEquate && nextEquate != -1) || nextEquate == -1))
                            {
                                endPoint = endSelects[j];
                            }
                        }

                        // Found a valid endpoint to insert to
                        // make sure there is an E% value between equatePositions and endpoint
                        // if so, make sure it matches E% assignments
                        // if so, then insert the string into the file
                        for (int j = 0; j < SpecificE.Count; j++)
                        {
                            if (SpecificE[j] > casePositions[i] && SpecificE[j] < endPoint && EValues.Contains(SpecificE[j]))
                            {
                                thi.add(printStat, SpecificE[j] + 1);
                                thi.Write();
                            }
                        }

                    }


                }
                // Bad case, this means that there are both equates and
                // select cases mixed in the file, requires a complex check
                else
                {
                    MessageBox.Show("Your printpage file is overly complicated, nothing is being changed to prevent your mess from being made worse");
                }

                returnVal = true;
            }
            // No previous packages located an insertion point
            // this means there were probably no references to packages found
            // pick the first matching E value and insert
            else if(package.Equals("ALL"))
            {
                // E assignment line matches an E number line
                // perfect, add the entry under this one
                foreach (int tmp in SpecificE)
                {
                    if (EValues.Contains(tmp))
                    {
                        thi.add(printStat, tmp + 1);
                        thi.Write();
                        returnVal = true;
                    }
                }
            }
            else
            {
                returnVal=false;
            }

            MessageBox.Show("returning and the value is " + returnVal.ToString());

            return returnVal;

        }

    }

    // contains a list of current file
    /***********************************
     * Source File Class
     * Creates a list of PowerBasic source files
     * loads list into memory for easy access
     * Methods: write, findfirst, findall
     *          replace, replaceLine, 
     * **********************************/
    public class SourceFile
    {
        List<string> LList;        //Actually holds the file line info
        string fileName;
        FileInfo curFile;

        public SourceFile(FileInfo fi)
        {
            // Constructor
            LList = new List<string>();
            fileName = fi.ToString();
            curFile = fi;

            if (fi.Exists != true) { return; }
            LList.Clear();
            StreamReader readFile = fi.OpenText();
            string CurLine;
            while ((CurLine = readFile.ReadLine()) != null)
            {
                LList.Add(CurLine);          // put line into vector
            }
            readFile.Close();

            //return LList;
        }

        // Creates a file from the existing list
        public void Write()
        {
            if (curFile.Exists != true) { return; }
            StreamWriter writeFile = curFile.CreateText();
            foreach (string outLine in LList)
            {
                writeFile.WriteLine(outLine);
            }
            //write out all lines
            writeFile.Close();
        }

        //adds a new line to an open file list
        public void add(string temp, int index)
        {
            if (temp.Trim() == "") {return;}        //empty string do not add
            LList.Insert(index, temp+"\t\'INSERTED BY ADDAFORM");

        }

        //search through file and replace a searchstring with something else
        public void replace(string searchstring, string replacewith)
        {
            for (int i = 1; i < LList.Count; i++)
            {
                // find match in all lines
                if (LList[i].ToUpper().Contains(searchstring.ToUpper()))
                {
                    LList[i] = LList[i].ToUpper().Replace(searchstring, replacewith);
                }
            }
        }

        //search through file and replace a searchstring with something else
        public void replaceLine(string searchstring, string replacewith)
        {
            for (int i = 1; i < LList.Count; i++)
            {
                // find match in all lines
                if (LList[i].ToUpper().Contains(searchstring.ToUpper()))
                {
                    LList[i] = replacewith;
                }
            }
        }

        //find a specifc line
        public int findFirst(string searchstring)
        {
            for (int i = 1; i < LList.Count; i++)
            {
                if (LList[i].ToUpper().Contains(searchstring.ToUpper())) {return i;}
            }

            return -1;
        }

        //find all matching lines in current file
        public List<int> findAll(string searchstring)
        {
            List<int> results = new List<int>();
            for (int i = 1; i < LList.Count; i++)
            {
                if (LList[i].ToUpper().Contains(searchstring.ToUpper())) 
                { 
                    results.Add(i); 
                }
            }
            return results;
        }

        public override string ToString()
        {
            return fileName;
        }

    }
}
