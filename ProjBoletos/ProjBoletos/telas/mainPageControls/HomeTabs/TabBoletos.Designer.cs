namespace ProjBoletos.telas.mainPageControls.HomeTabs {
    partial class TabBoletos {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.mainCard1 = new ProjBoletos.components.MainCard();
            this.mainCard3 = new ProjBoletos.components.MainCard();
            this.mainCard2 = new ProjBoletos.components.MainCard();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainCard1
            // 
            this.mainCard1.Location = new System.Drawing.Point(-75, 28);
            this.mainCard1.Name = "mainCard1";
            this.mainCard1.Size = new System.Drawing.Size(373, 262);
            this.mainCard1.TabIndex = 1;
            // 
            // mainCard3
            // 
            this.mainCard3.Location = new System.Drawing.Point(359, 37);
            this.mainCard3.Name = "mainCard3";
            this.mainCard3.Size = new System.Drawing.Size(373, 262);
            this.mainCard3.TabIndex = 3;
            // 
            // mainCard2
            // 
            this.mainCard2.Location = new System.Drawing.Point(776, 28);
            this.mainCard2.Name = "mainCard2";
            this.mainCard2.Size = new System.Drawing.Size(373, 262);
            this.mainCard2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mainCard1);
            this.panel1.Controls.Add(this.mainCard2);
            this.panel1.Controls.Add(this.mainCard3);
            this.panel1.Location = new System.Drawing.Point(63, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 3013);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(561, 3000);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // TabBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabBoletos";
            this.Size = new System.Drawing.Size(2000, 2000);
            this.Load += new System.EventHandler(this.TabBoletos_Load);
            this.Resize += new System.EventHandler(this.TabBoletos_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private components.MainCard mainCard1;
        private components.MainCard mainCard3;
        private components.MainCard mainCard2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
