﻿namespace ProjBoletos.components {
   partial class MeuComboBox {
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
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // comboBox1
         // 
         this.comboBox1.BackColor = System.Drawing.SystemColors.Desktop;
         this.comboBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
         this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.IntegralHeight = false;
         this.comboBox1.Location = new System.Drawing.Point(90, 95);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(267, 21);
         this.comboBox1.TabIndex = 0;
         // 
         // MeuComboBox
         // 
         this.Controls.Add(this.comboBox1);
         this.Name = "MeuComboBox";
         this.Size = new System.Drawing.Size(469, 242);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ComboBox comboBox1;
   }
}
