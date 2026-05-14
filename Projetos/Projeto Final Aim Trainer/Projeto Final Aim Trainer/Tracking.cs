using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Final_Aim_Trainer
{
    public partial class Tracking : Form
    {
        public Tracking()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tracking1 track1 = new tracking1();
            track1.Show();
        }
    }
}
