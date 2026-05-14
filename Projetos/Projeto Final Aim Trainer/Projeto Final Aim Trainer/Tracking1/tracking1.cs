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
    public partial class tracking1 : Form
    {
        // Variáveis de Jogo
        int pontos = 0;
        int tempoRestante = 60;

        // Variáveis de Movimento (Velocidade)
        int velX = 6;
        int velY = 6;

        public tracking1()
        {
            InitializeComponent();
        }

        private void tracking1_Load(object sender, EventArgs e)
        {
            ReiniciarJogo();
        }
        

        private void ReiniciarJogo()
        {
            pontos = 0;
            tempoRestante = 60;
            lblPontos.Text = "Pontos: 0";
            lblTimer.Text = "Tempo: 60s";

            // Inicia os motores
            gameTimer.Start();
            movementTimer.Start();
        }

        // Lógica de Movimento (Tick do movementTimer - Intervalo 20ms)
        private void movementTimer_Tick(object sender, EventArgs e)
        {
            // Move o botão
            btnAlvo.Left += velX;
            btnAlvo.Top += velY;

            // Colisão Direita/Esquerda - APENAS INVERTE, NÃO MUDA COR
            if (btnAlvo.Left <= 0 || btnAlvo.Right >= this.ClientSize.Width)
            {
                velX = -velX;
            }

            // Colisão Topo/Fundo - APENAS INVERTE
            if (btnAlvo.Top <= 0 || btnAlvo.Bottom >= this.ClientSize.Height)
            {
                velY = -velY;
            }
        }

        // REGRA: +2 pontos ao acertar no alvo em movimento
        private void btnAlvo_Click(object sender, EventArgs e)
        {
            pontos += 2;
            lblPontos.Text = $"Pontos: {pontos}";

            // Feedback visual ao clicar
            btnAlvo.BackColor = Color.LightGreen; // Cor ao clicar
            Timer t = new Timer { Interval = 100 };
            t.Tick += (s, ev) =>
            {
                btnAlvo.BackColor = Color.Gold; // Fica amarelo depois do clique
                t.Stop();
            };
            t.Start();
        }

        // REGRA: -1 ponto ao clicar no vazio (Erro de precisão)
        private void FormSquareTracking_MouseClick(object sender, MouseEventArgs e)
        {
            if (pontos > 0) pontos--;
            lblPontos.Text = $"Pontos: {pontos}";

            this.BackColor = Color.IndianRed;
            Timer flash = new Timer { Interval = 100 };
            flash.Tick += (s, ev) => { this.BackColor = SystemColors.Control; flash.Stop(); };
            flash.Start();
        }

        // REGRA: Timer decrescente de 60 a 0
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (tempoRestante > 0)
            {
                tempoRestante--; // Tira 1 segundo
                lblTimer.Text = $"Tempo: {tempoRestante}s"; // Atualiza o ecrã
            }
            else
            {
                // QUANDO O TEMPO ACABA:
                gameTimer.Stop(); // Para o relógio
                movementTimer.Stop(); // Para o quadrado de andar

                MessageBox.Show($"Treino Terminado!\nPontos: {pontos}");

                ReiniciarJogo(); // Volta a colocar tudo a 60s e 0 pontos
            }
        }

        private void MudarCorAlvo()
        {
            // Apenas para dar um efeito visual quando o quadrado bate na parede
            Random r = new Random();
            btnAlvo.BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }

        private void movementTimer_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
