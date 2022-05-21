using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using System.Threading;

namespace InfoToBG
{
    public partial class Ctrl_ProgressBar : UserControl
    {
        int _progress = 50;

        int nextProgress;
        bool stillUpdating = false;


        [Category("Special Controls")]
        public int Progress
        {
            get
            {
                if (stillUpdating)
                    return nextProgress;
                else
                    return _progress;
            }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > 100)
                    value = 100;

                nextProgress = value;

                if (!stillUpdating)
                {
                    //oldProgress = _progress;
                    stillUpdating = true;
                    //if (updatingTask == null || updatingTask.IsCompleted)
                    //    updatingTask = Task.Run(() => Updater());

                    updateTimer.Start();
                    BarColor = Color.FromArgb(255, BarColor);
                }
            }
        }

        [Category("Special Controls")]
        public Color BarColor
        {
            get { return progressBar.BackColor; }
            set { progressBar.BackColor = value; }
        }

        [Category("Special Controls")]
        public int StepInterval { get; set; } = 2;



        public Ctrl_ProgressBar()
        {
            InitializeComponent();
        }

        //void Updater()
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke((MethodInvoker)delegate () { Updater(); });
        //        Console.WriteLine("did it");
        //        return;
        //    }

        //    //updateTimer.Start();
        //    BarColor = Color.FromArgb(255, BarColor);

        //    do
        //    {
        //        _progress += StepInterval;

        //        _progress.Clamp(0, nextProgress);
        //        if (_progress == nextProgress)
        //        {
        //            updateTimer.Stop();
        //            stillUpdating = false;
        //        }


        //        float percent = _progress / 100f;

        //        progressBar.Width = Convert.ToInt32(this.Width * percent);
        //        // invert percent
        //        percent = Math.Abs(percent - 1);
        //        float totalHeight = .2f * this.Height;
        //        fillerTop.Height = Convert.ToInt32(totalHeight * percent);
        //        fillerBottom.Height = Convert.ToInt32(totalHeight * percent);


        //        Thread.Sleep(33);
        //    } while (_progress < nextProgress);

        //    //if (_progress == 100)
        //        fadeTimer.Start();
        //}

        private void Frm_ProgressBar_Resize(object sender, EventArgs e)
        {
            Progress = Progress;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            _progress += StepInterval;

            _progress.Clamp(0, nextProgress);
            if (_progress == nextProgress)
            {
                updateTimer.Stop();
                stillUpdating = false;
            }


            float percent = _progress / 100f;

            progressBar.Width = Convert.ToInt32(this.Width * percent);
            // invert percent
            percent = Math.Abs(percent - 1);
            float totalHeight = .2f * this.Height;
            fillerTop.Height = Convert.ToInt32(totalHeight * percent);
            fillerBottom.Height = Convert.ToInt32(totalHeight * percent);

            if (_progress == 100)
                fadeTimer.Start();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            int opacity = BarColor.A;
            opacity -= 10;
            opacity.Clamp(0, 255);

            BarColor = Color.FromArgb(opacity, BarColor);

            if (opacity == 0)
                fadeTimer.Stop();
        }
    }
}
