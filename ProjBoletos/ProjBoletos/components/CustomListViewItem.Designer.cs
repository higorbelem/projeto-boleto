namespace ProjBoletos.components {
    partial class CustomListViewItem {
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
            this.btnGerar1 = new ProjBoletos.testes.MeuButton();
            this.btnVer1 = new ProjBoletos.testes.MeuButton();
            this.SuspendLayout();
            // 
            // btnGerar1
            // 
            this.btnGerar1.Location = new System.Drawing.Point(3, 38);
            this.btnGerar1.Margin = new System.Windows.Forms.Padding(0);
            this.btnGerar1.Name = "btnGerar1";
            this.btnGerar1.Size = new System.Drawing.Size(128, 42);
            this.btnGerar1.TabIndex = 0;
            this.btnGerar1.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnVer1
            // 
            this.btnVer1.Location = new System.Drawing.Point(137, 38);
            this.btnVer1.Margin = new System.Windows.Forms.Padding(0);
            this.btnVer1.Name = "btnVer1";
            this.btnVer1.Size = new System.Drawing.Size(86, 42);
            this.btnVer1.TabIndex = 1;
            // 
            // CustomListViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVer1);
            this.Controls.Add(this.btnGerar1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CustomListViewItem";
            this.Size = new System.Drawing.Size(313, 150);
            this.Load += new System.EventHandler(this.CustomListViewItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private testes.MeuButton btnGerar1;
        private testes.MeuButton btnVer1;
    }
}
