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
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace PowerResource
{
    public partial class Complete : Form
    {
        public Complete()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EventLog rd = new EventLog();
            rd.Show();
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplicationInformation_Load(object sender, EventArgs e)
        {
            
        }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnkoutput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Output"));
        }

        private void lnkerror_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Error"));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Profile"));
        }
    }
}
