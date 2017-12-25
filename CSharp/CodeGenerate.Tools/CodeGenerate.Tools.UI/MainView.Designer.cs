namespace CodeGenerate.Tools.UI
{
    partial class MainView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Setting = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.lbpwd = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.lbDataSource = new System.Windows.Forms.Label();
            this.cbDataSource = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Setting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(667, 375);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.Setting);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(659, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Customer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(659, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Type";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.btnGenerate);
            this.Setting.Controls.Add(this.btnTest);
            this.Setting.Controls.Add(this.tbPwd);
            this.Setting.Controls.Add(this.lbpwd);
            this.Setting.Controls.Add(this.tbUserName);
            this.Setting.Controls.Add(this.lbUserName);
            this.Setting.Controls.Add(this.tbServer);
            this.Setting.Controls.Add(this.lbServer);
            this.Setting.Controls.Add(this.lbDataSource);
            this.Setting.Controls.Add(this.cbDataSource);
            this.Setting.Location = new System.Drawing.Point(8, 6);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(269, 335);
            this.Setting.TabIndex = 9;
            this.Setting.TabStop = false;
            this.Setting.Text = "Setting";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(37, 167);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(63, 23);
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(120, 118);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(121, 21);
            this.tbPwd.TabIndex = 16;
            // 
            // lbpwd
            // 
            this.lbpwd.AutoSize = true;
            this.lbpwd.Location = new System.Drawing.Point(35, 121);
            this.lbpwd.Name = "lbpwd";
            this.lbpwd.Size = new System.Drawing.Size(59, 12);
            this.lbpwd.TabIndex = 15;
            this.lbpwd.Text = "Password:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(120, 91);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(121, 21);
            this.tbUserName.TabIndex = 14;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(35, 94);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(65, 12);
            this.lbUserName.TabIndex = 13;
            this.lbUserName.Text = "User Name:";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(118, 59);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(121, 21);
            this.tbServer.TabIndex = 12;
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(35, 62);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(47, 12);
            this.lbServer.TabIndex = 11;
            this.lbServer.Text = "Server:";
            // 
            // lbDataSource
            // 
            this.lbDataSource.AutoSize = true;
            this.lbDataSource.Location = new System.Drawing.Point(35, 27);
            this.lbDataSource.Name = "lbDataSource";
            this.lbDataSource.Size = new System.Drawing.Size(77, 12);
            this.lbDataSource.TabIndex = 10;
            this.lbDataSource.Text = "Data Source:";
            // 
            // cbDataSource
            // 
            this.cbDataSource.FormattingEnabled = true;
            this.cbDataSource.Items.AddRange(new object[] {
            "MSSQL",
            "MySQL",
            "Access",
            "Sqlite"});
            this.cbDataSource.Location = new System.Drawing.Point(118, 24);
            this.cbDataSource.Name = "cbDataSource";
            this.cbDataSource.Size = new System.Drawing.Size(121, 20);
            this.cbDataSource.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbLog);
            this.groupBox2.Location = new System.Drawing.Point(322, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 342);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(6, 14);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(325, 326);
            this.tbLog.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(129, 167);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(63, 23);
            this.btnGenerate.TabIndex = 17;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 375);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generate";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Setting.ResumeLayout(false);
            this.Setting.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.GroupBox Setting;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label lbpwd;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Label lbDataSource;
        private System.Windows.Forms.ComboBox cbDataSource;
        private System.Windows.Forms.Button btnGenerate;
    }
}

