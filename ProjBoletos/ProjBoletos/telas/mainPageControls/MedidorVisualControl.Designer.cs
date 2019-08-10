namespace ProjBoletos.telas.mainPageControls {
   partial class MedidorVisualControl {
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
         this.panelTop = new System.Windows.Forms.Panel();
         this.btnSearch = new ProjBoletos.testes.MeuButton();
         this.txtBoxSearch = new ProjBoletos.components.MeuTextbox();
         this.customListView = new ProjBoletos.components.CustomListView();
         this.btnAdicionar = new ProjBoletos.testes.MeuButton();
         this.panelTop.SuspendLayout();
         this.SuspendLayout();
         // 
         // panelTop
         // 
         this.panelTop.Controls.Add(this.btnSearch);
         this.panelTop.Controls.Add(this.txtBoxSearch);
         this.panelTop.Location = new System.Drawing.Point(35, 21);
         this.panelTop.Name = "panelTop";
         this.panelTop.Size = new System.Drawing.Size(320, 48);
         this.panelTop.TabIndex = 1;
         // 
         // btnSearch
         // 
         this.btnSearch.Location = new System.Drawing.Point(185, 3);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(110, 40);
         this.btnSearch.TabIndex = 1;
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // txtBoxSearch
         // 
         this.txtBoxSearch.BackColor = System.Drawing.Color.White;
         this.txtBoxSearch.Location = new System.Drawing.Point(0, 3);
         this.txtBoxSearch.Name = "txtBoxSearch";
         this.txtBoxSearch.Size = new System.Drawing.Size(165, 43);
         this.txtBoxSearch.TabIndex = 0;
         // 
         // btnGerarRemessa
         // 
         this.btnAdicionar.Location = new System.Drawing.Point(437, 376);
         this.btnAdicionar.Name = "btnGerarRemessa";
         this.btnAdicionar.Size = new System.Drawing.Size(150, 150);
         this.btnAdicionar.TabIndex = 4;
         this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
         // 
         // customListView1
         // 
         this.customListView.AutoSize = true;
         this.customListView.Location = new System.Drawing.Point(30, 89);
         this.customListView.Name = "customListView1";
         this.customListView.Size = new System.Drawing.Size(380, 201);
         this.customListView.TabIndex = 1;
         // 
         // MedidorVisualControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.panelTop);
         this.Controls.Add(this.customListView);
         this.Controls.Add(this.btnAdicionar);
         this.Name = "MedidorVisualControl";
         this.Size = new System.Drawing.Size(388, 263);
         this.panelTop.ResumeLayout(false);
         this.ResumeLayout(false);
         this.Load += new System.EventHandler(this.MedidorVisualControl_Load);
         this.Resize += new System.EventHandler(this.MedidorVisualControl_Resize);

      }

      #endregion

      private System.Windows.Forms.Panel panelTop;
      private testes.MeuButton btnSearch;
      private components.MeuTextbox txtBoxSearch;
      private components.CustomListView customListView;
      private testes.MeuButton btnAdicionar;
   }
}
