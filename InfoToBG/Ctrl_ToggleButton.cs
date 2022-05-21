using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Drawing.Drawing2D;

namespace InfoToBG
{
    public partial class Ctrl_ToggleButton : UserControl
    {
        #region Local variables
        Image _deselectImage;
        bool _isSelected;
        int _iconSize = 45;
        int _iconRightSpacing = 0;
        Color _highlightColor = Color.FromArgb(97, 209, 228);
        #endregion

        [Category("Special Controls")]
        public Font TextFont
        {
            get { return button1.Font; }
            set { button1.Font = value; }
        }

        [Category("Special Controls")]
        public Color TextColor
        {
            get { return button1.ForeColor; }
            set { button1.ForeColor = value; }
        }

        [Description("Display text"), Category("Special Controls")]
        public string TextDisplay
        {
            get
            {
                return button1.Text;
            }
            set
            {
                button1.Text = value;
            }
        }


        [Description("This is the image that displays when the item is not checked"), Category("Special Controls")]
        public Image ImageDeselected
        {
            get { return _deselectImage; }
            set
            {
                _deselectImage = value;
                picBox.Image = _deselectImage;
            }
        }

        [Description("This is the image that displays when the item is checked"), Category("Special Controls")]
        public Image ImageSelected { get; set; }

        [Category("Special Controls")]
        public int IconSize
        {
            get { return _iconSize; }
            set
            {
                _iconSize = value;
                picBox.Width = _iconSize;
            }
        }

        [Category("Special Controls")]
        public int IconRightSpacing
        {
            get { return _iconRightSpacing; }
            set
            {
                _iconRightSpacing = value;
                spacer.Width = _iconRightSpacing;
            }
        }

        [Category("Special Controls")]
        public Color CheckHighlightColor
        {
            get { return highlight.BackColor; }
            set
            {
                highlight.BackColor = value;
            }
        }

        [Category("Special Controls")]
        public bool Checked
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                int alpha = value ? 255 : 0;
                highlight.BackColor = Color.FromArgb(alpha, highlight.BackColor);
                //highlight.BackColor = Color.FromArgb(0, highlight.BackColor);

                //Image img = new Bitmap(highlight.Width, highlight.Height);
                //LinearGradientBrush gradient = new LinearGradientBrush(new Point(0, 0), new Point(img.Width, 0), Color.Transparent, Color.FromArgb(alpha, highlight.BackColor));
                //using (Graphics g = Graphics.FromImage(img))
                //{
                //    g.FillRectangle(gradient, 0, 0, img.Width, img.Height);
                //}
                //_highlightGradient = img;

                //highlight.BackgroundImage = _highlightGradient;

                if (value)
                {
                    picBox.Image = ImageSelected;

                }
                else
                    picBox.Image = ImageDeselected;
            }
        }


        [Category("Special Controls")]
        public Color MouseOverColor { get; set; }
        [Category("Special Controls")]
        public Color MouseDownColor { get; set; }



        //bool IsMouseOver() => this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));

        public Ctrl_ToggleButton()
        {
            InitializeComponent();

        }

        private void Ctrl_ToggleButton_Load(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = MouseOverColor;
            button1.FlatAppearance.MouseDownBackColor = MouseDownColor;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Checked = !Checked;
            button1.Focus();
        }

        private void MouseOver(object sender, EventArgs e)
        {
            picBox.BackColor = MouseOverColor;
            spacer.BackColor = MouseOverColor;

            if (sender.GetType() != typeof(Button))
            {
                button1.BackColor = MouseOverColor;
            }
        }

        private void MouseExit(object sender, EventArgs e)
        {
            picBox.BackColor = Color.Transparent;
            spacer.BackColor = Color.Transparent;

            if (sender.GetType() != typeof(Button))
            {
                button1.BackColor = Color.Transparent;
            }
        }
    }
}
