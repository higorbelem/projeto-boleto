namespace ProjBoletos.telas.mainPageControls.HomeTabs {
    partial class TabBoletos {
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
            this.mainCard1 = new ProjBoletos.components.MainCard();
            this.mainCard3 = new ProjBoletos.components.MainCard();
            this.mainCard2 = new ProjBoletos.components.MainCard();
            this.customListView = new ProjBoletos.components.CustomListView(ProjBoletos.components.CustomListView.COD_BOLETO);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGerarRemessa = new ProjBoletos.testes.MeuButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainCard1
            // 
            this.mainCard1.Location = new System.Drawing.Point(-75, 28);
            this.mainCard1.Name = "mainCard1";
            this.mainCard1.Size = new System.Drawing.Size(373, 262);
            this.mainCard1.TabIndex = 1;
            // 
            // mainCard3
            // 
            this.mainCard3.Location = new System.Drawing.Point(359, 37);
            this.mainCard3.Name = "mainCard3";
            this.mainCard3.Size = new System.Drawing.Size(373, 262);
            this.mainCard3.TabIndex = 3;
            // 
            // mainCard2
            // 
            this.mainCard2.Location = new System.Drawing.Point(776, 28);
            this.mainCard2.Name = "mainCard2";
            this.mainCard2.Size = new System.Drawing.Size(373, 262);
            this.mainCard2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnGerarRemessa);
            this.panel1.Controls.Add(this.customListView);
            this.panel1.Controls.Add(this.mainCard1);
            this.panel1.Controls.Add(this.mainCard2);
            this.panel1.Controls.Add(this.mainCard3);
            this.panel1.Location = new System.Drawing.Point(63, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 3013);
            this.panel1.TabIndex = 4;
            // 
            // customListView
            // 
            this.customListView.AutoSize = true;
            this.customListView.Location = new System.Drawing.Point(370, 355);
            this.customListView.Name = "customListView";
            this.customListView.Size = new System.Drawing.Size(380, 201);
            this.customListView.TabIndex = 5;
            // 
            // btnGerarRemessa
            // 
            this.btnGerarRemessa.Location = new System.Drawing.Point(437, 376);
            this.btnGerarRemessa.Name = "btnGerarRemessa";
            this.btnGerarRemessa.Size = new System.Drawing.Size(150, 150);
            this.btnGerarRemessa.TabIndex = 4;
            this.btnGerarRemessa.Click += new System.EventHandler(this.btnGerarRemessa_Click);
            // 
            // TabBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabBoletos";
            this.Size = new System.Drawing.Size(2000, 2000);
            this.Load += new System.EventHandler(this.TabBoletos_Load);
            this.Resize += new System.EventHandler(this.TabBoletos_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private components.MainCard mainCard1;
        private components.MainCard mainCard3;
        private components.MainCard mainCard2;
        private System.Windows.Forms.Panel panel1;
        private testes.MeuButton btnGerarRemessa;
        private components.CustomListView customListView;
    }
}
