using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaSimpleDataShow
{
    public partial class frmShow : Form
    {
        public string sUrl
        {
            get { return sUrlAtual; }
            set { sUrlAtual = value;  axWindowsMediaPlayer1.URL = value; }
        }

        private string sUrlAtual;

        public frmShow()
        {
            InitializeComponent();
        }

        private void frmShow_Load(object sender, EventArgs e)
        {
            sUrlAtual = "";
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.Top = 0;
            axWindowsMediaPlayer1.Left = 0;
            axWindowsMediaPlayer1.Width = this.ClientSize.Width;
            axWindowsMediaPlayer1.Height = this.ClientSize.Height;
            axWindowsMediaPlayer1.settings.volume = 99;
        }

        private void frmShow_Resize(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.Top = 0;
            axWindowsMediaPlayer1.Left = 0;
            axWindowsMediaPlayer1.Width = this.ClientSize.Width;
            axWindowsMediaPlayer1.Height = this.ClientSize.Height;
        }

        private void axWindowsMediaPlayer1_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
            if (frmShow.ActiveForm.WindowState == FormWindowState.Normal)
            {
                frmShow.ActiveForm.WindowState = FormWindowState.Maximized;
            }
            else if (frmShow.ActiveForm.WindowState == FormWindowState.Maximized)
            {
                frmShow.ActiveForm.WindowState = FormWindowState.Normal;
            }
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.Top = 0;
            axWindowsMediaPlayer1.Left = 0;
            axWindowsMediaPlayer1.Width = this.ClientSize.Width;
            axWindowsMediaPlayer1.Height = this.ClientSize.Height;
        }

        private void frmShow_SizeChanged(object sender, EventArgs e)
        {
            if (frmShow.ActiveForm.WindowState == FormWindowState.Maximized)
            {
                frmShow.ActiveForm.Text = "";
            }else
            { 
                frmShow.ActiveForm.Text = "  ";
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

            string sUrl = sUrlAtual;
            //MessageBox.Show(sUrl);
            if (sUrl.Length < 4)
            {
                sUrl = "        ";
            }
            if ((sUrl.Substring(sUrl.Length - 3) != "mp4") && (sUrl.Substring(sUrl.Length - 3) != "avi") && (sUrl.Substring(sUrl.Length - 3) != "mpg"))
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }
    }
}
