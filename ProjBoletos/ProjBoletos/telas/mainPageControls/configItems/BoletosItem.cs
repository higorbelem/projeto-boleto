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
   public partial class BoletosItem : UserControl {
      public BoletosItem() {
         InitializeComponent();
      }

      private void BoletosItem_Load(object sender, EventArgs e) {

      }

      private void BoletosItem_Resize(object sender, EventArgs e) {

      }

      public void resize() {
         BoletosItem_Resize(null, null);
      }

      public static BoletosItem tryParse(Control control) {
         BoletosItem boletosItem;
         try {
            boletosItem = (BoletosItem)control;
         } catch (Exception e) {
            return null;
         }
         return boletosItem;
      }
   }
}
