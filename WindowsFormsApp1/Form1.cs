using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // Code from tuts+ YouTube video at https://www.youtube.com/watch?v=DqjIQiZ_ql4

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CallBigImportantMethod();
            label1.Text = "Waiting...";
        }

        private async void CallBigImportantMethod()
        {
            var result = await BigLongImportantMethodAsync("Andrew");
            label1.Text = result;
        }

        private Task<string> BigLongImportantMethodAsync(string name)
        {
            return Task.Factory.StartNew(() => BigLongImportantMethod(name));
        }

        private string BigLongImportantMethod(string name)
        {
            Thread.Sleep(2000);
            return ($"Hello, {name}!");
        }
    }
}
