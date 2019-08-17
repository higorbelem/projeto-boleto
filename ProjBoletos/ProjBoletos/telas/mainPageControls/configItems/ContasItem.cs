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
   public partial class ContasItem : UserControl {
      public ContasItem() {
         InitializeComponent();
      }

      private void ContasItem_Load(object sender, EventArgs e) {

      }

      private void ContasItem_Resize(object sender, EventArgs e) {

      }

      public void resize() {
         ContasItem_Resize(null, null);
      }

      public static ContasItem tryParse(Control control) {
         ContasItem contasItem;
         try {
            contasItem = (ContasItem)control;
         } catch (Exception e) {
            return null;
         }
         return contasItem;
      }
   }
}
