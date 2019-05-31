namespace ProjBoletos.telas
{
    partial class BoletoForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.fullBoletoLayout1 = new ProjBoletos.components.ParteCimaBoleto.FullBoletoLayout();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.fullBoletoLayout1);
            this.panel1.Location = new System.Drawing.Point(23, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 244);
            this.panel1.TabIndex = 1;
            // 
            // fullBoletoLayout1
            // 
            this.fullBoletoLayout1.AutoSize = true;
            this.fullBoletoLayout1.BackColor = System.Drawing.SystemColors.Control;
            this.fullBoletoLayout1.Location = new System.Drawing.Point(0, 0);
            this.fullBoletoLayout1.Margin = new System.Windows.Forms.Padding(0);
            this.fullBoletoLayout1.Name = "fullBoletoLayout1";
            this.fullBoletoLayout1.Size = new System.Drawing.Size(292, 412);
            this.fullBoletoLayout1.TabIndex = 0;
            this.fullBoletoLayout1.Load += new System.EventHandler(this.fullBoletoLayout1_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BoletoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "BoletoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoletoForm";
            this.Load += new System.EventHandler(this.BoletoForm_Load);
            this.Resize += new System.EventHandler(this.BoletoForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private components.ParteCimaBoleto.FullBoletoLayout fullBoletoLayout1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}