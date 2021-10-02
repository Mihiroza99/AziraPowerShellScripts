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
    public partial class Applicationlogs : Form
    {
        public Applicationlogs()
        {
            InitializeComponent();
            LoadLogs();
            //ApplicationInformation  p = (ApplicationInformation)this.Owner;
        }

        void LoadLogs()
        {
            string strapplog = "";
            string strapperr = "";
            string strresultlog = "";
            string strresulterr = "";

            if (Baseclass._strcsvpath == "")
            {
                rtbapplog.Text = "There are no logs for application";
                lnkapplogs.Visible = false;
            }
            else
            {
                strapplog = Baseclass._strcsvpath;
                strresultlog = File.ReadAllText(strapplog);
                rtbapplog.Text = strresultlog;
                lblapplog.Text = "Application scripts are executed successfully.Below are the logs.";
                
            }

            if (Baseclass._strerrpath == "")
            {
                rtbapperr.Text = "There are no errors for application";
                lnkapperr.Visible = false;
            }
            else 
            {
                strapperr = Baseclass._strerrpath;
                strresulterr = File.ReadAllText(strapperr);
                rtbapperr.Text = strresulterr;
                lblapplog.Text = "Application scripts are executed with errors.Below are the errors.";
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
            this.Owner.Enabled = false;
        }


        private void ApplicationInformation_Closed(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
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
