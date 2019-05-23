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
            this.boletosCustomScrollbar = new CustomControls.CustomScrollbar();
            this.medicoesCustomScrollbar = new CustomControls.CustomScrollbar();
            this.tabMedicoesWindow = new ProjBoletos.telas.mainPageControls.HomeTabs.TabMedicoes();
            this.tabBoletosWindow = new ProjBoletos.telas.mainPageControls.HomeTabs.TabBoletos();
            this.tabMedicoes = new ProjBoletos.components.RectangleButton();
            this.tabBoletos = new ProjBoletos.components.RectangleButton();
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
            // boletosCustomScrollbar
            // 
            this.boletosCustomScrollbar.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(166)))), ((int)(((byte)(3)))));
            this.boletosCustomScrollbar.LargeChange = 10;
            this.boletosCustomScrollbar.Location = new System.Drawing.Point(850, 124);
            this.boletosCustomScrollbar.Maximum = 100;
            this.boletosCustomScrollbar.Minimum = 0;
            this.boletosCustomScrollbar.MinimumSize = new System.Drawing.Size(96, 248);
            this.boletosCustomScrollbar.Name = "boletosCustomScrollbar";
            this.boletosCustomScrollbar.Size = new System.Drawing.Size(96, 248);
            this.boletosCustomScrollbar.SmallChange = 1;
            this.boletosCustomScrollbar.TabIndex = 8;
            this.boletosCustomScrollbar.Value = 0;
            this.boletosCustomScrollbar.Scroll += new System.EventHandler(this.boletosCustomScrollbar_Scroll);
            // 
            // medicoesCustomScrollbar
            // 
            this.medicoesCustomScrollbar.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(166)))), ((int)(((byte)(3)))));
            this.medicoesCustomScrollbar.LargeChange = 10;
            this.medicoesCustomScrollbar.Location = new System.Drawing.Point(748, 38);
            this.medicoesCustomScrollbar.Maximum = 100;
            this.medicoesCustomScrollbar.Minimum = 0;
            this.medicoesCustomScrollbar.MinimumSize = new System.Drawing.Size(96, 248);
            this.medicoesCustomScrollbar.Name = "medicoesCustomScrollbar";
            this.medicoesCustomScrollbar.Size = new System.Drawing.Size(96, 248);
            this.medicoesCustomScrollbar.SmallChange = 1;
            this.medicoesCustomScrollbar.TabIndex = 7;
            this.medicoesCustomScrollbar.Value = 0;
            this.medicoesCustomScrollbar.Scroll += new System.EventHandler(this.medicoesCustomScrollbar_Scroll);
            // 
            // tabMedicoesWindow
            // 
            this.tabMedicoesWindow.AutoScroll = true;
            this.tabMedicoesWindow.BackColor = System.Drawing.SystemColors.Control;
            this.tabMedicoesWindow.Location = new System.Drawing.Point(141, 324);
            this.tabMedicoesWindow.Margin = new System.Windows.Forms.Padding(0);
            this.tabMedicoesWindow.Name = "tabMedicoesWindow";
            this.tabMedicoesWindow.Size = new System.Drawing.Size(2000, 2000);
            this.tabMedicoesWindow.TabIndex = 6;
            this.tabMedicoesWindow.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tabMedicoesWindow_Scroll);
            this.tabMedicoesWindow.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.tabMedicoesWindow_MouseWheel);
            // 
            // tabBoletosWindow
            // 
            this.tabBoletosWindow.AutoScroll = true;
            this.tabBoletosWindow.BackColor = System.Drawing.SystemColors.Control;
            this.tabBoletosWindow.Location = new System.Drawing.Point(27, 144);
            this.tabBoletosWindow.Margin = new System.Windows.Forms.Padding(0);
            this.tabBoletosWindow.Name = "tabBoletosWindow";
            this.tabBoletosWindow.Size = new System.Drawing.Size(2000, 2000);
            this.tabBoletosWindow.TabIndex = 5;
            this.tabBoletosWindow.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.tabBoletosWindow_MouseWheel);
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
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.boletosCustomScrollbar);
            this.Controls.Add(this.medicoesCustomScrollbar);
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
        private CustomControls.CustomScrollbar medicoesCustomScrollbar;
        private CustomControls.CustomScrollbar boletosCustomScrollbar;
    }
}
