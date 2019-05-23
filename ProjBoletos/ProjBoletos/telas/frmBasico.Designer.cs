using Impactro.Cobranca;
using Impactro.WindowsControls;

namespace BoletoForm2
{
    partial class frmBasico
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
            this.SuspendLayout();
            // 
            // frmBasico
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmBasico";
            this.Load += new System.EventHandler(this.frmBasico_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPrintTabela;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.CheckBox chkCarne;
        private System.Windows.Forms.CheckBox chkRecibo;
        private System.Windows.Forms.CheckBox chkExtra;
        private System.Windows.Forms.CheckBox chkLogo;
        private System.Windows.Forms.NumericUpDown nmEscala;
        private System.Windows.Forms.CheckBox chkEscala;
        private System.Windows.Forms.CheckBox chkMaisEspaco;
        private BoletoForm bltFrm;
        private System.Windows.Forms.GroupBox groupBox1;
        private ProjBoletos.ParteCimaBoleto parteCimaBoleto;
    }
}