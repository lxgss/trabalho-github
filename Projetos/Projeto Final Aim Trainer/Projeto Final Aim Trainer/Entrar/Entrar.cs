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

   

    public partial class Entrar : Form
    {
        public Entrar()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
            Log_in_Sign_up log_In_Sign_Up = new Log_in_Sign_up();
            log_In_Sign_Up.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Server=(localdb)\MSSQLLocalDB;Database=AimLabsDB;Trusted_Connection=True;Encrypt=False;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SQL para buscar o ID do usuário
                string sql = "SELECT ID_User FROM Users WHERE Username = @user AND Password = @pass";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Ajusta txtNome e txtPassword para os nomes que deste às tuas caixas
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                try
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        // Guarda os dados na classe que criámos acima
                        SessaoUsuario.ID_UserLogado = Convert.ToInt32(resultado);
                        SessaoUsuario.NomeLogado = textBox1.Text;

                        MessageBox.Show("Bem-vindo, " + SessaoUsuario.NomeLogado + "!");

                        // Abre o menu principal (ajusta o nome do Form se não for Form1)
                        Form1 menu = new Form1();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Conta não existe. Pretende criar uma?", "Erro", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            // Aqui podes chamar o código de criar conta ou focar no botão de criar
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void Entrar_Load(object sender, EventArgs e)
        {

        }
    }
}
