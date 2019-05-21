namespace ProjBoletos.components {
    partial class AccountButton {
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
            this.icon1 = new PictureBoxWithInterpolationMode();
            this.dropIcon1 = new PictureBoxWithInterpolationMode();
            ((System.ComponentModel.ISupportInitialize)(this.icon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropIcon1)).BeginInit();
            this.SuspendLayout();
            // 
            // icon1
            // 
            this.icon1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.icon1.Location = new System.Drawing.Point(34, 63);
            this.icon1.Name = "icon1";
            this.icon1.Size = new System.Drawing.Size(100, 50);
            this.icon1.TabIndex = 0;
            this.icon1.TabStop = false;
            // 
            // dropIcon1
            // 
            this.dropIcon1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.dropIcon1.Location = new System.Drawing.Point(239, 51);
            this.dropIcon1.Name = "dropIcon1";
            this.dropIcon1.Size = new System.Drawing.Size(100, 50);
            this.dropIcon1.TabIndex = 1;
            this.dropIcon1.TabStop = false;
            // 
            // AccountButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dropIcon1);
            this.Controls.Add(this.icon1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AccountButton";
            this.Size = new System.Drawing.Size(374, 150);
            this.Load += new System.EventHandler(this.AccountButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropIcon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBoxWithInterpolationMode icon1;
        private PictureBoxWithInterpolationMode dropIcon1;
    }
}
