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
         this.radioButtonMedidor = new System.Windows.Forms.RadioButton();
         this.radioButtonVisualizador = new System.Windows.Forms.RadioButton();
         this.txtBoxSenhaConfirma = new ProjBoletos.components.MeuTextbox();
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
         this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
         // 
         // panelTopBar
         // 
         this.panelTopBar.Controls.Add(this.backButtonImg);
         this.panelTopBar.Controls.Add(this.labelTitle);
         this.panelTopBar.Location = new System.Drawing.Point(6, 5);
         this.panelTopBar.Name = "panelTopBar";
         this.panelTopBar.Size = new System.Drawing.Size(200, 60);
         this.panelTopBar.TabIndex = 0;
         this.panelTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTopBar_Paint);
         this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
         // 
         // radioButtonMedidor
         // 
         this.radioButtonMedidor.AutoSize = true;
         this.radioButtonMedidor.Location = new System.Drawing.Point(182, 295);
         this.radioButtonMedidor.Name = "radioButtonMedidor";
         this.radioButtonMedidor.Size = new System.Drawing.Size(63, 17);
         this.radioButtonMedidor.TabIndex = 5;
         this.radioButtonMedidor.TabStop = true;
         this.radioButtonMedidor.Text = "Medidor";
         this.radioButtonMedidor.UseVisualStyleBackColor = true;
         // 
         // radioButtonVisualizador
         // 
         this.radioButtonVisualizador.AutoSize = true;
         this.radioButtonVisualizador.Location = new System.Drawing.Point(251, 295);
         this.radioButtonVisualizador.Name = "radioButtonVisualizador";
         this.radioButtonVisualizador.Size = new System.Drawing.Size(81, 17);
         this.radioButtonVisualizador.TabIndex = 6;
         this.radioButtonVisualizador.TabStop = true;
         this.radioButtonVisualizador.Text = "Visualizador";
         this.radioButtonVisualizador.UseVisualStyleBackColor = true;
         // 
         // txtBoxSenhaConfirma
         // 
         this.txtBoxSenhaConfirma.BackColor = System.Drawing.Color.White;
         this.txtBoxSenhaConfirma.Location = new System.Drawing.Point(12, 211);
         this.txtBoxSenhaConfirma.Name = "txtBoxSenhaConfirma";
         this.txtBoxSenhaConfirma.Size = new System.Drawing.Size(476, 40);
         this.txtBoxSenhaConfirma.TabIndex = 4;
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(83, 336);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(335, 45);
         this.btnOk.TabIndex = 7;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // txtBoxSenha
         // 
         this.txtBoxSenha.BackColor = System.Drawing.Color.White;
         this.txtBoxSenha.Location = new System.Drawing.Point(12, 165);
         this.txtBoxSenha.Name = "txtBoxSenha";
         this.txtBoxSenha.Size = new System.Drawing.Size(476, 40);
         this.txtBoxSenha.TabIndex = 3;
         // 
         // txtBoxCpf
         // 
         this.txtBoxCpf.BackColor = System.Drawing.Color.White;
         this.txtBoxCpf.Location = new System.Drawing.Point(12, 119);
         this.txtBoxCpf.Name = "txtBoxCpf";
         this.txtBoxCpf.Size = new System.Drawing.Size(476, 40);
         this.txtBoxCpf.TabIndex = 2;
         // 
         // txtBoxNome
         // 
         this.txtBoxNome.BackColor = System.Drawing.Color.White;
         this.txtBoxNome.Location = new System.Drawing.Point(12, 73);
         this.txtBoxNome.Name = "txtBoxNome";
         this.txtBoxNome.Size = new System.Drawing.Size(476, 40);
         this.txtBoxNome.TabIndex = 1;
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
         // AdicionarEditarMedidorVisualizador
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(500, 413);
         this.Controls.Add(this.txtBoxSenhaConfirma);
         this.Controls.Add(this.radioButtonVisualizador);
         this.Controls.Add(this.radioButtonMedidor);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.txtBoxSenha);
         this.Controls.Add(this.txtBoxCpf);
         this.Controls.Add(this.txtBoxNome);
         this.Controls.Add(this.panelTopBar);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "AdicionarEditarMedidorVisualizador";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "AdicionarEditarMedidorVisualizador";
         this.Load += new System.EventHandler(this.AdicionarEditarMedidorVisualizador_Load);
         this.panelTopBar.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private testes.MeuButton btnOk;
      private components.MeuTextbox txtBoxSenha;
      private components.MeuTextbox txtBoxCpf;
      private components.MeuTextbox txtBoxNome;
      private System.Windows.Forms.Label labelTitle;
      private System.Windows.Forms.Panel panelTopBar;
      private PictureBoxWithInterpolationMode backButtonImg;
      private System.Windows.Forms.RadioButton radioButtonMedidor;
      private System.Windows.Forms.RadioButton radioButtonVisualizador;
      private components.MeuTextbox txtBoxSenhaConfirma;
   }
}