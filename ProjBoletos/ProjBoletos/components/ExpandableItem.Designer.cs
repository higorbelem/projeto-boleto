namespace ProjBoletos.components {
   partial class ExpandableItem {
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
         this.labelTitle1 = new System.Windows.Forms.Label();
         this.labelDescription1 = new System.Windows.Forms.Label();
         this.headerFlow = new System.Windows.Forms.FlowLayoutPanel();
         this.arrowImg = new PictureBoxWithInterpolationMode();
         this.headerPanel = new System.Windows.Forms.Panel();
         this.bodyPanel1 = new System.Windows.Forms.Panel();
         this.headerFlow.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.arrowImg)).BeginInit();
         this.headerPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // labelTitle1
         // 
         this.labelTitle1.AutoSize = true;
         this.labelTitle1.Location = new System.Drawing.Point(3, 0);
         this.labelTitle1.Name = "labelTitle1";
         this.labelTitle1.Size = new System.Drawing.Size(35, 13);
         this.labelTitle1.TabIndex = 1;
         this.labelTitle1.Text = "label1";
         this.labelTitle1.Click += new System.EventHandler(this.arrowImg_Click);
         // 
         // labelDescription1
         // 
         this.labelDescription1.AutoSize = true;
         this.labelDescription1.Location = new System.Drawing.Point(44, 0);
         this.labelDescription1.Name = "labelDescription1";
         this.labelDescription1.Size = new System.Drawing.Size(35, 13);
         this.labelDescription1.TabIndex = 2;
         this.labelDescription1.Text = "label1";
         this.labelDescription1.Click += new System.EventHandler(this.arrowImg_Click);
         // 
         // headerFlow
         // 
         this.headerFlow.Controls.Add(this.labelTitle1);
         this.headerFlow.Controls.Add(this.labelDescription1);
         this.headerFlow.Location = new System.Drawing.Point(15, 13);
         this.headerFlow.Name = "headerFlow";
         this.headerFlow.Size = new System.Drawing.Size(252, 100);
         this.headerFlow.TabIndex = 4;
         this.headerFlow.Click += new System.EventHandler(this.arrowImg_Click);
         // 
         // arrowImg
         // 
         this.arrowImg.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.arrowImg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
         this.arrowImg.Location = new System.Drawing.Point(273, 47);
         this.arrowImg.Name = "arrowImg";
         this.arrowImg.Size = new System.Drawing.Size(100, 50);
         this.arrowImg.TabIndex = 3;
         this.arrowImg.TabStop = false;
         this.arrowImg.Click += new System.EventHandler(this.arrowImg_Click);
         // 
         // headerPanel
         // 
         this.headerPanel.Controls.Add(this.arrowImg);
         this.headerPanel.Controls.Add(this.headerFlow);
         this.headerPanel.Location = new System.Drawing.Point(3, 18);
         this.headerPanel.Name = "headerPanel";
         this.headerPanel.Size = new System.Drawing.Size(395, 132);
         this.headerPanel.TabIndex = 3;
         // 
         // bodyPanel1
         // 
         this.bodyPanel1.AutoSize = true;
         this.bodyPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.bodyPanel1.Location = new System.Drawing.Point(82, 150);
         this.bodyPanel1.Name = "bodyPanel1";
         this.bodyPanel1.Size = new System.Drawing.Size(0, 0);
         this.bodyPanel1.TabIndex = 3;
         // 
         // ExpandableItem
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.Controls.Add(this.headerPanel);
         this.Controls.Add(this.bodyPanel1);
         this.Name = "ExpandableItem";
         this.Size = new System.Drawing.Size(419, 271);
         this.Load += new System.EventHandler(this.ExpandableItem_Load);
         this.Resize += new System.EventHandler(this.ExpandableItem_Resize);
         this.headerFlow.ResumeLayout(false);
         this.headerFlow.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.arrowImg)).EndInit();
         this.headerPanel.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private PictureBoxWithInterpolationMode arrowImg;
      private System.Windows.Forms.Label labelDescription1;
      private System.Windows.Forms.Label labelTitle1;
      private System.Windows.Forms.FlowLayoutPanel headerFlow;
      private System.Windows.Forms.Panel headerPanel;
      private System.Windows.Forms.Panel bodyPanel1;
   }
}
