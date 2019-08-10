using ProjBoletos.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs {
   public partial class AdicionarEditarMedidorVisualizador : Form {

      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern bool ReleaseCapture();

      private int dialogMode;

      public static int DIALOG_MODE_ADICIONAR = 0;
      public static int DIALOG_MODE_EDITAR = 1;

      public AdicionarEditarMedidorVisualizador(Cedente cedente, MedidorVisualizador medidorVisualizador, int dialogMode) {
         InitializeComponent();

         meuComboBoxTipo.comboBox.Items.Add("Medidor");
         meuComboBoxTipo.comboBox.Items.Add("Visualizador");

      }
   }
}
