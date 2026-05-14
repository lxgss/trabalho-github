using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Projeto_Final_Aim_Trainer
{
    public partial class GridShot : Form
    {
        int pontos = 0;
        int tempoRestante = 60;
        Random rnd = new Random();
        List<Point> posicoesGrid = new List<Point>();

        public GridShot()
        {
            InitializeComponent();
            ConfigurarGrade();
        }

        private void GridShot_Load(object sender, EventArgs e)
        {
            ReiniciarJogo();
        }

        private void ConfigurarGrade()
        {
            posicoesGrid.Clear();

            // Distância entre os botões
            int larguraCelula = 100;
            int alturaCelula = 100;

            // Tamanho total da grade 3x3
            int larguraTotalGrade = larguraCelula * 3;
            int alturaTotalGrade = alturaCelula * 3;

            // Centralização no formulário
            int inicioX = (this.ClientSize.Width - larguraTotalGrade) / 2;
            int inicioY = (this.ClientSize.Height - alturaTotalGrade) / 2;

            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
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
            int tentativas = 0;
            do
            {
                novaPosicao = posicoesGrid[rnd.Next(posicoesGrid.Count)];
                tentativas++;
                if (tentativas > 100) break;
            } while (novaPosicao == btnAlvo1.Location || novaPosicao == btnAlvo2.Location || novaPosicao == btnAlvo3.Location);

            botao.Location = novaPosicao;
        }

        // REGRA: +2 pontos por acerto
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

        // REGRA: -1 ponto ao clicar fora (no fundo do formulário)
        private void GridShot_MouseClick(object sender, MouseEventArgs e)
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
                ReiniciarJogo(); // Opcional: Reinicia automaticamente após o OK
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}