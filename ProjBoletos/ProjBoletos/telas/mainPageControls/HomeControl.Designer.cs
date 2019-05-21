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
            this.tabMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMedicoes = new ProjBoletos.components.RectangleButton();
            this.tabBoletos = new ProjBoletos.components.RectangleButton();
            this.tabMedicoesWindow = new ProjBoletos.telas.mainPageControls.HomeTabs.TabMedicoes();
            this.tabBoletosWindow = new ProjBoletos.telas.mainPageControls.HomeTabs.TabBoletos();
            this.tabMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.tabMedicoes.Click += new System.EventHandler(this.tabMedicoes_Click);
            // 
            // tabBoletos
            // 
            this.tabBoletos.Location = new System.Drawing.Point(240, 0);
            this.tabBoletos.Margin = new System.Windows.Forms.Padding(0);
            this.tabBoletos.Name = "tabBoletos";
            this.tabBoletos.Size = new System.Drawing.Size(240, 100);
            this.tabBoletos.TabIndex = 1;
            this.tabBoletos.Load += new System.EventHandler(this.tabBoletos_Load);
            this.tabBoletos.Click += new System.EventHandler(this.tabBoletos_Click);
            // 
            // tabMedicoesWindow
            // 
            this.tabMedicoesWindow.AutoScroll = true;
            this.tabMedicoesWindow.BackColor = System.Drawing.SystemColors.Control;
            this.tabMedicoesWindow.Location = new System.Drawing.Point(49, 218);
            this.tabMedicoesWindow.Name = "tabMedicoesWindow";
            this.tabMedicoesWindow.Size = new System.Drawing.Size(2000, 2000);
            this.tabMedicoesWindow.TabIndex = 6;
            // 
            // tabBoletosWindow
            // 
            this.tabBoletosWindow.BackColor = System.Drawing.SystemColors.Control;
            this.tabBoletosWindow.Location = new System.Drawing.Point(27, 144);
            this.tabBoletosWindow.Name = "tabBoletosWindow";
            this.tabBoletosWindow.Size = new System.Drawing.Size(473, 228);
            this.tabBoletosWindow.TabIndex = 5;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.tabMedicoesWindow);
            this.Controls.Add(this.tabBoletosWindow);
            this.Controls.Add(this.tabMenu);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(2000, 2000);
            this.Load += new System.EventHandler(this.HomeControl_Load);
            this.Resize += new System.EventHandler(this.HomeControl_Resize);
            this.tabMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel tabMenu;
        private components.RectangleButton tabMedicoes;
        private components.RectangleButton tabBoletos;
        private HomeTabs.TabBoletos tabBoletosWindow;
        private HomeTabs.TabMedicoes tabMedicoesWindow;
    }
}
