namespace HW.OSS.RandomPoint.Views
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbEndLong = new System.Windows.Forms.TextBox();
            this.tbStartLong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStartLati = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEndLati = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.tbSeek = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "End Longitude";
            // 
            // tbEndLong
            // 
            this.tbEndLong.Location = new System.Drawing.Point(413, 24);
            this.tbEndLong.Name = "tbEndLong";
            this.tbEndLong.Size = new System.Drawing.Size(151, 21);
            this.tbEndLong.TabIndex = 2;
            this.tbEndLong.Text = "0.0";
            this.tbEndLong.Validating += new System.ComponentModel.CancelEventHandler(this.tbEndLong_Validating);
            // 
            // tbStartLong
            // 
            this.tbStartLong.Location = new System.Drawing.Point(121, 24);
            this.tbStartLong.Name = "tbStartLong";
            this.tbStartLong.Size = new System.Drawing.Size(151, 21);
            this.tbStartLong.TabIndex = 6;
            this.tbStartLong.Text = "0.0";
            this.tbStartLong.Validating += new System.ComponentModel.CancelEventHandler(this.tbStartLong_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start Longitude";
            // 
            // tbStartLati
            // 
            this.tbStartLati.Location = new System.Drawing.Point(121, 59);
            this.tbStartLati.Name = "tbStartLati";
            this.tbStartLati.Size = new System.Drawing.Size(151, 21);
            this.tbStartLati.TabIndex = 10;
            this.tbStartLati.Text = "0.0";
            this.tbStartLati.Validating += new System.ComponentModel.CancelEventHandler(this.tbStartLati_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Start Latitude";
            // 
            // tbEndLati
            // 
            this.tbEndLati.Location = new System.Drawing.Point(413, 59);
            this.tbEndLati.Name = "tbEndLati";
            this.tbEndLati.Size = new System.Drawing.Size(151, 21);
            this.tbEndLati.TabIndex = 8;
            this.tbEndLati.Text = "0.0";
            this.tbEndLati.Validating += new System.ComponentModel.CancelEventHandler(this.tbEndLati_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "End Latitude";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(491, 114);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(73, 27);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tbSeek
            // 
            this.tbSeek.Location = new System.Drawing.Point(121, 95);
            this.tbSeek.Name = "tbSeek";
            this.tbSeek.Size = new System.Drawing.Size(151, 21);
            this.tbSeek.TabIndex = 13;
            this.tbSeek.Text = "5";
            this.tbSeek.Validating += new System.ComponentModel.CancelEventHandler(this.tbSeek_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Seek";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 378);
            this.Controls.Add(this.tbSeek);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbStartLati);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEndLati);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStartLong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbEndLong);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEndLong;
        private System.Windows.Forms.TextBox tbStartLong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStartLati;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEndLati;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox tbSeek;
        private System.Windows.Forms.Label label5;
    }
}

