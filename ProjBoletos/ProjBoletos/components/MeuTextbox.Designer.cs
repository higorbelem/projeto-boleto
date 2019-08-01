namespace ProjBoletos.components {
    partial class MeuTextbox {
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
         this.components = new System.ComponentModel.Container();
         this.textBox1 = new System.Windows.Forms.MaskedTextBox();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.SuspendLayout();
         // 
         // textBox1
         // 
         this.textBox1.BackColor = System.Drawing.Color.White;
         this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBox1.Location = new System.Drawing.Point(132, 118);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(314, 13);
         this.textBox1.TabIndex = 0;
         this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
         // 
         // MeuTextbox
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.textBox1);
         this.Name = "MeuTextbox";
         this.Size = new System.Drawing.Size(535, 273);
         this.Load += new System.EventHandler(this.MeuTextbox_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.MaskedTextBox textBox1;
      private System.Windows.Forms.ToolTip toolTip1;
   }
}
