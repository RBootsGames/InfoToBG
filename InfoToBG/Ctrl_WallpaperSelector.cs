using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InfoToBG
{
    public partial class Ctrl_WallpaperSelector : UserControl
    {
        // local variables
        Image l_ImageDisplay;
        Image l_ImageMouseOver;
        int l_OverlayOpacity = 50;
        //Image imageOverlay;

        bool usingOverlay { get { return ImageMouseOver == null ? true : false; } }


        [Category("Special Controls")]
        public Image ImageDisplay
        {
            get
            {
                return l_ImageDisplay;
            }
            set
            {
                l_ImageDisplay = value;
                image.BackgroundImage = l_ImageDisplay;
            }
        }

        [Category("Special Controls")]
        public Image ImageMouseOver
        {
            get
            {
                if (l_ImageMouseOver != null)
                {
                    return l_ImageMouseOver;
                }
                else
                {
                    Image imageOverlay;

                    if (ImageDisplay != null)
                        imageOverlay = ImageDisplay.Clone() as Image;
                    else
                        imageOverlay = new Bitmap(image.Width, image.Height);

                    using (Graphics graphics = Graphics.FromImage(imageOverlay))
                    {
                        Brush b = new SolidBrush(Color.FromArgb(OverlayOpacity, OverlayColor));
                        graphics.FillRectangle(b, 0, 0, imageOverlay.Width, imageOverlay.Height);
                        graphics.Dispose();
                    }

                    return imageOverlay;
                }
            }
            set
            {
                l_ImageMouseOver = value;
            }
        }

        [Category("Special Controls")]
        public Image ImageMouseClick { get; set; }

        [Category("Special Controls"), Description("This will only be used if a mouse over image isn't being used.")]
        public Color OverlayColor { get; set; } = Color.White;

        [Category("Special Controls"), Description("This will only be used if a mouse over image isn't being used.")]
        public int OverlayOpacity
        {
            get { return l_OverlayOpacity; }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > 255)
                    value = 255;

                l_OverlayOpacity = value;
            }
        }

        [Browsable(true), Category("Action"), Description("Invoked when button is clicked")]
        public event EventHandler ButtonClick;


        public Ctrl_WallpaperSelector()
        {
            InitializeComponent();
        }

        private void image_MouseEnter(object sender, EventArgs e)
        {
            image.BackgroundImage = ImageMouseOver;
        }
        private void image_MouseLeave(object sender, EventArgs e)
        {
            image.BackgroundImage = ImageDisplay;
        }

        private void image_MouseDown(object sender, MouseEventArgs e)
        {
            if ((ImageMouseClick == null))
                return;

            image.BackgroundImage = ImageMouseClick;
        }

        private void image_MouseUp(object sender, MouseEventArgs e)
        {
            if (ImageMouseOver != null)
                image.BackgroundImage = ImageMouseOver;
            else
                image.BackgroundImage = ImageDisplay;
        }

        private void image_Click(object sender, EventArgs e)
        {
            if (ButtonClick != null)
                ButtonClick(this, e);
        }
    }
}
