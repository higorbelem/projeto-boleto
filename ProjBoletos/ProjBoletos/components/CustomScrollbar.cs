using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;


namespace CustomControls {

    [Designer(typeof(ScrollbarControlDesigner))]
    public class CustomScrollbar : UserControl {

        public Color backgroundColor = ColorTranslator.FromHtml("#FFFFFF");
        public Color color = ColorTranslator.FromHtml("#FF0000");
        public Color btnsColor = ColorTranslator.FromHtml("#FFFF00");

        protected Color moChannelColor = Color.Empty;
        protected Image UpArrowImage = null;
        //protected Image moUpArrowImage_Over = null;
        //protected Image moUpArrowImage_Down = null;
        protected Image DownArrowImage = null;
        //protected Image moDownArrowImage_Over = null;
        //protected Image moDownArrowImage_Down = null;
        protected Image ThumbArrowImage = null;

        protected Image ThumbTopImage = null;
        protected Image ThumbTopSpanImage = null;
        protected Image ThumbBottomImage = null;
        protected Image ThumbBottomSpanImage = null;
        protected Image ThumbMiddleImage = null;

        protected int moLargeChange = 10;
        protected int moSmallChange = 1;
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;
        private int nClickPoint;

        protected int moThumbTop = 0;

        protected bool moAutoSize = false;

        private bool moThumbDown = false;
        private bool moThumbDragging = false;

        public new event EventHandler Scroll = null;
        public event EventHandler ValueChanged = null;

        private int GetThumbHeight()
        {
            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            return nThumbHeight;
        }

