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
    public partial class IISInformationlogs : Form
    {
        public IISInformationlogs()
        {
            InitializeComponent();
            LoadLogs();
        }

        void LoadLogs()
        {
            //string striislog = Baseclass._strcsvpath;
            //string striiserr = Baseclass._strerrpath;

            //string strresultlog = File.ReadAllText(striislog);
            ////string strresulterr = File.ReadAllText(striiserr);

            //rtbiislogs.Text = strresultlog;
            //rtbiiserrs.Text = strresultlog; // once err is generate need to change var

            string striislog = "";
            string striiserr = "";
            string strresultlog = "";
            string strresulterr = "";

            if (Baseclass._strcsvpath == "")
            {
                rtbiislogs.Text = "There are no logs for iis";
                lnkiislogs.Visible = false;
            }
            else
            {
                striislog = Baseclass._strcsvpath;
                strresultlog = File.ReadAllText(striislog);
                rtbiislogs.Text = strresultlog;
                lbliislog.Text = "iis scripts are executed successfully.Below are the logs.";
            }

            if (Baseclass._strerrpath == "")
            {
                rtbiiserrs.Text = "There are no errors for iis";
                lnkiiserr.Visible = false;
            }
            else
            {
                striiserr = Baseclass._strerrpath;
                strresulterr = File.ReadAllText(striiserr);
                rtbiiserrs.Text = strresulterr;
                lbliislog.Text = "iis scripts are executed with errors.Below are the errors.";
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

        private void lnkiiserr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strerrpath);
        }

        private void lnkiislogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Baseclass._strcsvpath);
        }
    }
}
