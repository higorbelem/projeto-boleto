﻿using System;
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
using ProjBoletos.telas.mainPageControls;
using ProjBoletos.telas.mainPageControls.configItems;

namespace ProjBoletos.components {
   public partial class ExpandableItem : UserControl {

      private System.Timers.Timer timer;

      private bool aberto = false;
      public int heightFechado = 70;
      public int heightAberto = 200;

      public Label labelTitle, labelDescription;
      public Panel bodyPanel, arrowPanel;
      public PictureBoxWithInterpolationMode arrowImg;

      public ExpandableItem() {
         InitializeComponent();

         labelTitle = labelTitle1;
         labelDescription = labelDescription1;
         bodyPanel = bodyPanel1;
         arrowPanel = arrowPanel1;
         arrowImg = arrowImg1;
      }

      private void ExpandableItem_Load(object sender, EventArgs e) {
         ExpandableItem_Resize(sender, e);

         BackColor = Colors.bg2;

         Height = heightFechado;

         timer = new System.Timers.Timer(8); //~60 FPS
         timer.AutoReset = true;
         timer.SynchronizingObject = this;
         timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
      }

      private void timer_Elapsed(object sender, ElapsedEventArgs e) {
         if (aberto) {
            if (Height > heightFechado) {
               Height -= 50;
               Application.DoEvents();
            } else {
               timer.Stop();
               Height = heightFechado;
               aberto = false;
            }
         } else {
            if (Height < heightAberto) {
               Height += 50;
               Application.DoEvents();
            } else {
               timer.Stop();
               Height = heightAberto;
               aberto = true;
            }
         }
      }

      private void ExpandableItem_Resize(object sender, EventArgs e) {
         headerPanel.Location = new Point(0, 0);
         headerPanel.Size = new Size(ClientRectangle.Width, heightFechado);

         headerFlow.Location = new Point(0, 0);
         headerFlow.Size = new Size((int)(headerPanel.Width * 0.9), heightFechado);

         labelTitle1.Margin = new Padding(20, (heightFechado / 2) - (labelTitle1.Height / 2), 0, 0);

         labelDescription1.Margin = new Padding(0, (heightFechado / 2) - (labelDescription1.Height / 2), 0, 0);

         arrowPanel1.Location = new Point(headerFlow.Location.X + headerFlow.Width, 0);
         arrowPanel1.Size = new Size((int)(headerPanel.Width * 0.1), heightFechado);

         arrowImg1.Size = new Size(50, 50);
         arrowImg1.Location = new Point((arrowPanel1.Width / 2) - (arrowImg1.Width / 2), (arrowPanel1.Height / 2) - (arrowImg1.Height / 2));

         bodyPanel1.Location = new Point(0, heightFechado);
         bodyPanel1.Size = new Size(ClientRectangle.Width, 0);

         foreach (Control control in bodyPanel1.Controls) {
            control.Location = new Point(0, 0);
            control.Size = new Size(ClientRectangle.Width, control.Height);

            PerfilItem perfilItem;
            if ((perfilItem = PerfilItem.tryParse(control)) != null) {
               perfilItem.resize();
            } else {
               BoletosItem boletosItem;
               if ((boletosItem = BoletosItem.tryParse(control)) != null) {
                  boletosItem.resize();
               } else {
                  SenhaItem senhaItem;
                  if ((senhaItem = SenhaItem.tryParse(control)) != null) {
                     senhaItem.resize();
                  }
               }
            }
         }
      }

      public void resize() {
         ExpandableItem_Resize(null, null);
      }

      private void headerPanel_Paint(object sender, PaintEventArgs e) {

      }

      private void arrowImg_Click(object sender, EventArgs e) {
         //timer.Start();
         if (aberto) {
            arrowImg1.Image = new Bitmap(Properties.Resources.arrow_down_high_res);
            while (Height >= heightFechado) {
               Height -= 40;
               Application.DoEvents();
            }
            Height = heightFechado;
            aberto = false;
         } else {
            arrowImg1.Image = new Bitmap(Properties.Resources.arrow_up_high_res);
            while (Height <= heightAberto) {
               Height += 40;
               Application.DoEvents();
            }
            Height = heightAberto;
            aberto = true;
         }
      }

      public void setHeightAberto(int height) {
         heightAberto = height + heightFechado;
         Invalidate();
      }

      public void setHeightFechado(int height) {
         heightFechado = height;
         Invalidate();
      }
   }
}
