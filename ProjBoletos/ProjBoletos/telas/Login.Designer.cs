using ProjBoletos.utils;

namespace ProjBoletos.telas {
    partial class Login {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
         this.box1 = new ProjBoletos.components.Box();
         this.buttonTeste1 = new ProjBoletos.testes.MeuButton();
         this.meuTextboxCnpj = new ProjBoletos.components.MeuTextbox();
         this.meuTextboxSenha = new ProjBoletos.components.MeuTextbox();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.labelErroConexao = new System.Windows.Forms.Label();
         this.labelErroLogin = new System.Windows.Forms.Label();
         this.labelErroVazio = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // box1
         // 
         this.box1.BackColor = System.Drawing.Color.Transparent;
         this.box1.Location = new System.Drawing.Point(313, 31);
         this.box1.Name = "box1";
         this.box1.Size = new System.Drawing.Size(299, 441);
         this.box1.TabIndex = 7;
         this.box1.TabStop = false;
         this.box1.Load += new System.EventHandler(this.box1_Load);
         // 
         // buttonTeste1
         // 
         this.buttonTeste1.BackColor = System.Drawing.Color.White;
         this.buttonTeste1.Location = new System.Drawing.Point(401, 354);
         this.buttonTeste1.Name = "buttonTeste1";
         this.buttonTeste1.Size = new System.Drawing.Size(122, 33);
         this.buttonTeste1.TabIndex = 2;
         this.buttonTeste1.Load += new System.EventHandler(this.buttonTeste1_Load);
         this.buttonTeste1.Click += new System.EventHandler(this.buttonTeste1_click);
         // 
         // meuTextboxCnpj
         // 
         this.meuTextboxCnpj.BackColor = System.Drawing.Color.White;
         this.meuTextboxCnpj.Location = new System.Drawing.Point(377, 264);
         this.meuTextboxCnpj.Name = "meuTextboxCnpj";
         this.meuTextboxCnpj.Size = new System.Drawing.Size(171, 39);
         this.meuTextboxCnpj.TabIndex = 0;
         // 
         // meuTextboxSenha
         // 
         this.meuTextboxSenha.BackColor = System.Drawing.Color.White;
         this.meuTextboxSenha.Location = new System.Drawing.Point(377, 309);
         this.meuTextboxSenha.Name = "meuTextboxSenha";
         this.meuTextboxSenha.Size = new System.Drawing.Size(171, 39);
         this.meuTextboxSenha.TabIndex = 1;
         // 
         // pictureBox1
         // 
         this.pictureBox1.BackColor = System.Drawing.Color.White;
         this.pictureBox1.BackgroundImage = global::ProjBoletos.Properties.Resources.logo2;
         this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.pictureBox1.Location = new System.Drawing.Point(355, 94);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(215, 155);
         this.pictureBox1.TabIndex = 8;
         this.pictureBox1.TabStop = false;
         // 
         // labelErroConexao
         // 
         this.labelErroConexao.AutoSize = true;
         this.labelErroConexao.BackColor = System.Drawing.Color.White;
         this.labelErroConexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelErroConexao.ForeColor = System.Drawing.Color.Red;
         this.labelErroConexao.Location = new System.Drawing.Point(353, 404);
         this.labelErroConexao.Name = "labelErroConexao";
         this.labelErroConexao.Size = new System.Drawing.Size(218, 13);
         this.labelErroConexao.TabIndex = 9;
         this.labelErroConexao.Text = "Verifique sua conexão com a internet";
         this.labelErroConexao.Visible = false;
         // 
         // labelErroLogin
         // 
         this.labelErroLogin.AutoSize = true;
         this.labelErroLogin.BackColor = System.Drawing.Color.White;
         this.labelErroLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelErroLogin.ForeColor = System.Drawing.Color.Red;
         this.labelErroLogin.Location = new System.Drawing.Point(391, 404);
         this.labelErroLogin.Name = "labelErroLogin";
         this.labelErroLogin.Size = new System.Drawing.Size(142, 13);
         this.labelErroLogin.TabIndex = 10;
         this.labelErroLogin.Text = "Cnpj ou senha incorreta";
         this.labelErroLogin.Visible = false;
         // 
         // labelErroVazio
         // 
         this.labelErroVazio.AutoSize = true;
         this.labelErroVazio.BackColor = System.Drawing.Color.White;
         this.labelErroVazio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
         this.labelErroVazio.ForeColor = System.Drawing.Color.Red;
         this.labelErroVazio.Location = new System.Drawing.Point(368, 404);
         this.labelErroVazio.Name = "labelErroVazio";
         this.labelErroVazio.Size = new System.Drawing.Size(189, 13);
         this.labelErroVazio.TabIndex = 11;
         this.labelErroVazio.Text = "Nenhum campo pode ficar vazio";
         this.labelErroVazio.Visible = false;
         // 
         // Login
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.ClientSize = new System.Drawing.Size(927, 529);
         this.Controls.Add(this.labelErroVazio);
         this.Controls.Add(this.labelErroLogin);
         this.Controls.Add(this.labelErroConexao);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.meuTextboxSenha);
         this.Controls.Add(this.meuTextboxCnpj);
         this.Controls.Add(this.buttonTeste1);
         this.Controls.Add(this.box1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.KeyPreview = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Login";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Login";
         this.Load += new System.EventHandler(this.Login_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private components.Box box1;
        private testes.MeuButton buttonTeste1;
        private components.MeuTextbox meuTextboxCnpj;
        private components.MeuTextbox meuTextboxSenha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelErroConexao;
        private System.Windows.Forms.Label labelErroLogin;
        private System.Windows.Forms.Label labelErroVazio;
    }
}