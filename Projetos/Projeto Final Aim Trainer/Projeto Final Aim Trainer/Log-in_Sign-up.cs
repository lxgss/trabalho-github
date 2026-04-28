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
    public partial class Log_in_Sign_up : Form
    {
        public Log_in_Sign_up()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Tens a certeza que queres sair do Aim Trainer?",
                                            "Sair",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entrar telaEntrar = new Entrar();

            // 2. Mostrar o formulário
            telaEntrar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Criar telaCriar = new Criar();

            // 2. Mostrar o formulário
            telaCriar.Show();
        }
    }
}
