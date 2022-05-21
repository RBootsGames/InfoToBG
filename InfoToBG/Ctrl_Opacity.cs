using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoToBG
{
    public partial class Ctrl_Opacity : UserControl
    {
        int l_Percentage;
        bool l_MaxAtTop = true;


        [Category("Special Controls")]
        public Color BackgroundColor
        {
            get => BackColor;
            set => BackColor = value;
        }

        [Category("Special Controls")]
        public Color ScrollerColor
        {
            get => scroller.BackColor;
            set => scroller.BackColor = value;
        }

        [Category("Special Controls")]
        public bool MaxAtTop
        {
            get => l_MaxAtTop;
            set
            {
                l_MaxAtTop = value;
                Percentage = Percentage;
            }
        }

        [Category("Special Controls")]
        public int Percentage
        {
            get => l_Percentage;
            set
            {
                if (value < 0)
                    l_Percentage = 0;
                else if (value > 100)
                    l_Percentage = 100;
                else
                    l_Percentage = value;
                
                int max = Height - ScrollerHeight;

                float pos = max * (l_Percentage / 100f);
                if (MaxAtTop)
                    pos = max - pos;
                scroller.Location = new Point(0, (int)pos);
            }
        }

        [Category("Special Controls")]
        public int ScrollerHeight
        {
            get => scroller.Height;
            set
            {
                scroller.Height = value;
                Percentage = Percentage;
            }
        }


        [Browsable(true), Category("Action"), Description("Invoked when the scroller is moved.")]
        public event EventHandler ValueChanged;

        public Ctrl_Opacity()
        {
            InitializeComponent();
            scroller.Width = this.Width;
            ScrollerHeight = ScrollerHeight;
        }


        Size mouseDownPos;
        Size panelStartPos;
        bool dragging = false;
        Size panelOffset;
        private void dragTimer_Tick(object sender, EventArgs e)
        {
            if (dragging)
            {
                int startPos = scroller.Location.Y;

                scroller.Width = this.Width;
                Point newPos = MousePosition - panelOffset;
                newPos.X = 0;

                //clamp
                if (newPos.Y < 0)
                    newPos.Y = 0;
                else if (newPos.Y > this.Height - scroller.Height)
                    newPos.Y = this.Height - scroller.Height;

                scroller.Location = newPos;

                // assign percentage value
                int max = Height - ScrollerHeight;
                int perc = Convert.ToInt32(((float)scroller.Location.Y / (float)max) * 100);
                l_Percentage = MaxAtTop ? (perc - 100) * -1 : perc;


                if (ValueChanged != null & scroller.Location.Y != startPos)
                {
                    ValueChanged(this, e);
                }
            }
        }
        private void scroller_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragTimer.Start();
            mouseDownPos = (Size)MousePosition;
            panelStartPos = (Size)scroller.Location;
            panelOffset = (Size)MousePosition - (Size)scroller.Location;
        }

        private void scroller_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            dragTimer.Stop();
        }

        private void Ctrl_Opacity_Resize(object sender, EventArgs e)
        {
            Percentage = Percentage;
        }
    }
}
