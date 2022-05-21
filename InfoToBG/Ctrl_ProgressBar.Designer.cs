namespace InfoToBG
{
    partial class Ctrl_ProgressBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fillerBottom = new System.Windows.Forms.Panel();
            this.fillerTop = new System.Windows.Forms.Panel();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.fadeTimer = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // fillerBottom
            // 
            this.fillerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fillerBottom.Location = new System.Drawing.Point(0, 70);
            this.fillerBottom.Name = "fillerBottom";
            this.fillerBottom.Size = new System.Drawing.Size(417, 15);
            this.fillerBottom.TabIndex = 1;
            // 
            // fillerTop
            // 
            this.fillerTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.fillerTop.Location = new System.Drawing.Point(0, 0);
            this.fillerTop.Name = "fillerTop";
            this.fillerTop.Size = new System.Drawing.Size(417, 15);
            this.fillerTop.TabIndex = 2;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 33;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // fadeTimer
            // 
            this.fadeTimer.Interval = 33;
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressBar.Location = new System.Drawing.Point(0, 15);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 55);
            this.progressBar.TabIndex = 3;
            this.progressBar.TabStop = false;
            // 
            // Frm_ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.fillerTop);
            this.Controls.Add(this.fillerBottom);
            this.Name = "Frm_ProgressBar";
            this.Size = new System.Drawing.Size(417, 85);
            this.Resize += new System.EventHandler(this.Frm_ProgressBar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel fillerBottom;
        private System.Windows.Forms.Panel fillerTop;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer fadeTimer;
        private System.Windows.Forms.PictureBox progressBar;
    }
}
