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
    public partial class SidebarButton : UserControl {

        public Color normalColor = ColorTranslator.FromHtml("#434549");
        public Color onEnterColor = ColorTranslator.FromHtml("#595c62");
        public Color onClickColor = ColorTranslator.FromHtml("#747881");
        public Color titleColor = Color.White;

        public Color selectedColor = Colors.accent1;

        public string title = "LOGARA";

        Color atualColor;

        public PictureBox icon;

        public int imagePadding = 12;
        public int distIconString = 10;
        public int marginLeftIcon = 10;

        public bool selected = false;

        public SidebarButton() {
            InitializeComponent();
            icon = icon1;
        }

        private void SidebarButton_Load(object sender, EventArgs e) {
            atualColor = normalColor;

            icon1.BackColor = atualColor;
            icon1.Location = new Point(imagePadding + marginLeftIcon, imagePadding);
            icon1.Size = new Size(Height - imagePadding*2, Height - imagePadding*2);
            icon1.SizeMode = PictureBoxSizeMode.StretchImage;

            GotFocus += onFocus;
            LostFocus += offFocus;
            icon1.GotFocus += onFocus;
            icon1.LostFocus += offFocus;

            icon1.MouseEnter += new EventHandler(OnMouseEnter);
            icon1.MouseLeave += new EventHandler(OnMouseLeave);
            icon1.MouseUp += new MouseEventHandler(OnMouseUp);
            icon1.MouseDown += new MouseEventHandler(OnMouseDown);
        }

        protected override void OnMouseEnter(EventArgs e) {
            OnMouseEnter(null, e);
        }
        public void OnMouseEnter(object sender, EventArgs e) {
            atualColor = onEnterColor;
            icon1.BackColor = atualColor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e) {
            OnMouseLeave(null, e);
        }
        public void OnMouseLeave(object sender, EventArgs e) {
            atualColor = normalColor;
            icon1.BackColor = atualColor;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent) {
            OnMouseDown(null, mevent);
        }
        public void OnMouseDown(object sender, MouseEventArgs e) {
            atualColor = onClickColor;
            icon1.BackColor = atualColor;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent) {
            OnMouseUp(null, mevent);
        }
        public void OnMouseUp(object sender, MouseEventArgs e) {
            atualColor = onEnterColor;
            icon1.BackColor = atualColor;
            Invalidate();
        }

        public void onFocus(object sender, EventArgs e) {
            atualColor = onEnterColor;
            icon1.BackColor = atualColor;
            Invalidate();
        }

        public void offFocus(object sender, EventArgs e) {
            atualColor = normalColor;
            icon1.BackColor = atualColor;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectangle = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

            Brush brush = new SolidBrush(atualColor);

            e.Graphics.FillRectangle(brush,rectangle);
            
            Rectangle rectForString= new Rectangle(icon1.Size.Width + icon1.Location.X + distIconString, 0, this.Size.Width - icon1.Size.Width, ClientRectangle.Height);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(title, Fonts.mainBold10, new SolidBrush(titleColor), rectForString, sf);

            if (selected) {
                int selectedWidth = 7;
                Rectangle rectSelected = new Rectangle(Size.Width - selectedWidth, 0, selectedWidth, this.Size.Height);
                e.Graphics.FillRectangle(new SolidBrush(selectedColor), rectSelected);
            }
            
            /*GraphicsPath path = RoundedRectangles.Create(rectangle, 5);

            Brush brush = new SolidBrush(atualColor);

            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(new Pen(brush), path);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString("LOGAR", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.White), ClientRectangle, sf);
            */
        }
    }
}
