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
    public partial class Criar : Form
    {
        public Criar()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Endereço do banco (o mesmo que usaste no outro)
            string connString = @"Server=(localdb)\MSSQLLocalDB;Database=AimLabsDB;Trusted_Connection=True;Encrypt=False;";

            // 2. Validação simples: não deixar criar conta com campos vazios
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, preenche todos os campos!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // 3. SQL para inserir o novo utilizador
                // Nota: ID_User não entra aqui porque é IDENTITY (o SQL cria sozinho)
                string sql = "INSERT INTO Users (Username, Password) VALUES (@user, @pass)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery(); // Executa o comando de inserção

                    MessageBox.Show("Conta criada com sucesso! Agora já podes fazer Login.");

                    // Limpa os campos para o utilizador poder fazer login
                    textBox1.Clear();
                   textBox2.Clear();
                }
                catch (SqlException ex)
                {
                    // O erro 2627 acontece se o Username já existir (por causa do UNIQUE que pusemos na tabela)
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Esse nome de utilizador já está a ser usado. Escolhe outro!");
                    }
                    else
                    {
                        MessageBox.Show("Erro técnico ao criar conta: " + ex.Message);
                    }
                }
            }
        }
    }
}
