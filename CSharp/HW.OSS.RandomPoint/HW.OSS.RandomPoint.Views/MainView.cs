using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HW.OSS.RandomPoint.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private double m_StartLong = 0.0;
        private double m_EndLong = 0.0;
        private double m_StartLati = 0;
        private double m_EndLati = 0;
        private int m_Seek = 0;

        private void MainView_Load(object sender, EventArgs e)
        {
            string appTitle = ConfigurationManager.AppSettings["AppTitle"];
            this.Text = appTitle;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["AppIco"]))
            {
                string filePath = ConfigurationManager.AppSettings["AppIco"];
                this.Icon = Icon.FromHandle(new Bitmap(filePath).GetHicon());
            }else if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favicon.ico")))
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favicon.ico");
                this.Icon = Icon.FromHandle(new Bitmap(filePath).GetHicon());
            }
        }

        private void tbStartLong_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbStartLon = sender as TextBox;
            CheckInputValue(tbStartLon, ref m_StartLong);
        }


        private void CheckInputValue(TextBox tb,ref double val)
        {
            if (tb != null)
            {
                if (!double.TryParse(tb.Text, out val))
                {
                    tb.Text = "0.0";
                }
            }
        }

        private void tbEndLong_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbEndLon = sender as TextBox;
            CheckInputValue(tbEndLon, ref m_EndLong);
        }

        private void tbStartLati_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbStartLat = sender as TextBox;
            CheckInputValue(tbStartLat, ref m_StartLati);
        }

        private void tbEndLati_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbEndLat = sender as TextBox;
            CheckInputValue(tbEndLat, ref m_EndLati);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            ClearBackColor();
            if (m_StartLong >= m_EndLong)
            {
                tbStartLong.BackColor = Color.Red;
                tbEndLong.BackColor = Color.Red;
                return;
            }

            if (m_StartLati >= m_EndLati)
            {
                tbStartLati.BackColor = Color.Red;
                tbEndLati.BackColor = Color.Red;
                return;
            }

            if (m_Seek <= 0)
            {
                tbSeek.BackColor = Color.Red;
                return;
            }

            Run();

        }

        private void ClearBackColor()
        {
            tbStartLong.BackColor = Color.White;
            tbEndLong.BackColor = Color.White;

            tbStartLati.BackColor = Color.White;
            tbEndLati.BackColor = Color.White;
            tbSeek.BackColor = Color.White;
        }

        private void Run()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Longitude,Latitude");
            Random random = new Random();
            int intStartLong = Convert.ToInt32(m_StartLong * 1000000);
            int intEndLong = Convert.ToInt32(m_EndLong * 1000000);
            int intStartLati = Convert.ToInt32(m_StartLati * 1000000);
            int intEndLati = Convert.ToInt32(m_EndLati * 1000000);

            for (int i = 0; i < m_Seek; i++)
            {
                sb.AppendLine(string.Format("{0},{1}", random.Next(intStartLong, intEndLong) / 1000000.0,
                    random.Next(intStartLati, intEndLati) / 1000000.0));
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "csv|*.csv";
                dialog.DefaultExt = ".csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                        {
                            writer.Write(sb.ToString());
                            writer.Flush();
                        }
                    }
                }
            }

            MessageBox.Show("Save success.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tbSeek_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tbSeek.BackColor = Color.White;
                if (!int.TryParse(tb.Text, out m_Seek))
                {
                    tbSeek.Text = "5";
                }
            }
        }
    }
}
