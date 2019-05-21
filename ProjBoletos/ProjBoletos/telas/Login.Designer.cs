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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.meuTextboxSenha = new ProjBoletos.components.MeuTextbox();
            this.meuTextboxCnpj = new ProjBoletos.components.MeuTextbox();
            this.buttonTeste1 = new ProjBoletos.testes.MeuButton();
            this.box1 = new ProjBoletos.components.Box();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::ProjBoletos.Properties.Resources.logo2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(364, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 155);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // meuTextboxSenha
            // 
            this.meuTextboxSenha.BackColor = System.Drawing.Color.White;
            this.meuTextboxSenha.Location = new System.Drawing.Point(373, 309);
            this.meuTextboxSenha.Name = "meuTextboxSenha";
            this.meuTextboxSenha.Size = new System.Drawing.Size(196, 39);
            this.meuTextboxSenha.TabIndex = 1;
            // 
            // meuTextboxCnpj
            // 
            this.meuTextboxCnpj.BackColor = System.Drawing.Color.White;
            this.meuTextboxCnpj.Location = new System.Drawing.Point(373, 264);
            this.meuTextboxCnpj.Name = "meuTextboxCnpj";
            this.meuTextboxCnpj.Size = new System.Drawing.Size(196, 39);
            this.meuTextboxCnpj.TabIndex = 0;
            // 
            // buttonTeste1
            // 
            this.buttonTeste1.BackColor = System.Drawing.Color.White;
            this.buttonTeste1.Location = new System.Drawing.Point(398, 372);
            this.buttonTeste1.Name = "buttonTeste1";
            this.buttonTeste1.Size = new System.Drawing.Size(147, 36);
            this.buttonTeste1.TabIndex = 2;
            this.buttonTeste1.Load += new System.EventHandler(this.buttonTeste1_Load);
            this.buttonTeste1.Click += new System.EventHandler(this.buttonTeste1_click);
            // 
            // box1
            // 
            this.box1.BackColor = System.Drawing.Color.Transparent;
            this.box1.Location = new System.Drawing.Point(309, 31);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(324, 462);
            this.box1.TabIndex = 7;
            this.box1.TabStop = false;
            this.box1.Load += new System.EventHandler(this.box1_Load);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(927, 529);
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

        }

        #endregion
        private testes.MeuButton buttonTeste1;
        private components.Box box1;
        private components.MeuTextbox meuTextboxCnpj;
        private components.MeuTextbox meuTextboxSenha;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}