using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProjBoletos.components {
   public partial class MeuComboBox : ComboBox {

      Color color;

      public MeuComboBox() {
         SetStyle(ControlStyles.UserPaint, true);
      }

      public MeuComboBox(Color color) {
         InitializeComponent();
         SetStyle(ControlStyles.UserPaint, true);
         this.color = color;
         this.FlatStyle = FlatStyle.Popup;
      }

      /*private void MeuComboBox_Load(object sender, EventArgs e) {
         comboBox1.Location = new Point(10, (Size.Height / 2) - (comboBox1.Size.Height / 2));
         comboBox1.Size = new Size(this.Size.Width - 20, this.Size.Height - 20);

         comboBox1.BackColor = color;
      }*/

      protected override void OnPaint(PaintEventArgs e) {
         base.OnPaint(e);

         e.Graphics.FillRectangle(new SolidBrush(color), ClientRectangle);
         //drawBackLine(e.Graphics, rect, new SolidBrush(color));
      }

      private void drawBackLine(Graphics g, Rectangle rect, Brush brush) {
         GraphicsPath p = new GraphicsPath();
         p.AddArc(new Rectangle(rect.X, rect.Y, rect.Height, rect.Height), 90, 180);
         p.AddLine(new Point(rect.Height / 2, rect.Y), new Point(rect.Width - (rect.Height / 2), rect.Y));
         p.AddArc(new Rectangle(rect.Width - rect.Height, rect.Y, rect.Height, rect.Height), -90, 180);
         p.CloseFigure();

         g.FillPath(brush, p);
      }
   }
}
