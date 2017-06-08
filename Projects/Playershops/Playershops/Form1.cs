using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace Playershops
{

    public partial class frmMain : Form
    {

        // Find window
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //set foregroundwindow
//        [return: MarshalAs(UnmanagedType.Bool)]
//        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//        public static extern bool SetForegroundWindow(IntPtr hwnd);

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDoInventory_Click(object sender, EventArgs e)
        {

            string strPartialTitle = "GemStone IV";
            string FEtitle = "";
            IntPtr parentHandle= IntPtr.Zero;
            IntPtr entryHandle;
            IntPtr textWindow;

            int hWnd;

            MessageHelper msg = new MessageHelper();

            // enumerate all processes
            foreach (Process pProcess in Process.GetProcesses())
            {
                // check process' main window title
                if (pProcess.MainWindowTitle.Contains(strPartialTitle))
                {
                    // it's a match
                    String strMsg = String.Format("Window \"{0}\" is a match!", pProcess.MainWindowTitle);
                    FEtitle = pProcess.MainWindowTitle;
                    MessageBox.Show(strMsg);

                    hWnd = msg.getWindowId(null, FEtitle);
                    msg.bringAppToFront(hWnd);

                    parentHandle = pProcess.Handle;

                    //msg.sendWindowsStringMessage(cWnd, 0, "Some_String_Message");

                    

                }
               
            }

            //int result = 0;
            //First param can be null
            hWnd = msg.getWindowId(null, FEtitle);

            msg.bringAppToFront(hWnd);
            //msg.sendWindowsStringMessage(hWnd, 0, "Some_String_Message");

            SendKeys.SendWait("Something here{ENTER}");
          
            List<IntPtr> kids;
            List<IntPtr> kids2;
            
            bool tried = true;
            while (tried)
            {
                 kids2 = msg.getChildId(parentHandle);
                 kids.Join<IntPtr>(kids2);
                kids.j
            }

            MessageBox.Show(kids.Count.ToString());

            //IDictionary<IntPtr, string> windows = msg.GetOpenWindowsFromPID(hWnd);
            foreach (IntPtr curKid in kids)
            {
                // Do whatever you want here 
                MessageBox.Show("trying to find some kids " + curKid.ToString());
            }

            //MessageBox.Show("the parent id is " + hWnd.ToString());

            //Or for an integer message
            //result = msg.sendWindowsMessage(hWnd, MessageHelper.WM_USER, 123, 456);


            //string lpClassName = "wizard";
            //string lpWindowName = "wizard";
            //IntPtr hWnd = FindWindow(lpClassName, lpWindowName);
            //SetForegroundWindow(hWnd); string z = "TEXT"; const int WM_SETTEXT = 0x0C; SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, z);
            //SendKeys.Send("This is my text");



            /*
            Process[] processes = Process.GetProcessesByName("wizard");
            Process theProcess = new Process();
            MessageBox.Show("Doin this");
            foreach (Process p in processes)
            {
                MessageBox.Show("found something "+p.ToString());               
            }

             */ 
            //string lpClassName = "WizardFE";
            //string lpWindowName = "[Hevalt : Gemstone IV]";

            //IntPtr hWnd = FindWindow





            // locate an open wizardFE or StormFront
            // verify this is the one they want to use for inventory gathering
            // once verified take control of FE
                // Figure out what town you're in
                // Go to a starting point
                // collect information one shop at a time
                // save information to a local database - timestamp
        }

        private void btnUpLoadInventory_Click(object sender, EventArgs e)
        {
            // collect to the website
            // check for local database
                // if exists then upload to the website - join database with existing
                // if it doesn't exist then toss up error dialog
        }
    }
}

public class MessageHelper
{
        [DllImport("User32.dll")]
        private static extern int RegisterWindowMessage(string lpString);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);

        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        //public static extern Int32 FindWindowEx(IntPtr hwndParent, string tat, string lpszClass, string lpszWindow);
        public static extern Int32 FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);        

        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        // send message
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        // post message
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(int hWnd, int Msg, int wParam, int lParam);

        // setforegroundwindow
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(int hWnd);

        // show window
        [DllImport("User32.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(int hWnd, int nShow);


        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        [DllImport("USER32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        public const int WM_USER = 0x400;
        public const int WM_COPYDATA = 0x4A;

        //Used for WM_COPYDATA for string messages
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        public bool bringAppToFront(int hWnd)
        {
            ShowWindow(hWnd, 1);
            return SetForegroundWindow(hWnd);
        }

        public int sendWindowsStringMessage(int hWnd, int wParam, string msg)
        {
            int result = 0;

            if (hWnd > 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(msg);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = msg;
                cds.cbData = len + 1;
                result = SendMessage(hWnd, WM_COPYDATA, wParam, ref cds);
            }
            return result;
        }

        public int sendWindowsMessage(int hWnd, int Msg, int wParam, int lParam)
        {
            int result = 0;

            if (hWnd > 0)
            {
                result = SendMessage(hWnd, Msg, wParam, lParam);
            }

            return result;
        }

        public int getWindowId(string className, string windowName)
        {
            return FindWindow(className, windowName);
        }

        public List<IntPtr> getChildId(IntPtr hParent)
        {
            //ShowWindow(hParent.ToInt32(), 1);
            return GetChildWindows(hParent);
            
        }

        //*****************************************************************

        /// <summary>
        /// Returns a list of child windows
        /// </summary>
        /// <param name="parent">Parent of the windows to return</param>
        /// <returns>List of child windows</returns>
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                    if (listHandle.IsAllocated)
                        listHandle.Free();
            }
            return result;
        }

        /// <summary>
        /// Callback method to be used when enumerating windows.
        /// </summary>
        /// <param name="handle">Handle of the next window</param>
        /// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
        /// <returns>True to continue the enumeration, false to bail</returns>
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }

        /// <summary>
        /// Delegate for the EnumChildWindows method
        /// </summary>
        /// <param name="hWnd">Window handle</param>
        /// <param name="parameter">Caller-defined variable; we use it for a pointer to our list</param>
        /// <returns>True to continue enumerating, false to bail.</returns>
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);



        //*****************************************************************
}