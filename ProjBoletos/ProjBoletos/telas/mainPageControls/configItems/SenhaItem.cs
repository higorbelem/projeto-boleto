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
   public partial class SenhaItem : UserControl {
      public SenhaItem() {
         InitializeComponent();
      }

      private void SenhaItem_Resize(object sender, EventArgs e) {

      }

      public void resize() {
         SenhaItem_Resize(null, null);
      }

      public static SenhaItem tryParse(Control control) {
         SenhaItem senhaItem;
         try {
            senhaItem = (SenhaItem)control;
         } catch (Exception e) {
            return null;
         }
         return senhaItem;
      }
   }
}
