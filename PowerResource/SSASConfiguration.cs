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
using System.Security;
using System.Dynamic;
using PowerResource.Model;
using PowerResource.Helper;

namespace PowerResource
{
    public partial class SSASConfiguration : Form
    {

        private int tIndex = -1;
        BackgroundWorker bgw = new BackgroundWorker();
        public string timeStamp { get; set; }
        public static string scriptName = "SSASConfiguration";
        public SSASConfigurationModel FormElements { get; set; }

        public SSASConfiguration()
        {
            InitializeComponent();
            this.timeStamp = DateTime.Now.Ticks.ToString();
            var helper = new WindowHelper();
            FormElements = helper.BindCheckBoxList<SSASConfigurationModel>(Application.ExecutablePath, scriptName, chklstApp);
            LoadCredentials();
        }

        void LoadCredentials()
        {
            //if (FormElements.Credential.SameAsApplication)
            //{
            //    chkssascred.Checked = true;
            //}
            //else
            //{
            //    chkssascred.Checked = false;
            //}
            chkssascred.Checked = true;
            txtappip.Text = FormElements.Credential.MachineHostName;
            txtappport.Text = FormElements.Credential.MachinePortNumber;
            if (FormElements.Credential.MachineMode == "w")
            {
                rbtnapplocal.Checked = true;
            }
            else
            {
                rbtnappnetwork.Checked = true;
                txtappuname.Text = FormElements.Credential.MachineUserName;
                txtapppwd.Text = FormElements.Credential.MachinePassword;
            }

            txtsqldatabase.Text = FormElements.Credential.SqlDatabaseName;
            txtsqlhost.Text = FormElements.Credential.SqlInstanceName;
            if (Convert.ToString(FormElements.Credential.SqlInstanceName).ToLower() == "localhost")
            {
                chkdfltinstance.Checked = true;
            }
            if (FormElements.Credential.SqlAuthMode == "w")
            {
                rbtnsqlwin.Checked = true;
            }
            else
            {
                rbtnsql.Checked = true;
                txtsqllogin.Text = FormElements.Credential.SqlUserName;
                txtsqlpass.Text = FormElements.Credential.SqlPassword;
            }
        }

        private void SSASConfiguration_Load(object sender, EventArgs e)
        {
        }

        private void chkallssas_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chklstApp.Items.Count; i++)
            {
                if (chkallssas.Checked)
                {
                    chklstApp.SetItemChecked(i, true);
                }
                else
                {
                    chklstApp.SetItemChecked(i, false);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            int total = 157; //some number (this is your variable to change)!!

            for (int i = 0; i <= total; i++) //some number (total)
            {
                System.Threading.Thread.Sleep(100);
                int percents = (i * 100) / total;
                bgw.ReportProgress(percents, i);
                //2 arguments:
                //1. procenteges (from 0 t0 100) - i do a calcumation 
                //2. some current value!
            }
        }
           
        private void btnssaslogs_Click(object sender, EventArgs e)
        {
            //SSASConfigurationlogs frmssas = new SSASConfigurationlogs();
            //frmssas.Show();
            //SSASConfigurationlogs frmssas = new SSASConfigurationlogs();
            //DialogResult dr = frmssas.ShowDialog(this);
            //if (dr == DialogResult.Cancel)
            //{
            //    //frmapplog.Close();
            //}
            //else if (dr == DialogResult.OK)
            //{
            //    //textBox1.Text = frm2.getText();
            //    //frmapplog.Close();
            //    this.Enabled = true;
            //}


        }

        private void btnssasbck_Click(object sender, EventArgs e)
        {
            SSRSConfiguration rd = new SSRSConfiguration();
            rd.Show();
            this.Close();
        }

        private void btnssascancel_click(object sender, EventArgs e)
        {
            this.Close();
        }

        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //label1.Text = String.Format("Progress: {0} %", e.ProgressPercentage);
            //label2.Text = String.Format("Total items transfered: {0}", e.UserState);
        }

