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
using System.Runtime.InteropServices;
using ProjBoletos.utils;

namespace ProjBoletos.components {
   public partial class MeuTextbox : UserControl {

      public TextBox txtBox;

      public bool isPassword = false;

      Color backColor = Color.FromArgb(210, 210, 210);

      Color colorHint = Color.FromArgb(100, 100, 100);
      Color colorNormal = Color.FromArgb(20, 20, 20);

      Font fontHint = Fonts.mainBold8;
      Font fontNormal = Fonts.main10;

      public string hint = "";
      public bool useHint = true;

      public bool isEmpty = true;

      public MeuTextbox() {
         InitializeComponent();

      }

      public MeuTextbox(bool useHint) {
         InitializeComponent();

         this.useHint = useHint;
      }

      private void MeuTextbox_Load(object sender, EventArgs e) {
         BackColor = Color.White;

         textBox1.Multiline = false;
         textBox1.Location = new Point(10, (Size.Height / 2) - (textBox1.Size.Height / 2));
         textBox1.Size = new Size(this.Size.Width - 20, this.Size.Height - 20);

         if (useHint) {
            textBox1.Text = hint;
            textBox1.ForeColor = colorHint;
            textBox1.Font = fontHint;
         } else {
            textBox1.ForeColor = colorNormal;
            textBox1.Font = fontNormal;
         }

         textBox1.GotFocus += RemoveText;
         textBox1.LostFocus += AddText;
         
         textBox1.BackColor = backColor;

         if (isPassword) textBox1.PasswordChar = '\0';

         textBox1.TextAlign = HorizontalAlignment.Center;

         txtBox = textBox1;
      }

      protected override void OnPaint(PaintEventArgs e) {
         base.OnPaint(e);
         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

         Rectangle rect = new Rectangle(1, 1, Size.Width - 2, Size.Height - 2);

         drawBackLine(e, rect, new SolidBrush(backColor));
      }

      private void drawBackLine(PaintEventArgs e, Rectangle rect, Brush brush) {
         GraphicsPath p = new GraphicsPath();
         p.AddArc(new Rectangle(rect.X, rect.Y, rect.Height, rect.Height), 90, 180);
         p.AddLine(new Point(rect.Height / 2, rect.Y), new Point(rect.Width - (rect.Height / 2), rect.Y));
         p.AddArc(new Rectangle(rect.Width - rect.Height, rect.Y, rect.Height, rect.Height), -90, 180);
         p.CloseFigure();

         e.Graphics.FillPath(brush, p);
         /*e.Graphics.DrawArc(pen, new Rectangle(rect.X, rect.Y, rect.Height, rect.Height), 90, 180);
         e.Graphics.DrawLine(pen, new Point(rect.Height / 2, rect.Y), new Point(rect.Width - rect.Height / 2, rect.Y));
         e.Graphics.DrawLine(pen, new Point(rect.Height / 2, rect.Height + rect.Y), new Point(rect.Width - rect.Height / 2, rect.Height + rect.Y));
         e.Graphics.DrawArc(pen, new Rectangle(rect.Width - rect.Height, rect.Y, rect.Height, rect.Height), 90, -180);*/
      }

      public void RemoveText(object sender, EventArgs e) {
         if (useHint) {
            if (textBox1.Text == hint) {
               textBox1.Text = "";
               textBox1.ForeColor = colorNormal;
               textBox1.Font = fontNormal;

               isEmpty = false;

               if (isPassword) textBox1.PasswordChar = '*';
            }
         }
      }

      public void AddText(object sender, EventArgs e) {
         if (useHint) {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) {
               textBox1.Text = hint;
               textBox1.ForeColor = colorHint;
               textBox1.Font = fontHint;

               isEmpty = true;

               if (isPassword) textBox1.PasswordChar = '\0';
            }
         }
      }
   }
}
