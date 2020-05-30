using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreCsharpFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private int ReturnCount()
        {
            int count;
            Thread.Sleep(5000);
            count = 1000;
            return count;
        }

        //USING TASK
        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Task<int> mytask = new Task<int>(ReturnCount);
            mytask.Start();
            label1.Text = "Processing";
            int count = await mytask;
            label1.Text = "Count is " + count.ToString();
        }

        //USING THREAD : CODE BECOMES MORE COMPLICATED
        //HENCE FOR ASYNCHRONOUS PROGRAMMING TASK IS PREFERRRED OVER THREAD
        int characterCount = 0;
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread mythread = new Thread(() => 
            {
                characterCount = ReturnCount();
                //ACTION IS USED TO MAKE THE THREAD UNDERSTAND THAT THIS CODE NEED TO BE EXECUTED IN THE MAIN THREAD (link click) AND NOT WORKER THREAD (mythread)
                Action myaction = new Action(SetLabel);
                this.BeginInvoke(myaction);
            });
            mythread.Start();
            label2.Text = "Processing";
        }

        private void SetLabel()
        {
            label2.Text = "Count is " + characterCount.ToString();
            MessageBox.Show("Good Bye C#");
        }
    }
}
