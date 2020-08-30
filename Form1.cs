using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Typer_T_600
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);



        public Form1()
        {
            InitializeComponent();
        }

        public string SelectedTextToType = "";
        public string[] WordsToType;

        public int Index = 0;


        public void SetNextText()
        {
            if (Index == WordsToType.Length-1)
            {
                SelectedTextToType = "EXIT";
            } else
            {
                Index++;
                SelectedTextToType = WordsToType[Index];
            }
        }




        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == radioButton2.Checked)
            {
                MessageBox.Show("Please Select a Method");
                return;
            }

            if (richTextBox1.Text=="")
            {
                MessageBox.Show("Please Enter Text To Type");
                return;
            }

            if (richTextBox1.Text.Length < 500)
            {
                MessageBox.Show("Please Enter Something Challenging to Type. AT least a Few 100 Words");
                return;
            }

            if (radioButton1.Checked==true)
            {
                WordsToType = richTextBox1.Text.Split(' ');
            } else
            {
                WordsToType = richTextBox1.Text.Split('.');
            }

            SelectedTextToType = WordsToType[Index];

            System.Threading.Thread.Sleep(5000);
                        

            while (true)
            {
                if (SelectedTextToType == "EXIT")
                    break;
                SendKeys.SendWait(SelectedTextToType);
                SendKeys.SendWait("{ENTER}");
                SetNextText();
            }
        }

        
    }
}
