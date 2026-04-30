namespace Aimlabs_prot
{
    partial class Gridshot
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
            this.btnAlvo1 = new System.Windows.Forms.Button();
            this.btnAlvo2 = new System.Windows.Forms.Button();
            this.btnAlvo3 = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblPontos = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnAlvo1
            // 
            this.btnAlvo1.BackColor = System.Drawing.Color.Gold;
            this.btnAlvo1.Location = new System.Drawing.Point(364, 229);
            this.btnAlvo1.Name = "btnAlvo1";
            this.btnAlvo1.Size = new System.Drawing.Size(89, 74);
            this.btnAlvo1.TabIndex = 2;
            this.btnAlvo1.UseVisualStyleBackColor = false;
            // 
            // btnAlvo2
            // 
            this.btnAlvo2.BackColor = System.Drawing.Color.Gold;
            this.btnAlvo2.Location = new System.Drawing.Point(486, 229);
            this.btnAlvo2.Name = "btnAlvo2";
            this.btnAlvo2.Size = new System.Drawing.Size(89, 74);
            this.btnAlvo2.TabIndex = 4;
            this.btnAlvo2.UseVisualStyleBackColor = false;
            // 
            // btnAlvo3
            // 
            this.btnAlvo3.BackColor = System.Drawing.Color.Gold;
            this.btnAlvo3.Location = new System.Drawing.Point(611, 229);
            this.btnAlvo3.Name = "btnAlvo3";
            this.btnAlvo3.Size = new System.Drawing.Size(89, 74);
            this.btnAlvo3.TabIndex = 5;
            this.btnAlvo3.UseVisualStyleBackColor = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTimer.Location = new System.Drawing.Point(560, 35);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(89, 29);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "Timer: ";
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPontos.Location = new System.Drawing.Point(394, 35);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(100, 29);
            this.lblPontos.TabIndex = 6;
            this.lblPontos.Text = "Pontos: ";
            this.lblPontos.Click += new System.EventHandler(this.lblPontos_Click_1);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            // 
            // Gridshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1182, 625);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.btnAlvo3);
            this.Controls.Add(this.btnAlvo2);
            this.Controls.Add(this.btnAlvo1);
            this.Name = "Gridshot";
            this.Text = "Grid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAlvo1;
        private System.Windows.Forms.Button btnAlvo2;
        private System.Windows.Forms.Button btnAlvo3;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Timer gameTimer;
    }
}