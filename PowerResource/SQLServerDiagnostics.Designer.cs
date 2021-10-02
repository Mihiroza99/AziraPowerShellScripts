﻿namespace PowerResource
{
    partial class SQLServerDiagnostics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLServerDiagnostics));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsqldlogs = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblprogress = new System.Windows.Forms.Label();
            this.chkallsqld = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chklstApp = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblevent = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblssas = new System.Windows.Forms.Label();
            this.lblsql = new System.Windows.Forms.Label();
            this.lbliis = new System.Windows.Forms.Label();
            this.lblssrs = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblapp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsqldnxt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkdfltinstance = new System.Windows.Forms.CheckBox();
            this.rbtnsql = new System.Windows.Forms.RadioButton();
            this.txtsqldatabase = new System.Windows.Forms.TextBox();
            this.rbtnsqlwin = new System.Windows.Forms.RadioButton();
            this.txtsqllogin = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtsqlhost = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtsqlpass = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rbtnapplocal = new System.Windows.Forms.RadioButton();
            this.rbtnappnetwork = new System.Windows.Forms.RadioButton();
            this.txtapppwd = new System.Windows.Forms.TextBox();
            this.txtappuname = new System.Windows.Forms.TextBox();
            this.txtappport = new System.Windows.Forms.TextBox();
            this.txtappip = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chksqldcred = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnsqldlogs);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnsqldnxt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 513);
            this.panel1.TabIndex = 0;
            // 
            // btnsqldlogs
            // 
            this.btnsqldlogs.Location = new System.Drawing.Point(6, 488);
            this.btnsqldlogs.Name = "btnsqldlogs";
            this.btnsqldlogs.Size = new System.Drawing.Size(196, 23);
            this.btnsqldlogs.TabIndex = 23;
            this.btnsqldlogs.Text = "SQL Server Diagnostic Logs";
            this.btnsqldlogs.UseVisualStyleBackColor = true;
            this.btnsqldlogs.Visible = false;
            this.btnsqldlogs.Click += new System.EventHandler(this.btnsqldlogs_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(563, 487);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "< Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.lblprogress);
            this.panel4.Controls.Add(this.chkallsqld);
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Location = new System.Drawing.Point(205, 142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(594, 343);
            this.panel4.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-2, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(589, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Select the scripts you want to execute.Output of execution will be stored in outp" +
    "ut folder.\n";
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Location = new System.Drawing.Point(265, 32);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(65, 13);
            this.lblprogress.TabIndex = 10;
            this.lblprogress.Text = "Progress";
            this.lblprogress.Visible = false;
            // 
            // chkallsqld
            // 
            this.chkallsqld.AutoSize = true;
            this.chkallsqld.Location = new System.Drawing.Point(8, 32);
            this.chkallsqld.Name = "chkallsqld";
            this.chkallsqld.Size = new System.Drawing.Size(66, 17);
            this.chkallsqld.TabIndex = 15;
            this.chkallsqld.Text = "Select";
            this.chkallsqld.UseVisualStyleBackColor = true;
            this.chkallsqld.CheckedChanged += new System.EventHandler(this.chkallsqld_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(350, 26);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 27);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chklstApp);
            this.groupBox1.Location = new System.Drawing.Point(1, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 330);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Server Diagnostic";
            // 
            // chklstApp
            // 
            this.chklstApp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chklstApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chklstApp.FormattingEnabled = true;
            this.chklstApp.Location = new System.Drawing.Point(6, 17);
            this.chklstApp.Name = "chklstApp";
            this.chklstApp.Size = new System.Drawing.Size(583, 272);
            this.chklstApp.TabIndex = 16;
            this.chklstApp.MouseHover += new System.EventHandler(this.chklstApp_MouseHover);
            this.chklstApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chklstApp_MouseMove);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.lblevent);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.lblssas);
            this.panel3.Controls.Add(this.lblsql);
            this.panel3.Controls.Add(this.lbliis);
            this.panel3.Controls.Add(this.lblssrs);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.lblapp);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(2, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 344);
            this.panel3.TabIndex = 1;
            // 
            // lblevent
            // 
            this.lblevent.AutoSize = true;
            this.lblevent.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblevent.Location = new System.Drawing.Point(12, 166);
            this.lblevent.Name = "lblevent";
            this.lblevent.Size = new System.Drawing.Size(70, 14);
            this.lblevent.TabIndex = 103;
            this.lblevent.Text = "Event Log";
            this.toolTip1.SetToolTip(this.lblevent, "click to open");
            this.lblevent.Click += new System.EventHandler(this.lblevent_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(10, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(164, 14);
            this.label15.TabIndex = 73;
            this.label15.Text = "SQL Server Diagnostics";
            // 
            // lblssas
            // 
            this.lblssas.AutoSize = true;
            this.lblssas.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblssas.Location = new System.Drawing.Point(10, 145);
            this.lblssas.Name = "lblssas";
            this.lblssas.Size = new System.Drawing.Size(130, 14);
            this.lblssas.TabIndex = 72;
            this.lblssas.Text = "SSAS Server Scripts";
            this.toolTip1.SetToolTip(this.lblssas, "click to open");
            this.lblssas.Click += new System.EventHandler(this.lblssas_Click);
            // 
            // lblsql
            // 
            this.lblsql.AutoSize = true;
            this.lblsql.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsql.Location = new System.Drawing.Point(10, 99);
            this.lblsql.Name = "lblsql";
            this.lblsql.Size = new System.Drawing.Size(123, 14);
            this.lblsql.TabIndex = 71;
            this.lblsql.Text = "SQL Server Scripts";
            this.toolTip1.SetToolTip(this.lblsql, "click to open");
            this.lblsql.Click += new System.EventHandler(this.lblsql_Click);
            // 
            // lbliis
            // 
            this.lbliis.AutoSize = true;
            this.lbliis.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbliis.Location = new System.Drawing.Point(10, 58);
            this.lbliis.Name = "lbliis";
            this.lbliis.Size = new System.Drawing.Size(116, 14);
            this.lbliis.TabIndex = 70;
            this.lbliis.Text = "IIS Server Scripts";
            this.toolTip1.SetToolTip(this.lbliis, "click to open");
            this.lbliis.Click += new System.EventHandler(this.lbliis_Click);
            // 
            // lblssrs
            // 
            this.lblssrs.AutoSize = true;
            this.lblssrs.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblssrs.Location = new System.Drawing.Point(10, 123);
            this.lblssrs.Name = "lblssrs";
            this.lblssrs.Size = new System.Drawing.Size(130, 14);
            this.lblssrs.TabIndex = 69;
            this.lblssrs.Text = "SSRS Server Scripts";
            this.toolTip1.SetToolTip(this.lblssrs, "click to open");
            this.lblssrs.Click += new System.EventHandler(this.lblssrs_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9F);
            this.label21.Location = new System.Drawing.Point(10, 187);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 14);
            this.label21.TabIndex = 68;
            this.label21.Text = "Complete";
            // 
            // lblapp
            // 
            this.lblapp.AutoSize = true;
            this.lblapp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblapp.Location = new System.Drawing.Point(10, 36);
            this.lblapp.Name = "lblapp";
            this.lblapp.Size = new System.Drawing.Size(121, 14);
            this.lblapp.TabIndex = 67;
            this.lblapp.Text = "Application Scripts";
            this.toolTip1.SetToolTip(this.lblapp, "click to open");
            this.lblapp.Click += new System.EventHandler(this.lblapp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F);
            this.label6.Location = new System.Drawing.Point(10, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 14);
            this.label6.TabIndex = 66;
            this.label6.Text = "Add Resource Information";
            // 
            // btnsqldnxt
            // 
            this.btnsqldnxt.Location = new System.Drawing.Point(642, 487);
            this.btnsqldnxt.Name = "btnsqldnxt";
            this.btnsqldnxt.Size = new System.Drawing.Size(75, 23);
            this.btnsqldnxt.TabIndex = 17;
            this.btnsqldnxt.Text = "Next >";
            this.btnsqldnxt.UseVisualStyleBackColor = true;
            this.btnsqldnxt.Click += new System.EventHandler(this.btnsqldnxt_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.chksqldcred);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 147);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PowerResource.Properties.Resources.NetZoom_Logo_200x48px;
            this.pictureBox2.Location = new System.Drawing.Point(4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(195, 50);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.rbtnapplocal);
            this.groupBox4.Controls.Add(this.rbtnappnetwork);
            this.groupBox4.Controls.Add(this.txtapppwd);
            this.groupBox4.Controls.Add(this.txtappuname);
            this.groupBox4.Controls.Add(this.txtappport);
            this.groupBox4.Controls.Add(this.txtappip);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(203, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(595, 137);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Windows-Machine";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkdfltinstance);
            this.groupBox6.Controls.Add(this.rbtnsql);
            this.groupBox6.Controls.Add(this.txtsqldatabase);
            this.groupBox6.Controls.Add(this.rbtnsqlwin);
            this.groupBox6.Controls.Add(this.txtsqllogin);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.txtsqlhost);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.txtsqlpass);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Location = new System.Drawing.Point(7, 69);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(583, 65);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "SQL Server";
            // 
            // chkdfltinstance
            // 
            this.chkdfltinstance.AutoSize = true;
            this.chkdfltinstance.Location = new System.Drawing.Point(122, 27);
            this.chkdfltinstance.Name = "chkdfltinstance";
            this.chkdfltinstance.Size = new System.Drawing.Size(73, 17);
            this.chkdfltinstance.TabIndex = 11;
            this.chkdfltinstance.Text = "Default";
            this.chkdfltinstance.UseVisualStyleBackColor = true;
            this.chkdfltinstance.CheckedChanged += new System.EventHandler(this.chkdfltinstance_CheckedChanged);
            // 
            // rbtnsql
            // 
            this.rbtnsql.AutoSize = true;
            this.rbtnsql.Checked = true;
            this.rbtnsql.Location = new System.Drawing.Point(4, 39);
            this.rbtnsql.Name = "rbtnsql";
            this.rbtnsql.Size = new System.Drawing.Size(97, 17);
            this.rbtnsql.TabIndex = 9;
            this.rbtnsql.TabStop = true;
            this.rbtnsql.Text = "SQL Server";
            this.rbtnsql.UseVisualStyleBackColor = true;
            // 
            // txtsqldatabase
            // 
            this.txtsqldatabase.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtsqldatabase.Location = new System.Drawing.Point(214, 44);
            this.txtsqldatabase.Name = "txtsqldatabase";
            this.txtsqldatabase.Size = new System.Drawing.Size(132, 21);
            this.txtsqldatabase.TabIndex = 12;
            // 
            // rbtnsqlwin
            // 
            this.rbtnsqlwin.AutoSize = true;
            this.rbtnsqlwin.Location = new System.Drawing.Point(4, 20);
            this.rbtnsqlwin.Name = "rbtnsqlwin";
            this.rbtnsqlwin.Size = new System.Drawing.Size(82, 17);
            this.rbtnsqlwin.TabIndex = 8;
            this.rbtnsqlwin.Text = "Windows";
            this.rbtnsqlwin.UseVisualStyleBackColor = true;
            this.rbtnsqlwin.CheckedChanged += new System.EventHandler(this.rbtnsqlwin_CheckedChanged);
            // 
            // txtsqllogin
            // 
            this.txtsqllogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtsqllogin.Location = new System.Drawing.Point(439, 1);
            this.txtsqllogin.Name = "txtsqllogin";
            this.txtsqllogin.Size = new System.Drawing.Size(132, 21);
            this.txtsqllogin.TabIndex = 13;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(119, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 14);
            this.label20.TabIndex = 9;
            this.label20.Text = "Server";
            // 
            // txtsqlhost
            // 
            this.txtsqlhost.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtsqlhost.Location = new System.Drawing.Point(214, 2);
            this.txtsqlhost.Name = "txtsqlhost";
            this.txtsqlhost.Size = new System.Drawing.Size(132, 21);
            this.txtsqlhost.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(355, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 14);
            this.label13.TabIndex = 11;
            this.label13.Text = "Login";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(355, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 14);
            this.label17.TabIndex = 13;
            this.label17.Text = "Password";
            // 
            // txtsqlpass
            // 
            this.txtsqlpass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtsqlpass.Location = new System.Drawing.Point(439, 44);
            this.txtsqlpass.Name = "txtsqlpass";
            this.txtsqlpass.PasswordChar = '*';
            this.txtsqlpass.Size = new System.Drawing.Size(132, 21);
            this.txtsqlpass.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(119, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 14);
            this.label18.TabIndex = 23;
            this.label18.Text = "Database";
            // 
            // rbtnapplocal
            // 
            this.rbtnapplocal.AutoSize = true;
            this.rbtnapplocal.Location = new System.Drawing.Point(10, 20);
            this.rbtnapplocal.Name = "rbtnapplocal";
            this.rbtnapplocal.Size = new System.Drawing.Size(88, 17);
            this.rbtnapplocal.TabIndex = 2;
            this.rbtnapplocal.Text = "LocalHost";
            this.rbtnapplocal.UseVisualStyleBackColor = true;
            this.rbtnapplocal.CheckedChanged += new System.EventHandler(this.rbtnapplocal_CheckedChanged);
            // 
            // rbtnappnetwork
            // 
            this.rbtnappnetwork.AutoSize = true;
            this.rbtnappnetwork.Checked = true;
            this.rbtnappnetwork.Location = new System.Drawing.Point(10, 39);
            this.rbtnappnetwork.Name = "rbtnappnetwork";
            this.rbtnappnetwork.Size = new System.Drawing.Size(100, 17);
            this.rbtnappnetwork.TabIndex = 3;
            this.rbtnappnetwork.TabStop = true;
            this.rbtnappnetwork.Text = "On Network";
            this.rbtnappnetwork.UseVisualStyleBackColor = true;
            // 
            // txtapppwd
            // 
            this.txtapppwd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtapppwd.Location = new System.Drawing.Point(446, 45);
            this.txtapppwd.Name = "txtapppwd";
            this.txtapppwd.PasswordChar = '*';
            this.txtapppwd.Size = new System.Drawing.Size(132, 21);
            this.txtapppwd.TabIndex = 7;
            // 
            // txtappuname
            // 
            this.txtappuname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtappuname.Location = new System.Drawing.Point(446, 16);
            this.txtappuname.Name = "txtappuname";
            this.txtappuname.Size = new System.Drawing.Size(132, 21);
            this.txtappuname.TabIndex = 6;
            // 
            // txtappport
            // 
            this.txtappport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtappport.Location = new System.Drawing.Point(221, 44);
            this.txtappport.Name = "txtappport";
            this.txtappport.Size = new System.Drawing.Size(132, 21);
            this.txtappport.TabIndex = 5;
            // 
            // txtappip
            // 
            this.txtappip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtappip.Location = new System.Drawing.Point(221, 16);
            this.txtappip.Name = "txtappip";
            this.txtappip.Size = new System.Drawing.Size(132, 21);
            this.txtappip.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(126, 42);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(33, 14);
            this.label26.TabIndex = 15;
            this.label26.Text = "Port";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(359, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(359, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "User";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(126, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 14);
            this.label16.TabIndex = 9;
            this.label16.Text = "IP/Hostname";
            // 
            // chksqldcred
            // 
            this.chksqldcred.AutoSize = true;
            this.chksqldcred.Location = new System.Drawing.Point(7, 118);
            this.chksqldcred.Name = "chksqldcred";
            this.chksqldcred.Size = new System.Drawing.Size(159, 17);
            this.chksqldcred.TabIndex = 1;
            this.chksqldcred.Text = "Same As Application";
            this.chksqldcred.UseVisualStyleBackColor = true;
            this.chksqldcred.CheckedChanged += new System.EventHandler(this.chksqldcred_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "SQL Server Diagonostic";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(721, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(777, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(753, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "_";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Power Script - NetZoom";
            // 
            // SQLServerDiagnostics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SQLServerDiagnostics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power Script";
            this.Load += new System.EventHandler(this.SQLServerDiagnostics_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnsqldnxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chklstApp;
        private System.Windows.Forms.CheckBox chkallsqld;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblssas;
        private System.Windows.Forms.Label lblsql;
        private System.Windows.Forms.Label lbliis;
        private System.Windows.Forms.Label lblssrs;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblapp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblevent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnsqldlogs;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chksqldcred;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbtnsql;
        private System.Windows.Forms.TextBox txtsqldatabase;
        private System.Windows.Forms.RadioButton rbtnsqlwin;
        private System.Windows.Forms.TextBox txtsqllogin;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtsqlhost;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtsqlpass;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rbtnapplocal;
        private System.Windows.Forms.RadioButton rbtnappnetwork;
        private System.Windows.Forms.TextBox txtapppwd;
        private System.Windows.Forms.TextBox txtappuname;
        private System.Windows.Forms.TextBox txtappport;
        private System.Windows.Forms.TextBox txtappip;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkdfltinstance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

