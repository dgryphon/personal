using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
            if (temp.Trim() == "") { return; }        //empty string do not add
            LList.Insert(index, temp + "\t\'INSERTED BY ADDAFORM");

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
                if (LList[i].ToUpper().Contains(searchstring.ToUpper())) { return i; }
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
