using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Namespace para comunicar com a BD

namespace Projeto_Final_Aim_Trainer
{
    public partial class MicroGrid : Form
    {
        int pontos = 0;
        int tempoRestante = 60;
        Random rnd = new Random();
        List<Point> posicoesMicro = new List<Point>();

        // 1. String de conexão oficial com o teu banco de dados localdb
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AimLabsDB;Trusted_Connection=True;Encrypt=False;";

        // 2. O MicroGrid vai responder pelo ID 3 na tua tabela dbo.Exercicios
        private int idExercicioModo = 3;

        // CONSTRUTOR 1: Vazio. Evita o erro CS7036 ao abrir a partir de Precisao.cs
        public MicroGrid()
        {
            InitializeComponent();
            ConfigurarGrade();
        }

        // CONSTRUTOR 2: Com parâmetros (Caso precises de passar dados pelas rotas)
        public MicroGrid(int idUser, int idEx)
        {
            InitializeComponent();
            ConfigurarGrade();
            SessaoUsuario.ID_UserLogado = idUser;
            this.idExercicioModo = idEx;
        }

        private void MicroGrid_Load(object sender, EventArgs e)
        {
            ReiniciarJogo();
        }

        private void ConfigurarGrade()
        {
            posicoesMicro.Clear();

            // Distância entre os botões
            int larguraCelula = 100;
            int alturaCelula = 100;

            // Tamanho total da grade 3x3
            int larguraTotalGrade = larguraCelula * 3;
            int alturaTotalGrade = alturaCelula * 3;

            // Centralização no formulário
            int inicioX = (this.ClientSize.Width - larguraTotalGrade) / 2;
            int inicioY = (this.ClientSize.Height - alturaTotalGrade) / 2;

            // CORRIGIDO: loop usa agora "linha++" de forma correta
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    int x = inicioX + (coluna * larguraCelula) + (larguraCelula / 2) - (btnAlvo1.Width / 2);
                    int y = inicioY + (linha * alturaCelula) + (alturaCelula / 2) - (btnAlvo1.Height / 2);

                    posicoesMicro.Add(new Point(x, y));
                }
            }
        }

        private void ReiniciarJogo()
        {
            pontos = 0;
            tempoRestante = 60;
            lblPontos.Text = "Pontos: 0";
            lblTimer.Text = "Tempo: 60s";

            // Configurar botões alvos
            Button[] botoes = { btnAlvo1, btnAlvo2, btnAlvo3 };
            foreach (var btn in botoes)
            {
                btn.Click -= btnAlvo_Click; // Remove para não duplicar o evento
                btn.Click += btnAlvo_Click;
                ReposicionarBotao(btn);
            }

            gameTimer.Start();
        }

        private void ReposicionarBotao(Button botao)
        {
            Point novaPosicao;
            int tentatives = 0;
            do
            {
                novaPosicao = posicoesMicro[rnd.Next(posicoesMicro.Count)];
                tentatives++;
                if (tentatives > 100) break;
            } while (novaPosicao == btnAlvo1.Location || novaPosicao == btnAlvo2.Location || novaPosicao == btnAlvo3.Location);

            botao.Location = novaPosicao;
        }

        private void btnAlvo_Click(object sender, EventArgs e)
        {
            if (tempoRestante > 0)
            {
                pontos += 2; // Adiciona 2 pontos
                lblPontos.Text = $"Pontos: {pontos}";

                if (sender is Button btn)
                {
                    ReposicionarBotao(btn);
                    btn.BringToFront();
                }
            }
        }

        private void MicroGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (tempoRestante > 0)
            {
                if (pontos > 0) pontos--; // Desconta 1 ponto (se tiver pontos)
                lblPontos.Text = $"Pontos: {pontos}";

                // Flash Vermelho de feedback de erro
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
                MessageBox.Show($"Treino Terminado!\nPontos: {pontos}");

                // Grava automaticamente a pontuação na BD
                GravarPontuacaoNoRanking();

                ReiniciarJogo();
            }
        }

        private void GravarPontuacaoNoRanking()
        {
            // Segurança: Só grava se houver sessão de utilizador ativa
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
                        comando.Parameters.AddWithValue("@idUser", SessaoUsuario.ID_UserLogado);
                        comando.Parameters.AddWithValue("@idEx", idExercicioModo); // Envia o ID 3
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