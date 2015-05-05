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
    public enum Direction
    {
        RIGHT,
        LEFT
    }
    public partial class Form1 : Form
    {
        GameManager gm;
        public double deltaTime;
        public Form1()
        {
            InitializeComponent();
            gm = new GameManager();
            DoubleBuffered = true;
            Width = 1264;
            Height = 759;
            gameTimer.Enabled = true;
            deltaTime = DateTime.Now.Second;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            gm.Update();
            Invalidate();
            deltaTime = DateTime.Now.Second - deltaTime;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            gm.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                gm.marko.Move(Direction.RIGHT, deltaTime);
            }
            else if(e.KeyCode == Keys.Left)
            {
                gm.marko.Move(Direction.LEFT, deltaTime);
            }
        }
    }
}
