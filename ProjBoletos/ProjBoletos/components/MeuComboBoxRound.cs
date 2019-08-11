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
using ProjBoletos.utils;

namespace ProjBoletos.components {
   public partial class MeuComboBoxRound : UserControl {

      Color backColor = Color.FromArgb(210, 210, 210);
      public MeuComboBox comboBox;

      public MeuComboBoxRound() {
         InitializeComponent();
         this.comboBox = meuComboBox1;
      }

      private void MeuComboBoxRound_Load(object sender, EventArgs e) {
         meuComboBox1.Location = new Point(10, (Size.Height / 2) - (meuComboBox1.Size.Height / 2));
         meuComboBox1.Size = new Size(this.Size.Width - 20, this.Size.Height - 20);
         meuComboBox1.FlatStyle = FlatStyle.Flat;

         meuComboBox1.Font = Fonts.main12;
         meuComboBox1.ForeColor = Colors.primaryText;

         meuComboBox1.BackColor = backColor;
      }

      protected override void OnPaint(PaintEventArgs e) {
         base.OnPaint(e);
         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

         Rectangle rect = new Rectangle(1, 1, Size.Width - 2, Size.Height - 2);

         drawBackLine(e.Graphics, rect, new SolidBrush(backColor));
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
