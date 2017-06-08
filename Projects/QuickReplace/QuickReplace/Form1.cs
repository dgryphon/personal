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
        }

        //=================Make list of files to use==============//        
        private void FindDeaders()
        {
            List<SourceFile> theList = new List<SourceFile>();
            bool itemfound = false;
            foreach (SourceFile fi in FileList)
            {
                itemfound = false;
                foreach (SourceFile fi2 in FileList)
                {
                    if (fi2.findFirst(fi.ToString()) > 0)
                    {
                        itemfound = true;
                    }
                }
                if (itemfound==false && (fi.ToString().Contains(".INC") || fi.ToString().Contains(".inc")) ) { theList.Add(fi); }
            }

            string outp = "";
            foreach(SourceFile th in theList)
            {
                outp += th.ToString()+"\n";
            }

            MessageBox.Show(outp);
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
