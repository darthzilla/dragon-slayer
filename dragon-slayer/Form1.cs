using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dragon_slayer
{
    public partial class Form1 : Form
    {
        GameManager gm;
        public Form1()
        {
            InitializeComponent();
            gm = new GameManager();
            DoubleBuffered = true;
            Width = 1264;
            Height = 759;
            gameTimer.Enabled = true;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            gm.Update();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            gm.Draw(e.Graphics);
        }
    }
}
