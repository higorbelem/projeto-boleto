namespace ProjBoletos.telas.dialogs {
   partial class AdicionarEditarClienteDialog {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarEditarClienteDialog));
         this.labelTitle = new System.Windows.Forms.Label();
         this.panelTopBar = new System.Windows.Forms.Panel();
         this.backButtonImg = new PictureBoxWithInterpolationMode();
         this.flowCasas = new System.Windows.Forms.FlowLayoutPanel();
         this.btnAddCasa = new ProjBoletos.testes.MeuButton();
         this.labelCasas = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnOk = new ProjBoletos.testes.MeuButton();
         this.txtBoxDocumento = new ProjBoletos.components.MeuTextbox();
         this.txtBoxEmail = new ProjBoletos.components.MeuTextbox();
         this.txtBoxNome = new ProjBoletos.components.MeuTextbox();
         this.labelErroExcluirCasa = new System.Windows.Forms.Label();
         this.labelCampoVazioNenhumaCasa = new System.Windows.Forms.Label();
         this.labelCampoVazio = new System.Windows.Forms.Label();
         this.labelSemCasa = new System.Windows.Forms.Label();
         this.labelErroPost = new System.Windows.Forms.Label();
         this.panelTopBar.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).BeginInit();
         this.flowCasas.SuspendLayout();
         this.panel1.SuspendLayout();
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
         // flowCasas
         // 
         this.flowCasas.AutoScroll = true;
         this.flowCasas.Controls.Add(this.btnAddCasa);
         this.flowCasas.Location = new System.Drawing.Point(0, 0);
         this.flowCasas.Margin = new System.Windows.Forms.Padding(0);
         this.flowCasas.Name = "flowCasas";
         this.flowCasas.Size = new System.Drawing.Size(444, 274);
         this.flowCasas.TabIndex = 9;
         // 
         // btnAddCasa
         // 
         this.btnAddCasa.Location = new System.Drawing.Point(3, 3);
         this.btnAddCasa.Name = "btnAddCasa";
         this.btnAddCasa.Size = new System.Drawing.Size(150, 43);
         this.btnAddCasa.TabIndex = 0;
         this.btnAddCasa.Click += new System.EventHandler(this.btnAddCasa_Click);
         // 
         // labelCasas
         // 
         this.labelCasas.Location = new System.Drawing.Point(27, 203);
         this.labelCasas.Name = "labelCasas";
         this.labelCasas.Size = new System.Drawing.Size(447, 47);
         this.labelCasas.TabIndex = 1;
         this.labelCasas.Text = "CASAS";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.flowCasas);
         this.panel1.Location = new System.Drawing.Point(30, 253);
         this.panel1.Margin = new System.Windows.Forms.Padding(0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(444, 274);
         this.panel1.TabIndex = 10;
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(83, 535);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(335, 45);
         this.btnOk.TabIndex = 8;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // txtBoxDocumento
         // 
         this.txtBoxDocumento.BackColor = System.Drawing.Color.White;
         this.txtBoxDocumento.Location = new System.Drawing.Point(12, 160);
         this.txtBoxDocumento.Name = "txtBoxDocumento";
         this.txtBoxDocumento.Size = new System.Drawing.Size(476, 40);
         this.txtBoxDocumento.TabIndex = 7;
         // 
         // txtBoxEmail
         // 
         this.txtBoxEmail.BackColor = System.Drawing.Color.White;
         this.txtBoxEmail.Location = new System.Drawing.Point(12, 114);
         this.txtBoxEmail.Name = "txtBoxEmail";
         this.txtBoxEmail.Size = new System.Drawing.Size(476, 40);
         this.txtBoxEmail.TabIndex = 6;
         // 
         // txtBoxNome
         // 
         this.txtBoxNome.BackColor = System.Drawing.Color.White;
         this.txtBoxNome.Location = new System.Drawing.Point(12, 68);
         this.txtBoxNome.Name = "txtBoxNome";
         this.txtBoxNome.Size = new System.Drawing.Size(476, 40);
         this.txtBoxNome.TabIndex = 5;
         // 
         // labelErroExcluirCasa
         // 
         this.labelErroExcluirCasa.AutoSize = true;
         this.labelErroExcluirCasa.BackColor = System.Drawing.Color.White;
         this.labelErroExcluirCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelErroExcluirCasa.ForeColor = System.Drawing.Color.Red;
         this.labelErroExcluirCasa.Location = new System.Drawing.Point(134, 590);
         this.labelErroExcluirCasa.Name = "labelErroExcluirCasa";
         this.labelErroExcluirCasa.Size = new System.Drawing.Size(232, 13);
         this.labelErroExcluirCasa.TabIndex = 14;
         this.labelErroExcluirCasa.Text = "Algum erro aconteceu ao excluir a casa";
         this.labelErroExcluirCasa.Visible = false;
         // 
         // labelCampoVazioNenhumaCasa
         // 
         this.labelCampoVazioNenhumaCasa.AutoSize = true;
         this.labelCampoVazioNenhumaCasa.BackColor = System.Drawing.Color.White;
         this.labelCampoVazioNenhumaCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelCampoVazioNenhumaCasa.ForeColor = System.Drawing.Color.Red;
         this.labelCampoVazioNenhumaCasa.Location = new System.Drawing.Point(123, 590);
         this.labelCampoVazioNenhumaCasa.Name = "labelCampoVazioNenhumaCasa";
         this.labelCampoVazioNenhumaCasa.Size = new System.Drawing.Size(254, 13);
         this.labelCampoVazioNenhumaCasa.TabIndex = 15;
         this.labelCampoVazioNenhumaCasa.Text = "Campos vazios e nenhuma casa adicionada";
         this.labelCampoVazioNenhumaCasa.Visible = false;
         // 
         // labelCampoVazio
         // 
         this.labelCampoVazio.AutoSize = true;
         this.labelCampoVazio.BackColor = System.Drawing.Color.White;
         this.labelCampoVazio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelCampoVazio.ForeColor = System.Drawing.Color.Red;
         this.labelCampoVazio.Location = new System.Drawing.Point(178, 590);
         this.labelCampoVazio.Name = "labelCampoVazio";
         this.labelCampoVazio.Size = new System.Drawing.Size(144, 13);
         this.labelCampoVazio.TabIndex = 16;
         this.labelCampoVazio.Text = "Algum campo esta vazio";
         this.labelCampoVazio.Visible = false;
         // 
         // labelSemCasa
         // 
         this.labelSemCasa.AutoSize = true;
         this.labelSemCasa.BackColor = System.Drawing.Color.White;
         this.labelSemCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelSemCasa.ForeColor = System.Drawing.Color.Red;
         this.labelSemCasa.Location = new System.Drawing.Point(162, 590);
         this.labelSemCasa.Name = "labelSemCasa";
         this.labelSemCasa.Size = new System.Drawing.Size(176, 13);
         this.labelSemCasa.TabIndex = 17;
         this.labelSemCasa.Text = "Adicione no mínimo uma casa";
         this.labelSemCasa.Visible = false;
         // 
         // labelErroPost
         // 
         this.labelErroPost.AutoSize = true;
         this.labelErroPost.BackColor = System.Drawing.Color.White;
         this.labelErroPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelErroPost.ForeColor = System.Drawing.Color.Red;
         this.labelErroPost.Location = new System.Drawing.Point(145, 590);
         this.labelErroPost.Name = "labelErroPost";
         this.labelErroPost.Size = new System.Drawing.Size(210, 13);
         this.labelErroPost.TabIndex = 18;
         this.labelErroPost.Text = "Houve algum erro, tente novamente";
         this.labelErroPost.Visible = false;
         // 
         // AdicionarEditarClienteDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(500, 610);
         this.Controls.Add(this.labelErroPost);
         this.Controls.Add(this.labelSemCasa);
         this.Controls.Add(this.labelCampoVazio);
         this.Controls.Add(this.labelCampoVazioNenhumaCasa);
         this.Controls.Add(this.labelErroExcluirCasa);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.labelCasas);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.txtBoxDocumento);
         this.Controls.Add(this.txtBoxEmail);
         this.Controls.Add(this.txtBoxNome);
         this.Controls.Add(this.panelTopBar);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "AdicionarEditarClienteDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "AdicionarClienteDialog";
         this.Load += new System.EventHandler(this.AdicionarClienteDialog_Load);
         this.panelTopBar.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).EndInit();
         this.flowCasas.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelTitle;
      private System.Windows.Forms.Panel panelTopBar;
      private PictureBoxWithInterpolationMode backButtonImg;
      private components.MeuTextbox txtBoxNome;
      private components.MeuTextbox txtBoxEmail;
      private components.MeuTextbox txtBoxDocumento;
      private testes.MeuButton btnOk;
      private System.Windows.Forms.FlowLayoutPanel flowCasas;
      private System.Windows.Forms.Label labelCasas;
      private System.Windows.Forms.Panel panel1;
      private testes.MeuButton btnAddCasa;
      private System.Windows.Forms.Label labelErroExcluirCasa;
      private System.Windows.Forms.Label labelCampoVazioNenhumaCasa;
      private System.Windows.Forms.Label labelCampoVazio;
      private System.Windows.Forms.Label labelSemCasa;
      private System.Windows.Forms.Label labelErroPost;
   }
}