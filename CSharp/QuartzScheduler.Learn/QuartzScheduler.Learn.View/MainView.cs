using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuartzScheduler.Learn.Dao;
using Quartz;

namespace QuartzScheduler.Learn.View
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            SchedulerManager.Shutdown(true);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SchedulerManager.AddJob<SchedulerJob>("5seconds", "*/5 * * * * ?");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SchedulerManager.DeleteJob("5seconds");
        }

        public void WriteLog(string msg)
        {
            if (tbLog.InvokeRequired)
            {
                Action<string> action = (m)=>{tbLog.Text += m + "\r\n"; };
                tbLog.Invoke(action, new object[] { msg });
            }
            else
            {
                tbLog.Text += msg + "\r\n";
            }
        }
    }


    public class SchedulerJob : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            Program.MainForm.WriteLog(DateTime.Now.ToString("r"));
        }
    }
}
