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
    public partial class frmMain : Form
    {
        frmShow thefrmShow = new frmShow();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            listApresentation.Items.Clear();
            listApresentation.Items.Add("Blank");
            axWindowsMediaPlayer1.uiMode = "none";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listApresentation.Items.Clear();
            listApresentation.Items.Add("Blank");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Suported Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.avi;*.mpg;*.mp4";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listApresentation.Items.Add(openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            thefrmShow.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thefrmShow.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listApresentation.SelectedIndex > 0)
            {
                listApresentation.Items.RemoveAt(listApresentation.SelectedIndex);
            }
        }

        private void listApresentation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listApresentation.SelectedIndex == 0)
            {
                axWindowsMediaPlayer1.URL = "";
                thefrmShow.sUrl = "";
            }
            else
            {
                string sUrl = listApresentation.GetItemText(listApresentation.SelectedItem);
                axWindowsMediaPlayer1.URL = sUrl;
                thefrmShow.sUrl = sUrl;
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
