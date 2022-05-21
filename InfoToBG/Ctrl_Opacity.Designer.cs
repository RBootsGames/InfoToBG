namespace InfoToBG
{
    partial class Ctrl_Opacity
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
            this.scroller = new System.Windows.Forms.Panel();
            this.dragTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // scroller
            // 
            this.scroller.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scroller.Location = new System.Drawing.Point(0, 0);
            this.scroller.Margin = new System.Windows.Forms.Padding(0);
            this.scroller.Name = "scroller";
            this.scroller.Size = new System.Drawing.Size(53, 27);
            this.scroller.TabIndex = 0;
            this.scroller.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scroller_MouseDown);
            this.scroller.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroller_MouseUp);
            // 
            // dragTimer
            // 
            this.dragTimer.Interval = 20;
            this.dragTimer.Tick += new System.EventHandler(this.dragTimer_Tick);
            // 
            // Ctrl_Opacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scroller);
            this.Name = "Ctrl_Opacity";
            this.Size = new System.Drawing.Size(53, 364);
            this.Resize += new System.EventHandler(this.Ctrl_Opacity_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scroller;
        private System.Windows.Forms.Timer dragTimer;
    }
}
