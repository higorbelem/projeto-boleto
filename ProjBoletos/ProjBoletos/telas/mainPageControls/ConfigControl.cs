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
         expandableItemPerfil.labelDescription.Text = "Nome, Cnpj, Contato, Email, Endereço...";
         expandableItemPerfil.BackColor = Colors.bg2;
         expandableItemPerfil.arrowPanel.BackColor = Colors.bg2;
         expandableItemPerfil.arrowImg.BackColor = Colors.bg2;
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
         expandableItemBoletos.BackColor = Colors.bg2;
         expandableItemBoletos.arrowPanel.BackColor = Colors.bg2;
         expandableItemBoletos.arrowImg.BackColor = Colors.bg2;
         BoletosItem boletosItem = new BoletosItem();
         boletosItem.Size = new Size(expandableItemBoletos.Width, boletosItem.Height);
         expandableItemBoletos.setHeightAberto(boletosItem.Height);
         expandableItemBoletos.setHeightFechado(70);
         expandableItemBoletos.bodyPanel.Controls.Add(boletosItem);

      }

      private void ConfigControl_Resize(object sender, EventArgs e) {
         flowLayoutPanel.Location = new Point(0, 0);
         flowLayoutPanel.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);

         label1.Margin = new Padding((flowLayoutPanel.Width / 2) - (label1.Width / 2), 20, 0, 20);

         expandableItemPerfil.Location = new Point(0, 0);
         expandableItemPerfil.Size = new Size(flowLayoutPanel.Width, expandableItemPerfil.Height);
         expandableItemPerfil.resize();

         expandableItemBoletos.Location = new Point(0, 0);
         expandableItemBoletos.Size = new Size(flowLayoutPanel.Width, expandableItemBoletos.Height);
         expandableItemBoletos.Margin = new Padding(0, 5, 0, 0);
         expandableItemBoletos.resize();
      }

      public void resize() {
         ConfigControl_Resize(null, null);
      }

   }
}
