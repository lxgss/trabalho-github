namespace Projeto_Final_Aim_Trainer
{
    partial class tracking1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblPontos = new System.Windows.Forms.Label();
            this.btnAlvo = new System.Windows.Forms.Button();
            this.movementTimer = new System.Windows.Forms.Timer(this.components);
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTimer.Location = new System.Drawing.Point(448, 20);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(89, 29);
            this.lblTimer.TabIndex = 5;
            this.lblTimer.Text = "Timer: ";
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPontos.Location = new System.Drawing.Point(245, 20);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(94, 29);
            this.lblPontos.TabIndex = 4;
            this.lblPontos.Text = "Pontos:";
            // 
            // btnAlvo
            // 
            this.btnAlvo.BackColor = System.Drawing.Color.Gold;
            this.btnAlvo.Location = new System.Drawing.Point(345, 160);
            this.btnAlvo.Name = "btnAlvo";
            this.btnAlvo.Size = new System.Drawing.Size(115, 84);
            this.btnAlvo.TabIndex = 3;
            this.btnAlvo.UseVisualStyleBackColor = false;
            this.btnAlvo.Click += new System.EventHandler(this.btnAlvo_Click);
            // 
            // movementTimer
            // 
            this.movementTimer.Enabled = true;
            this.movementTimer.Interval = 20;
            this.movementTimer.Tick += new System.EventHandler(this.movementTimer_Tick);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // tracking1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.btnAlvo);
            this.Name = "tracking1";
            this.Text = "tracking1";
            this.Load += new System.EventHandler(this.tracking1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Button btnAlvo;
        private System.Windows.Forms.Timer movementTimer;
        private System.Windows.Forms.Timer gameTimer;
    }
}