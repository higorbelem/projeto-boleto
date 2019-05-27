using ProjBoletos.utils;

namespace ProjBoletos.telas
{
    partial class MedicaoForm
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
            this.panelMasterInterno = new System.Windows.Forms.Panel();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.customScrollbar1 = new CustomControls.CustomScrollbar();
            this.boxMedidor = new ProjBoletos.components.Box();
            this.boxCliente = new ProjBoletos.components.Box();
            this.boxCasa = new ProjBoletos.components.Box();
            this.boxMedicao = new ProjBoletos.components.Box();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelMasterInterno.SuspendLayout();
            this.panelMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMasterInterno
            // 
            this.panelMasterInterno.AutoSize = true;
            this.panelMasterInterno.Controls.Add(this.labelTitulo);
            this.panelMasterInterno.Controls.Add(this.boxMedidor);
            this.panelMasterInterno.Controls.Add(this.boxCliente);
            this.panelMasterInterno.Controls.Add(this.boxCasa);
            this.panelMasterInterno.Controls.Add(this.boxMedicao);
            this.panelMasterInterno.Location = new System.Drawing.Point(72, 19);
            this.panelMasterInterno.Margin = new System.Windows.Forms.Padding(0);
            this.panelMasterInterno.Name = "panelMasterInterno";
            this.panelMasterInterno.Size = new System.Drawing.Size(580, 363);
            this.panelMasterInterno.TabIndex = 1;
            // 
            // panelMaster
            // 
            this.panelMaster.AutoScroll = true;
            this.panelMaster.Controls.Add(this.panelMasterInterno);
            this.panelMaster.Location = new System.Drawing.Point(12, 12);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(760, 437);
            this.panelMaster.TabIndex = 1;
            // 
            // customScrollbar1
            // 
            this.customScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(166)))), ((int)(((byte)(3)))));
            this.customScrollbar1.LargeChange = 10;
            this.customScrollbar1.Location = new System.Drawing.Point(622, 116);
            this.customScrollbar1.Maximum = 100;
            this.customScrollbar1.Minimum = 0;
            this.customScrollbar1.MinimumSize = new System.Drawing.Size(150, 96);
            this.customScrollbar1.Name = "customScrollbar1";
            this.customScrollbar1.Size = new System.Drawing.Size(150, 150);
            this.customScrollbar1.SmallChange = 1;
            this.customScrollbar1.TabIndex = 2;
            this.customScrollbar1.Value = 0;
            this.customScrollbar1.Scroll += new System.EventHandler(this.customScrollbar1_Scroll);
            // 
            // boxMedidor
            // 
            this.boxMedidor.AutoSize = true;
            this.boxMedidor.BackColor = System.Drawing.Color.Transparent;
            this.boxMedidor.Location = new System.Drawing.Point(303, 179);
            this.boxMedidor.Margin = new System.Windows.Forms.Padding(0);
            this.boxMedidor.Name = "boxMedidor";
            this.boxMedidor.Size = new System.Drawing.Size(152, 111);
            this.boxMedidor.TabIndex = 3;
            // 
            // boxCliente
            // 
            this.boxCliente.AutoSize = true;
            this.boxCliente.BackColor = System.Drawing.Color.Transparent;
            this.boxCliente.Location = new System.Drawing.Point(112, 179);
            this.boxCliente.Margin = new System.Windows.Forms.Padding(0);
            this.boxCliente.Name = "boxCliente";
            this.boxCliente.Size = new System.Drawing.Size(152, 111);
            this.boxCliente.TabIndex = 2;
            // 
            // boxCasa
            // 
            this.boxCasa.AutoSize = true;
            this.boxCasa.BackColor = System.Drawing.Color.Transparent;
            this.boxCasa.Location = new System.Drawing.Point(303, 49);
            this.boxCasa.Margin = new System.Windows.Forms.Padding(0);
            this.boxCasa.Name = "boxCasa";
            this.boxCasa.Size = new System.Drawing.Size(152, 111);
            this.boxCasa.TabIndex = 1;
            // 
            // boxMedicao
            // 
            this.boxMedicao.AutoSize = true;
            this.boxMedicao.BackColor = System.Drawing.Color.Transparent;
            this.boxMedicao.Location = new System.Drawing.Point(112, 49);
            this.boxMedicao.Margin = new System.Windows.Forms.Padding(0);
            this.boxMedicao.Name = "boxMedicao";
            this.boxMedicao.Size = new System.Drawing.Size(152, 111);
            this.boxMedicao.TabIndex = 0;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = Fonts.mainBold20;
            this.labelTitulo.Location = new System.Drawing.Point(158, 16);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(267, 33);
            this.labelTitulo.TabIndex = 4;
            this.labelTitulo.Text = "Detalhes da Medição";
            // 
            // MedicaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.customScrollbar1);
            this.Controls.Add(this.panelMaster);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MedicaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicaoForm";
            this.Load += new System.EventHandler(this.MedicaoForm_Load);
            this.Resize += new System.EventHandler(this.MedicaoForm_Resize);
            this.panelMasterInterno.ResumeLayout(false);
            this.panelMasterInterno.PerformLayout();
            this.panelMaster.ResumeLayout(false);
            this.panelMaster.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private components.Box boxMedicao;
        private System.Windows.Forms.Panel panelMasterInterno;
        private CustomControls.CustomScrollbar customScrollbar1;
        private System.Windows.Forms.Panel panelMaster;
        private components.Box boxCasa;
        private components.Box boxCliente;
        private components.Box boxMedidor;
        private System.Windows.Forms.Label labelTitulo;
    }
}