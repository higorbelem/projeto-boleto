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
    public partial class AccountButton : UserControl {
        public Color normalColor = ColorTranslator.FromHtml("#383a3d");
        public Color onEnterColor = ColorTranslator.FromHtml("#5e6166");
        public Color onClickColor = ColorTranslator.FromHtml("#83878d");

        public string title = "LOGARA";

        Color atualColor;

        public PictureBoxWithInterpolationMode icon;
        public PictureBoxWithInterpolationMode dropIcon;

        public int imagePadding = 8;
        public int distIconString = 5;
        public int marginLeftIcon = 5;

        public int marginRightDropIcon = 10;


        public AccountButton() {
            InitializeComponent();
            icon = icon1;
            dropIcon = dropIcon1;
        }

        private void AccountButton_Load(object sender, EventArgs e) {
            atualColor = normalColor;

            icon1.BackColor = atualColor;
            icon1.Location = new Point(imagePadding + marginLeftIcon, imagePadding);
            icon1.Size = new Size(Height - imagePadding * 2, Height - imagePadding * 2);
            icon1.SizeMode = PictureBoxSizeMode.StretchImage;

            dropIcon1.BackColor = atualColor;
            dropIcon1.Size = new Size(25,25);
            dropIcon1.Location = new Point(Width - dropIcon1.Width - marginRightDropIcon, (Height/2) - (dropIcon1.Height/2));
            dropIcon1.SizeMode = PictureBoxSizeMode.StretchImage;

            GotFocus += onFocus;
            LostFocus += offFocus;
            icon1.GotFocus += onFocus;
            icon1.LostFocus += offFocus;
            dropIcon1.GotFocus += onFocus;
            dropIcon1.LostFocus += offFocus;

            icon1.MouseEnter += new EventHandler(OnMouseEnter);
            icon1.MouseLeave += new EventHandler(OnMouseLeave);
            icon1.MouseUp += new MouseEventHandler(OnMouseUp);
            icon1.MouseDown += new MouseEventHandler(OnMouseDown);
            dropIcon1.MouseEnter += new EventHandler(OnMouseEnter);
            dropIcon1.MouseLeave += new EventHandler(OnMouseLeave);
            dropIcon1.MouseUp += new MouseEventHandler(OnMouseUp);
            dropIcon1.MouseDown += new MouseEventHandler(OnMouseDown);
        }

        protected override void OnMouseEnter(EventArgs e) {
            OnMouseEnter(null,e);
        }
        public void OnMouseEnter(object sender, EventArgs e) {
            atualColor = onEnterColor;
            icon1.BackColor = atualColor;
            dropIcon1.BackColor = atualColor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e) {
            OnMouseLeave(null,e);
        }
        public void OnMouseLeave(object sender, EventArgs e) {
            atualColor = normalColor;
            icon1.BackColor = atualColor;
            dropIcon1.BackColor = atualColor;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent) {
            OnMouseDown(null, mevent);
        }
        public void OnMouseDown(object sender, MouseEventArgs e) {
            atualColor = onClickColor;
            icon1.BackColor = atualColor;
            dropIcon1.BackColor = atualColor;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent) {
            OnMouseUp(null, mevent);
        }
        public void OnMouseUp(object sender, MouseEventArgs e) {
            atualColor = onEnterColor;
            icon1.BackColor = atualColor;
            dropIcon1.BackColor = atualColor;
            Invalidate();
        }

        public void onFocus(object sender, EventArgs e) {
            atualColor = onEnterColor;
            icon1.BackColor = atualColor;
            dropIcon1.BackColor = atualColor;
            Invalidate();
        }

        public void offFocus(object sender, EventArgs e) {
            atualColor = normalColor;
            icon1.BackColor = atualColor;
            dropIcon1.BackColor = atualColor;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Rectangle rectangle = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

            Brush brush = new SolidBrush(atualColor);

            e.Graphics.FillRectangle(brush, rectangle);

            Rectangle rectForString = new Rectangle(icon1.Size.Width + icon1.Location.X + distIconString, 0, this.Size.Width - icon1.Size.Width, this.Size.Height);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(title, Fonts.mainBold10, new SolidBrush(Color.White), rectForString, sf);
            
        }
    }
}
