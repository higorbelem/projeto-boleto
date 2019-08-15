using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.mainPageControls.configItems {
   public partial class PerfilItem : UserControl {
      public PerfilItem() {
         InitializeComponent();
      }

      private void PerfilItem_Load(object sender, EventArgs e) {
         //PerfilItem_Resize(sender,e);
      }

      private void PerfilItem_Resize(object sender, EventArgs e) {
         panel.Location = new Point(0,0);
         panel.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);

         txtBoxNome.Location = new Point(panel.Location.X,panel.Location.Y);
         txtBoxNome.Size = new Size(panel.Width,50);
      }

      private void panel1_Paint(object sender, PaintEventArgs e) {

      }
   }
}
