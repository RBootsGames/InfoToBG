using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InfoToBG
{
    public partial class Ctrl_RadioButtons : UserControl
    {
        bool _selected = false;

        [Category("Special Controls")]
        public Color HighlightColor
        {
            get { return highlight.BackColor; }
            set { highlight.BackColor = value; }
        }

        [Category("Special Controls")]
        public string DisplayText
        {
            get { return lbl_Text.Text; }
            set { lbl_Text.Text = value; }
        }

        [Category("Special Controls")]
        public Font DisplayFont
        {
            get { return lbl_Text.Font; }
            set { lbl_Text.Font = value; }
        }

        [Category("Special Controls")]
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (this.Parent == null) return;
                if (value)
                {
                    foreach (Control ctrl in this.Parent.Controls)
                    {
                        if (ctrl.GetType() == typeof(Ctrl_RadioButtons))
                        {
                            if (ctrl != this)
                                (ctrl as Ctrl_RadioButtons).Selected = false;
                        }
                    }
                }

                animTimer.Start();
            }
        }

        [Category("Action"), Description("Invoked when button is clicked")]
        public event EventHandler ButtonClick;


        public Ctrl_RadioButtons()
        {
            InitializeComponent();
            hightlightSize = bottomArea.Height;
        }

        private void ControlLoad(object sender, EventArgs e)
        {
            if (Selected)
                highlight.Height = hightlightSize;
            else
                highlight.Height = 0;

        }

        private void ControlClick(object sender, EventArgs e)
        {
            Selected = true;

            if (ButtonClick != null)
                ButtonClick(this, e);
        }

        int Clamp(int input, int min, int max)
        {
            if (input < min)
                input = min;
            else if (input > max)
                input = max;

            return input;
        }

        int hightlightSize = 5;
        int animInterval = 1;
        private void animTimer_Tick(object sender, EventArgs e)
        {
            if (Selected)
            {
                highlight.Height = Clamp(highlight.Height + animInterval, 0, hightlightSize);
                //bottomArea.Height = Clamp(bottomArea.Height - animInterval, 0, hightlightSize);
            }
            else
            {
                highlight.Height = Clamp(highlight.Height - animInterval, 0, hightlightSize);
                //bottomArea.Height = Clamp(bottomArea.Height + animInterval, 0, hightlightSize);
            }

            if (highlight.Height == 0 || highlight.Height == hightlightSize)
                animTimer.Stop();
        }

        private void lbl_Text_MouseEnter(object sender, EventArgs e)
        {
            lbl_Text.BackColor = Color.FromArgb(10, Color.White);
        }

        private void lbl_Text_MouseLeave(object sender, EventArgs e)
        {
            lbl_Text.BackColor = Color.FromArgb(0, Color.White);
        }
    }
}
