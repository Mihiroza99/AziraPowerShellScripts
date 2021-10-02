namespace PowerResource
{
    partial class IISInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IISInformation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btniislogs = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblprogress = new System.Windows.Forms.Label();
            this.chkalliis = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chklstApp = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbleventlog = new System.Windows.Forms.Label();
            this.lblsqld = new System.Windows.Forms.Label();
            this.lblssas = new System.Windows.Forms.Label();
            this.lblsql = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblssrs = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblapp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnapplocal = new System.Windows.Forms.RadioButton();
            this.rbtnappnetwork = new System.Windows.Forms.RadioButton();
            this.txtapppwd = new System.Windows.Forms.TextBox();
            this.txtappuname = new System.Windows.Forms.TextBox();
            this.txtappport = new System.Windows.Forms.TextBox();
            this.txtappip = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chkiiscred = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btniislogs);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 513);
            this.panel1.TabIndex = 0;
            // 
            // btniislogs
            // 
            this.btniislogs.Location = new System.Drawing.Point(7, 487);
            this.btniislogs.Name = "btniislogs";
            this.btniislogs.Size = new System.Drawing.Size(125, 23);
            this.btniislogs.TabIndex = 21;
            this.btniislogs.Text = "IIS Logs";
            this.btniislogs.UseVisualStyleBackColor = true;
            this.btniislogs.Visible = false;
            this.btniislogs.Click += new System.EventHandler(this.btniislogs_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(563, 487);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "< Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.lblprogress);
            this.panel4.Controls.Add(this.chkalliis);
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Location = new System.Drawing.Point(205, 99);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(594, 387);
            this.panel4.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(589, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Select the scripts you want to execute.Output of execution will be stored in outp" +
    "ut folder.\n";
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Location = new System.Drawing.Point(259, 30);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(65, 13);
            this.lblprogress.TabIndex = 8;
            this.lblprogress.Text = "Progress";
            this.lblprogress.Visible = false;
            // 
            // chkalliis
            // 
            this.chkalliis.AutoSize = true;
            this.chkalliis.Location = new System.Drawing.Point(6, 30);
            this.chkalliis.Name = "chkalliis";
            this.chkalliis.Size = new System.Drawing.Size(66, 17);
            this.chkalliis.TabIndex = 8;
            this.chkalliis.Text = "Select";
            this.chkalliis.UseVisualStyleBackColor = true;
            this.chkalliis.CheckedChanged += new System.EventHandler(this.chkalliis_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(350, 27);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 27);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chklstApp);
            this.groupBox1.Location = new System.Drawing.Point(0, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 330);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IIS Server Scripts";
            // 
            // chklstApp
            // 
            this.chklstApp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chklstApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chklstApp.FormattingEnabled = true;
            this.chklstApp.Location = new System.Drawing.Point(5, 19);
            this.chklstApp.Name = "chklstApp";
            this.chklstApp.Size = new System.Drawing.Size(581, 304);
            this.chklstApp.TabIndex = 9;
            this.chklstApp.MouseHover += new System.EventHandler(this.chklstApp_MouseHover);
            this.chklstApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chklstApp_MouseMove);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.lbleventlog);
            this.panel3.Controls.Add(this.lblsqld);
            this.panel3.Controls.Add(this.lblssas);
            this.panel3.Controls.Add(this.lblsql);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.lblssrs);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.lblapp);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(2, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 387);
            this.panel3.TabIndex = 1;
            // 
            // lbleventlog
            // 
            this.lbleventlog.AutoSize = true;
            this.lbleventlog.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbleventlog.Location = new System.Drawing.Point(10, 163);
            this.lbleventlog.Name = "lbleventlog";
            this.lbleventlog.Size = new System.Drawing.Size(70, 14);
            this.lbleventlog.TabIndex = 101;
            this.lbleventlog.Text = "Event Log";
            this.toolTip1.SetToolTip(this.lbleventlog, "click to open");
            this.lbleventlog.Click += new System.EventHandler(this.lbleventlog_Click);
            // 
            // lblsqld
            // 
            this.lblsqld.AutoSize = true;
            this.lblsqld.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblsqld.Location = new System.Drawing.Point(10, 78);
            this.lblsqld.Name = "lblsqld";
            this.lblsqld.Size = new System.Drawing.Size(153, 14);
            this.lblsqld.TabIndex = 81;
            this.lblsqld.Text = "SQL Server Diagnostics";
            this.toolTip1.SetToolTip(this.lblsqld, "click to open");
            this.lblsqld.Click += new System.EventHandler(this.lblsqld_Click);
            // 
            // lblssas
            // 
            this.lblssas.AutoSize = true;
            this.lblssas.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblssas.Location = new System.Drawing.Point(10, 144);
            this.lblssas.Name = "lblssas";
            this.lblssas.Size = new System.Drawing.Size(130, 14);
            this.lblssas.TabIndex = 80;
            this.lblssas.Text = "SSAS Server Scripts";
            this.toolTip1.SetToolTip(this.lblssas, "click to open");
            this.lblssas.Click += new System.EventHandler(this.lblssas_Click);
            // 
            // lblsql
            // 
            this.lblsql.AutoSize = true;
            this.lblsql.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsql.Location = new System.Drawing.Point(10, 98);
            this.lblsql.Name = "lblsql";
            this.lblsql.Size = new System.Drawing.Size(123, 14);
            this.lblsql.TabIndex = 79;
            this.lblsql.Text = "SQL Server Scripts";
            this.toolTip1.SetToolTip(this.lblsql, "click to open");
            this.lblsql.Click += new System.EventHandler(this.lblsql_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(10, 57);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(127, 14);
            this.label23.TabIndex = 78;
            this.label23.Text = "IIS Server Scripts";
            // 
            // lblssrs
            // 
            this.lblssrs.AutoSize = true;
            this.lblssrs.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblssrs.Location = new System.Drawing.Point(10, 122);
            this.lblssrs.Name = "lblssrs";
            this.lblssrs.Size = new System.Drawing.Size(130, 14);
            this.lblssrs.TabIndex = 77;
            this.lblssrs.Text = "SSRS Server Scripts";
            this.toolTip1.SetToolTip(this.lblssrs, "click to open");
            this.lblssrs.Click += new System.EventHandler(this.lblssrs_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9F);
            this.label21.Location = new System.Drawing.Point(10, 183);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 14);
            this.label21.TabIndex = 76;
            this.label21.Text = "Complete";
            // 
            // lblapp
            // 
            this.lblapp.AutoSize = true;
            this.lblapp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblapp.Location = new System.Drawing.Point(10, 35);
            this.lblapp.Name = "lblapp";
            this.lblapp.Size = new System.Drawing.Size(121, 14);
            this.lblapp.TabIndex = 75;
            this.lblapp.Text = "Application Scripts";
            this.toolTip1.SetToolTip(this.lblapp, "click to open");
            this.lblapp.Click += new System.EventHandler(this.lblapp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F);
            this.label6.Location = new System.Drawing.Point(10, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 14);
            this.label6.TabIndex = 74;
            this.label6.Text = "Add Resource Information";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(642, 487);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Next >";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.chkiiscred);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PowerResource.Properties.Resources.NetZoom_Logo_200x48px;
            this.pictureBox2.Location = new System.Drawing.Point(4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(195, 50);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnapplocal);
            this.groupBox4.Controls.Add(this.rbtnappnetwork);
            this.groupBox4.Controls.Add(this.txtapppwd);
            this.groupBox4.Controls.Add(this.txtappuname);
            this.groupBox4.Controls.Add(this.txtappport);
            this.groupBox4.Controls.Add(this.txtappip);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(202, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(595, 94);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Windows-Machine";
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
            this.rbtnappnetwork.Location = new System.Drawing.Point(9, 39);
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
            this.label9.Location = new System.Drawing.Point(359, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(360, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 14);
            this.label10.TabIndex = 11;
            this.label10.Text = "User";
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
            // chkiiscred
            // 
            this.chkiiscred.AutoSize = true;
            this.chkiiscred.Location = new System.Drawing.Point(6, 76);
            this.chkiiscred.Name = "chkiiscred";
            this.chkiiscred.Size = new System.Drawing.Size(159, 17);
            this.chkiiscred.TabIndex = 1;
            this.chkiiscred.Text = "Same As Application";
            this.chkiiscred.UseVisualStyleBackColor = true;
            this.chkiiscred.CheckedChanged += new System.EventHandler(this.chkiiscred_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "IIS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(721, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Power Script - NetZoom";
            // 
            // IISInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IISInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power Script";
            this.Load += new System.EventHandler(this.IISInformation_Load);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chklstApp;
        private System.Windows.Forms.CheckBox chkalliis;
        private System.Windows.Forms.Label lblsqld;
        private System.Windows.Forms.Label lblssas;
        private System.Windows.Forms.Label lblsql;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblssrs;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblapp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbleventlog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btniislogs;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkiiscred;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtnapplocal;
        private System.Windows.Forms.RadioButton rbtnappnetwork;
        private System.Windows.Forms.TextBox txtapppwd;
        private System.Windows.Forms.TextBox txtappuname;
        private System.Windows.Forms.TextBox txtappport;
        private System.Windows.Forms.TextBox txtappip;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

