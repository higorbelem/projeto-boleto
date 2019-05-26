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
            this.btn = new ProjBoletos.testes.MeuButton();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(3, 38);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(128, 42);
            this.btn.TabIndex = 0;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // CustomListViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CustomListViewItem";
            this.Load += new System.EventHandler(this.CustomListViewItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private testes.MeuButton btn;
    }
}
