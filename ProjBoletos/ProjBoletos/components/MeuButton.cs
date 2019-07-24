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
using ProjBoletos.components;
using ProjBoletos.utils;

namespace ProjBoletos.testes {
   public partial class MeuButton : UserControl {
      
      private Color normalColor;
      private Color onEnterColor;
      private Color onClickColor;
      //public Color onEnterColor = ColorTranslator.FromHtml("#509ade");
      //public Color onClickColor = ColorTranslator.FromHtml("#75b0e6");

      Color atualColor;

      public String title = "";
      public int cornerRadius = 5;
      //public Bitmap img = new Bitmap(Properties.Resources.arrow_down);
      public Bitmap img;

      public MeuButton() {
         InitializeComponent();

         setColor(Colors.accent1);

         atualColor = normalColor;

         //buttonIcon.Image = new Bitmap(Properties.Resources.arrow_down);
      }

      private void ButtonTeste_Load(object sender, EventArgs e) {
         GotFocus += onFocus;
         LostFocus += offFocus;
      }

      protected override void OnMouseEnter(EventArgs e) {
         atualColor = onEnterColor;
         Invalidate();
      }
      
      protected override void OnMouseLeave(EventArgs e) {
         atualColor = normalColor;
         Invalidate();
      }
      
      protected override void OnMouseDown(MouseEventArgs mevent) {
         atualColor = onClickColor;
         Invalidate();
      }
      
      protected override void OnMouseUp(MouseEventArgs mevent) {
         atualColor = onEnterColor;
         Invalidate();
      }

      public void onFocus(object sender, EventArgs e) {
         atualColor = onEnterColor;
         Invalidate();
      }

      public void offFocus(object sender, EventArgs e) {
         atualColor = normalColor;
         Invalidate();
      }

      public void setColor(Color color) {
         normalColor = color;
         int r = normalColor.R - 20 > 255 ? 255 : normalColor.R - 20;
         int g = normalColor.G - 20 > 255 ? 255 : normalColor.G - 20;
         int b = normalColor.B - 20 > 255 ? 255 : normalColor.B - 20;
         onEnterColor = Color.FromArgb(255, r, g, b);
         r = onEnterColor.R - 20 > 255 ? 255 : onEnterColor.R - 20;
         g = onEnterColor.G - 20 > 255 ? 255 : onEnterColor.G - 20;
         b = onEnterColor.B - 20 > 255 ? 255 : onEnterColor.B - 20;
         onClickColor = Color.FromArgb(255, r, g, b);

         atualColor = normalColor;

         Invalidate();
      }

      protected override void OnPaint(PaintEventArgs e) {
         base.OnPaint(e);
         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
         
         Rectangle rectangle = new Rectangle(1, 1, this.ClientRectangle.Width - 2, this.ClientRectangle.Height - 2);

         GraphicsPath path = RoundedRectangles.Create(rectangle, cornerRadius);

         Brush brush = new SolidBrush(atualColor);

         e.Graphics.FillPath(brush, path);
         e.Graphics.DrawPath(new Pen(brush), path);

         //e.Graphics.DrawImage(teste,rectangle);

         if (img == null) {

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(title, Fonts.mainBold10, new SolidBrush(Color.White), rectangle, sf);

         } else if(title.Equals("")) {

            Rectangle rectangleImg = new Rectangle(rectangle.X + ((rectangle.Width/2) - ((rectangle.Height - 10)/2)), rectangle.Y + 5, rectangle.Height - 10, rectangle.Height - 10);
            e.Graphics.DrawImage(img, rectangleImg);

         } else {

            Rectangle rectangleImg = new Rectangle(rectangle.X + 5, rectangle.Y, (int)(rectangle.Width * 0.2),rectangle.Height);
            Rectangle actualRectangle;
            if (rectangleImg.Width < rectangleImg.Height) {
               actualRectangle = new Rectangle(rectangleImg.X, rectangleImg.Y + ((rectangleImg.Height/2) - (rectangleImg.Width/2)), rectangleImg.Width, rectangleImg.Width);
            } else {
               actualRectangle = new Rectangle(rectangleImg.X + ((rectangleImg.Width / 2) - (rectangleImg.Height / 2)), rectangleImg.Y, rectangleImg.Height, rectangleImg.Height);
            }
            e.Graphics.DrawImage(img, actualRectangle);

            Rectangle rectangleText = new Rectangle(rectangleImg.Width + rectangleImg.X, rectangle.Y, (int)(rectangle.Width * 0.8), rectangle.Height);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(title, Fonts.mainBold10, new SolidBrush(Color.White), rectangleText, sf);

         }
         
      }
   }
}
