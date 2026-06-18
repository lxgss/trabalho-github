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
            this.Close();
            GridShot grid  = new GridShot();
            grid.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            SixShot six = new SixShot();
            six.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            MicroGrid microGrid = new MicroGrid();
            microGrid.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            SpiderShot spider = new SpiderShot();
            spider.Show();
        }
    }
}
