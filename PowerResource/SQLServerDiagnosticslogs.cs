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
    public partial class SQLServerDiagnosticslogs : Form
    {
        public SQLServerDiagnosticslogs()
        {
            InitializeComponent();
            LoadLogs();
        }

        void LoadLogs()
        {
            string strsqldlog = "";
            string strsqlderr = "";
            string strresultlog = "";
            string strresulterr = "";

            if (Baseclass._strcsvpath == "")
            {
                rtbsqldlogs.Text = "There are no logs for sql server diagnostics";
                lnksqldlogs.Visible = false;
            }
            else
            {
                strsqldlog = Baseclass._strcsvpath;
                strresultlog = File.ReadAllText(strsqldlog);
                rtbsqldlogs.Text = strresultlog;
                lblsqldlog.Text = "SQL Server Diagnostics scripts are executed successfully.Below are the logs.";
            }

            if (Baseclass._strerrpath == "")
            {
                rtbsqlderrs.Text = "There are no errors for sql server diagnostics";
                lnksqlderr.Visible = false;
            }
            else
            {
                strsqlderr = Baseclass._strerrpath;
                strresulterr = File.ReadAllText(strsqlderr);
                rtbsqlderrs.Text = strresulterr;
                lblsqldlog.Text = "SQL Server Diagnostics scripts are executed with errors.Below are the errors.";
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

        private void lnksqlderr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strerrpath);
        }

        private void lnksqldlogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strcsvpath);
        }
    }
}
