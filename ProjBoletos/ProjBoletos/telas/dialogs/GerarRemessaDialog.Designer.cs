namespace ProjBoletos.telas.dialogs {
   partial class GerarRemessaDialog {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerarRemessaDialog));
         this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
         this.labelTitle = new System.Windows.Forms.Label();
         this.panelTopBar = new System.Windows.Forms.Panel();
         this.backButtonImg = new PictureBoxWithInterpolationMode();
         this.btnGerarTodos = new ProjBoletos.testes.MeuButton();
         this.panelTopBar.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).BeginInit();
         this.SuspendLayout();
         // 
         // flowLayoutPanel1
         // 
         this.flowLayoutPanel1.AutoScroll = true;
         this.flowLayoutPanel1.Location = new System.Drawing.Point(175, 194);
         this.flowLayoutPanel1.Name = "flowLayoutPanel1";
         this.flowLayoutPanel1.Size = new System.Drawing.Size(133, 50);
         this.flowLayoutPanel1.TabIndex = 1;
         // 
         // labelTitle
         // 
         this.labelTitle.Location = new System.Drawing.Point(106, 26);
         this.labelTitle.Name = "labelTitle";
         this.labelTitle.Size = new System.Drawing.Size(91, 38);
         this.labelTitle.TabIndex = 1;
         this.labelTitle.Text = "label1";
         this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
         // 
         // panelTopBar
         // 
         this.panelTopBar.Controls.Add(this.backButtonImg);
         this.panelTopBar.Controls.Add(this.labelTitle);
         this.panelTopBar.Location = new System.Drawing.Point(143, 12);
         this.panelTopBar.Name = "panelTopBar";
         this.panelTopBar.Size = new System.Drawing.Size(200, 100);
         this.panelTopBar.TabIndex = 2;
         this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
         // 
         // backButtonImg
         // 
         this.backButtonImg.Image = ((System.Drawing.Image)(resources.GetObject("backButtonImg.Image")));
         this.backButtonImg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
         this.backButtonImg.Location = new System.Drawing.Point(3, 26);
         this.backButtonImg.Name = "backButtonImg";
         this.backButtonImg.Size = new System.Drawing.Size(51, 43);
         this.backButtonImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.backButtonImg.TabIndex = 0;
         this.backButtonImg.TabStop = false;
         this.backButtonImg.Click += new System.EventHandler(this.backButtonImg_Click);
         // 
         // btnGerarTodos
         // 
         this.btnGerarTodos.Location = new System.Drawing.Point(158, 122);
         this.btnGerarTodos.Name = "btnGerarTodos";
         this.btnGerarTodos.Size = new System.Drawing.Size(150, 50);
         this.btnGerarTodos.TabIndex = 0;
         this.btnGerarTodos.Click += new System.EventHandler(this.btnGerarTodos_Click);
         // 
         // GerarRemessaDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(500, 600);
         this.Controls.Add(this.panelTopBar);
         this.Controls.Add(this.flowLayoutPanel1);
         this.Controls.Add(this.btnGerarTodos);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "GerarRemessaDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "GerarRemessaDialog";
         this.Load += new System.EventHandler(this.GerarRemessaDialog_Load);
         this.panelTopBar.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private testes.MeuButton btnGerarTodos;
      private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
      private PictureBoxWithInterpolationMode backButtonImg;
      private System.Windows.Forms.Label labelTitle;
      private System.Windows.Forms.Panel panelTopBar;
   }
}