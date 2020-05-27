using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NetCoreCsharpFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //NOT REQUIRED SINCE CALLED IN THREAD
            //linkLabel1.Enabled = false;
            //linkLabel2.Enabled = false;

            //DoSomeHecticWork();
            //5 WAYS TO CALL A THREAD
            Thread mythread1 = new Thread(DoSomeHecticWork);

            //Thread mythread2 = new Thread(new ThreadStart(DoSomeHecticWork));

            //Thread mythread3 = new Thread(delegate () { DoSomeHecticWork(); });

            //Thread mythread4 = new Thread(() => DoSomeHecticWork() );

            //Class2 obj = new Class2();
            //Thread mythread5 = new Thread(obj.DoSomeHecticWork2);

            mythread1.Start();

            //NOT REQUIRED SINCE CALLED IN THREAD
            //linkLabel1.Enabled = true;
            //linkLabel2.Enabled = true;
        }
        public void DoSomeHecticWork()
        {
            Thread.Sleep(5000);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add(i);
            }

        }
    }

    public class Class2
    {
        public void DoSomeHecticWork2()
        {
            Thread.Sleep(5000);
        }
    }
}
