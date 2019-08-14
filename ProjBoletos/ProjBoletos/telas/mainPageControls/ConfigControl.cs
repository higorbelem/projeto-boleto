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

namespace ProjBoletos.telas.mainPageControls {
    public partial class ConfigControl : UserControl {
        public ConfigControl() {
            InitializeComponent();
        }

      private void ConfigControl_Load(object sender, EventArgs e) {
         expandableItem1.labelTitle.Font = Fonts.mainBold14;
         expandableItem1.labelTitle.ForeColor = Colors.primaryText;
         expandableItem1.labelTitle.Text = "PERFIL";

         expandableItem1.labelDescription.Font = Fonts.mainBold10;
         expandableItem1.labelDescription.ForeColor = Colors.secondaryText;
         expandableItem1.labelDescription.Text = "Nome, ads...";

         TabBoletos tabBoletos = new TabBoletos();
         expandableItem1.setHeightAberto(tabBoletos.Height);
         expandableItem1.bodyPanel.Controls.Add(tabBoletos);
      }

      private void ConfigControl_Resize(object sender, EventArgs e) {
         expandableItem1.Location = new Point(0, 0);
         expandableItem1.Size = new Size(ClientRectangle.Width, 200);
      }
   }
}
