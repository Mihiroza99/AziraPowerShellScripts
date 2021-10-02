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
    public partial class SQLServer : Form
    {

        private int tIndex = -1;
        BackgroundWorker bgw = new BackgroundWorker();
        public string timeStamp { get; set; }
        public SQLServerModel FormElements { get; set; }
        public static string scriptName = "SQLServer";

        public SQLServer()
        {
            InitializeComponent();
            this.timeStamp = DateTime.Now.Ticks.ToString();

            var helper = new WindowHelper();
            FormElements = helper.BindCheckBoxList<SQLServerModel>(Application.ExecutablePath, scriptName, chklstApp);
            LoadCredentials();
        }
        void LoadCredentials()
        {
            //if (FormElements.Credential.SameAsApplication)
            //{
            //    chksqlcred.Checked = true;
            //}
            //else
            //{
            //    chksqlcred.Checked = false;
            //}
            //FormElements.Credential.SameAsApplication = true;
            chksqlcred.Checked = true;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void chkallsql_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chklstApp.Items.Count; i++)
            {
                if (chkallsql.Checked)
                {
                    chklstApp.SetItemChecked(i, true);
                }
                else
                {
                    chklstApp.SetItemChecked(i, false);
                }
            }
        }

        private void btnsqlbck_Click(object sender, EventArgs e)
        {
            SQLServerDiagnostics rd = new SQLServerDiagnostics();
            rd.Show();
            this.Close();
        }

        private void btnsqlcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btneventlogs_Click(object sender, EventArgs e)
        {
            //SQLServerlogs frmsql = new SQLServerlogs();
            //frmsql.Show();

            //SQLServerlogs frmsql = new SQLServerlogs();
            //DialogResult dr = frmsql.ShowDialog(this);
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

        private void btnsqlnext_Click(object sender, EventArgs e)
        {
            try
            {
                if (chksqlcred.Checked == false)
                {
                    if (!ValidateControls())
                        return;
                }

                if (chklstApp.CheckedIndices.Count <= 0)
                {
                    MessageBox.Show("Select atleast one item");
                    return;
                }

                btnsqlnext.Enabled = false;
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
                MessageBox.Show("Error Occured.for more detail kindly check sQL server log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
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


                if (string.IsNullOrEmpty(FormElements.Credential.SqlDatabaseName))
                {
                    myCommand.Parameters.Add(new CommandParameter(null, FormElements.Credential.SqlDatabaseName));
                }
                else
                {
                    myCommand.Parameters.Add(new CommandParameter(null, "master"));
                }

                if (FormElements.Credential.SqlAuthMode != "w")
                {
                    sqlWindowsAuthParam = new CommandParameter(null, "network");
                }

                myCommand.Parameters.Add(sqlWindowsAuthParam);
                myCommand.Parameters.Add(sqlServerParam);

                myCommand.Parameters.Add(sqlUserName);
                myCommand.Parameters.Add(sqlPwd);

                foreach (var item in FormElements.SQLServer)
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
                generateCSV.WriteOutput(Application.ExecutablePath, scriptName, results, pipeline, this.timeStamp, out blnsqlerr);
                // CSV or Error file Generation code
                if (blnsqlerr)
                {
                    //MessageBox.Show("Error Occured.for more detail kindly check SQL Log!!\r\n", "Error Message");
                    //return;
                }
                else
                {
                    if (isNormalExecution)
                    {
                        var profileHelper = new ProfileHelper();
                        profileHelper.SetProfileData<SQLServerModel>(Application.ExecutablePath, scriptName, FormElements, chklstApp);
                    }
                }

                // Profilecreation();
                runspace.Close();


                //DialogResult dialogResult = MessageBox.Show("SQL Server scripts executed successfully.Do you want to execute next script?", "Success", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    //do something
                //    SSRSConfiguration objfrm = new SSRSConfiguration();
                //    objfrm.Show();
                //    this.Close();
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    SQLServer objfrm = new SQLServer();
                //    objfrm.Show();
                //    this.Close();
                //}

                if (isNormalExecution)
                {
                    SQLServerlogs frmsql = new SQLServerlogs();
                    DialogResult dr = frmsql.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        //frmapplog.Close();
                    }
                    else if (dr == DialogResult.OK)
                    {
                        //textBox1.Text = frm2.getText();
                        //frmapplog.Close();
                        this.Enabled = true;
                        SSRSConfiguration objfrm = new SSRSConfiguration();
                        objfrm.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured.for more detail kindly check SQL Server Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
            }
        }

        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //label1.Text = String.Format("Progress: {0} %", e.ProgressPercentage);
            //label2.Text = String.Format("Total items transfered: {0}", e.UserState);
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

        private void chklstApp_MouseHover(object sender, EventArgs e)
        {
            GetToolTip();
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

        void GetToolTip()
        {

            Point pos = chklstApp.PointToClient(MousePosition);
            tIndex = chklstApp.IndexFromPoint(pos);
            if (tIndex > -1)
            {
                pos = this.PointToClient(MousePosition);
                toolTip1.SetToolTip(chklstApp, FormElements.SQLServer[tIndex].Tooltip);
            }
        }

        private void chksqlcred_CheckedChanged(object sender, EventArgs e)
        {
            if (chksqlcred.Checked)
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
                txtsqldatabase.BackColor = Color.Silver;
            }
            else
            {
                //txtsqlhost.Enabled = true;
                txtsqllogin.Enabled = true;
                txtsqlpass.Enabled = true;
                //txtsqlhost.BackColor = Color.WhiteSmoke; ;
                txtsqllogin.BackColor = Color.WhiteSmoke; ;
                txtsqlpass.BackColor = Color.WhiteSmoke; ;
                txtsqldatabase.BackColor = Color.WhiteSmoke;
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

        void setcredentials()
        {
            FormElements.Credential.SameAsApplication = chksqlcred.Checked;

            if (chksqlcred.Checked)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
