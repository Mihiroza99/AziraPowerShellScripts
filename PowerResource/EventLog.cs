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
using PowerResource.Helper;
using PowerResource.Model;

namespace PowerResource
{
    public partial class EventLog : Form
    {

        BackgroundWorker bgw = new BackgroundWorker();
        public string timeStamp { get; set; }
        public static string scriptName = "EventLog";

        public EventLog()
        {
            InitializeComponent();
            this.timeStamp = DateTime.Now.Ticks.ToString();

            ReadJson();
        }
        private void ApplicationInformation_Load(object sender, EventArgs e)
        {

        }

        private void ReadJson()
        {
            var _rootpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources";//.Substring(0, System.IO.Path.GetDirectoryName(Application.ExecutablePath).Length - 10) + "\\Resources";
            var _configpath = _rootpath + "\\EventLog.json";

            cmbevent.Items.Clear();
            var returnValue = JsonConvert.DeserializeObject<EventlogModel>(File.ReadAllText(_configpath));
            BindingSource bs1 = new BindingSource(returnValue, scriptName);
            cmbevent.DataSource = bs1;
            cmbevent.DisplayMember = "item";
            cmbevent.ValueMember = "Value";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SSASConfiguration rd = new SSASConfiguration();
            rd.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblssas_Click(object sender, EventArgs e)
        {
            SSASConfiguration ssas = new SSASConfiguration();
            ssas.Show();
            this.Close();
        }

        private void lblssrs_Click(object sender, EventArgs e)
        {
            SSRSConfiguration ssrs = new SSRSConfiguration();
            ssrs.Show();
            this.Close();
        }

        private void lblsql_Click(object sender, EventArgs e)
        {
            SQLServer app = new SQLServer();
            app.Show();
            this.Close();
        }

        private void lblsqld_Click(object sender, EventArgs e)
        {
            SQLServerDiagnostics sqld = new SQLServerDiagnostics();
            sqld.Show();
            this.Close();
        }

        private void lbliis_Click(object sender, EventArgs e)
        {
            IISInformation iis = new IISInformation();
            iis.Show();
            this.Close();
        }

        private void lblapp_Click(object sender, EventArgs e)
        {
            ApplicationInformation app = new ApplicationInformation();
            app.Show();
            this.Close();
        }

        private void btneventlogs_Click(object sender, EventArgs e)
        {
            //Eventlogs frmevent = new Eventlogs();
            //frmevent.Close();
            //Eventlogs frmevntlog = new Eventlogs();
            //DialogResult dr = frmevntlog.ShowDialog(this);
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

        private void cmbevent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 0-for application
            // 1- iis
        }

        private void chklstApp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                button2.Enabled = false;
                lblprogress.Visible = true;
                progressBar1.Visible = true;

                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                bgw.WorkerReportsProgress = true;
                bgw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured.for more detail kindly check event Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
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
                bool blneventerr = false;
                var _rootpath = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Resources");
                string script = Path.Combine(_rootpath, scriptName + ".ps1");
                string scriptText = File.ReadAllText(script);
                StringBuilder sb = new StringBuilder();
                var powershell = new PowerShellHelper();
                var runspace = powershell.CreateRunSpace(Application.ExecutablePath, cmbevent.SelectedValue.ToString());
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                Command myCommand = new Command(scriptText, true);
                if (txtsource.Text.Trim() != string.Empty)
                {
                    var sourceFilter = new CommandParameter(null, txtsource.Text);
                    myCommand.Parameters.Add(sourceFilter);
                }
                else
                {
                    var sourceFilter = new CommandParameter(null, " ");
                    myCommand.Parameters.Add(sourceFilter);
                }
                if (txtmessage.Text.Trim() != string.Empty)
                {
                    var messageFilter = new CommandParameter(null, txtmessage.Text);
                    myCommand.Parameters.Add(messageFilter);
                }
                else
                {
                    var messageFilter = new CommandParameter(null, " ");
                    myCommand.Parameters.Add(messageFilter);
                }

                pipeline.Commands.Add(myCommand);

                Collection<PSObject> results = pipeline.Invoke();
                var errors = pipeline.Error;

                // CSV or Error file Generation code
                var generateCSV = new Csvhelper();
                generateCSV.WriteOutput(Application.ExecutablePath, scriptName, results, pipeline, this.timeStamp, out blneventerr);
                // CSV or Error file Generation code
                if (blneventerr)
                {
                    //MessageBox.Show("Error Occured.for more detail kindly check Event Log!!\r\n", "Error Message");
                    //return;
                }

                runspace.Close();

                Console.WriteLine(sb.ToString());

                //DialogResult dialogResult = MessageBox.Show("Selected event log executed successfully.Do you want to complete?", "Success", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    //do something
                //    Complete objfrm = new Complete();
                //    objfrm.Show();
                //    this.Close();
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    EventLog objfrm = new EventLog();
                //    objfrm.Show();
                //    this.Close();
                //}

                if (isNormalExecution)
                {
                    Eventlogs frmevntlog = new Eventlogs();
                    DialogResult dr = frmevntlog.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        //frmapplog.Close();
                    }
                    else if (dr == DialogResult.OK)
                    {
                        //textBox1.Text = frm2.getText();
                        //frmapplog.Close();
                        this.Enabled = true;
                        Complete objfrm = new Complete();
                        objfrm.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured.for more detail kindly check Event Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
            }
        }
    }
}
