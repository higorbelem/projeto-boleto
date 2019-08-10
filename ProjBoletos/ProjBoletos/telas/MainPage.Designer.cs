using ProjBoletos.utils;

namespace ProjBoletos.telas {
   partial class MainPage {
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
         this.sideBarFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.logoImage = new PictureBoxWithInterpolationMode();
         this.separator1 = new ProjBoletos.components.Separator();
         this.label1 = new System.Windows.Forms.Label();
         this.btnHome = new ProjBoletos.components.SidebarButton();
         this.btnConfig = new ProjBoletos.components.SidebarButton();
         this.btnCliente = new ProjBoletos.components.SidebarButton();
         this.btnMedidorVisual = new ProjBoletos.components.SidebarButton();
         this.topBarFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
         this.accountButton = new ProjBoletos.components.AccountButton();
         this.dropMenu = new System.Windows.Forms.FlowLayoutPanel();
         this.dropMenuButtonSair = new ProjBoletos.components.SidebarButton();
         this.configControl = new ProjBoletos.telas.mainPageControls.ConfigControl();
         this.homeControl = new ProjBoletos.telas.mainPageControls.HomeControl();
         this.clientControl = new ProjBoletos.telas.mainPageControls.ClienteControl();
         this.medidorVisualControl = new ProjBoletos.telas.mainPageControls.MedidorVisualControl();
         this.sideBarFlowPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.logoImage)).BeginInit();
         this.topBarFlowLayout.SuspendLayout();
         this.dropMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // sideBarFlowPanel
         // 
         this.sideBarFlowPanel.BackColor = System.Drawing.Color.White;
         this.sideBarFlowPanel.Controls.Add(this.logoImage);
         this.sideBarFlowPanel.Controls.Add(this.separator1);
         this.sideBarFlowPanel.Controls.Add(this.label1);
         this.sideBarFlowPanel.Controls.Add(this.btnHome);
         this.sideBarFlowPanel.Controls.Add(this.btnCliente);
         this.sideBarFlowPanel.Controls.Add(this.btnMedidorVisual);
         this.sideBarFlowPanel.Controls.Add(this.btnConfig);
         this.sideBarFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.sideBarFlowPanel.Location = new System.Drawing.Point(0, 0);
         this.sideBarFlowPanel.Name = "sideBarFlowPanel";
         this.sideBarFlowPanel.Size = new System.Drawing.Size(200, 451);
         this.sideBarFlowPanel.TabIndex = 0;
         this.sideBarFlowPanel.WrapContents = false;
         // 
         // logoImage
         // 
         this.logoImage.Image = global::ProjBoletos.Properties.Resources.logo2;
         this.logoImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
         this.logoImage.Location = new System.Drawing.Point(0, 0);
         this.logoImage.Margin = new System.Windows.Forms.Padding(0);
         this.logoImage.Name = "logoImage";
         this.logoImage.Padding = new System.Windows.Forms.Padding(30);
         this.logoImage.Size = new System.Drawing.Size(93, 62);
         this.logoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.logoImage.TabIndex = 4;
         this.logoImage.TabStop = false;
         // 
         // separator1
         // 
         this.separator1.Location = new System.Drawing.Point(3, 65);
         this.separator1.Name = "separator1";
         this.separator1.Size = new System.Drawing.Size(150, 26);
         this.separator1.TabIndex = 3;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.BackColor = System.Drawing.Color.Transparent;
         this.label1.Font = Fonts.mainBold10;
         this.label1.ForeColor = System.Drawing.Color.LightGray;
         this.label1.Location = new System.Drawing.Point(15, 104);
         this.label1.Margin = new System.Windows.Forms.Padding(15, 10, 0, 10);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(50, 19);
         this.label1.TabIndex = 1;
         this.label1.Text = "MENU";
         // 
         // btnHome
         // 
         this.btnHome.Location = new System.Drawing.Point(0, 133);
         this.btnHome.Margin = new System.Windows.Forms.Padding(0);
         this.btnHome.Name = "btnHome";
         this.btnHome.Size = new System.Drawing.Size(172, 50);
         this.btnHome.TabIndex = 1;
         this.btnHome.Click += new System.EventHandler(this.btnHome_click);
         // 
         // btnConfig
         // 
         this.btnConfig.Location = new System.Drawing.Point(0, 183);
         this.btnConfig.Margin = new System.Windows.Forms.Padding(0);
         this.btnConfig.Name = "btnConfig";
         this.btnConfig.Size = new System.Drawing.Size(172, 50);
         this.btnConfig.TabIndex = 2;
         this.btnConfig.Click += new System.EventHandler(this.btnConfig_click);
         // 
         // btnCliente
         // 
         this.btnCliente.Location = new System.Drawing.Point(0, 183);
         this.btnCliente.Margin = new System.Windows.Forms.Padding(0);
         this.btnCliente.Name = "btnCliente";
         this.btnCliente.Size = new System.Drawing.Size(172, 50);
         this.btnCliente.TabIndex = 2;
         this.btnCliente.Click += new System.EventHandler(this.btnCliente_click);
         // 
         // btnMedidorVisual
         // 
         this.btnMedidorVisual.Location = new System.Drawing.Point(0, 183);
         this.btnMedidorVisual.Margin = new System.Windows.Forms.Padding(0);
         this.btnMedidorVisual.Name = "btnMedidorVisual";
         this.btnMedidorVisual.Size = new System.Drawing.Size(172, 50);
         this.btnMedidorVisual.TabIndex = 10;
         this.btnMedidorVisual.Click += new System.EventHandler(this.btnMedidorVisual_click);
         // 
         // topBarFlowLayout
         // 
         this.topBarFlowLayout.BackColor = System.Drawing.Color.Gray;
         this.topBarFlowLayout.Controls.Add(this.accountButton);
         this.topBarFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
         this.topBarFlowLayout.Location = new System.Drawing.Point(219, 12);
         this.topBarFlowLayout.Margin = new System.Windows.Forms.Padding(0);
         this.topBarFlowLayout.Name = "topBarFlowLayout";
         this.topBarFlowLayout.Size = new System.Drawing.Size(370, 40);
         this.topBarFlowLayout.TabIndex = 3;
         this.topBarFlowLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.topBarFlowLayout_Paint);
         // 
         // accountButton
         // 
         this.accountButton.Location = new System.Drawing.Point(193, 0);
         this.accountButton.Margin = new System.Windows.Forms.Padding(0);
         this.accountButton.Name = "accountButton";
         this.accountButton.Size = new System.Drawing.Size(177, 50);
         this.accountButton.TabIndex = 0;
         this.accountButton.Load += new System.EventHandler(this.accountButton_Load);
         this.accountButton.Click += new System.EventHandler(this.accountButton_click);
         // 
         // dropMenu
         // 
         this.dropMenu.Controls.Add(this.dropMenuButtonSair);
         this.dropMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.dropMenu.Location = new System.Drawing.Point(604, 0);
         this.dropMenu.Name = "dropMenu";
         this.dropMenu.Size = new System.Drawing.Size(200, 100);
         this.dropMenu.TabIndex = 4;
         // 
         // dropMenuButtonSair
         // 
         this.dropMenuButtonSair.Location = new System.Drawing.Point(0, 0);
         this.dropMenuButtonSair.Margin = new System.Windows.Forms.Padding(0);
         this.dropMenuButtonSair.Name = "dropMenuButtonSair";
         this.dropMenuButtonSair.Size = new System.Drawing.Size(179, 60);
         this.dropMenuButtonSair.TabIndex = 0;
         this.dropMenuButtonSair.Load += new System.EventHandler(this.dropMenuButtonSair_Load);
         this.dropMenuButtonSair.Click += new System.EventHandler(this.dropMenuButtonSair_click);
         // 
         // configControl
         // 
         this.configControl.BackColor = System.Drawing.Color.Snow;
         this.configControl.Location = new System.Drawing.Point(367, 177);
         this.configControl.Name = "configControl";
         this.configControl.Size = new System.Drawing.Size(451, 410);
         this.configControl.TabIndex = 2;
         // 
         // homeControl
         // 
         this.homeControl.BackColor = System.Drawing.Color.Snow;
         this.homeControl.Location = new System.Drawing.Point(260, 89);
         this.homeControl.Margin = new System.Windows.Forms.Padding(0);
         this.homeControl.Name = "homeControl";
         this.homeControl.Size = new System.Drawing.Size(503, 498);
         this.homeControl.TabIndex = 1;
         // 
         // clientControl
         // 
         this.clientControl.BackColor = System.Drawing.Color.Snow;
         this.clientControl.Location = new System.Drawing.Point(260, 89);
         this.clientControl.Margin = new System.Windows.Forms.Padding(0);
         this.clientControl.Name = "clientControl";
         this.clientControl.Size = new System.Drawing.Size(503, 498);
         this.clientControl.TabIndex = 20;
         // 
         // medidorVisualControl
         // 
         this.medidorVisualControl.BackColor = System.Drawing.Color.Snow;
         this.medidorVisualControl.Location = new System.Drawing.Point(260, 89);
         this.medidorVisualControl.Margin = new System.Windows.Forms.Padding(0);
         this.medidorVisualControl.Name = "medidorVisualControl";
         this.medidorVisualControl.Size = new System.Drawing.Size(503, 498);
         this.medidorVisualControl.TabIndex = 20;
         // 
         // MainPage
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 411);
         this.Controls.Add(this.dropMenu);
         this.Controls.Add(this.topBarFlowLayout);
         this.Controls.Add(this.configControl);
         this.Controls.Add(this.homeControl);
         this.Controls.Add(this.clientControl);
         this.Controls.Add(this.medidorVisualControl);
         this.Controls.Add(this.sideBarFlowPanel);
         this.Name = "MainPage";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Main";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.Main_Load);
         this.Resize += new System.EventHandler(this.Main_Resize);
         this.sideBarFlowPanel.ResumeLayout(false);
         this.sideBarFlowPanel.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.logoImage)).EndInit();
         this.topBarFlowLayout.ResumeLayout(false);
         this.dropMenu.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.FlowLayoutPanel sideBarFlowPanel;
      private System.Windows.Forms.Label label1;
      private components.SidebarButton btnHome;
      private components.SidebarButton btnConfig;
      private components.SidebarButton btnCliente;
      private components.SidebarButton btnMedidorVisual;
      private mainPageControls.HomeControl homeControl;
      private mainPageControls.ClienteControl clientControl;
      private mainPageControls.MedidorVisualControl medidorVisualControl;
      private mainPageControls.ConfigControl configControl;
      private System.Windows.Forms.FlowLayoutPanel topBarFlowLayout;
      private components.AccountButton accountButton;
      private System.Windows.Forms.FlowLayoutPanel dropMenu;
      private components.SidebarButton dropMenuButtonSair;
      private components.Separator separator1;
      private PictureBoxWithInterpolationMode logoImage;
   }
}