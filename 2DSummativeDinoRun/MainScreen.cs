using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DSummativeDinoRun
{
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        SolidBrush titleBrush = new SolidBrush(Color.SlateGray);
        Font titleFont = new Font("Segoe UI", 16);
        Font smallTitleFont = new Font("Segoe UI", 12);

        GameScreen js = new GameScreen();
        #region Keys

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                //this doesnt work 
                case Keys.Space:
                    Form j = this.FindForm();
                    j.Controls.Remove(this);
                    this.Controls.Add(js);
                    js.Focus();
                    break;
                case Keys.Escape:
                    ((Form1)this.TopLevelControl).Close();
                    break;
            }
        }

        #endregion

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Press space to start", titleFont, titleBrush, 10, 10);
            e.Graphics.DrawString("No internet", titleFont, titleBrush, 10, 30);
            e.Graphics.DrawString("Try:", smallTitleFont, titleBrush, 10, 60);
            e.Graphics.DrawString("- Checking the network cables, modem and router", smallTitleFont,titleBrush, 20, 75);
            e.Graphics.DrawString("- Reconnecting to Wi-Fi", smallTitleFont, titleBrush, 20, 90);
            e.Graphics.DrawString("- Running Windows Network Diagnostics", smallTitleFont, titleBrush, 20, 105);
            e.Graphics.DrawString("ERR_INTERNET_DISCONNECTED", smallTitleFont, titleBrush, 10, 120);
        }
    }
}

