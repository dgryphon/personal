using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {            
            StreamWriter tw;
            tw = File.CreateText("C:\\resultsd.txt");
            foreach (string arg in args)
            {                
                //Console.WriteLine(arg);                
                tw.WriteLine(arg);
                //tw.Write("this");
            }

            //Console.ReadLine();
            tw.Close();
        }


    }
}
