namespace ProjBoletos.telas.mainPageControls.HomeTabs {
    partial class TabMedicoes {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.loading1 = new ProjBoletos.components.Loading();
            this.gerarTodasBtn = new ProjBoletos.testes.MeuButton();
            this.customListView = new ProjBoletos.components.CustomListView();
            this.mainCard1 = new ProjBoletos.components.MainCard();
            this.mainCard2 = new ProjBoletos.components.MainCard();
            this.mainCard3 = new ProjBoletos.components.MainCard();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.loading1);
            this.panel1.Controls.Add(this.gerarTodasBtn);
            this.panel1.Controls.Add(this.customListView);
            this.panel1.Controls.Add(this.mainCard1);
            this.panel1.Controls.Add(this.mainCard2);
            this.panel1.Controls.Add(this.mainCard3);
            this.panel1.Location = new System.Drawing.Point(21, 129);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 1513);
            this.panel1.TabIndex = 4;
            // 
            // loading1
            // 
            this.loading1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.loading1.Location = new System.Drawing.Point(383, 120);
            this.loading1.Name = "loading1";
            this.loading1.Size = new System.Drawing.Size(299, 262);
            this.loading1.TabIndex = 5;
            // 
            // gerarTodasBtn
            // 
            this.gerarTodasBtn.Location = new System.Drawing.Point(254, 320);
            this.gerarTodasBtn.Name = "gerarTodasBtn";
            this.gerarTodasBtn.Size = new System.Drawing.Size(150, 80);
            this.gerarTodasBtn.TabIndex = 6;
            // 
            // customListView
            // 
            this.customListView.AutoSize = true;
            this.customListView.Location = new System.Drawing.Point(130, 403);
            this.customListView.Margin = new System.Windows.Forms.Padding(0);
            this.customListView.Name = "customListView";
            this.customListView.Size = new System.Drawing.Size(640, 500);
            this.customListView.TabIndex = 5;
            // 
            // mainCard1
            // 
            this.mainCard1.Location = new System.Drawing.Point(0, -46);
            this.mainCard1.Name = "mainCard1";
            this.mainCard1.Size = new System.Drawing.Size(265, 262);
            this.mainCard1.TabIndex = 0;
            // 
            // mainCard2
            // 
            this.mainCard2.Location = new System.Drawing.Point(297, -46);
            this.mainCard2.Name = "mainCard2";
            this.mainCard2.Size = new System.Drawing.Size(201, 262);
            this.mainCard2.TabIndex = 1;
            // 
            // mainCard3
            // 
            this.mainCard3.Location = new System.Drawing.Point(559, -46);
            this.mainCard3.Name = "mainCard3";
            this.mainCard3.Size = new System.Drawing.Size(190, 262);
            this.mainCard3.TabIndex = 2;
            // 
            // TabMedicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabMedicoes";
            this.Size = new System.Drawing.Size(2000, 2000);
            this.Load += new System.EventHandler(this.TabMedicoes_Load);
            this.Resize += new System.EventHandler(this.TabMedicoes_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private components.MainCard mainCard3;
        private components.MainCard mainCard2;
        private components.MainCard mainCard1;
        private components.CustomListView customListView;
        private System.Windows.Forms.Panel panel1;
        private testes.MeuButton gerarTodasBtn;
        private components.Loading loading1;
    }
}
