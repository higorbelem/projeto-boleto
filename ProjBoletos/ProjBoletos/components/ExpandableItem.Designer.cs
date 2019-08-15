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
         this.headerPanel = new System.Windows.Forms.Panel();
         this.arrowPanel1 = new System.Windows.Forms.Panel();
         this.arrowImg1 = new PictureBoxWithInterpolationMode();
         this.bodyPanel1 = new System.Windows.Forms.Panel();
         this.headerFlow.SuspendLayout();
         this.headerPanel.SuspendLayout();
         this.arrowPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.arrowImg1)).BeginInit();
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
         // headerPanel
         // 
         this.headerPanel.Controls.Add(this.arrowPanel1);
         this.headerPanel.Controls.Add(this.headerFlow);
         this.headerPanel.Location = new System.Drawing.Point(3, 18);
         this.headerPanel.Name = "headerPanel";
         this.headerPanel.Size = new System.Drawing.Size(395, 132);
         this.headerPanel.TabIndex = 3;
         // 
         // arrowPanel1
         // 
         this.arrowPanel1.Controls.Add(this.arrowImg1);
         this.arrowPanel1.Location = new System.Drawing.Point(285, 13);
         this.arrowPanel1.Name = "arrowPanel1";
         this.arrowPanel1.Size = new System.Drawing.Size(200, 100);
         this.arrowPanel1.TabIndex = 5;
         this.arrowPanel1.Click += new System.EventHandler(this.arrowImg_Click);
         // 
         // arrowImg1
         // 
         this.arrowImg1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.arrowImg1.Image = global::ProjBoletos.Properties.Resources.arrow_down_high_res;
         this.arrowImg1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
         this.arrowImg1.Location = new System.Drawing.Point(10, 16);
         this.arrowImg1.Name = "arrowImg1";
         this.arrowImg1.Size = new System.Drawing.Size(100, 50);
         this.arrowImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.arrowImg1.TabIndex = 3;
         this.arrowImg1.TabStop = false;
         this.arrowImg1.Click += new System.EventHandler(this.arrowImg_Click);
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
         this.headerPanel.ResumeLayout(false);
         this.arrowPanel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.arrowImg1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private PictureBoxWithInterpolationMode arrowImg1;
      private System.Windows.Forms.Label labelDescription1;
      private System.Windows.Forms.Label labelTitle1;
      private System.Windows.Forms.FlowLayoutPanel headerFlow;
      private System.Windows.Forms.Panel headerPanel;
      private System.Windows.Forms.Panel bodyPanel1;
      private System.Windows.Forms.Panel arrowPanel1;
   }
}
