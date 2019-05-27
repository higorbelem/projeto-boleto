using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.utils;

namespace ProjBoletos.components {
    public partial class RectangleButton : UserControl {
        public Color normalColor = ColorTranslator.FromHtml("#e6e6e6");
        public Color onEnterColor = ColorTranslator.FromHtml("#595c62");
        public Color onClickColor = ColorTranslator.FromHtml("#747881");

        public Color unselectedTitleColor = ColorTranslator.FromHtml("#8c8c8c");
        public Color selectedTitleColor = ColorTranslator.FromHtml("#404040");
        public Color atualTitleColor = ColorTranslator.FromHtml("#8c8c8c");

        public string title = "LOGARA";

        Color atualColor;


        public int imagePadding = 12;
        public int distIconString = 10;
        public int marginLeftIcon = 10;

        public bool selected = false;

        public RectangleButton() {
            InitializeComponent();
        }

        private void RectangleButton_Load(object sender, EventArgs e) {
            GotFocus += onFocus;
            LostFocus += offFocus;
        }

        private void RectangleButton_Resize(object sender, EventArgs e) {
            atualColor = normalColor;
        }

        protected override void OnMouseEnter(EventArgs e) {
            OnMouseEnter(null, e);
        }
        public void OnMouseEnter(object sender, EventArgs e) {
            atualColor = onEnterColor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e) {
            OnMouseLeave(null, e);
        }
        public void OnMouseLeave(object sender, EventArgs e) {
            atualColor = normalColor;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent) {
            OnMouseDown(null, mevent);
        }
        public void OnMouseDown(object sender, MouseEventArgs e) {
            atualColor = onClickColor;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent) {
            OnMouseUp(null, mevent);
        }
        public void OnMouseUp(object sender, MouseEventArgs e) {
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
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectangle = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);

            Brush brush = new SolidBrush(atualColor);

            e.Graphics.FillRectangle(brush, rectangle);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            if (selected) {
                atualTitleColor = selectedTitleColor;
            } else {
                atualTitleColor = unselectedTitleColor;
            }
            e.Graphics.DrawString(title, Fonts.main12, new SolidBrush(atualTitleColor), rectangle, sf);

            if (selected) {
                int selectedWidth = 3;
                Rectangle rectSelected = new Rectangle(0, ClientRectangle.Height - selectedWidth, ClientRectangle.Width, selectedWidth);
                e.Graphics.FillRectangle(new SolidBrush(unselectedTitleColor), rectSelected);
            }
        }
    }
}
