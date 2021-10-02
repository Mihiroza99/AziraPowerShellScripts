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
    public partial class SQLServerlogs : Form
    {
        public SQLServerlogs()
        {
            InitializeComponent();
            LoadLogs();
        }

        void LoadLogs()
        {
            string strsqllog = "";
            string strsqlerr = "";
            string strresultlog = "";
            string strresulterr = "";

            if (Baseclass._strcsvpath == "")
            {
                rtbsqllog.Text = "There are no logs for sql server";
                lnksqllogs.Visible = false;
            }
            else
            {
                strsqllog = Baseclass._strcsvpath;
                strresultlog = File.ReadAllText(strsqllog);
                rtbsqllog.Text = strresultlog;
                lblsqllog.Text = "SQL Server scripts are executed successfully.Below are the logs.";
            }

            if (Baseclass._strerrpath == "")
            {
                rtbsqlerr.Text = "There are no errors for sql server";
                lnksqlerr.Visible = false;
            }
            else
            {
                strsqlerr = Baseclass._strerrpath;
                strresulterr = File.ReadAllText(strsqlerr);
                rtbsqlerr.Text = strresulterr;
                lblsqllog.Text = "SQL Server scripts are executed with errors.Below are the errors.";
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

        private void lnksqllogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strcsvpath);
        }

        private void lnksqlerr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strerrpath);
        }
    }
}
