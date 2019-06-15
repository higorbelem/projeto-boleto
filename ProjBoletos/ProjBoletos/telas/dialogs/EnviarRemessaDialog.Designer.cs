namespace ProjBoletos.telas.dialogs {
   partial class EnviarRemessaDialog {
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnviarRemessaDialog));
         this.labelTitle = new System.Windows.Forms.Label();
         this.panelTopBar = new System.Windows.Forms.Panel();
         this.backButtonImg = new PictureBoxWithInterpolationMode();
         this.textBoxRemessa = new System.Windows.Forms.TextBox();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.btnAbrirArquivo = new ProjBoletos.testes.MeuButton();
         this.btnAbrirSite = new ProjBoletos.testes.MeuButton();
         this.btnJaEnviei = new ProjBoletos.testes.MeuButton();
         this.textBoxCaminho = new ProjBoletos.components.MeuTextbox();
         this.btnCopiar = new ProjBoletos.testes.MeuButton();
         this.panelTopBar.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).BeginInit();
         this.SuspendLayout();
         // 
         // labelTitle
         // 
         this.labelTitle.Location = new System.Drawing.Point(91, 8);
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
         this.panelTopBar.Location = new System.Drawing.Point(0, 0);
         this.panelTopBar.Name = "panelTopBar";
         this.panelTopBar.Size = new System.Drawing.Size(200, 60);
         this.panelTopBar.TabIndex = 3;
         this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
         // 
         // backButtonImg
         // 
         this.backButtonImg.Image = ((System.Drawing.Image)(resources.GetObject("backButtonImg.Image")));
         this.backButtonImg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
         this.backButtonImg.Location = new System.Drawing.Point(0, 3);
         this.backButtonImg.Name = "backButtonImg";
         this.backButtonImg.Size = new System.Drawing.Size(51, 43);
         this.backButtonImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.backButtonImg.TabIndex = 0;
         this.backButtonImg.TabStop = false;
         this.backButtonImg.Click += new System.EventHandler(this.backButtonImg_Click);
         // 
         // textBoxRemessa
         // 
         this.textBoxRemessa.Location = new System.Drawing.Point(12, 66);
         this.textBoxRemessa.Multiline = true;
         this.textBoxRemessa.Name = "textBoxRemessa";
         this.textBoxRemessa.ReadOnly = true;
         this.textBoxRemessa.Size = new System.Drawing.Size(476, 305);
         this.textBoxRemessa.TabIndex = 4;
         // 
         // btnAbrirArquivo
         // 
         this.btnAbrirArquivo.Location = new System.Drawing.Point(252, 486);
         this.btnAbrirArquivo.Name = "btnAbrirArquivo";
         this.btnAbrirArquivo.Size = new System.Drawing.Size(236, 48);
         this.btnAbrirArquivo.TabIndex = 10;
         this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
         // 
         // btnAbrirSite
         // 
         this.btnAbrirSite.Location = new System.Drawing.Point(12, 486);
         this.btnAbrirSite.Name = "btnAbrirSite";
         this.btnAbrirSite.Size = new System.Drawing.Size(234, 48);
         this.btnAbrirSite.TabIndex = 9;
         this.btnAbrirSite.Click += new System.EventHandler(this.btnAbrirSite_Click);
         // 
         // btnJaEnviei
         // 
         this.btnJaEnviei.Location = new System.Drawing.Point(12, 540);
         this.btnJaEnviei.Name = "btnJaEnviei";
         this.btnJaEnviei.Size = new System.Drawing.Size(476, 48);
         this.btnJaEnviei.TabIndex = 8;
         this.btnJaEnviei.Click += new System.EventHandler(this.btnJaEnviei_Click);
         // 
         // textBoxCaminho
         // 
         this.textBoxCaminho.BackColor = System.Drawing.Color.White;
         this.textBoxCaminho.Location = new System.Drawing.Point(12, 407);
         this.textBoxCaminho.Name = "textBoxCaminho";
         this.textBoxCaminho.Size = new System.Drawing.Size(393, 37);
         this.textBoxCaminho.TabIndex = 7;
         // 
         // btnCopiar
         // 
         this.btnCopiar.Location = new System.Drawing.Point(411, 407);
         this.btnCopiar.Name = "btnCopiar";
         this.btnCopiar.Size = new System.Drawing.Size(77, 37);
         this.btnCopiar.TabIndex = 6;
         this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
         // 
         // EnviarRemessaDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(500, 600);
         this.Controls.Add(this.btnAbrirArquivo);
         this.Controls.Add(this.btnAbrirSite);
         this.Controls.Add(this.btnJaEnviei);
         this.Controls.Add(this.textBoxCaminho);
         this.Controls.Add(this.btnCopiar);
         this.Controls.Add(this.textBoxRemessa);
         this.Controls.Add(this.panelTopBar);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "EnviarRemessaDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "EnviarRemessaDialog";
         this.Load += new System.EventHandler(this.EnviarRemessaDialog_Load);
         this.panelTopBar.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelTitle;
      private System.Windows.Forms.Panel panelTopBar;
      private PictureBoxWithInterpolationMode backButtonImg;
      private System.Windows.Forms.TextBox textBoxRemessa;
      private testes.MeuButton btnCopiar;
      private components.MeuTextbox textBoxCaminho;
      private System.Windows.Forms.ToolTip toolTip1;
      private testes.MeuButton btnJaEnviei;
      private testes.MeuButton btnAbrirSite;
      private testes.MeuButton btnAbrirArquivo;
   }
}