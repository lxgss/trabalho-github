namespace Projeto_Final_Aim_Trainer
{
    partial class MicroGrid
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
            this.btnAlvo2 = new System.Windows.Forms.Button();
            this.btnAlvo3 = new System.Windows.Forms.Button();
            this.lblPontos = new System.Windows.Forms.Label();
            this.btnAlvo1 = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTimer.Location = new System.Drawing.Point(586, 7);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(89, 29);
            this.lblTimer.TabIndex = 14;
            this.lblTimer.Text = "Timer: ";
            // 
            // btnAlvo2
            // 
            this.btnAlvo2.BackColor = System.Drawing.Color.Gold;
            this.btnAlvo2.Location = new System.Drawing.Point(543, 289);
            this.btnAlvo2.Name = "btnAlvo2";
            this.btnAlvo2.Size = new System.Drawing.Size(47, 42);
            this.btnAlvo2.TabIndex = 13;
            this.btnAlvo2.UseVisualStyleBackColor = false;
            this.btnAlvo2.Click += new System.EventHandler(this.btnAlvo_Click);
            // 
            // btnAlvo3
            // 
            this.btnAlvo3.BackColor = System.Drawing.Color.Gold;
            this.btnAlvo3.Location = new System.Drawing.Point(641, 289);
            this.btnAlvo3.Name = "btnAlvo3";
            this.btnAlvo3.Size = new System.Drawing.Size(44, 42);
            this.btnAlvo3.TabIndex = 12;
            this.btnAlvo3.UseVisualStyleBackColor = false;
            this.btnAlvo3.Click += new System.EventHandler(this.btnAlvo_Click);
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPontos.Location = new System.Drawing.Point(440, 7);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(100, 29);
            this.lblPontos.TabIndex = 11;
            this.lblPontos.Text = "Pontos: ";
            // 
            // btnAlvo1
            // 
            this.btnAlvo1.BackColor = System.Drawing.Color.Gold;
            this.btnAlvo1.Location = new System.Drawing.Point(448, 289);
            this.btnAlvo1.Name = "btnAlvo1";
            this.btnAlvo1.Size = new System.Drawing.Size(47, 42);
            this.btnAlvo1.TabIndex = 10;
            this.btnAlvo1.UseVisualStyleBackColor = false;
            this.btnAlvo1.Click += new System.EventHandler(this.btnAlvo_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Location = new System.Drawing.Point(1074, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "Sair";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MicroGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1182, 625);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnAlvo2);
            this.Controls.Add(this.btnAlvo3);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.btnAlvo1);
            this.Name = "MicroGrid";
            this.Text = "MicroGrid";
            this.Load += new System.EventHandler(this.MicroGrid_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MicroGrid_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnAlvo2;
        private System.Windows.Forms.Button btnAlvo3;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Button btnAlvo1;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button button1;
    }
}