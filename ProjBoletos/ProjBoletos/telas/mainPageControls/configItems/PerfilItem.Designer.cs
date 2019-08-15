namespace ProjBoletos.telas.mainPageControls.configItems {
   partial class PerfilItem {
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
         this.panel = new System.Windows.Forms.Panel();
         this.txtBoxNome = new ProjBoletos.components.MeuTextbox();
         this.btnSalvar = new ProjBoletos.testes.MeuButton();
         this.panel.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel
         // 
         this.panel.Controls.Add(this.txtBoxNome);
         this.panel.Controls.Add(this.btnSalvar);
         this.panel.Location = new System.Drawing.Point(16, 12);
         this.panel.Name = "panel";
         this.panel.Size = new System.Drawing.Size(574, 118);
         this.panel.TabIndex = 2;
         this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
         // 
         // txtBoxNome
         // 
         this.txtBoxNome.BackColor = System.Drawing.Color.White;
         this.txtBoxNome.Location = new System.Drawing.Point(23, 15);
         this.txtBoxNome.Name = "txtBoxNome";
         this.txtBoxNome.Size = new System.Drawing.Size(535, 48);
         this.txtBoxNome.TabIndex = 0;
         // 
         // btnSalvar
         // 
         this.btnSalvar.Location = new System.Drawing.Point(132, 69);
         this.btnSalvar.Name = "btnSalvar";
         this.btnSalvar.Size = new System.Drawing.Size(150, 42);
         this.btnSalvar.TabIndex = 1;
         // 
         // PerfilItem
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.panel);
         this.Name = "PerfilItem";
         this.Size = new System.Drawing.Size(631, 142);
         this.Load += new System.EventHandler(this.PerfilItem_Load);
         this.Resize += new System.EventHandler(this.PerfilItem_Resize);
         this.panel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private components.MeuTextbox txtBoxNome;
      private testes.MeuButton btnSalvar;
      private System.Windows.Forms.Panel panel;
   }
}
