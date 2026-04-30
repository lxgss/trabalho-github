 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Aimlabs_prot
    {
        public partial class Gridshot : Form
        {
            int pontos = 0;
            int tempoRestante = 60;
            Random rnd = new Random();
            List<Point> posicoesGrid = new List<Point>();

            public Gridshot()
            {
                InitializeComponent();
                ConfigurarGrade();
            }

            // Conecte ao evento 'Load' do Form no Raio ⚡
            private void Form1_Load(object sender, EventArgs e)
            {
                ReiniciarJogo();
            }

            private void ConfigurarGrade()
            {
                posicoesGrid.Clear();

                // 1. Defina o quão perto você quer os botões (ex: 100 pixels de distância)
                int larguraCelula = 100;
                int alturaCelula = 100;

                // 2. Calcule o tamanho total da grade (3 colunas x 100px, 3 linhas x 100px)
                int larguraTotalGrade = larguraCelula * 3;
                int alturaTotalGrade = alturaCelula * 3;

                // 3. Calcule o ponto inicial (topo/esquerda) para centralizar a grade no formulário
                int inicioX = (this.ClientSize.Width - larguraTotalGrade) / 2;
                int inicioY = (this.ClientSize.Height - alturaTotalGrade) / 2;

                for (int linha = 0; linha < 3; linha++)
                {
                    for (int coluna = 0; coluna < 3; coluna++)
                    {
                        // O cálculo agora usa o 'inicioX' e 'inicioY' como base centralizada
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
                gameTimer.Start();
                ReposicionarBotao(btnAlvo1);
                ReposicionarBotao(btnAlvo2);
                ReposicionarBotao(btnAlvo3);
            }

            private void ReposicionarBotao(Button botao)
            {
                Point novaPosicao;
                do
                {
                    novaPosicao = posicoesGrid[rnd.Next(posicoesGrid.Count)];
                } while (novaPosicao == btnAlvo1.Location || novaPosicao == btnAlvo2.Location || novaPosicao == btnAlvo3.Location);
                botao.Location = novaPosicao;
            }

            // REGRA 1: +2 pontos por acerto
            private void btnAlvo_Click(object sender, EventArgs e)
            {
                pontos += 2;
                lblPontos.Text = $"Pontos: {pontos}";
                if (sender is Button btn) ReposicionarBotao(btn);
            }

            // REGRA 2: -1 ponto ao clicar no void (Form)
            // REGRA 2: -1 ponto ao clicar no void (Form)
            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
                // Só desconta se o jogo estiver a decorrer e tiveres pontos para tirar
                if (tempoRestante > 0 && pontos > 0)
                {
                    pontos--; // Tira 1 ponto
                    lblPontos.Text = $"Pontos: {pontos}"; // Atualiza a label

                    // Feedback visual: fundo pisca em vermelho
                    this.BackColor = Color.IndianRed;
                    Timer flash = new Timer { Interval = 100 };
                    flash.Tick += (s, ev) => {
                        this.BackColor = SystemColors.Control;
                        flash.Stop();
                    };
                    flash.Start();
                }
            }

            // REGRA 3: Timer decrescente de 60 a 0
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
                    ReiniciarJogo();
                }
            }


        private void lblPontos_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

