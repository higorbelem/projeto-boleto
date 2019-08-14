using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using ProjBoletos.utils;

namespace ProjBoletos.components {
   public partial class ExpandableItem : UserControl {

      private System.Timers.Timer timer;

      private bool aberto = false;
      public int heightFechado = 50;
      public int heightAberto = 200;

      public Label labelTitle, labelDescription;
      public Panel bodyPanel;

      public ExpandableItem(int heightFechado, int heightAberto) {
         InitializeComponent();

         BackColor = Colors.bg;

         this.heightFechado = heightFechado;
         this.heightAberto = heightAberto;

         labelTitle = labelTitle1;
         labelDescription = labelDescription1;
         bodyPanel = bodyPanel1;
      }

      private void ExpandableItem_Load(object sender, EventArgs e) {

         Height = heightFechado;

         timer = new System.Timers.Timer(8); //~60 FPS
         timer.AutoReset = true;
         timer.SynchronizingObject = this;
         timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
      }

      private void timer_Elapsed(object sender, ElapsedEventArgs e) {
         if (aberto) {
            if (Height > heightFechado) {
               Height -= 20;
            } else {
               timer.Stop();
               Height = heightFechado;
               aberto = false;
               //labelFechado.Visible = true;
               //labelFechado.Text = txtBoxRua.txtBox.Text + ", " + txtBoxNumero.txtBox.Text + " " + txtBoxBairro.txtBox.Text;
            }
         } else {
            if (Height < heightAberto) {
               Height += 20;
            } else {
               timer.Stop();
               Height = heightAberto;
               aberto = true;
            }
         }
      }

      private void ExpandableItem_Resize(object sender, EventArgs e) {
         headerPanel.Location = new Point(0,0);
         headerPanel.Size = new Size(ClientRectangle.Width, heightFechado);

         headerFlow.Location = new Point(0, 0);
         headerFlow.Size = new Size((int)(headerPanel.Width * 0.9), heightFechado);

         labelTitle1.Margin = new Padding(20, (heightFechado / 2) - (labelTitle1.Height / 2), 0, 0);

         labelDescription1.Margin = new Padding(0, (heightFechado / 2) - (labelDescription1.Height / 2), 0, 0);

         arrowImg.Location = new Point(headerFlow.Location.X + headerFlow.Width, 0);
         arrowImg.Size = new Size((int)(headerPanel.Width * 0.1), heightFechado);

         bodyPanel1.Location = new Point(0, heightFechado);
         bodyPanel1.Size = new Size(ClientRectangle.Width, 0);
      }

      private void headerPanel_Paint(object sender, PaintEventArgs e) {

      }

      private void arrowImg_Click(object sender, EventArgs e) {
         timer.Start();
      }

      public void setHeightAberto(int height) {
         heightAberto = height;
         Invalidate();
      }
   }
}
