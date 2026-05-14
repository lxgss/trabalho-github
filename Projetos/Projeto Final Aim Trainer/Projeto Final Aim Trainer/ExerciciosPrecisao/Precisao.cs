using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Aimlabs_prot;
using Projeto_Final_Aim_Trainer;

namespace Projeto_Final_Aim_Trainer
{
    public partial class Precisao : Form
    {
        public Precisao()
        {
            InitializeComponent();
        }

       

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            GridShot grid  = new GridShot();
            grid.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
