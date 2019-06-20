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
         this.flowCasas = new System.Windows.Forms.FlowLayoutPanel();
         this.labelCasas = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnAddCasa = new ProjBoletos.testes.MeuButton();
         this.btnOk = new ProjBoletos.testes.MeuButton();
         this.txtBoxDocumento = new ProjBoletos.components.MeuTextbox();
         this.txtBoxEmail = new ProjBoletos.components.MeuTextbox();
         this.txtBoxNome = new ProjBoletos.components.MeuTextbox();
         this.backButtonImg = new PictureBoxWithInterpolationMode();
         this.panelTopBar.SuspendLayout();
         this.flowCasas.SuspendLayout();
         this.panel1.SuspendLayout();
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
         // btnAddCasa
         // 
         this.btnAddCasa.Location = new System.Drawing.Point(3, 3);
         this.btnAddCasa.Name = "btnAddCasa";
         this.btnAddCasa.Size = new System.Drawing.Size(150, 43);
         this.btnAddCasa.TabIndex = 0;
         this.btnAddCasa.Click += new System.EventHandler(this.btnAddCasa_Click);
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(83, 533);
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
         // AdicionarEditarClienteDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(500, 588);
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
         this.flowCasas.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).EndInit();
         this.ResumeLayout(false);

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
   }
}