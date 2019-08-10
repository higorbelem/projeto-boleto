namespace ProjBoletos.telas.dialogs {
   partial class AdicionarEditarMedidorVisualizador {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarEditarMedidorVisualizador));
         this.labelTitle = new System.Windows.Forms.Label();
         this.panelTopBar = new System.Windows.Forms.Panel();
         this.meuComboBoxTipo = new ProjBoletos.components.MeuComboBoxRound();
         this.btnOk = new ProjBoletos.testes.MeuButton();
         this.txtBoxSenha = new ProjBoletos.components.MeuTextbox();
         this.txtBoxCpf = new ProjBoletos.components.MeuTextbox();
         this.txtBoxNome = new ProjBoletos.components.MeuTextbox();
         this.backButtonImg = new PictureBoxWithInterpolationMode();
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
         // 
         // panelTopBar
         // 
         this.panelTopBar.Controls.Add(this.backButtonImg);
         this.panelTopBar.Controls.Add(this.labelTitle);
         this.panelTopBar.Location = new System.Drawing.Point(6, 5);
         this.panelTopBar.Name = "panelTopBar";
         this.panelTopBar.Size = new System.Drawing.Size(200, 60);
         this.panelTopBar.TabIndex = 9;
         // 
         // meuComboBoxTipo
         // 
         this.meuComboBoxTipo.Location = new System.Drawing.Point(18, 211);
         this.meuComboBoxTipo.Name = "meuComboBoxTipo";
         this.meuComboBoxTipo.Size = new System.Drawing.Size(476, 40);
         this.meuComboBoxTipo.TabIndex = 14;
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(89, 538);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(335, 45);
         this.btnOk.TabIndex = 13;
         // 
         // txtBoxSenha
         // 
         this.txtBoxSenha.BackColor = System.Drawing.Color.White;
         this.txtBoxSenha.Location = new System.Drawing.Point(18, 165);
         this.txtBoxSenha.Name = "txtBoxSenha";
         this.txtBoxSenha.Size = new System.Drawing.Size(476, 40);
         this.txtBoxSenha.TabIndex = 12;
         // 
         // txtBoxCpf
         // 
         this.txtBoxCpf.BackColor = System.Drawing.Color.White;
         this.txtBoxCpf.Location = new System.Drawing.Point(18, 119);
         this.txtBoxCpf.Name = "txtBoxCpf";
         this.txtBoxCpf.Size = new System.Drawing.Size(476, 40);
         this.txtBoxCpf.TabIndex = 11;
         // 
         // txtBoxNome
         // 
         this.txtBoxNome.BackColor = System.Drawing.Color.White;
         this.txtBoxNome.Location = new System.Drawing.Point(18, 73);
         this.txtBoxNome.Name = "txtBoxNome";
         this.txtBoxNome.Size = new System.Drawing.Size(476, 40);
         this.txtBoxNome.TabIndex = 10;
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
         // 
         // AdicionarEditarMedidorVisualizador
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(500, 588);
         this.Controls.Add(this.meuComboBoxTipo);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.txtBoxSenha);
         this.Controls.Add(this.txtBoxCpf);
         this.Controls.Add(this.txtBoxNome);
         this.Controls.Add(this.panelTopBar);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "AdicionarEditarMedidorVisualizador";
         this.Text = "AdicionarEditarMedidorVisualizador";
         this.panelTopBar.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private testes.MeuButton btnOk;
      private components.MeuTextbox txtBoxSenha;
      private components.MeuTextbox txtBoxCpf;
      private components.MeuTextbox txtBoxNome;
      private System.Windows.Forms.Label labelTitle;
      private System.Windows.Forms.Panel panelTopBar;
      private PictureBoxWithInterpolationMode backButtonImg;
      private components.MeuComboBoxRound meuComboBoxTipo;
   }
}