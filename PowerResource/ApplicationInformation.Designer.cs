namespace PowerResource
{
    partial class ApplicationInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationInformation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnapplogs = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblprogress = new System.Windows.Forms.Label();
            this.chkallapp = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chklstApp = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbleventlog = new System.Windows.Forms.Label();
            this.lblsqld = new System.Windows.Forms.Label();
            this.lblssas = new System.Windows.Forms.Label();
            this.lblsql = new System.Windows.Forms.Label();
            this.lbliis = new System.Windows.Forms.Label();
            this.lblssrs = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnapplogs);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 515);
            this.panel1.TabIndex = 0;
            // 
            // btnapplogs
            // 
            this.btnapplogs.Location = new System.Drawing.Point(5, 487);
            this.btnapplogs.Name = "btnapplogs";
            this.btnapplogs.Size = new System.Drawing.Size(125, 23);
            this.btnapplogs.TabIndex = 20;
            this.btnapplogs.Text = "Application Logs";
            this.btnapplogs.UseVisualStyleBackColor = true;
            this.btnapplogs.Visible = false;
            this.btnapplogs.Click += new System.EventHandler(this.btnapplogs_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(563, 487);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "< Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.lblprogress);
            this.panel4.Controls.Add(this.chkallapp);
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
            this.label8.Location = new System.Drawing.Point(2, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(589, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Select the scripts you want to execute.Output of execution will be stored in outp" +
    "ut folder.\n";
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Location = new System.Drawing.Point(256, 33);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(65, 13);
            this.lblprogress.TabIndex = 6;
            this.lblprogress.Text = "Progress";
            this.lblprogress.Visible = false;
            // 
            // chkallapp
            // 
            this.chkallapp.AutoSize = true;
            this.chkallapp.Location = new System.Drawing.Point(5, 31);
            this.chkallapp.Name = "chkallapp";
            this.chkallapp.Size = new System.Drawing.Size(66, 17);
            this.chkallapp.TabIndex = 1;
            this.chkallapp.Text = "Select";
            this.chkallapp.UseVisualStyleBackColor = true;
            this.chkallapp.CheckedChanged += new System.EventHandler(this.chkallapp_CheckedChanged_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(349, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 27);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chklstApp);
            this.groupBox1.Location = new System.Drawing.Point(4, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 291);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Scripts";
            // 
            // chklstApp
            // 
            this.chklstApp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chklstApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chklstApp.FormattingEnabled = true;
            this.chklstApp.Location = new System.Drawing.Point(-1, 20);
            this.chklstApp.Name = "chklstApp";
            this.chklstApp.Size = new System.Drawing.Size(588, 304);
            this.chklstApp.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.lbleventlog);
            this.panel3.Controls.Add(this.lblsqld);
            this.panel3.Controls.Add(this.lblssas);
            this.panel3.Controls.Add(this.lblsql);
            this.panel3.Controls.Add(this.lbliis);
            this.panel3.Controls.Add(this.lblssrs);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label19);
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
            this.lbleventlog.Location = new System.Drawing.Point(13, 163);
            this.lbleventlog.Name = "lbleventlog";
            this.lbleventlog.Size = new System.Drawing.Size(70, 14);
            this.lbleventlog.TabIndex = 98;
            this.lbleventlog.Text = "Event Log";
            this.toolTip1.SetToolTip(this.lbleventlog, "click to open");
            this.lbleventlog.Click += new System.EventHandler(this.lbleventlog_Click);
            // 
            // lblsqld
            // 
            this.lblsqld.AutoSize = true;
            this.lblsqld.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblsqld.Location = new System.Drawing.Point(12, 77);
            this.lblsqld.Name = "lblsqld";
            this.lblsqld.Size = new System.Drawing.Size(153, 14);
            this.lblsqld.TabIndex = 97;
            this.lblsqld.Text = "SQL Server Diagnostics";
            this.toolTip1.SetToolTip(this.lblsqld, "click to open");
            this.lblsqld.Click += new System.EventHandler(this.lblsqld_Click);
            // 
            // lblssas
            // 
            this.lblssas.AutoSize = true;
            this.lblssas.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblssas.Location = new System.Drawing.Point(12, 143);
            this.lblssas.Name = "lblssas";
            this.lblssas.Size = new System.Drawing.Size(130, 14);
            this.lblssas.TabIndex = 96;
            this.lblssas.Text = "SSAS Server Scripts";
            this.toolTip1.SetToolTip(this.lblssas, "click to open");
            this.lblssas.Click += new System.EventHandler(this.lblssas_Click);
            // 
            // lblsql
            // 
            this.lblsql.AutoSize = true;
            this.lblsql.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblsql.Location = new System.Drawing.Point(12, 97);
            this.lblsql.Name = "lblsql";
            this.lblsql.Size = new System.Drawing.Size(123, 14);
            this.lblsql.TabIndex = 95;
            this.lblsql.Text = "SQL Server Scripts";
            this.toolTip1.SetToolTip(this.lblsql, "click to open");
            this.lblsql.Click += new System.EventHandler(this.lblsql_Click);
            // 
            // lbliis
            // 
            this.lbliis.AutoSize = true;
            this.lbliis.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbliis.Location = new System.Drawing.Point(12, 56);
            this.lbliis.Name = "lbliis";
            this.lbliis.Size = new System.Drawing.Size(116, 14);
            this.lbliis.TabIndex = 94;
            this.lbliis.Text = "IIS Server Scripts";
            this.toolTip1.SetToolTip(this.lbliis, "click to open");
            this.lbliis.Click += new System.EventHandler(this.lbliis_Click);
            // 
            // lblssrs
            // 
            this.lblssrs.AutoSize = true;
            this.lblssrs.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblssrs.Location = new System.Drawing.Point(12, 121);
            this.lblssrs.Name = "lblssrs";
            this.lblssrs.Size = new System.Drawing.Size(130, 14);
            this.lblssrs.TabIndex = 93;
            this.lblssrs.Text = "SSRS Server Scripts";
            this.toolTip1.SetToolTip(this.lblssrs, "click to open");
            this.lblssrs.Click += new System.EventHandler(this.lblssrs_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9F);
            this.label21.Location = new System.Drawing.Point(12, 182);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 14);
            this.label21.TabIndex = 92;
            this.label21.Text = "Complete";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(12, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 14);
            this.label19.TabIndex = 91;
            this.label19.Text = "Application Scripts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F);
            this.label6.Location = new System.Drawing.Point(12, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 14);
            this.label6.TabIndex = 90;
            this.label6.Text = "Add Resource Information";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(642, 487);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Next >";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PowerResource.Properties.Resources.NetZoom_Logo_200x48px;
            this.pictureBox2.Location = new System.Drawing.Point(7, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(195, 50);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Application";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(721, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Power Script - NetZoom";
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
            // ApplicationInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ApplicationInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power Script";
            this.Load += new System.EventHandler(this.ApplicationInformation_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox chklstApp;
        private System.Windows.Forms.CheckBox chkallapp;
        private System.Windows.Forms.Label lblsqld;
        private System.Windows.Forms.Label lblssas;
        private System.Windows.Forms.Label lblsql;
        private System.Windows.Forms.Label lbliis;
        private System.Windows.Forms.Label lblssrs;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.Label lbleventlog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnapplogs;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

