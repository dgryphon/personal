using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GSFrontEnd
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                string server = "gs3.simutronics.net";
                string message = "ea5c8d89c6e7686929daf9cedf353d22";
                Int32 port = 4900;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                //Console.WriteLine("Sent: {0}", message);
                MessageBox.Show("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //Console.WriteLine("Received: {0}", responseData);
                MessageBox.Show("Received: ", responseData);

                // Close everything.
                client.Close();
            }
            catch (ArgumentNullException ei)
            {
                //Console.WriteLine("ArgumentNullException: {0}", ei);
                MessageBox.Show("failed");
            }
            catch (SocketException ei)
            {
                //Console.WriteLine("SocketException: {0}", ei);
                MessageBox.Show("failed socket");
            }

            MessageBox.Show("Down here!");

            //Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
