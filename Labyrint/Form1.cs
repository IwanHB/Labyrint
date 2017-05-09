using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadMaze_Click(object sender, EventArgs e)
        {
            if (!thepanel.Controls.Contains(UserControl1.Instance))
            {
                thepanel.Controls.Add(UserControl1.Instance);
                UserControl1.Instance.Dock = DockStyle.Fill;
                UserControl1.Instance.BringToFront();
            }
            else
            {
                UserControl1.Instance.BringToFront();
            }
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            if (!thepanel.Controls.Contains(UserControl2.Instance))
            {
                thepanel.Controls.Add(UserControl2.Instance);
                UserControl2.Instance.Dock = DockStyle.Fill;
                UserControl2.Instance.BringToFront();
            }
            else
            {
                UserControl2.Instance.BringToFront();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void PaintMe(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
