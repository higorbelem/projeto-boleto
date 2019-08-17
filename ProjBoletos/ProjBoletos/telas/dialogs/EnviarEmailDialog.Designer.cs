namespace ProjBoletos.telas.dialogs {
   partial class EnviarEmailDialog {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnviarEmailDialog));
         this.labelTitle = new System.Windows.Forms.Label();
         this.panelTopBar = new System.Windows.Forms.Panel();
         this.backButtonImg = new PictureBoxWithInterpolationMode();
         this.label1 = new System.Windows.Forms.Label();
         this.btnEnviar = new ProjBoletos.testes.MeuButton();
         this.txtBoxSenha = new ProjBoletos.components.MeuTextbox();
         this.txtBoxEmail = new ProjBoletos.components.MeuTextbox();
         this.labelErro = new System.Windows.Forms.Label();
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
         this.panelTopBar.TabIndex = 4;
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
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(41, 76);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(418, 45);
         this.label1.TabIndex = 8;
         this.label1.Text = "label1";
         // 
         // btnEnviar
         // 
         this.btnEnviar.Location = new System.Drawing.Point(57, 236);
         this.btnEnviar.Name = "btnEnviar";
         this.btnEnviar.Size = new System.Drawing.Size(386, 50);
         this.btnEnviar.TabIndex = 7;
         this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
         // 
         // txtBoxSenha
         // 
         this.txtBoxSenha.BackColor = System.Drawing.Color.White;
         this.txtBoxSenha.Location = new System.Drawing.Point(12, 180);
         this.txtBoxSenha.Name = "txtBoxSenha";
         this.txtBoxSenha.Size = new System.Drawing.Size(476, 41);
         this.txtBoxSenha.TabIndex = 6;
         // 
         // txtBoxEmail
         // 
         this.txtBoxEmail.BackColor = System.Drawing.Color.White;
         this.txtBoxEmail.Location = new System.Drawing.Point(12, 133);
         this.txtBoxEmail.Name = "txtBoxEmail";
         this.txtBoxEmail.Size = new System.Drawing.Size(476, 41);
         this.txtBoxEmail.TabIndex = 5;
         // 
         // labelErro
         // 
         this.labelErro.AutoSize = true;
         this.labelErro.BackColor = System.Drawing.Color.White;
         this.labelErro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelErro.ForeColor = System.Drawing.Color.Red;
         this.labelErro.Location = new System.Drawing.Point(183, 297);
         this.labelErro.Name = "labelErro";
         this.labelErro.Size = new System.Drawing.Size(135, 13);
         this.labelErro.TabIndex = 13;
         this.labelErro.Text = "Campo de senha vazio";
         this.labelErro.Visible = false;
         // 
         // EnviarEmailDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(500, 324);
         this.Controls.Add(this.labelErro);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnEnviar);
         this.Controls.Add(this.txtBoxSenha);
         this.Controls.Add(this.txtBoxEmail);
         this.Controls.Add(this.panelTopBar);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "EnviarEmailDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "EnviarEmailDialog";
         this.Load += new System.EventHandler(this.EnviarEmailDialog_Load);
         this.Resize += new System.EventHandler(this.EnviarEmailDialog_Resize);
         this.panelTopBar.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelTitle;
      private System.Windows.Forms.Panel panelTopBar;
      private PictureBoxWithInterpolationMode backButtonImg;
      private components.MeuTextbox txtBoxEmail;
      private components.MeuTextbox txtBoxSenha;
      private testes.MeuButton btnEnviar;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label labelErro;
   }
}