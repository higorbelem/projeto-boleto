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


        public Color normalColor = ColorTranslator.FromHtml("#3289d8");
        public Color onEnterColor = ColorTranslator.FromHtml("#509ade");
        public Color onClickColor = ColorTranslator.FromHtml("#75b0e6");

        Color atualColor;

        public String title = "LOGAR";
        public int cornerRadius = 5;

        public MeuButton() {
            InitializeComponent();

            atualColor = normalColor;
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

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectangle = new Rectangle(1, 1, this.Size.Width-2, this.Size.Height-2);

            GraphicsPath path = RoundedRectangles.Create(rectangle , cornerRadius);

            Brush brush = new SolidBrush(atualColor);

            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(new Pen(brush), path);
            
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(title, Fonts.mainBold10, new SolidBrush(Color.White), ClientRectangle, sf);
        }
    }
}
