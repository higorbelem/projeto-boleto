namespace ProjBoletos.telas.mainPageControls {
    partial class HomeControl {
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
            this.SuspendLayout();
            // 
            // mainCard1
            // 
            this.mainCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.mainCard1.Location = new System.Drawing.Point(19, 89);
            this.mainCard1.Name = "mainCard1";
            this.mainCard1.Size = new System.Drawing.Size(351, 265);
            this.mainCard1.TabIndex = 0;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.mainCard1);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(503, 498);
            this.Load += new System.EventHandler(this.HomeControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private components.MainCard mainCard1;
    }
}
