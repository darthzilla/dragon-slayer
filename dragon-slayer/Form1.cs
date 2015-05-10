using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public static float deltaTime = 0.016f;
        public Form1()
        {
            InitializeComponent();
            gm = new GameManager();
            DoubleBuffered = true;
            Width = 1264;
            Height = 759;
            gameTimer.Enabled = true;
            animationTimer.Enabled = true;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            gm.Update();
            if (gm.gameOver)
            {
                gm = new GameManager();
            }
            gm.marko.UpdateAnimState();
            Invalidate();
            Exit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            gm.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                gm.marko.direction = Direction.RIGHT;
                gm.marko.isMovingRight = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                gm.marko.direction = Direction.LEFT;
                gm.marko.isMovingLeft = true;
            }
            if ((e.KeyCode == Keys.Space || e.KeyCode == Keys.X || e.KeyCode == Keys.Up) && !gm.marko.isJumping)
            {
                gm.marko.isJumping = true;
            }
            if (e.KeyCode == Keys.Z)
            {
                gm.marko.attackState = true;
                hitTimer.Enabled = true;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                gm.marko.isMovingRight = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                gm.marko.isMovingLeft = false;
            }
        }

        private void hitTimer_Tick(object sender, EventArgs e)
        {
            gm.marko.attackState = false;
            hitTimer.Enabled = false;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            gm.Animate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //-------------------------------
        //| CHECK IF ABLE TO PROGRESS
        //-------------------------------
        public void Exit()
        {
            if (gm.marko.location.X >= 1200 && gm.marko.location.Y >= 524)
            {
                foreach (Enemy e in gm.levels.ElementAt(gm.currentLevel).enemies)
                {
                    if (e.isAlive)
                        return;
                }
                if (gm.currentLevel < gm.levels.Count - 1)
                    gm.NextLevel();
                else
                {
                    this.Close();
                    DialogResult dir = MessageBox.Show("You won! \n Do you want to play again?","Winning is awesome",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if (dir == System.Windows.Forms.DialogResult.Yes)
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                    }
                    else if (dir == System.Windows.Forms.DialogResult.No)
                    {
                        StartingForm sForm = new StartingForm();
                        sForm.Show();
                    }
                }
            }
        }
    }
}
