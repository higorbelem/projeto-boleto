﻿namespace ProjBoletos.telas.mainPageControls {
    partial class ConfigControl {
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
         this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.expandableItemPerfil = new ProjBoletos.components.ExpandableItem();
         this.separator1 = new ProjBoletos.components.Separator();
         this.expandableItemBoletos = new ProjBoletos.components.ExpandableItem();
         this.flowLayoutPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // flowLayoutPanel
         // 
         this.flowLayoutPanel.Controls.Add(this.label1);
         this.flowLayoutPanel.Controls.Add(this.expandableItemPerfil);
         this.flowLayoutPanel.Controls.Add(this.separator1);
         this.flowLayoutPanel.Controls.Add(this.expandableItemBoletos);
         this.flowLayoutPanel.Location = new System.Drawing.Point(11, 34);
         this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
         this.flowLayoutPanel.Name = "flowLayoutPanel";
         this.flowLayoutPanel.Size = new System.Drawing.Size(440, 363);
         this.flowLayoutPanel.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(0, 0);
         this.label1.Margin = new System.Windows.Forms.Padding(0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(35, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "label1";
         // 
         // expandableItemPerfil
         // 
         this.expandableItemPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
         this.expandableItemPerfil.Location = new System.Drawing.Point(0, 13);
         this.expandableItemPerfil.Margin = new System.Windows.Forms.Padding(0);
         this.expandableItemPerfil.Name = "expandableItemPerfil";
         this.expandableItemPerfil.Size = new System.Drawing.Size(419, 50);
         this.expandableItemPerfil.TabIndex = 0;
         // 
         // separator1
         // 
         this.separator1.Location = new System.Drawing.Point(0, 63);
         this.separator1.Margin = new System.Windows.Forms.Padding(0);
         this.separator1.Name = "separator1";
         this.separator1.Size = new System.Drawing.Size(150, 10);
         this.separator1.TabIndex = 2;
         // 
         // expandableItemBoletos
         // 
         this.expandableItemBoletos.BackColor = System.Drawing.SystemColors.Control;
         this.expandableItemBoletos.Location = new System.Drawing.Point(3, 76);
         this.expandableItemBoletos.Name = "expandableItemBoletos";
         this.expandableItemBoletos.Size = new System.Drawing.Size(419, 271);
         this.expandableItemBoletos.TabIndex = 3;
         // 
         // ConfigControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.Controls.Add(this.flowLayoutPanel);
         this.Margin = new System.Windows.Forms.Padding(0);
         this.Name = "ConfigControl";
         this.Size = new System.Drawing.Size(451, 410);
         this.Load += new System.EventHandler(this.ConfigControl_Load);
         this.Resize += new System.EventHandler(this.ConfigControl_Resize);
         this.flowLayoutPanel.ResumeLayout(false);
         this.flowLayoutPanel.PerformLayout();
         this.ResumeLayout(false);

        }

      #endregion

      private components.ExpandableItem expandableItemPerfil;
      private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
      private System.Windows.Forms.Label label1;
      private components.Separator separator1;
      private components.ExpandableItem expandableItemBoletos;
   }
}
