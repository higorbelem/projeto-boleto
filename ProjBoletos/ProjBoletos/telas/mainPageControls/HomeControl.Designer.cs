namespace ProjBoletos.telas.mainPageControls {
    partial class HomeControl {
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
            this.mainCard4 = new ProjBoletos.components.MainCard();
            this.mainCard3 = new ProjBoletos.components.MainCard();
            this.mainCard2 = new ProjBoletos.components.MainCard();
            this.mainCard1 = new ProjBoletos.components.MainCard();
            this.tabMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMedicoes = new ProjBoletos.components.RectangleButton();
            this.tabBoletos = new ProjBoletos.components.RectangleButton();
            this.tabMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainCard4
            // 
            this.mainCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.mainCard4.Location = new System.Drawing.Point(1015, 295);
            this.mainCard4.Margin = new System.Windows.Forms.Padding(0);
            this.mainCard4.Name = "mainCard4";
            this.mainCard4.Size = new System.Drawing.Size(293, 220);
            this.mainCard4.TabIndex = 3;
            // 
            // mainCard3
            // 
            this.mainCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.mainCard3.Location = new System.Drawing.Point(684, 295);
            this.mainCard3.Margin = new System.Windows.Forms.Padding(0);
            this.mainCard3.Name = "mainCard3";
            this.mainCard3.Size = new System.Drawing.Size(293, 220);
            this.mainCard3.TabIndex = 2;
            // 
            // mainCard2
            // 
            this.mainCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.mainCard2.Location = new System.Drawing.Point(343, 295);
            this.mainCard2.Margin = new System.Windows.Forms.Padding(0);
            this.mainCard2.Name = "mainCard2";
            this.mainCard2.Size = new System.Drawing.Size(293, 220);
            this.mainCard2.TabIndex = 1;
            // 
            // mainCard1
            // 
            this.mainCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.mainCard1.Location = new System.Drawing.Point(24, 295);
            this.mainCard1.Margin = new System.Windows.Forms.Padding(0);
            this.mainCard1.Name = "mainCard1";
            this.mainCard1.Size = new System.Drawing.Size(293, 220);
            this.mainCard1.TabIndex = 0;
            // 
            // tabMenu
            // 
            this.tabMenu.BackColor = System.Drawing.Color.Gray;
            this.tabMenu.Controls.Add(this.tabMedicoes);
            this.tabMenu.Controls.Add(this.tabBoletos);
            this.tabMenu.Location = new System.Drawing.Point(49, 38);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Size = new System.Drawing.Size(693, 100);
            this.tabMenu.TabIndex = 4;
            // 
            // tabMedicoes
            // 
            this.tabMedicoes.Location = new System.Drawing.Point(0, 0);
            this.tabMedicoes.Margin = new System.Windows.Forms.Padding(0);
            this.tabMedicoes.Name = "tabMedicoes";
            this.tabMedicoes.Size = new System.Drawing.Size(240, 100);
            this.tabMedicoes.TabIndex = 0;
            // 
            // tabBoletos
            // 
            this.tabBoletos.Location = new System.Drawing.Point(240, 0);
            this.tabBoletos.Margin = new System.Windows.Forms.Padding(0);
            this.tabBoletos.Name = "tabBoletos";
            this.tabBoletos.Size = new System.Drawing.Size(240, 100);
            this.tabBoletos.TabIndex = 1;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.tabMenu);
            this.Controls.Add(this.mainCard4);
            this.Controls.Add(this.mainCard3);
            this.Controls.Add(this.mainCard2);
            this.Controls.Add(this.mainCard1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(2000, 2000);
            this.Load += new System.EventHandler(this.HomeControl_Load);
            this.Resize += new System.EventHandler(this.HomeControl_Resize);
            this.tabMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private components.MainCard mainCard1;
        private components.MainCard mainCard2;
        private components.MainCard mainCard3;
        private components.MainCard mainCard4;
        private System.Windows.Forms.FlowLayoutPanel tabMenu;
        private components.RectangleButton tabMedicoes;
        private components.RectangleButton tabBoletos;
    }
}
