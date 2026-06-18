    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Projeto_Final_Aim_Trainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Precisao precisao = new Precisao();
            precisao.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Log_in_Sign_up log_In_Sign_Up = new Log_in_Sign_up();
            log_In_Sign_Up.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tracking tracking = new Tracking();
            tracking.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Precisao precisao = new Precisao();
            precisao.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RankingsFrom rank = new RankingsFrom();
            rank.Show();
            this.Hide();
        }
    }
}
