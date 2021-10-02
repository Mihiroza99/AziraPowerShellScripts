using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Diagnostics;

namespace PowerResource
{
    public partial class Eventlogs : Form
    {
        public Eventlogs()
        {
            InitializeComponent();
            LoadLogs();
        }

        void LoadLogs()
        {
            //string streventlog = Baseclass._strcsvpath;
            //string streventerr = Baseclass._strerrpath;

            //string strresultlog = File.ReadAllText(streventlog);
            ////string strresulterr = File.ReadAllText(streventerr);

            //rtbeventlog.Text = strresultlog;
            //rtbeventerr.Text = strresultlog; // once err is generate need to change var


            string streventlog = "";
            string streventerr = "";
            string strresultlog = "";
            string strresulterr = "";

            if (Baseclass._strcsvpath == "")
            {
                rtbeventlog.Text = "There are no logs for eventlog";
                lnkapplogs.Visible = false;
            }
            else
            {
                streventlog = Baseclass._strcsvpath;
                strresultlog = File.ReadAllText(streventlog);
                rtbeventlog.Text = strresultlog;
                lbleventlog.Text = "Eventlog scripts are executed successfully.Below are the logs.";
            }

            if (Baseclass._strerrpath == "")
            {
                rtbeventerr.Text = "There are no errors for eventlog";
                lnkapperr.Visible = false;
            }
            else
            {
                streventerr = Baseclass._strerrpath;
                strresulterr = File.ReadAllText(streventerr);
                rtbeventerr.Text = strresulterr;
                lbleventlog.Text = "Eventlog scripts are executed with errors.Below are the errors.";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResourceInformation rd = new ResourceInformation();
            rd.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ApplicationInformation_Load(object sender, EventArgs e)
        {
            
        }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkapplogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strcsvpath);
        }

        private void lnkapperr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strerrpath);
        }
    }
}
