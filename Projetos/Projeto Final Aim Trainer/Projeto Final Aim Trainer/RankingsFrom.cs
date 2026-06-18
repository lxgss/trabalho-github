using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Projeto_Final_Aim_Trainer
{
    public partial class RankingsFrom : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AimLabsDB;Trusted_Connection=True;Encrypt=False;";

        public RankingsFrom()
        {
            InitializeComponent();
        }

        private void RankingsFrom_Load(object sender, EventArgs e)
        {
            // 1. Configurar o estilo visual escuro premium de todas as tabelas
            ConfigurarEstiloTabela(dgvGridShot);
            ConfigurarEstiloTabela(dgvSixShot);
            ConfigurarEstiloTabela(dgvMicroGrid);
            ConfigurarEstiloTabela(dgvSpiderShot);
            ConfigurarEstiloTabela(dgvStrafeTrack);

            // 2. Organizar e limpar as caixas de texto superiores (Adeus sobreposições!)
            OrganizarLabelsDoPainel(lblGridNome, lblGridScore, "GRIDSHOT");
            OrganizarLabelsDoPainel(lblSixNome, lblSixScore, "SIXSHOT");
            OrganizarLabelsDoPainel(lblMicroNome, lblMicroScore, "MICROGRID");
            OrganizarLabelsDoPainel(lblSpiderNome, lblSpiderScore, "SPIDERSHOT");
            OrganizarLabelsDoPainel(lblStrafeNome, lblStrafeScore, "STRAFETRACK");

            // 3. Chamar os dados da BD
            CarregarColunaRanking("GridShot", dgvGridShot, lblGridNome, lblGridScore);
            CarregarColunaRanking("SixShot", dgvSixShot, lblSixNome, lblSixScore);
            CarregarColunaRanking("MicroGridShot", dgvMicroGrid, lblMicroNome, lblMicroScore);
            CarregarColunaRanking("SpiderShot", dgvSpiderShot, lblSpiderNome, lblSpiderScore);
            CarregarColunaRanking("StrafeTrack", dgvStrafeTrack, lblStrafeNome, lblStrafeScore);
        }

        private void OrganizarLabelsDoPainel(Label lblNome, Label lblScore, string nomeExercicio)
        {
            if (lblNome.Parent == null) return;

            // Procurar pelo label genérico antigo (label1, label2 ou label3) e reconfigurá-lo
            foreach (Control c in lblNome.Parent.Controls)
            {
                if (c is Label)
                {
                    Label lblGenerico = (Label)c;

                    // Detetar qual label antigo foi selecionado para limpar o lixo do designer
                    if (lblGenerico.Name.Contains("label1") || lblGenerico.Text.Contains("label"))
                    {
                        // Transformar o antigo label1 no Título do Exercício centrado no topo
                        lblGenerico.Text = nomeExercicio;
                        lblGenerico.ForeColor = Color.Gold;
                        lblGenerico.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        lblGenerico.Size = new Size(lblNome.Parent.Width, 20);
                        lblGenerico.Location = new Point(0, 8);
                        lblGenerico.TextAlign = ContentAlignment.TopCenter;
                    }
                }
            }

            // Reposicionar o Nome do Jogador #1 (Desce um pouco e encosta à esquerda)
            lblNome.Location = new Point(15, 38);
            lblNome.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNome.ForeColor = Color.White;
            lblNome.Text = "-";

            // Reposicionar a Pontuação do Jogador #1 (Desce um pouco e encosta à direita)
            lblScore.Size = new Size(110, 20);
            lblScore.Location = new Point(lblNome.Parent.Width - 125, 38);
            lblScore.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblScore.ForeColor = Color.FromArgb(212, 175, 55); // Tom ouro discreto para o score
            lblScore.TextAlign = ContentAlignment.TopRight;
            lblScore.Text = "0 PTS";
        }

        private void ConfigurarEstiloTabela(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.EnableHeadersVisualStyles = false;

            // Fundo escuro integrado
            dgv.BackgroundColor = Color.FromArgb(24, 24, 24);
            dgv.ForeColor = Color.White;
            dgv.GridColor = Color.FromArgb(35, 35, 35);

            // Configuração dos Cabeçalhos (# / Jogador / Score)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(212, 175, 55);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 28;

            // Linhas com maior altura para melhor legibilidade
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 24);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 220);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.RowTemplate.Height = 28;

            // Criar as colunas perfeitamente alinhadas
            dgv.Columns.Add("Posicao", "#");
            dgv.Columns.Add("Jogador", "Jogador");
            dgv.Columns.Add("Pontos", "Score");

            // Margens e tamanhos otimizados
            dgv.Columns["Posicao"].Width = 40;
            dgv.Columns["Posicao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Posicao"].DefaultCellStyle.ForeColor = Color.DarkGray;

            dgv.Columns["Jogador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Jogador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Jogador"].DefaultCellStyle.Padding = new Padding(3, 0, 0, 0);

            dgv.Columns["Pontos"].Width = 80;
            dgv.Columns["Pontos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Pontos"].DefaultCellStyle.Padding = new Padding(0, 0, 5, 0);

            // Remover controlos indesejados da interface
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ScrollBars = ScrollBars.None;
        }

        private void CarregarColunaRanking(string nomeExercicio, DataGridView dgv, Label lblNomeTop1, Label lblScoreTop1)
        {
            string query = @"
                SELECT TOP 10 U.Username, R.Pontos 
                FROM dbo.Rankings R
                INNER JOIN dbo.Users U ON R.ID_User = U.ID_User
                INNER JOIN dbo.Exercicios E ON R.ID_Ex = E.ID_Ex
                WHERE E.Nome = @nomeEx
                ORDER BY R.Pontos DESC;";

            DataTable tabelaDados = new DataTable();

            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nomeEx", nomeExercicio);
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            conexao.Open();
                            adaptador.Fill(tabelaDados);
                        }
                    }
                }

                dgv.Rows.Clear();

                if (tabelaDados.Rows.Count == 0)
                {
                    lblNomeTop1.Text = "Sem Registo";
                    lblScoreTop1.Text = "0 PTS";
                    return;
                }

                // =================================================================
                // 1º Classificado (Destaque do painel dourado)
                // =================================================================
                DataRow primeiraLinha = tabelaDados.Rows[0];
                lblNomeTop1.Text = "👑 @" + primeiraLinha["Username"].ToString();
                lblScoreTop1.Text = primeiraLinha["Pontos"].ToString() + " PTS";

                // =================================================================
                // Restantes classificados do exercício (#2 ao #10)
                // =================================================================
                for (int i = 1; i < tabelaDados.Rows.Count; i++)
                {
                    string posicaoFormatada = "#" + (i + 1);
                    string nomeJogador = "@" + tabelaDados.Rows[i]["Username"].ToString();
                    string scoreJogador = tabelaDados.Rows[i]["Pontos"].ToString() + " PTS";

                    dgv.Rows.Add(posicaoFormatada, nomeJogador, scoreJogador);
                }

                dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar {nomeExercicio}: {ex.Message}", "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }
    }
}