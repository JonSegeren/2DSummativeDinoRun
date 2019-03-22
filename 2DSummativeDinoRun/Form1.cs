using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DSummativeDinoRun
{
    public partial class Form1 : Form
    {
        public static int score = 0;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Form f = FindForm();
            GameScreen ms = new GameScreen();
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
            this.Controls.Add(ms);            
            ms.Focus();
        }
    }
}
