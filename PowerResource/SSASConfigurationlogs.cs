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
    public partial class SSASConfigurationlogs : Form
    {
        public SSASConfigurationlogs()
        {
            InitializeComponent();
            LoadLogs();
        }

        void LoadLogs()
        {
            string strssaslog = "";
            string strssaserr = "";
            string strresultlog = "";
            string strresulterr = "";

            if (Baseclass._strcsvpath == "")
            {
                rtbssaslogs.Text = "There are no logs for ssas";
                lnkssaslogs.Visible = false;
            }
            else
            {
                strssaslog = Baseclass._strcsvpath;
                strresultlog = File.ReadAllText(strssaslog);
                rtbssaslogs.Text = strresultlog;
                lblssaslog.Text = "SSAS Configuration scripts are executed successfully.Below are the logs.";
            }

            if (Baseclass._strerrpath == "")
            {
                rtbssaserrs.Text = "There are no errors for ssas";
                lnkssaserr.Visible = false;
            }
            else
            {
                strssaserr = Baseclass._strerrpath;
                strresulterr = File.ReadAllText(strssaserr);
                rtbssaserrs.Text = strresulterr;
                lblssaslog.Text = "SSAS Configuration scripts are executed with errors.Below are the errors.";
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
        
        private void lnkssaslogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strcsvpath);
        }

        private void lnkssaserr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strerrpath);
        }
    }
}
