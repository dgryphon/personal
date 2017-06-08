using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DeadInc
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
            ddState.Items.Add("AR");
            ddState.Items.Add("CO");
            ddState.Items.Add("CT");
            ddState.Items.Add("DE");
            ddState.Items.Add("FL");
            ddState.Items.Add("KS");
            ddState.Items.Add("LA");
            ddState.Items.Add("MD");
            ddState.Items.Add("NJ");
            ddState.Items.Add("NY");
            ddState.Items.Add("PA");
            ddState.Items.Add("RI");
            ddState.Items.Add("UT");
            ddState.Items.Add("VT");
        }

        //=================Button click==========================//
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("first thing" + ddState.Text.Trim());

            MakeAssignments();         //Makes list of files to work with - returns file list
            FindDeaders();
            FindSubs();
            //QuickReplace();
        }

        //=========Find all includes that are not referenced with any includes======
        private void FindDeaders()
        {
            FileList.fin
        }

        //=========Find all sub routines that are not referenced with any includes======
        private void FindSubs()
        {

        }

        //=================Make list of files to use==============//        
        private void QuickReplace()
        {
            foreach (SourceFile fi in FileList)
            {
                fi.replace("LLC$(56)" , "LLC.QSUB");      
                fi.replace("LLC$(57)" , "LLC.ShortYear");
                fi.replace("LLC$(1)" , "LLC.Gross");     
                fi.replace("LLC$(2)" , "LLC.DepAsset");  
                fi.replace("LLC$(3)" , "LLC.TotAsset");  
                fi.replace("LLC$(52)" , "LLC.4411Sales"); 
                fi.replace("LLC$(9)" , "LLC.FedInc");    
                fi.replace("LLC$(14)" , "LLC.BonDepDed"); 
                fi.replace("LLC$(59)" , "LLC.IndebtDed"); 
                fi.replace("LLC$(10)" , "LLC.NOLDed");    
                fi.replace("LLC$(11)" , "LLC.SpecDed");   
                fi.replace("LLC$(12)" , "LLC.DivInt");    
                fi.replace("LLC$(13)" , "LLC.ForeignD");  
                fi.replace("LLC$(15)" , "LLC.IntAdd");    
                fi.replace("LLC$(16)" , "LLC.CorpTax");   
                fi.replace("LLC$(17)" , "LLC.BonDepAdd"); 
                fi.replace("LLC$(51)" , "LLC.Intang");    
                fi.replace("LLC$(58)" , "LLC.IndebtAdd"); 
                fi.replace("LLC$(18)" , "LLC.ExtPmt");    
                fi.replace("LLC$(19)" , "LLC.OthrPmt");   
                fi.replace("LLC$(20)" , "LLC.NYEstTax");  
                fi.replace("LLC$(53)" , "LLC.Int");       
                fi.replace("LLC$(54)" , "LLC.Pen");      
                fi.replace("LLC$(55)" , "LLC.Int2210");   
                fi.replace("LLC$(49)" , "LLC.title");     
                fi.replace("LLC$(50)" , "LLC.sigdte");    
                fi.replace("LLC$(4)" , "LLC.IncorpDte"); 
                fi.replace("LLC$(5)" , "LLC.StIncorp");  
                fi.replace("LLC$(6)" , "LLC.ParVal");    
                fi.replace("LLC$(7)" , "LLC.AuthShare"); 
                fi.replace("LLC$(8)" , "LLC.Buscode");   
                fi.replace("LLC$(21)" , "LLC.RIInven");   
                fi.replace("LLC$(22)" , "LLC.FDInv");     
                fi.replace("LLC$(23)" , "LLC.RIdepAss");  
                fi.replace("LLC$(24)" , "LLC.FDdepAss");  
                fi.replace("LLC$(25)" , "LLC.RILand");    
                fi.replace("LLC$(26)" , "LLC.FDLand");   
                fi.replace("LLC$(27)" , "LLC.RIRent");    
                fi.replace("LLC$(28)" , "LLC.FDRent");    
                fi.replace("LLC$(29)" , "LLC.RIGross");   
                fi.replace("LLC$(30)" , "LLC.FDGross");   
                fi.replace("LLC$(31)" , "LLC.RIDiv");     
                fi.replace("LLC$(32)" , "LLC.FDDiv");     
                fi.replace("LLC$(33)" , "LLC.RIInt");     
                fi.replace("LLC$(34)" , "LLC.FDInt");     
                fi.replace("LLC$(35)" , "LLC.RIRents");  
                fi.replace("LLC$(36)" , "LLC.FDRents");    
                fi.replace("LLC$(37)" , "LLC.RIRoyal");   
                fi.replace("LLC$(38)" , "LLC.FDRoyal");   
                fi.replace("LLC$(39)" , "LLC.RINetCap");  
                fi.replace("LLC$(40)" , "LLC.FDNetCap");  
                fi.replace("LLC$(41)" , "LLC.RIOrdin");   
                fi.replace("LLC$(42)" , "LLC.FDOrdin");   
                fi.replace("LLC$(43)" , "LLC.RIOther");   
                fi.replace("LLC$(44)" , "LLC.FDOther");  
                fi.replace("LLC$(45)" , "LLC.RIExempt");  
                fi.replace("LLC$(46)" , "LLC.FDExempt");  
                fi.replace("LLC$(47)" , "LLC.RISalary");
                fi.replace("LLC$(48)", "LLC.FDSalary");
                fi.Write();
            }

            MessageBox.Show("Done");
        }

        //=================Make list of files to use==============//        
        private void MakeAssignments()
        {

            //file list            
            di = new DirectoryInfo("h:/source09/state/" + ddState.Text.Trim() + "/");
            //di = new DirectoryInfo("c:/test/" + ddState.Text.Trim() + "/");
            FileInfo[] Incfiles = di.GetFiles("*.inc");
            FileInfo[] Srcfiles = di.GetFiles("*.bas");
            //SourceFile[] FileList = new SourceFile()[Incfiles.Count + Srcfiles.Count];

            FileList = new List<SourceFile>();

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
