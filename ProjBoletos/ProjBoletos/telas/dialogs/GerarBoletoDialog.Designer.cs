namespace ProjBoletos.telas.dialogs
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
            this.btnFechar = new ProjBoletos.testes.MeuButton();
            this.btnOk = new ProjBoletos.testes.MeuButton();
            this.label1 = new System.Windows.Forms.Label();
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
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(12, 241);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(150, 47);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(238, 241);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 47);
            this.btnOk.TabIndex = 2;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // GerarBoletoDialog
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comboBoxCarteiras);
            this.Controls.Add(this.comboBoxContas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GerarBoletoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.GerarBoletoDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxContas;
        private System.Windows.Forms.ComboBox comboBoxCarteiras;
        private testes.MeuButton btnOk;
        private testes.MeuButton btnFechar;
        private System.Windows.Forms.Label label1;
    }
}