using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
namespace RunAll_2._0
{
    public partial class Form1 : Form
    {

        List<Process> ProcessList = new List<Process>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listBox1.BackColor = Color.FromArgb(26, 20, 16);
            listBox1.ForeColor = Color.White;
            DirectoryInfo directoryInfo = new DirectoryInfo(Assembly.GetAssembly(typeof(Program)).Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "") + @"shortcuts");
            List<string> list = new List<string>();

            foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.lnk"))
            {
                System.Diagnostics.Process process = new Process();
                process.StartInfo.FileName = fileInfo.FullName;
                process.Start();
                ProcessList.Add(process);
                listBox1.Items.Add(fileInfo.Name);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var prop in ProcessList)
            {
                try {
                    prop.Kill();
                } catch(Exception k) {
                    continue;
                }
            }

            this.Name = (Process.GetProcessesByName("AutoHotkey").Length.ToString());

            foreach (var proP in Process.GetProcessesByName("AutoHotkey")) {
                proP.Kill();
            }
        }
    }
}
