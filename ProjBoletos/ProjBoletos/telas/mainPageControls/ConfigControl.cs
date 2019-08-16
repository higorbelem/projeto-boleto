using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.utils;
using ProjBoletos.telas.mainPageControls.HomeTabs;
using ProjBoletos.telas.mainPageControls.configItems;

namespace ProjBoletos.telas.mainPageControls {
   public partial class ConfigControl : UserControl {
      public ConfigControl() {
         InitializeComponent();
      }

      private void ConfigControl_Load(object sender, EventArgs e) {
         //ConfigControl_Resize(sender, e);

         BackColor = Colors.bg;

         label1.Text = "CONFIGURAÇÕES";
         label1.Font = Fonts.mainBold20;
         label1.ForeColor = Colors.accent1;

         expandableItemPerfil.labelTitle.Font = Fonts.mainBold14;
         expandableItemPerfil.labelTitle.ForeColor = Colors.primaryText;
         expandableItemPerfil.labelTitle.Text = "PERFIL";
         expandableItemPerfil.labelDescription.Font = Fonts.mainBold10;
         expandableItemPerfil.labelDescription.ForeColor = Colors.secondaryText;
         expandableItemPerfil.labelDescription.Text = "Nome, ads...";
         expandableItemPerfil.BackColor = Colors.bg;
         expandableItemPerfil.arrowPanel.BackColor = Colors.bg;
         expandableItemPerfil.arrowImg.BackColor = Colors.bg;
         PerfilItem perfilItem = new PerfilItem();
         perfilItem.Size = new Size(expandableItemPerfil.Width, perfilItem.Height);
         expandableItemPerfil.setHeightAberto(perfilItem.Height);
         expandableItemPerfil.setHeightFechado(70);
         expandableItemPerfil.bodyPanel.Controls.Add(perfilItem);

         expandableItemBoletos.labelTitle.Font = Fonts.mainBold14;
         expandableItemBoletos.labelTitle.ForeColor = Colors.primaryText;
         expandableItemBoletos.labelTitle.Text = "BOLETOS";
         expandableItemBoletos.labelDescription.Font = Fonts.mainBold10;
         expandableItemBoletos.labelDescription.ForeColor = Colors.secondaryText;
         expandableItemBoletos.labelDescription.Text = "Coisas, coisas, coisas...";
         expandableItemBoletos.BackColor = Colors.bg;
         expandableItemBoletos.arrowPanel.BackColor = Colors.bg;
         expandableItemBoletos.arrowImg.BackColor = Colors.bg;
         BoletosItem boletosItem = new BoletosItem();
         boletosItem.Size = new Size(expandableItemBoletos.Width, boletosItem.Height);
         expandableItemBoletos.setHeightAberto(boletosItem.Height);
         expandableItemBoletos.setHeightFechado(70);
         expandableItemBoletos.bodyPanel.Controls.Add(boletosItem);

         separator1.color = Colors.secondaryText;
      }

      private void ConfigControl_Resize(object sender, EventArgs e) {
         flowLayoutPanel.Location = new Point(0, 0);
         flowLayoutPanel.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);

         label1.Margin = new Padding((flowLayoutPanel.Width / 2) - (label1.Width / 2), 20, 20, 0);

         expandableItemPerfil.Location = new Point(0, 0);
         expandableItemPerfil.Size = new Size(flowLayoutPanel.Width, expandableItemPerfil.Height);

         separator1.Size = new Size(flowLayoutPanel.Width, 10);

         expandableItemBoletos.Location = new Point(0, 0);
         expandableItemBoletos.Size = new Size(flowLayoutPanel.Width, expandableItemBoletos.Height);
      }

      public void resize() {
         ConfigControl_Resize(null, null);
      }

   }
}
