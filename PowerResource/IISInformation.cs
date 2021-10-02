using Newtonsoft.Json;
using PowerResource.Helper;
using PowerResource.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerResource
{
    public partial class IISInformation : Form
    {
        private int tIndex = -1;
        BackgroundWorker bgw = new BackgroundWorker();
        public string timeStamp { get; set; }
        public static string scriptName = "IISInformation";
        public IISInformationModel FormElements { get; set; }

        public IISInformation()
        {
            InitializeComponent();
            this.timeStamp = DateTime.Now.Ticks.ToString();

            var helper = new WindowHelper();
            FormElements = helper.BindCheckBoxList<IISInformationModel>(Application.ExecutablePath, scriptName, chklstApp);
            LoadCredentials();
        }

        void LoadCredentials()
        {
            //if (FormElements.Credential.SameAsApplication)
            //{
            //    chkiiscred.Checked = true;
            //}
            //else
            //{
            //    chkiiscred.Checked = false;
            //}
            //FormElements.Credential.SameAsApplication = true;
            chkiiscred.Checked = true;
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
        }

        private void IISInformation_Load(object sender, EventArgs e)
        {

        }

        private void chkalliis_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chklstApp.Items.Count; i++)
            {
                if (chkalliis.Checked)
                {
                    chklstApp.SetItemChecked(i, true);
                }
                else
                {
                    chklstApp.SetItemChecked(i, false);
                }
            }
        }

        private void btniislogs_Click(object sender, EventArgs e)
        {
            //IISInformationlogs frmiislogs = new IISInformationlogs();
            //frmiislogs.Show();

            //IISInformationlogs frmiislogs = new IISInformationlogs();
            //DialogResult dr = frmiislogs.ShowDialog(this);
            //if (dr == DialogResult.Cancel)
            //{
            //}
            //else if (dr == DialogResult.OK)
            //{
            //    this.Enabled = true;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApplicationInformation rd = new ApplicationInformation();
            rd.Show();
            this.Close();
        }

        private void chkiiscred_CheckedChanged(object sender, EventArgs e)
        {
            if (chkiiscred.Checked)
            {
                groupBox4.Enabled = false;
                FormElements.Credential.SameAsApplication = true;
                Setallcredentials();
            }
            else
            {
                FormElements.Credential.SameAsApplication = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkiiscred.Checked == false)
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
                MessageBox.Show("Error Occured.for more detail kindly check iis Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
            }

        }
        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //label1.Text = String.Format("Progress: {0} %", e.ProgressPercentage);
            //label2.Text = String.Format("Total items transfered: {0}", e.UserState);
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Execute();
        }

        public void Execute(bool isNormalExecution = true)
        {
            try
            {
                bool blniiserr = false;
                var _rootpath = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Resources");
                string script = Path.Combine(_rootpath, scriptName + ".ps1");
                string scriptText = File.ReadAllText(script);
                StringBuilder sb = new StringBuilder();
                var powershell = new PowerShellHelper();
                var runspace = powershell.CreateRunSpace(Application.ExecutablePath, scriptName);
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                Command myCommand = new Command(scriptText, true);

                foreach (var item in FormElements.IISInformation)
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

                // CSV or Error file Generation code
                var generateCSV = new Csvhelper();
                generateCSV.WriteOutput(Application.ExecutablePath, scriptName, results, pipeline, this.timeStamp, out blniiserr);
                // CSV or Error file Generation code
                //Profilecreation();


                if (blniiserr)
                {
                    // MessageBox.Show("Error Occured.for more detail kindly check iis Log!!\r\n", "Error Message");
                    // return;
                }
                else
                {
                    if (isNormalExecution)
                    {
                        var profileHelper = new ProfileHelper();
                        profileHelper.SetProfileData<IISInformationModel>(Application.ExecutablePath, scriptName, FormElements, chklstApp);
                    }
                }
                runspace.Close();
                //DialogResult dialogResult = MessageBox.Show("IIS scripts executed successfully.Do you want to execute next script?", "Success", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    //do something
                //    SQLServerDiagnostics objfrm = new SQLServerDiagnostics();
                //    objfrm.Show();
                //    this.Close();
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    IISInformation objfrm = new IISInformation();
                //    objfrm.Show();
                //    this.Close();
                //}

                if (isNormalExecution)
                {
                    IISInformationlogs frmiislogs = new IISInformationlogs();
                    DialogResult dr = frmiislogs.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                    }
                    else if (dr == DialogResult.OK)
                    {
                        this.Enabled = true;
                        SQLServerDiagnostics objfrm = new SQLServerDiagnostics();
                        objfrm.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured.for more detail kindly check IIS Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
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
            return true;
        }

        void setcredentials()
        {
            FormElements.Credential.SameAsApplication = chkiiscred.Checked;
            if (chkiiscred.Checked)
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
            }
        }

        private void lblapp_Click(object sender, EventArgs e)
        {
            ApplicationInformation app = new ApplicationInformation();
            app.Show();
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
            SQLServer sql = new SQLServer();
            sql.Show();
            this.Close();
        }

        private void lblssrs_Click(object sender, EventArgs e)
        {
            SSRSConfiguration ssrs = new SSRSConfiguration();
            ssrs.Show();
            this.Close();
        }

        private void lblssas_Click(object sender, EventArgs e)
        {
            SSASConfiguration ssas = new SSASConfiguration();
            ssas.Show();
            this.Close();
        }

        private void lbleventlog_Click(object sender, EventArgs e)
        {
            EventLog evt = new EventLog();
            evt.Show();
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
            var pos = chklstApp.PointToClient(MousePosition);
            tIndex = chklstApp.IndexFromPoint(pos);
            if (tIndex > -1)
            {
                pos = this.PointToClient(MousePosition);
                toolTip1.SetToolTip(chklstApp, FormElements.IISInformation[tIndex].Tooltip);
            }
        }
    }
}
