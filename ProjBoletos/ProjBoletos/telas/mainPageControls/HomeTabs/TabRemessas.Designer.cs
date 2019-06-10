namespace ProjBoletos.telas.mainPageControls.HomeTabs {
   partial class TabRemessas {
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.flowRemessas = new System.Windows.Forms.FlowLayoutPanel();
         this.mainCard1 = new ProjBoletos.components.MainCard();
         this.mainCard2 = new ProjBoletos.components.MainCard();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.AutoSize = true;
         this.panel1.Controls.Add(this.flowRemessas);
         this.panel1.Controls.Add(this.mainCard1);
         this.panel1.Controls.Add(this.mainCard2);
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(856, 424);
         this.panel1.TabIndex = 2;
         // 
         // flowRemessas
         // 
         this.flowRemessas.AutoSize = true;
         this.flowRemessas.Location = new System.Drawing.Point(298, 264);
         this.flowRemessas.Name = "flowRemessas";
         this.flowRemessas.Size = new System.Drawing.Size(200, 100);
         this.flowRemessas.TabIndex = 2;
         // 
         // mainCard1
         // 
         this.mainCard1.Location = new System.Drawing.Point(125, 0);
         this.mainCard1.Name = "mainCard1";
         this.mainCard1.Size = new System.Drawing.Size(239, 177);
         this.mainCard1.TabIndex = 0;
         // 
         // mainCard2
         // 
         this.mainCard2.Location = new System.Drawing.Point(416, 23);
         this.mainCard2.Name = "mainCard2";
         this.mainCard2.Size = new System.Drawing.Size(239, 177);
         this.mainCard2.TabIndex = 1;
         // 
         // TabRemessas
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoScroll = true;
         this.Controls.Add(this.panel1);
         this.Name = "TabRemessas";
         this.Size = new System.Drawing.Size(877, 482);
         this.Load += new System.EventHandler(this.TabRemessas_Load);
         this.Resize += new System.EventHandler(this.TabRemessas_Resize);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private components.MainCard mainCard1;
      private components.MainCard mainCard2;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.FlowLayoutPanel flowRemessas;
   }
}
