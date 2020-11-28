using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfTcpLib;

namespace TcpClient
{
    public partial class Form1 : Form
    {
        static ChannelFactory<IServiceTcp> cf;
        static IServiceTcp serv;

        public Form1()
        {
            InitializeComponent();

            cf = new ChannelFactory<IServiceTcp>(new NetTcpBinding(), "net.tcp://localhost:8001/tcp");
            serv = cf.CreateChannel();

            Thread time = new Thread(() => GetTime(serv));
            time.Start();
        }


        private void GetTime(IServiceTcp serv)
        {
            while (true)
            {
                dateLabel.Text = serv.GetTime();
                Thread.Sleep(1000);
            }
        }

        private string path = "D:/";

        private void getBase64Button_Click(object sender, EventArgs e)
        {
            textTextBox.Text = serv.GetBase64Encode(fileNameTextBox.Text, int.Parse(offsetTextBox.Text), int.Parse(sizeTextBox.Text));
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            byte[] piece = File.ReadAllBytes(path + fileNameTextBox.Text).Skip(int.Parse(offsetTextBox.Text)).Take(int.Parse(sizeTextBox.Text)).ToArray();
            textTextBox.Text = serv.SaveFileBlock(piece);
        }

        private void countWordsButton_Click(object sender, EventArgs e)
        {
            if (textTextBox.Text != "")
            {
                List<string> list = new List<string>();
                foreach (string str in textTextBox.Lines)
                {
                    list.Add(str);
                }
                if (list.Count != 0)
                {
                    wordCountLabel.Text = "Count = " + serv.GetWordsCount(list).ToString();
                }
            }
        }
    }
}
