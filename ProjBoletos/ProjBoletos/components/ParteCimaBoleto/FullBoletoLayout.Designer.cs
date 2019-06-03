namespace ProjBoletos.components.ParteCimaBoleto
{
    partial class FullBoletoLayout
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.boletoForm1 = new Impactro.WindowsControls.BoletoForm();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boletoForm1
            // 
            this.boletoForm1.BackColor = System.Drawing.Color.White;
            this.boletoForm1.Location = new System.Drawing.Point(0, 92);
            this.boletoForm1.Margin = new System.Windows.Forms.Padding(0);
            this.boletoForm1.Name = "boletoForm1";
            this.boletoForm1.Size = new System.Drawing.Size(348, 190);
            this.boletoForm1.TabIndex = 0;
            this.boletoForm1.tamanhoDaParteDeCima = 0;
            this.boletoForm1.Boleto.ExibeReciboSacado = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(348, 282);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // FullBoletoLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FullBoletoLayout";
            this.Size = new System.Drawing.Size(534, 436);
            this.Load += new System.EventHandler(this.FullBoletoLayout_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FullBoletoLayout_Paint);
            this.Resize += new System.EventHandler(this.FullBoletoLayout_Resize);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Impactro.WindowsControls.BoletoForm boletoForm1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
