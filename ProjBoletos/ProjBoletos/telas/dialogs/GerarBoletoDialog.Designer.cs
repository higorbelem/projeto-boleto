﻿namespace ProjBoletos.telas.dialogs
{
    partial class GerarBoletoDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         this.comboBoxContas = new System.Windows.Forms.ComboBox();
         this.comboBoxCarteiras = new System.Windows.Forms.ComboBox();
         this.btnOk = new ProjBoletos.testes.MeuButton();
         this.panelTopBar = new System.Windows.Forms.Panel();
         this.labelTitle = new System.Windows.Forms.Label();
         this.backButtonImg = new System.Windows.Forms.PictureBox();
         this.panelTopBar.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).BeginInit();
         this.SuspendLayout();
         // 
         // comboBoxContas
         // 
         this.comboBoxContas.FormattingEnabled = true;
         this.comboBoxContas.ItemHeight = 13;
         this.comboBoxContas.Location = new System.Drawing.Point(12, 129);
         this.comboBoxContas.Name = "comboBoxContas";
         this.comboBoxContas.Size = new System.Drawing.Size(376, 21);
         this.comboBoxContas.TabIndex = 0;
         // 
         // comboBoxCarteiras
         // 
         this.comboBoxCarteiras.FormattingEnabled = true;
         this.comboBoxCarteiras.ItemHeight = 13;
         this.comboBoxCarteiras.Location = new System.Drawing.Point(12, 173);
         this.comboBoxCarteiras.Name = "comboBoxCarteiras";
         this.comboBoxCarteiras.Size = new System.Drawing.Size(376, 21);
         this.comboBoxCarteiras.TabIndex = 1;
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(128, 241);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(150, 47);
         this.btnOk.TabIndex = 2;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // panelTopBar
         // 
         this.panelTopBar.Controls.Add(this.backButtonImg);
         this.panelTopBar.Controls.Add(this.labelTitle);
         this.panelTopBar.Location = new System.Drawing.Point(12, 12);
         this.panelTopBar.Name = "panelTopBar";
         this.panelTopBar.Size = new System.Drawing.Size(316, 59);
         this.panelTopBar.TabIndex = 5;
         this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
         // 
         // labelTitle
         // 
         this.labelTitle.Location = new System.Drawing.Point(166, 29);
         this.labelTitle.Name = "labelTitle";
         this.labelTitle.Size = new System.Drawing.Size(100, 23);
         this.labelTitle.TabIndex = 0;
         this.labelTitle.Text = "label2";
         this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
         // 
         // backButtonImg
         // 
         this.backButtonImg.Image = global::ProjBoletos.Properties.Resources.backButton;
         this.backButtonImg.Location = new System.Drawing.Point(0, 0);
         this.backButtonImg.Name = "backButtonImg";
         this.backButtonImg.Size = new System.Drawing.Size(100, 50);
         this.backButtonImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.backButtonImg.TabIndex = 1;
         this.backButtonImg.TabStop = false;
         this.backButtonImg.Click += new System.EventHandler(this.backButtonImg_Click);
         // 
         // GerarBoletoDialog
         // 
         this.ClientSize = new System.Drawing.Size(400, 300);
         this.Controls.Add(this.panelTopBar);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.comboBoxCarteiras);
         this.Controls.Add(this.comboBoxContas);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "GerarBoletoDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Load += new System.EventHandler(this.GerarBoletoDialog_Load);
         this.panelTopBar.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.backButtonImg)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxContas;
        private System.Windows.Forms.ComboBox comboBoxCarteiras;
        private testes.MeuButton btnOk;
      private System.Windows.Forms.Panel panelTopBar;
      private System.Windows.Forms.Label labelTitle;
      private System.Windows.Forms.PictureBox backButtonImg;
   }
}