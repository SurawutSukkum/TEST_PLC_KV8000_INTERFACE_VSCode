using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace TEST_PLC_V3
{
    public partial class Form1 : Form
    {
        public string _data;
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        public Form1()
        {
            InitializeComponent();
            //clientSocket.Connect("169.254.98.140", 8501);
            textBox1.Text = "PLEASE INPUT IP ADDRESS";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s = "WR " + textBox2.Text + ".U 1\r\n";
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.UTF8.GetBytes(s);
            serverStream.Write(outStream, 0, outStream.Length);
            byte[] msg = new byte[1024];     //the messages arrive as byte array
            serverStream.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
            textBox3.Text= (Encoding.UTF8.GetString(msg)); //now , we write the message as string
            serverStream.Flush();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string s = "WR " + textBox2.Text + ".U 0\r\n";
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.UTF8.GetBytes(s);
            serverStream.Write(outStream, 0, outStream.Length);
            byte[] msg = new byte[1024];     //the messages arrive as byte array
            serverStream.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
            textBox3.Text = (Encoding.UTF8.GetString(msg)); //now , we write the message as string
            serverStream.Flush();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clientSocket.Connect(textBox1.Text, 8501);
            button3.Visible = false;
        }
    }
}