        private void btnssasnext_click(object sender, EventArgs e)
        {

            try
            {
                if (chkssascred.Checked == false)
                {
                    if (!ValidateControls())
                        return;
                }

                if (chklstApp.CheckedIndices.Count <= 0)
                {
                    MessageBox.Show("Select atleast one item");
                    return;
                }

                button2.Enabled = false;
                lblprogress.Visible = true;
                progressBar1.Visible = true;
                setcredentials();

                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                bgw.WorkerReportsProgress = true;
                bgw.RunWorkerAsync();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Occured.for more detail kindly check SSAS Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
            }
        }


        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Execute();
        }

        public void Execute(bool isNormalExecution = true)
        {
            try
            {
                bool blnsqlerr = false;
                var _rootpath = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Resources");
                string script = Path.Combine(_rootpath, scriptName + ".ps1");
                string scriptText = File.ReadAllText(script);
                StringBuilder sb = new StringBuilder();
                var powershell = new PowerShellHelper();
                var runspace = powershell.CreateRunSpace(Application.ExecutablePath, scriptName);
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                Command myCommand = new Command(scriptText, true);

                var sqlWindowsAuthParam = new CommandParameter(null, "w");
                var sqlServerParam = new CommandParameter(null, FormElements.Credential.SqlInstanceName);
                var sqlUserName = new CommandParameter(null, FormElements.Credential.SqlUserName);
                var sqlPwd = new CommandParameter(null, FormElements.Credential.SqlPassword);
                myCommand.Parameters.Add(sqlWindowsAuthParam);
                myCommand.Parameters.Add(sqlServerParam);

                myCommand.Parameters.Add(sqlUserName);
                myCommand.Parameters.Add(sqlPwd);

                foreach (var item in FormElements.SSASConfiguration)
                {
                    if (chklstApp.CheckedIndices.Contains(item.id))
                    {
                        var param5 = new CommandParameter(null, 1);
                        myCommand.Parameters.Add(param5);
                    }
                    else
                    {
                        var param5 = new CommandParameter(null, 0);
                        myCommand.Parameters.Add(param5);
                    }
                }

                pipeline.Commands.Add(myCommand);

                Collection<PSObject> results = pipeline.Invoke();
                var errors = pipeline.Error;
                Console.WriteLine(sb.ToString());
                // CSV or Error file Generation code
                var generateCSV = new Csvhelper();
                generateCSV.WriteOutput(Application.ExecutablePath, scriptName, results, pipeline, this.timeStamp, out blnsqlerr);
                // CSV or Error file Generation code
                //Profilecreation();

                if (blnsqlerr)
                {
                    //MessageBox.Show("Error Occured.for more detail kindly check SSAS Log!!\r\n", "Error Message");
                    //return;
                }
                else
                {
                    if (isNormalExecution)
                    {
                        var profileHelper = new ProfileHelper();
                        profileHelper.SetProfileData<SSASConfigurationModel>(Application.ExecutablePath, scriptName, FormElements, chklstApp);
                    }
                }

                runspace.Close();

                //DialogResult dialogResult = MessageBox.Show("SSAS scripts executed successfully.Do you want to execute next script?", "Success", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    //do something
                //    EventLog objfrm = new EventLog();
                //    objfrm.Show();
                //    this.Close();
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    SSASConfiguration objfrm = new SSASConfiguration();
                //    objfrm.Show();
                //    this.Close();
                //}

                if (isNormalExecution)
                {
                    SSASConfigurationlogs frmssas = new SSASConfigurationlogs();
                    DialogResult dr = frmssas.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        //frmapplog.Close();
                    }
                    else if (dr == DialogResult.OK)
                    {
                        //textBox1.Text = frm2.getText();
                        //frmapplog.Close();
                        this.Enabled = true;
                        EventLog objfrm = new EventLog();
                        objfrm.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured.for more detail kindly check SSAS Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
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
                    MessageBox.Show("Enter Server");
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
                    MessageBox.Show("Enter Instance Name");
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

        private void lblapp_Click(object sender, EventArgs e)
        {
            ApplicationInformation app = new ApplicationInformation();
            app.Show();
            this.Close();
        }

        private void lbliis_Click(object sender, EventArgs e)
        {
            IISInformation iis = new IISInformation();
            iis.Show();
            this.Close();
        }

        private void lblsqld_Click(object sender, EventArgs e)
        {
            SQLServerDiagnostics sqld = new SQLServerDiagnostics();
            sqld.Show();
            this.Close();
        }

        private void lblsql_Click(object sender, EventArgs e)
        {
            SQLServer app = new SQLServer();
            app.Show();
            this.Close();
        }

        private void lblevent_Click(object sender, EventArgs e)
        {
            EventLog evt = new EventLog();
            evt.Show();
            this.Close();
        }

        private void lblssrs_Click(object sender, EventArgs e)
        {
            SSRSConfiguration ssrs = new SSRSConfiguration();
            ssrs.Show();
            this.Close();
        }

        private void chklstApp_MouseMove(object sender, MouseEventArgs e)
        {
            //int index = chkallapp.IndexFromPoint(e.Location);
            //if (tIndex != index)
            //{
            //    GetToolTip();
            //}
            //if (tIndex != chkallapp.IndexFromPoint(e.Location))
            //    GetToolTip();
        }

        private void chklstApp_MouseHover(object sender, EventArgs e)
        {
            GetToolTip();
        }

        void GetToolTip()
        {
            Point pos = chklstApp.PointToClient(MousePosition);
            tIndex = chklstApp.IndexFromPoint(pos);
            if (tIndex > -1)
            {
                pos = this.PointToClient(MousePosition);
                toolTip1.SetToolTip(chklstApp, FormElements.SSASConfiguration[tIndex].Tooltip);
            }
        }

        private void chkssascred_CheckedChanged(object sender, EventArgs e)
        {
            if (chkssascred.Checked)
            { 
                groupBox4.Enabled = false;
                Setallcredentials();
            }
            else
            { 
                groupBox4.Enabled = true;
            }
        }

        void Setallcredentials()
        {
            if (Baseclass._strappmode == "w")
            {
                rbtnapplocal.Checked = true;
            }
            else
            {
                rbtnappnetwork.Checked = true;
                txtappip.Text = Baseclass._strappip;
                txtappport.Text = Baseclass._strappport;
                txtappuname.Text = Baseclass._strappuname;
                txtapppwd.Text = Baseclass._strapppwd;
            }

            if (Baseclass._strsqlmode == "w")
            {
                rbtnsqlwin.Checked = true;
                txtsqlhost.Text = Baseclass._strsqlhostname;
                txtsqldatabase.Text = Baseclass._strsqldatabase;
            }
            else
            {
                rbtnsql.Checked = true;
                txtsqlhost.Text = Baseclass._strsqlhostname;
                txtsqllogin.Text = Baseclass._strsqlunm;
                txtsqlpass.Text = Baseclass._strsqlpwd;
                txtsqldatabase.Text = Baseclass._strsqldatabase;
            }

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

        private void rbtnapplocal_CheckedChanged(object sender, EventArgs e)
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

                txtappip.Text = FormElements.Credential.MachineHostName;
                txtappport.Text = FormElements.Credential.MachinePortNumber;
            }
            else
            {
                txtappip.Enabled = true;
                txtappport.Enabled = true;
                txtappuname.Enabled = true;
                txtapppwd.Enabled = true;

                txtappip.Text = "";
                txtappport.Text = "";
                txtappuname.Text = "";
                txtapppwd.Text = "";

                txtappip.BackColor = Color.WhiteSmoke;
                txtappport.BackColor = Color.WhiteSmoke;
                txtappuname.BackColor = Color.WhiteSmoke;
                txtapppwd.BackColor = Color.WhiteSmoke;
            }
        }

        void setcredentials()
        {
            FormElements.Credential.SameAsApplication = chkssascred.Checked;
            if (chkssascred.Checked)
            {
                FormElements.Credential.MachineMode = Baseclass._strappmode;
                FormElements.Credential.MachineHostName = Baseclass._strappip;
                FormElements.Credential.MachinePortNumber = Baseclass._strappport;
                FormElements.Credential.MachineUserName = Baseclass._strappuname;
                FormElements.Credential.MachinePassword = Baseclass._strapppwd;

                FormElements.Credential.SqlAuthMode = Baseclass._strsqlmode;
                FormElements.Credential.SqlInstanceName = Baseclass._strsqlhostname;
                FormElements.Credential.SqlUserName = Baseclass._strsqlunm;
                FormElements.Credential.SqlPassword = Baseclass._strsqlpwd;
                FormElements.Credential.SqlDatabaseName = Baseclass._strsqldatabase;
            }
            else
            {
                if (rbtnapplocal.Checked)
                {
                    FormElements.Credential.MachineMode = "w";
                    FormElements.Credential.MachineHostName = "localhost";
                    FormElements.Credential.MachinePortNumber = "80";
                    FormElements.Credential.MachineUserName = " ";
                    FormElements.Credential.MachinePassword = " ";
                }
                if (rbtnappnetwork.Checked)
                {
                    FormElements.Credential.MachineMode = "network";
                    FormElements.Credential.MachineHostName = Convert.ToString(txtappip.Text);
                    FormElements.Credential.MachinePortNumber = Convert.ToString(txtappport.Text);
                    FormElements.Credential.MachineUserName = Convert.ToString(txtappuname.Text);
                    FormElements.Credential.MachinePassword = Convert.ToString(txtapppwd.Text);
                }

                if (rbtnsqlwin.Checked)
                {
                    FormElements.Credential.SqlAuthMode = "w";
                    //FormElements.Credential.SqlInstanceName = " ";
                    FormElements.Credential.SqlUserName = " ";
                    FormElements.Credential.SqlPassword = " ";
                }
                if (rbtnsql.Checked)
                {
                    FormElements.Credential.SqlAuthMode = "network";
                    FormElements.Credential.SqlInstanceName = Convert.ToString(txtsqlhost.Text);
                    FormElements.Credential.SqlUserName = Convert.ToString(txtsqllogin.Text);
                    FormElements.Credential.SqlPassword = Convert.ToString(txtsqlpass.Text);
                }

                FormElements.Credential.SqlDatabaseName = Convert.ToString(txtsqldatabase.Text) == "" ? " " : Convert.ToString(txtsqldatabase.Text);
            }
        }
    }
}
