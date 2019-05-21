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
            this.SuspendLayout();
            // 
            // mainCard1
            // 
            this.mainCard1.Location = new System.Drawing.Point(21, 116);
            this.mainCard1.Name = "mainCard1";
            this.mainCard1.Size = new System.Drawing.Size(373, 262);
            this.mainCard1.TabIndex = 1;
            // 
            // mainCard3
            // 
            this.mainCard3.Location = new System.Drawing.Point(423, 116);
            this.mainCard3.Name = "mainCard3";
            this.mainCard3.Size = new System.Drawing.Size(373, 262);
            this.mainCard3.TabIndex = 3;
            // 
            // mainCard2
            // 
            this.mainCard2.Location = new System.Drawing.Point(1202, 116);
            this.mainCard2.Name = "mainCard2";
            this.mainCard2.Size = new System.Drawing.Size(373, 262);
            this.mainCard2.TabIndex = 2;
            // 
            // TabBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainCard3);
            this.Controls.Add(this.mainCard2);
            this.Controls.Add(this.mainCard1);
            this.Name = "TabBoletos";
            this.Size = new System.Drawing.Size(2000, 2000);
            this.Load += new System.EventHandler(this.TabBoletos_Load);
            this.Resize += new System.EventHandler(this.TabBoletos_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private components.MainCard mainCard1;
        private components.MainCard mainCard3;
        private components.MainCard mainCard2;
    }
}
