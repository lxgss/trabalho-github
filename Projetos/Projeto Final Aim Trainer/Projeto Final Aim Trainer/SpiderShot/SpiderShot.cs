using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Namespace correto (igual ao teu Login/Criar Conta)

namespace Projeto_Final_Aim_Trainer
{
    public partial class SpiderShot : Form
    {
        int pontos = 0;
        int tempoRestante = 60;
        Random rnd = new Random();
        List<Point> posicoesBordas = new List<Point>();
        Point posicaoCentro;
        bool estaNoCentro = true;

        // 1. String de conexão oficial para o teu banco de dados localdb
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AimLabsDB;Trusted_Connection=True;Encrypt=False;";

        // 2. ATUALIZADO: Agora o SpiderShot é oficialmente o ID 4 no banco de dados!
        private int idExercicioModo = 4;

        // CONSTRUTOR 1: Vazio. Resolve o erro CS7036 no ecrã Precisao.cs
        public SpiderShot()
        {
            InitializeComponent();
            ConfigurarGradeSpider();
        }

        // CONSTRUTOR 2: Com parâmetros (Mantido por segurança e rotas do projeto)
        public SpiderShot(int idUser, int idEx)
        {
            InitializeComponent();
            ConfigurarGradeSpider();
            SessaoUsuario.ID_UserLogado = idUser;
            this.idExercicioModo = idEx;
        }

        private void SpiderShot_Load(object sender, EventArgs e)
        {
            ReiniciarJogo();
        }

        private void ConfigurarGradeSpider()
        {
            posicoesBordas.Clear();

            int larguraCelula = 130;
            int alturaCelula = 120;
            int colunas = 5;
            int linhas = 4;

            int larguraTotal = larguraCelula * colunas;
            int alturaTotal = alturaCelula * linhas;

            int inicioX = (this.ClientSize.Width - larguraTotal) / 2;
            int inicioY = (this.ClientSize.Height - alturaTotal) / 2;

            int centroX = (this.ClientSize.Width / 2) - (btnAlvo.Width / 2);
            int centroY = (this.ClientSize.Height / 2) - (btnAlvo.Height / 2);
            posicaoCentro = new Point(centroX, centroY);

            // Correção do loop: alterado de 'line++' para 'linha++'
            for (int linha = 0; linha < linhas; linha++)
            {
                for (int coluna = 0; coluna < colunas; coluna++)
                {
                    if (linha == linhas / 2 && coluna == colunas / 2) continue;

                    int x = inicioX + (coluna * larguraCelula) + (larguraCelula / 2) - (btnAlvo.Width / 2);
                    int y = inicioY + (linha * alturaCelula) + (alturaCelula / 2) - (btnAlvo.Height / 2);

                    posicoesBordas.Add(new Point(x, y));
                }
            }
        }

        private void ReiniciarJogo()
        {
            pontos = 0;
            tempoRestante = 60;
            lblScore.Text = "Score: 0";
            lblTimer.Text = "Tempo: 60s";
            estaNoCentro = true;

            btnAlvo.Click -= btnAlvo_Click;
            btnAlvo.Click += btnAlvo_Click;

            btnAlvo.Location = posicaoCentro;
            gameTimer.Start();
        }

        private void btnAlvo_Click(object sender, EventArgs e)
        {
            if (tempoRestante <= 0) return;

            pontos += 2;
            lblScore.Text = $"Score: {pontos}";

            if (estaNoCentro)
            {
                btnAlvo.Location = posicoesBordas[rnd.Next(posicoesBordas.Count)];
                estaNoCentro = false;
            }
            else
            {
                btnAlvo.Location = posicaoCentro;
                estaNoCentro = true;
            }

            btnAlvo.BringToFront();
        }

        private void SpiderShot_MouseClick(object sender, MouseEventArgs e)
        {
            if (tempoRestante > 0)
            {
                if (pontos > 0) pontos--;
                lblScore.Text = $"Score: {pontos}";

                Color corOriginal = this.BackColor;
                this.BackColor = Color.Maroon;
                Timer flash = new Timer { Interval = 70 };
                flash.Tick += (s, ev) => {
                    this.BackColor = corOriginal;
                    flash.Stop();
                    flash.Dispose();
                };
                flash.Start();
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (tempoRestante > 0)
            {
                tempoRestante--;
                lblTimer.Text = $"Tempo: {tempoRestante}s";
            }
            else
            {
                gameTimer.Stop();
                MessageBox.Show($"Treino Terminado!\nScore Final: {pontos}");

                // Grava a pontuação no banco de dados local
                GravarPontuacaoNoRanking();

                ReiniciarJogo();
            }
        }

        private void GravarPontuacaoNoRanking()
        {
            // Impede gravações nulas se o utilizador não tiver sessão iniciada de verdade
            if (SessaoUsuario.ID_UserLogado <= 0)
            {
                MessageBox.Show("Nenhum utilizador logado detetado. A pontuação não será guardada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO dbo.Rankings (ID_User, ID_Ex, Pontos, Data_Treino) " +
                           "VALUES (@idUser, @idEx, @pontos, @data);";

            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        // Utiliza a variável correta da tua classe global (ID_UserLogado)
                        comando.Parameters.AddWithValue("@idUser", SessaoUsuario.ID_UserLogado);
                        comando.Parameters.AddWithValue("@idEx", idExercicioModo); // Envia o valor 4
                        comando.Parameters.AddWithValue("@pontos", pontos);
                        comando.Parameters.AddWithValue("@data", DateTime.Now);

                        conexao.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar no banco de dados: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Precisao precisao = new Precisao();
            precisao.Show();
        }
    }
}