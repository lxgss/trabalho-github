using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Namespace correto para comunicação com a BD

namespace Projeto_Final_Aim_Trainer
{
    public partial class SixShot : Form
    {
        int pontos = 0;
        int tempoRestante = 60;
        Random rnd = new Random();
        List<Point> posicoesGrid = new List<Point>();

        // 1. String de conexão oficial com o teu banco de dados localdb
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AimLabsDB;Trusted_Connection=True;Encrypt=False;";

        // 2. O SixShot é o ID 2 na tua tabela dbo.Exercicios
        private int idExercicioModo = 2;

        // CONSTRUTOR 1: Vazio. Evita o erro CS7036 quando abres este ecrã a partir de Precisao.cs
        public SixShot()
        {
            InitializeComponent();
            ConfigurarGrade();
        }

        // CONSTRUTOR 2: Com parâmetros (Mantido por compatibilidade e rotas do projeto)
        public SixShot(int idUser, int idEx)
        {
            InitializeComponent();
            ConfigurarGrade();
            SessaoUsuario.ID_UserLogado = idUser;
            this.idExercicioModo = idEx;
        }

        private void SixShot_Load(object sender, EventArgs e)
        {
            ReiniciarJogo();
        }

        private void ConfigurarGrade()
        {
            posicoesGrid.Clear();

            // Distância entre os botões (espaço aumentado para dispersão wide)
            int larguraCelula = 120;
            int alturaCelula = 110;

            // Grade 5x4 (5 colunas e 4 linhas) para espalhar bem os 6 alvos
            int colunasGrade = 5;
            int linhasGrade = 4;

            int larguraTotalGrade = larguraCelula * colunasGrade;
            int alturaTotalGrade = alturaCelula * linhasGrade;

            // Centralização da área wide no formulário
            int inicioX = (this.ClientSize.Width - larguraTotalGrade) / 2;
            int inicioY = (this.ClientSize.Height - alturaTotalGrade) / 2;

            for (int linha = 0; linha < linhasGrade; linha++)
            {
                for (int coluna = 0; coluna < colunasGrade; coluna++)
                {
                    // Usa o btnAlvo1 como base de tamanho
                    int x = inicioX + (coluna * larguraCelula) + (larguraCelula / 2) - (btnAlvo1.Width / 2);
                    int y = inicioY + (linha * alturaCelula) + (alturaCelula / 2) - (btnAlvo1.Height / 2);

                    posicoesGrid.Add(new Point(x, y));
                }
            }
        }

        private void ReiniciarJogo()
        {
            pontos = 0;
            tempoRestante = 60;
            lblPontos.Text = "Pontos: 0";
            lblTimer.Text = "Tempo: 60s";

            // Array agora configurado estritamente com os 6 botões alvos
            Button[] botoes = { btnAlvo1, btnAlvo2, btnAlvo3, btnAlvo4, btnAlvo5, btnAlvo6 };
            foreach (var btn in botoes)
            {
                btn.Click -= btnAlvo_Click;
                btn.Click += btnAlvo_Click;
                ReposicionarBotao(btn);
            }

            gameTimer.Start();
        }

        private void ReposicionarBotao(Button botao)
        {
            Point novaPosicao;
            int tentativas = 0;
            do
            {
                novaPosicao = posicoesGrid[rnd.Next(posicoesGrid.Count)];
                tentativas++;
                if (tentativas > 100) break;
            }
            // Garante que nenhum dos 6 botões fica sobreposto
            while (novaPosicao == btnAlvo1.Location ||
                   novaPosicao == btnAlvo2.Location ||
                   novaPosicao == btnAlvo3.Location ||
                   novaPosicao == btnAlvo4.Location ||
                   novaPosicao == btnAlvo5.Location ||
                   novaPosicao == btnAlvo6.Location);

            botao.Location = novaPosicao;
        }

        // REGRA: +2 pontos por acerto
        private void btnAlvo_Click(object sender, EventArgs e)
        {
            if (tempoRestante > 0)
            {
                pontos += 2;
                lblPontos.Text = $"Pontos: {pontos}";

                if (sender is Button btn)
                {
                    ReposicionarBotao(btn);
                    btn.BringToFront();
                }
            }
        }

        // REGRA: -1 ponto ao falhar (clicar no fundo preto do Sixshot)
        private void Sixshot_MouseClick(object sender, MouseEventArgs e)
        {
            if (tempoRestante > 0)
            {
                if (pontos > 0) pontos--;
                lblPontos.Text = $"Pontos: {pontos}";

                // Feedback visual (Flash Vermelho)
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

                // Grava a pontuação deste treino de forma automática
                GravarPontuacaoNoRanking();

                ReiniciarJogo();
            }
        }

        private void GravarPontuacaoNoRanking()
        {
            // Segurança: Garante que só guarda os pontos se houver utilizador com sessão ativa
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
                        comando.Parameters.AddWithValue("@idEx", idExercicioModo); // Envia o valor 2 correspondente ao SixShot
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