        public CustomScrollbar() {

            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            moChannelColor = Color.FromArgb(51, 166, 3);
            UpArrowImage = new Bitmap(ProjBoletos.Properties.Resources.icon_person1,new Size(ClientRectangle.Width,20));
            DownArrowImage = new Bitmap(ProjBoletos.Properties.Resources.icon_person1, new Size(ClientRectangle.Width, 20));


            ThumbBottomImage = new Bitmap(ProjBoletos.Properties.Resources.icon_person1, new Size(ClientRectangle.Width, 20));
            ThumbBottomSpanImage = new Bitmap(ProjBoletos.Properties.Resources.icon_person1, new Size(ClientRectangle.Width, 20));
            ThumbTopImage = new Bitmap(ProjBoletos.Properties.Resources.icon_person1, new Size(ClientRectangle.Width, 20));
            ThumbTopSpanImage = new Bitmap(ProjBoletos.Properties.Resources.icon_person1, new Size(ClientRectangle.Width, 20));
            ThumbMiddleImage = new Bitmap(ProjBoletos.Properties.Resources.icon_person1, new Size(ClientRectangle.Width, 20));

            this.Width = UpArrowImage.Width;
            base.MinimumSize = new Size(UpArrowImage.Width, UpArrowImage.Height + DownArrowImage.Height + GetThumbHeight());
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("LargeChange")]
        public int LargeChange {
            get { return moLargeChange; }
            set { moLargeChange = value;
            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("SmallChange")]
        public int SmallChange {
            get { return moSmallChange; }
            set { moSmallChange = value;
            Invalidate();    
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Minimum")]
        public int Minimum {
            get { return moMinimum; }
            set { moMinimum = value;
            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Maximum")]
        public int Maximum {
            get { return moMaximum; }
            set { moMaximum = value;
            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Value")]
        public int Value {
            get { return moValue; }
            set { moValue = value;

            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            //figure out value
            int nPixelRange = nTrackHeight - nThumbHeight;
            int nRealRange = (Maximum - Minimum)-LargeChange;
            float fPerc = 0.0f;
            if (nRealRange != 0)
            {
                fPerc = (float)moValue / (float)nRealRange;
                
            }
            
            float fTop = fPerc * nPixelRange;
            moThumbTop = (int)fTop;
            

            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Channel Color")]
        public Color ChannelColor
        {
            get { return moChannelColor; }
            set { moChannelColor = value; }
        }

        

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), ClientRectangle);

            //top button
            e.Graphics.FillRectangle(new SolidBrush(btnsColor), new Rectangle(0, 0, ClientRectangle.Width, UpArrowImage.Height));

            //bottom button
            e.Graphics.FillRectangle(new SolidBrush(btnsColor), new Rectangle(0, Height - DownArrowImage.Height, ClientRectangle.Width, DownArrowImage.Height));


            int nTop = moThumbTop;
            nTop += UpArrowImage.Height;

            e.Graphics.FillRectangle(new SolidBrush(color), new Rectangle(0,nTop,ClientRectangle.Width, nThumbHeight));
            /*if (UpArrowImage != null) {
                e.Graphics.DrawImage(UpArrowImage, new Rectangle(new Point(0,0), new Size(this.Width, UpArrowImage.Height)));
            }

            Brush oBrush = new SolidBrush(moChannelColor);
            Brush oWhiteBrush = new SolidBrush(Color.FromArgb(255,255,255));
            
            //draw channel left and right border colors
            e.Graphics.FillRectangle(oWhiteBrush, new Rectangle(0,UpArrowImage.Height, 1, (this.Height-DownArrowImage.Height)));
            e.Graphics.FillRectangle(oWhiteBrush, new Rectangle(this.Width-1, UpArrowImage.Height, 1, (this.Height - DownArrowImage.Height)));
            
            //draw channel
            e.Graphics.FillRectangle(oBrush, new Rectangle(1, UpArrowImage.Height, this.Width-2, (this.Height-DownArrowImage.Height)));

            //draw thumb
            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight) {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56) {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            //Debug.WriteLine(nThumbHeight.ToString());

            float fSpanHeight = (fThumbHeight - (ThumbMiddleImage.Height + ThumbTopImage.Height + ThumbBottomImage.Height)) / 2.0f;
            int nSpanHeight = (int)fSpanHeight;

            int nTop = moThumbTop;
            nTop += UpArrowImage.Height;

            //draw top
            e.Graphics.DrawImage(ThumbTopImage, new Rectangle(1, nTop, this.Width - 2, ThumbTopImage.Height));

            nTop += ThumbTopImage.Height;
            //draw top span
            Rectangle rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight);


            e.Graphics.DrawImage(ThumbTopSpanImage, 1.0f,(float)nTop, (float)this.Width-2.0f, (float) fSpanHeight*2);

            nTop += nSpanHeight;
            //draw middle
            e.Graphics.DrawImage(ThumbMiddleImage, new Rectangle(1, nTop, this.Width - 2, ThumbMiddleImage.Height));


            nTop += ThumbMiddleImage.Height;
            //draw top span
            rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight*2);
            e.Graphics.DrawImage(ThumbBottomSpanImage, rect);

            nTop += nSpanHeight;
            //draw bottom
            e.Graphics.DrawImage(ThumbBottomImage, new Rectangle(1, nTop, this.Width - 2, nSpanHeight));
            
            if (DownArrowImage != null) {
                e.Graphics.DrawImage(DownArrowImage, new Rectangle(new Point(0, (this.Height-DownArrowImage.Height)), new Size(this.Width, DownArrowImage.Height)));
            }*/

        }

        public override bool AutoSize {
            get {
                return base.AutoSize;
            }
            set {
                base.AutoSize = value;
                if (base.AutoSize) {
                    this.Width = UpArrowImage.Width;
                }
            }
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // CustomScrollbar
            // 
            this.Name = "CustomScrollbar";
            this.Load += new System.EventHandler(this.CustomScrollbar_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseUp);
            this.ResumeLayout(false);

        }

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e) {
            Point ptPoint = this.PointToClient(Cursor.Position);
            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight) {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56) {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nTop = moThumbTop;
            nTop += UpArrowImage.Height;


            Rectangle thumbrect = new Rectangle(new Point(0, nTop), new Size(ThumbMiddleImage.Width, nThumbHeight));
            if (thumbrect.Contains(ptPoint))
            {
                //hit the thumb
                nClickPoint = (ptPoint.Y - nTop);
                //MessageBox.Show(Convert.ToString((ptPoint.Y - nTop)));
                this.moThumbDown = true;
            }

            Rectangle uparrowrect = new Rectangle(new Point(0, 0), new Size(UpArrowImage.Width, UpArrowImage.Height));
            if (uparrowrect.Contains(ptPoint))
            {

                int nRealRange = (Maximum - Minimum)-LargeChange;
                int nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((moThumbTop - SmallChange) < 0)
                            moThumbTop = 0;
                        else
                            moThumbTop -= SmallChange;

                        //figure out value
                        float fPerc = (float)moThumbTop / (float)nPixelRange;
                        float fValue = fPerc * (Maximum - LargeChange);
                        
                            moValue = (int)fValue;
                        Debug.WriteLine(moValue.ToString());

                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());

                        if (Scroll != null)
                            Scroll(this, new EventArgs());

                        Invalidate();
                    }
                }
            }

            Rectangle downarrowrect = new Rectangle(new Point(0, UpArrowImage.Height+nTrackHeight), new Size(UpArrowImage.Width, UpArrowImage.Height));
            if (downarrowrect.Contains(ptPoint))
            {
                int nRealRange = (Maximum - Minimum) - LargeChange;
                int nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((moThumbTop + SmallChange) > nPixelRange)
                            moThumbTop = nPixelRange;
                        else
                            moThumbTop += SmallChange;

                        //figure out value
                        float fPerc = (float)moThumbTop / (float)nPixelRange;
                        float fValue = fPerc * (Maximum-LargeChange);
                       
                            moValue = (int)fValue;
                        Debug.WriteLine(moValue.ToString());

                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());

                        if (Scroll != null)
                            Scroll(this, new EventArgs());

                        Invalidate();
                    }
                }
            }
        }

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e) {
            this.moThumbDown = false;
            this.moThumbDragging = false;
        }

        private void MoveThumb(int y) {
            int nRealRange = Maximum - Minimum;
            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight) {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56) {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nSpot = nClickPoint;

            int nPixelRange = (nTrackHeight - nThumbHeight);
            if (moThumbDown && nRealRange > 0) {
                if (nPixelRange > 0) {
                    int nNewThumbTop = y - (UpArrowImage.Height+nSpot);
                    
                    if(nNewThumbTop<0)
                    {
                        moThumbTop = nNewThumbTop = 0;
                    }
                    else if(nNewThumbTop > nPixelRange)
                    {
                        moThumbTop = nNewThumbTop = nPixelRange;
                    }
                    else {
                        moThumbTop = y - (UpArrowImage.Height + nSpot);
                    }
                   
                    //figure out value
                    float fPerc = (float)moThumbTop / (float)nPixelRange;
                    float fValue = fPerc * (Maximum-LargeChange);
                    moValue = (int)fValue;
                    Debug.WriteLine(moValue.ToString());

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e) {
            if(moThumbDown == true)
            {
                this.moThumbDragging = true;
            }

            if (this.moThumbDragging) {

                MoveThumb(e.Y);
            }

            if(ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if(Scroll != null)
                Scroll(this, new EventArgs());
        }

        private void CustomScrollbar_Load(object sender, EventArgs e) {

        }
    }

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class ScrollbarControlDesigner : System.Windows.Forms.Design.ControlDesigner {
        
        public override SelectionRules SelectionRules {
            get {
                SelectionRules selectionRules = base.SelectionRules;
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(this.Component)["AutoSize"];
                if (propDescriptor != null) {
                    bool autoSize = (bool)propDescriptor.GetValue(this.Component);
                    if (autoSize) {
                        selectionRules = SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }
                    else {
                        selectionRules = SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;
                    }
                }
                return selectionRules;
            }
        } 
    }
}