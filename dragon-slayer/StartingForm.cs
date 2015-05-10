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
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void howTo_Click(object sender, EventArgs e)
        {
            htForm how = new htForm();
            how.Show();
        }
    }
}
