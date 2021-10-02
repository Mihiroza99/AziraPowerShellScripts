using PowerResource.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerResource
{
    public partial class ResourceInformation : Form
    {
        public string strsqlauth = " ";
        public string strsqlhostname = " ";
        public string strsqluname = " ";
        public string strsqlpwd = " ";
        public string strsqldatabase = " ";
        public string strappmode = " ";
        public string strappip = " ";
        public string strappport = " ";
        public string strappuname = " ";
        public string strapppwd = " ";
        BackgroundWorker bgwr = new BackgroundWorker();


        public ResourceInformation()
        {
            InitializeComponent();
            //txtappip.Text = "SVRV-LBDB";
            //txtappport.Text = "80";
            //txtappuname.Text = "testadmin";
            //txtapppwd.Text = "ExtPSrun@dm1n";

            //txtsqlhost.Text = "SVRV-LBDB";
            //txtsqllogin.Text = "psUser";
            //txtsqlpass.Text = "server";
            //txtsqldatabase.Text = "NZEnt";

            //txtappip.Text = "KANKHARA";
            //txtappport.Text = "80";
            //txtappuname.Text = "";
            //txtapppwd.Text = "";
            //txtsqlhost.Text = "KANKHARA";
            //txtsqllogin.Text = "sa";
            //txtsqlpass.Text = "server";
            //txtsqldatabase.Text = "Kripalhomes";

            //txtsqlhost.Text = "localhost";
            //txtsqllogin.Text = "sa";
            //txtsqlpass.Text = "server";
            //txtsqldatabase.Text = "master";
            DefaultLoadcontrols();
            OnBackControls();
        }

        private void OnBackControls()
        {
            if (Baseclass._strappmode == "w")
            {
                rbtnapplocal.Checked = true;
                txtappip.Enabled = false;
                txtappport.Enabled = false;
                txtappuname.Enabled = false;
                txtapppwd.Enabled = false;
                txtappip.BackColor = Color.Silver;
                txtappport.BackColor = Color.Silver;
                txtappuname.BackColor = Color.Silver;
                txtapppwd.BackColor = Color.Silver;
            }
            if (Baseclass._strappmode == "network")
            {
                txtappip.Text = Baseclass._strappip;
                txtappport.Text = Baseclass._strappport;
                txtappuname.Text = Baseclass._strappuname;
                txtapppwd.Text = Baseclass._strapppwd;
                rbtnappnetwork.Checked = true;
                txtappip.Enabled = true;
                txtappport.Enabled = true;
                txtappuname.Enabled = true;
                txtapppwd.Enabled = true;
                txtappip.BackColor = Color.WhiteSmoke;
                txtappport.BackColor = Color.WhiteSmoke;
                txtappuname.BackColor = Color.WhiteSmoke;
                txtapppwd.BackColor = Color.WhiteSmoke;
            }
            if (Baseclass._strsqlmode == "w")
            {
                txtsqlhost.Text = Baseclass._strsqlhostname;
                if (Baseclass._strsqlhostname == "localhost")
                {
                    chkdfltinstance.Checked = true;
                }
                txtsqldatabase.Text = Baseclass._strsqldatabase;
                rbtnsqlwin.Checked = true;
                txtsqllogin.Enabled = false;
                txtsqlpass.Enabled = false;
                txtsqllogin.BackColor = Color.Silver;
                txtsqlpass.BackColor = Color.Silver;
            }
            if (Baseclass._strsqlmode == "network")
            {
                txtsqlhost.Text = Baseclass._strsqlhostname;
                if (Baseclass._strsqlhostname == "localhost")
                {
                    chkdfltinstance.Checked = true;
                }
                txtsqldatabase.Text = Baseclass._strsqldatabase;
                txtsqllogin.Text = Baseclass._strsqlunm;
                txtsqlpass.Text = Baseclass._strsqlpwd;
                rbtnsql.Checked = true;
                txtsqllogin.Enabled = true;
                txtsqlpass.Enabled = true;
                txtsqllogin.BackColor = Color.WhiteSmoke;
                txtsqlpass.BackColor = Color.WhiteSmoke;
            }

        }

        private void DefaultLoadcontrols()
        {
            txtappip.Enabled = true;
            txtappport.Enabled = true;
            txtappuname.Enabled = true;
            txtapppwd.Enabled = true;
            txtappip.BackColor = Color.WhiteSmoke;
            txtappport.BackColor = Color.WhiteSmoke;
            txtappuname.BackColor = Color.WhiteSmoke;
            txtapppwd.BackColor = Color.WhiteSmoke;


            txtsqlhost.Enabled = true;
            txtsqllogin.Enabled = true;
            txtsqlpass.Enabled = true;
            txtsqlhost.BackColor = Color.WhiteSmoke;
            txtsqllogin.BackColor = Color.WhiteSmoke;
            txtsqlpass.BackColor = Color.WhiteSmoke;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidateControls())
                return;

            SetDefaultCredential();
            // ApplicationInformation abc = new ApplicationInformation();
            var abc = new EventLog();
            //abc.Getvalues(strsqlauth, strsqlhostname, strsqluname, strsqlpwd, strsqldatabase, strappmode, strappip, strappport, strappuname, strapppwd);
            abc.Show();
            this.Hide();
        }

        private bool ValidateControls()
        {


            if (rbtnappnetwork.Checked)
            {
                if (Convert.ToString(txtappip.Text) == "")
                {
                    MessageBox.Show("Enter IP/Host Name");
                    return false;
                }

                if (Convert.ToString(txtappport.Text) == "")
                {
                    MessageBox.Show("Enter Port");
                    return false;
                }

                if (Convert.ToString(txtappuname.Text) == "")
                {
                    MessageBox.Show("Enter User");
                    return false;
                }

                if (Convert.ToString(txtapppwd.Text) == "")
                {
                    MessageBox.Show("Enter Password");
                    return false;
                }

            }

            if (rbtnsql.Checked)
            {
                if (Convert.ToString(txtsqlhost.Text) == "")
                {
                    MessageBox.Show("Enter Instance");
                    return false;
                }

                if (Convert.ToString(txtsqllogin.Text) == "")
                {
                    MessageBox.Show("Enter Login");
                    return false;
                }

                if (Convert.ToString(txtsqlpass.Text) == "")
                {
                    MessageBox.Show("Enter Password");
                    return false;
                }

                if (Convert.ToString(txtsqldatabase.Text) == "")
                {
                    MessageBox.Show("Enter Database");
                    return false;
                }
                
            }

            if (rbtnsqlwin.Checked)
            {
                if (Convert.ToString(txtsqlhost.Text) == "")
                {
                    MessageBox.Show("Enter Instance");
                    return false;
                }
                if (Convert.ToString(txtsqldatabase.Text) == "")
                {
                    MessageBox.Show("Enter Database");
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnapplocal.Checked == true)
            {
                txtappip.Enabled = false;
                txtappport.Enabled = false;
                txtappuname.Enabled = false;
                txtapppwd.Enabled = false;
                txtappip.BackColor = Color.Silver;
                txtappport.BackColor = Color.Silver;
                txtappuname.BackColor = Color.Silver;
                txtapppwd.BackColor = Color.Silver;
            }
            else
            {
                txtappip.Enabled = true;
                txtappport.Enabled = true;
                txtappuname.Enabled = true;
                txtapppwd.Enabled = true;
                txtappip.BackColor = Color.WhiteSmoke;
                txtappport.BackColor = Color.WhiteSmoke;
                txtappuname.BackColor = Color.WhiteSmoke;
                txtapppwd.BackColor = Color.WhiteSmoke;
            }
        }

        private void ResourceInformation_Load(object sender, EventArgs e)
        {


            //txtappip.Enabled = true;
            //txtappport.Enabled = true;
            //txtappuname.Enabled = true;
            //txtapppwd.Enabled = true;
            //txtappip.BackColor = Color.WhiteSmoke;
            //txtappport.BackColor = Color.WhiteSmoke;
            //txtappuname.BackColor = Color.WhiteSmoke;
            //txtapppwd.BackColor = Color.WhiteSmoke;


            //txtsqlhost.Enabled = true;
            //txtsqllogin.Enabled = true;
            //txtsqlpass.Enabled = true;
            //txtsqlhost.BackColor = Color.WhiteSmoke;
            //txtsqllogin.BackColor = Color.WhiteSmoke;
            //txtsqlpass.BackColor = Color.WhiteSmoke;


            //richTextBox2.Enabled = false;
            //richTextBox3.Enabled = false;
            //richTextBox4.Enabled = false;
            //richTextBox2.BackColor = Color.Silver;
            //richTextBox3.BackColor = Color.Silver;
            //richTextBox4.BackColor = Color.Silver;

            //richTextBox10.Enabled = false;
            //richTextBox9.Enabled = false;
            //richTextBox8.Enabled = false;
            //richTextBox10.BackColor = Color.Silver;
            //richTextBox9.BackColor = Color.Silver;
            //richTextBox8.BackColor = Color.Silver;

            //richTextBox13.Enabled = false;
            //richTextBox12.Enabled = false;
            //richTextBox11.Enabled = false;
            //richTextBox13.BackColor = Color.Silver;
            //richTextBox12.BackColor = Color.Silver;
            //richTextBox11.BackColor = Color.Silver;

            //richTextBox5.Enabled = false;
            //richTextBox6.Enabled = false;
            //richTextBox7.Enabled = false;
            //richTextBox5.BackColor = Color.Silver;
            //richTextBox6.BackColor = Color.Silver;
            //richTextBox7.BackColor = Color.Silver;

            //panel4.Height = 594;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnsqlwin_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnsqlwin.Checked == true)
            {
                //txtsqlhost.Enabled = false;
                txtsqllogin.Enabled = false;
                txtsqlpass.Enabled = false;
                //txtsqlhost.BackColor = Color.Silver;
                txtsqllogin.BackColor = Color.Silver;
                txtsqlpass.BackColor = Color.Silver;
            }
            else
            {
                //txtsqlhost.Enabled = true;
                txtsqllogin.Enabled = true;
                txtsqlpass.Enabled = true;
                //txtsqlhost.BackColor = Color.WhiteSmoke; ;
                txtsqllogin.BackColor = Color.WhiteSmoke; ;
                txtsqlpass.BackColor = Color.WhiteSmoke; ;
            }

        }

        private void chkdfltinstance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdfltinstance.Checked)
            {
                txtsqlhost.Text = "localhost";
                txtsqlhost.BackColor = Color.Silver;
            }
            else
            {
                txtsqlhost.Text = "";
                txtsqlhost.BackColor = Color.WhiteSmoke;
            }
        }

        private void SetDefaultCredential()
        {
            if (rbtnapplocal.Checked)
            {
                Baseclass._strappmode = "w";
                Baseclass._strappip = "localhost";
                Baseclass._strappport = "80";
                Baseclass._strappuname = " ";
                Baseclass._strapppwd = " ";
            }
            if (rbtnappnetwork.Checked)
            {
                Baseclass._strappmode = "network";
                Baseclass._strappip = Convert.ToString(txtappip.Text);
                Baseclass._strappport = Convert.ToString(txtappport.Text);
                Baseclass._strappuname = Convert.ToString(txtappuname.Text);
                Baseclass._strapppwd = Convert.ToString(txtapppwd.Text);
            }

            if (rbtnsqlwin.Checked)
            {
                Baseclass._strsqlmode = "w";
                //Baseclass._strsqlhostname = " ";
                Baseclass._strsqlhostname = Convert.ToString(txtsqlhost.Text) == "" ? " " : Convert.ToString(txtsqlhost.Text);
                Baseclass._strsqlunm = " ";
                Baseclass._strsqlpwd = " ";
            }
            if (rbtnsql.Checked)
            {
                Baseclass._strsqlmode = "network";
                Baseclass._strsqlhostname = Convert.ToString(txtsqlhost.Text);
                Baseclass._strsqlunm = Convert.ToString(txtsqllogin.Text);
                Baseclass._strsqlpwd = Convert.ToString(txtsqlpass.Text);
            }
            Baseclass._strsqldatabase = Convert.ToString(txtsqldatabase.Text) == "" ? " " : Convert.ToString(txtsqldatabase.Text);
            Baseclass._IsdefaultCredentialSet = true;
        }

        private void oneclickexecution_Click(object sender, EventArgs e)
        {
            var list = ProfileHelper.GetScritsProfileStatus();
            var profileName = new StringBuilder();
            if (list.Count > 0)
            {
                profileName.Append("Below Script Profile doesn't exists. Default credentials and all parameters as checked will be considered.");
                profileName.Append(Environment.NewLine);
                foreach (var item in list)
                {
                    profileName.Append("- " + item.Key);
                    profileName.Append(Environment.NewLine);
                }
            }
            else
            {
                var requiredFields = ValidateForOneClick();
                if (requiredFields.Length > 0)
                {
                    profileName.Append("No Profile Found. Neither any credentials details");
                    profileName.Append(Environment.NewLine);
                    profileName.Append("Kindly feel the required fields and click again on One click Execution.");
                    profileName.Append(Environment.NewLine);
                    profileName.Append(requiredFields);
                    MessageBox.Show(profileName.ToString(), "One Click Execution", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    profileName.Append("All Scripts execution will be with entered default credentials.");
                    profileName.Append(Environment.NewLine);
                    SetDefaultCredential();
                }
            }
            profileName.Append("Are you sure you want to continue One click Execution?");

            var dialogResult = MessageBox.Show(profileName.ToString(), "One Click Execution", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (list.Any(a => a.Key == "ApplicationInformation"))
                {
                    if (!ValidateControls())
                    {
                        MessageBox.Show("Default credentials not found. Kindly feel the required fields and click again on One click Execution.", "Need default Credentials", MessageBoxButtons.OK);
                        return;
                    }

                    SetDefaultCredential();
                }

                lblprogress.Visible = true;
                progressBar1.Visible = true;
                button2.Enabled = false;
                oneclickexecution.Enabled = false;

                bgwr.DoWork += new DoWorkEventHandler(bgwr_DoWork);
                bgwr.ProgressChanged += new ProgressChangedEventHandler(bgwr_ProgressChanged);
                bgwr.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwr_RunWorkerCompleted);
                bgwr.WorkerReportsProgress = true;
                bgwr.RunWorkerAsync();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            //    var application = new ApplicationInformation();
            //    application.Execute(false);
            //    var iisInformation = new IISInformation();
            //    iisInformation.Execute(false);
            //    var sqlServerDiagnostics = new SQLServerDiagnostics();
            //    sqlServerDiagnostics.Execute(false);
            //    var sqlServer = new SQLServer();
            //    sqlServer.Execute(false);
            //    var ssrsConfiguration = new SSRSConfiguration();
            //    ssrsConfiguration.Execute(false);
            //    var ssasConfiguration = new SSASConfiguration();
            //    ssasConfiguration.Execute(false);
            //    var eventLog = new EventLog();
            //    eventLog.Execute(false);

            //    var frmapplog = new Applicationlogs();
            //    DialogResult dr = frmapplog.ShowDialog(this);
            //    if (dr == DialogResult.OK)
            //    {
            //        frmapplog.Close();
            //        var frmiislogs = new IISInformationlogs();
            //        var iisDialog = frmiislogs.ShowDialog(this);
            //        if (iisDialog == DialogResult.OK)
            //        {
            //            frmiislogs.Close();
            //            var frmsqlserverdiagnostics = new SQLServerDiagnosticslogs();
            //            var sqlServerDiagnosticsDialog = frmsqlserverdiagnostics.ShowDialog(this);
            //            if (sqlServerDiagnosticsDialog == DialogResult.OK)
            //            {
            //                frmsqlserverdiagnostics.Close();
            //                var sqlServerLogs = new SQLServerlogs();
            //                var sqlServerLogDialog = sqlServerLogs.ShowDialog(this);
            //                if (sqlServerLogDialog == DialogResult.OK)
            //                {
            //                    sqlServerLogs.Close();
            //                    var ssrsLogs = new SSRSConfigurationLogs();
            //                    var ssrsLogDialog = ssrsLogs.ShowDialog(this);
            //                    if (ssrsLogDialog == DialogResult.OK)
            //                    {
            //                        ssrsLogs.Close();
            //                        var ssasLogs = new SSASConfigurationlogs();
            //                        var ssasLogDialog = ssasLogs.ShowDialog(this);
            //                        if (ssasLogDialog == DialogResult.OK)
            //                        {
            //                            ssasLogs.Close();
            //                            var eventLogs = new Eventlogs();
            //                            var eventLogDialog = eventLogs.ShowDialog(this);
            //                            if (eventLogDialog == DialogResult.OK) {
            //                                eventLogs.Close();
            //                                this.Show();
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    //this.Close();
            //    this.Enabled = true;
            //}
            //else if (dialogResult == DialogResult.No)
            //{

            //    return;
            //}
        }


        void bgwr_DoWork(object sender, DoWorkEventArgs e)
        {
            int total = 157; //some number (this is your variable to change)!!

            for (int i = 0; i <= total; i++) //some number (total)
            {
                System.Threading.Thread.Sleep(100);
                int percents = (i * 100) / total;
                bgwr.ReportProgress(percents, i);
            }
        }

        void bgwr_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //label1.Text = String.Format("Progress: {0} %", e.ProgressPercentage);
            //label2.Text = String.Format("Total items transfered: {0}", e.UserState);
        }


        void bgwr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var application = new ApplicationInformation();
            application.Execute(false);
            var iisInformation = new IISInformation();
            iisInformation.Execute(false);
            var sqlServerDiagnostics = new SQLServerDiagnostics();
            sqlServerDiagnostics.Execute(false);
            var sqlServer = new SQLServer();
            sqlServer.Execute(false);
            var ssrsConfiguration = new SSRSConfiguration();
            ssrsConfiguration.Execute(false);
            var ssasConfiguration = new SSASConfiguration();
            ssasConfiguration.Execute(false);
            var eventLog = new EventLog();
            eventLog.Execute(false);

            var frmapplog = new Applicationlogs();
            DialogResult dr = frmapplog.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                frmapplog.Close();
                var frmiislogs = new IISInformationlogs();
                var iisDialog = frmiislogs.ShowDialog(this);
                if (iisDialog == DialogResult.OK)
                {
                    frmiislogs.Close();
                    var frmsqlserverdiagnostics = new SQLServerDiagnosticslogs();
                    var sqlServerDiagnosticsDialog = frmsqlserverdiagnostics.ShowDialog(this);
                    if (sqlServerDiagnosticsDialog == DialogResult.OK)
                    {
                        frmsqlserverdiagnostics.Close();
                        var sqlServerLogs = new SQLServerlogs();
                        var sqlServerLogDialog = sqlServerLogs.ShowDialog(this);
                        if (sqlServerLogDialog == DialogResult.OK)
                        {
                            sqlServerLogs.Close();
                            var ssrsLogs = new SSRSConfigurationLogs();
                            var ssrsLogDialog = ssrsLogs.ShowDialog(this);
                            if (ssrsLogDialog == DialogResult.OK)
                            {
                                ssrsLogs.Close();
                                var ssasLogs = new SSASConfigurationlogs();
                                var ssasLogDialog = ssasLogs.ShowDialog(this);
                                if (ssasLogDialog == DialogResult.OK)
                                {
                                    ssasLogs.Close();
                                    var eventLogs = new Eventlogs();
                                    var eventLogDialog = eventLogs.ShowDialog(this);
                                    if (eventLogDialog == DialogResult.OK)
                                    {
                                        eventLogs.Close();
                                        this.Show();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            this.Enabled = true;
            lblprogress.Visible = false;
            progressBar1.Visible = false;
            button2.Enabled = true;
            oneclickexecution.Enabled = true;
            //ResourceInformation rd = new ResourceInformation();
            //rd.Show();
            //this.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private string ValidateForOneClick()
        {
            var returnvalue = string.Empty;

            if (rbtnappnetwork.Checked)
            {
                if (Convert.ToString(txtappip.Text) == "")
                {
                    returnvalue += "- IP/Host";
                    returnvalue += Environment.NewLine;
                }

                if (Convert.ToString(txtappport.Text) == "")
                {
                    returnvalue += "- Port";
                    returnvalue += Environment.NewLine;
                }

                if (Convert.ToString(txtappuname.Text) == "")
                {
                    returnvalue += "- Machine User";
                    returnvalue += Environment.NewLine;
                }

                if (Convert.ToString(txtapppwd.Text) == "")
                {
                    returnvalue += "- Machine Password";
                    returnvalue += Environment.NewLine;
                }

            }

            if (rbtnsql.Checked)
            {
                if (Convert.ToString(txtsqlhost.Text) == "")
                {
                    returnvalue += "- SqL Instance";
                    returnvalue += Environment.NewLine;
                }

                if (Convert.ToString(txtsqllogin.Text) == "")
                {
                    returnvalue += "- SqL User";
                    returnvalue += Environment.NewLine;
                }

                if (Convert.ToString(txtsqlpass.Text) == "")
                {
                    returnvalue += "- SqL Password";
                    returnvalue += Environment.NewLine;
                }

                if (Convert.ToString(txtsqldatabase.Text) == "")
                {
                    returnvalue += "- SqL Database";
                    returnvalue += Environment.NewLine;
                }
            }

            if (rbtnsqlwin.Checked)
            {
                if (Convert.ToString(txtsqlhost.Text) == "")
                {
                    returnvalue += "- SqL Instance";
                    returnvalue += Environment.NewLine;
                }

                if (Convert.ToString(txtsqldatabase.Text) == "")
                {
                    returnvalue += "- SqL Database";
                    returnvalue += Environment.NewLine;
                }
            }
            return returnvalue;
        }



    }
}
