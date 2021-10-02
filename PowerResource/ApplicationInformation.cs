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
using System.Web.Script.Serialization;
using System.Dynamic;
using PowerResource.Model;
using PowerResource.Helper;

namespace PowerResource
{

    public partial class ApplicationInformation : Form
    {
        private int tIndex = -1;

        BackgroundWorker bgw = new BackgroundWorker();
        public string timeStamp { get; set; }
        public ApplicationModel FormElements { get; set; }

        public static string scriptName = "ApplicationInformation";

        public ApplicationInformation()
        {
            InitializeComponent();
            chklstApp.MouseHover += new EventHandler(chklstApp_MouseHover);
            chklstApp.MouseMove += new MouseEventHandler(chklstApp_MouseMove);
            this.timeStamp = DateTime.Now.Ticks.ToString();

            var helper = new WindowHelper();
            FormElements = helper.BindCheckBoxList<ApplicationModel>(Application.ExecutablePath, scriptName, chklstApp);
        }

        private void ApplicationInformation_Load(object sender, EventArgs e)
        {
        }

        private void chkallapp_CheckedChanged_1(object sender, EventArgs e)
        {
            for (int i = 0; i < chklstApp.Items.Count; i++)
            {
                if (chkallapp.Checked)
                {
                    chklstApp.SetItemChecked(i, true);
                }
                else
                {
                    chklstApp.SetItemChecked(i, false);
                }
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
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnapplogs_Click(object sender, EventArgs e)
        {
            //Applicationlogs frmapplog = new Applicationlogs();
            //DialogResult dr = frmapplog.ShowDialog(this);
            //if (dr == DialogResult.Cancel)
            //{
            //    //frmapplog.Close();
            //}
            //else if (dr == DialogResult.OK)
            //{
            //    this.Enabled = true;
            //}
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            int total = 157; //some number (this is your variable to change)!!

            for (int i = 0; i <= total; i++) //some number (total)
            {
                System.Threading.Thread.Sleep(100);
                int percents = (i * 100) / total;
                bgw.ReportProgress(percents, i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                    return;

                lblprogress.Visible = true;
                progressBar1.Visible = true;
                button2.Enabled = false;

                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                bgw.WorkerReportsProgress = true;
                bgw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured.for more detail kindly check Application Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
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
                bool blnapperr = false;
                //do the code when bgv completes its work
                var _rootpath = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Resources");
                string script = Path.Combine(_rootpath, scriptName + ".ps1");
                string scriptText = File.ReadAllText(script);
                StringBuilder sb = new StringBuilder();

                var powershell = new PowerShellHelper();
                var runspace = powershell.CreateRunSpace(Application.ExecutablePath, scriptName);
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                Command myCommand = new Command(scriptText, true);

                var hostName = new CommandParameter(null, FormElements.Credential.MachineHostName);
                var port = new CommandParameter(null, FormElements.Credential.MachinePortNumber);
                var sqlWindowsAuthParam = new CommandParameter(null, FormElements.Credential.SqlAuthMode);
                var sqlServerParam = new CommandParameter(null, FormElements.Credential.SqlInstanceName);
                var sqlUserName = new CommandParameter(null, FormElements.Credential.SqlUserName);
                var sqlPwd = new CommandParameter(null, FormElements.Credential.SqlPassword);

                myCommand.Parameters.Add(hostName);
                myCommand.Parameters.Add(port);

                if (FormElements.Credential.SqlAuthMode != "w")
                {
                    sqlWindowsAuthParam = new CommandParameter(null, "network");
                }

                myCommand.Parameters.Add(sqlWindowsAuthParam);

                myCommand.Parameters.Add(sqlServerParam);
                myCommand.Parameters.Add(sqlUserName);
                myCommand.Parameters.Add(sqlPwd);

                foreach (var item in FormElements.ApplicationInformation)
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
                generateCSV.WriteOutput(Application.ExecutablePath, scriptName, results, pipeline, this.timeStamp, out blnapperr);
                // CSV or Error file Generation code

                if (blnapperr)
                {
                    //MessageBox.Show("Error Occured.for more detail kindly check Application Log!!\r\n", "Error Message");
                    //return;
                }
                else
                {
                    var profileHelper = new ProfileHelper();
                    profileHelper.SetBaseClassValues(FormElements);

                    if (isNormalExecution)
                    {
                        profileHelper.SetProfileData<ApplicationModel>(Application.ExecutablePath, scriptName, FormElements, chklstApp);
                    }
                }
                runspace.Close();

                if (isNormalExecution)
                {
                    Applicationlogs frmapplog = new Applicationlogs();
                    DialogResult dr = frmapplog.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        //this.Enabled = true;
                        //ApplicationInformation objapp = new ApplicationInformation();
                        //objapp.Show();
                        //this.Close();
                        //frmapplog.Close();
                    }
                    else if (dr == DialogResult.OK)
                    {
                        this.Enabled = true;
                        IISInformation objfrm = new IISInformation();
                        objfrm.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured.for more detail kindly check Application Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
            }
        }
        private bool Validation()
        {
            if (chklstApp.CheckedIndices.Count <= 0)
            {
                MessageBox.Show("Select atleast one item");
                return false;
            }
            return true;

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
                toolTip1.SetToolTip(chklstApp, FormElements.ApplicationInformation[tIndex].Tooltip);
            }
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

        
    }
}

