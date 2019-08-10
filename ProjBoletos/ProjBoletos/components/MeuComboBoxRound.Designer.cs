using System.Drawing;

namespace ProjBoletos.components {
   partial class MeuComboBoxRound {
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
         this.meuComboBox1 = new ProjBoletos.components.MeuComboBox(Color.FromArgb(210,210,210));
         this.SuspendLayout();
         // 
         // meuComboBox1
         // 
         this.meuComboBox1.FormattingEnabled = true;
         this.meuComboBox1.Location = new System.Drawing.Point(304, 66);
         this.meuComboBox1.Name = "meuComboBox1";
         this.meuComboBox1.Size = new System.Drawing.Size(247, 21);
         this.meuComboBox1.TabIndex = 0;
         // 
         // MeuComboBoxRound
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.meuComboBox1);
         this.Name = "MeuComboBoxRound";
         this.Size = new System.Drawing.Size(707, 150);
         this.Load += new System.EventHandler(this.MeuComboBoxRound_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private MeuComboBox meuComboBox1;
   }
}
