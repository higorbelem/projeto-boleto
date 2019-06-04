namespace ProjBoletos.telas.dialogs {
   partial class GerarRemessaDialog {
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
         this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
         this.btnGerarTodos = new ProjBoletos.testes.MeuButton();
         this.SuspendLayout();
         // 
         // flowLayoutPanel1
         // 
         this.flowLayoutPanel1.AutoScroll = true;
         this.flowLayoutPanel1.Location = new System.Drawing.Point(131, 132);
         this.flowLayoutPanel1.Name = "flowLayoutPanel1";
         this.flowLayoutPanel1.Size = new System.Drawing.Size(133, 50);
         this.flowLayoutPanel1.TabIndex = 1;
         // 
         // btnGerarTodos
         // 
         this.btnGerarTodos.Location = new System.Drawing.Point(114, 12);
         this.btnGerarTodos.Name = "btnGerarTodos";
         this.btnGerarTodos.Size = new System.Drawing.Size(150, 50);
         this.btnGerarTodos.TabIndex = 0;
         this.btnGerarTodos.Click += new System.EventHandler(this.btnGerarTodos_Click);
         // 
         // GerarRemessaDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(500, 600);
         this.Controls.Add(this.flowLayoutPanel1);
         this.Controls.Add(this.btnGerarTodos);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "GerarRemessaDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "GerarRemessaDialog";
         this.Load += new System.EventHandler(this.GerarRemessaDialog_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private testes.MeuButton btnGerarTodos;
      private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
   }
}