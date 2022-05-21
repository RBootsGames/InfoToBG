namespace InfoToBG
{
    partial class Ctrl_RadioButtons
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
            this.highlight = new System.Windows.Forms.Panel();
            this.lbl_Text = new System.Windows.Forms.Label();
            this.bottomArea = new System.Windows.Forms.Panel();
            this.fillerRight = new System.Windows.Forms.Panel();
            this.fillerLeft = new System.Windows.Forms.Panel();
            this.animTimer = new System.Windows.Forms.Timer(this.components);
            this.bottomArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // highlight
            // 
            this.highlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.highlight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.highlight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.highlight.Location = new System.Drawing.Point(18, 0);
            this.highlight.Name = "highlight";
            this.highlight.Size = new System.Drawing.Size(92, 5);
            this.highlight.TabIndex = 0;
            this.highlight.Click += new System.EventHandler(this.ControlClick);
            // 
            // lbl_Text
            // 
            this.lbl_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Text.Font = new System.Drawing.Font("Open Sans", 11F);
            this.lbl_Text.ForeColor = System.Drawing.Color.White;
            this.lbl_Text.Location = new System.Drawing.Point(0, 0);
            this.lbl_Text.Name = "lbl_Text";
            this.lbl_Text.Size = new System.Drawing.Size(128, 47);
            this.lbl_Text.TabIndex = 1;
            this.lbl_Text.Text = "radio";
            this.lbl_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Text.Click += new System.EventHandler(this.ControlClick);
            this.lbl_Text.MouseEnter += new System.EventHandler(this.lbl_Text_MouseEnter);
            this.lbl_Text.MouseLeave += new System.EventHandler(this.lbl_Text_MouseLeave);
            // 
            // bottomArea
            // 
            this.bottomArea.Controls.Add(this.highlight);
            this.bottomArea.Controls.Add(this.fillerRight);
            this.bottomArea.Controls.Add(this.fillerLeft);
            this.bottomArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bottomArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomArea.Location = new System.Drawing.Point(0, 47);
            this.bottomArea.Name = "bottomArea";
            this.bottomArea.Size = new System.Drawing.Size(128, 5);
            this.bottomArea.TabIndex = 2;
            this.bottomArea.Click += new System.EventHandler(this.ControlClick);
            // 
            // fillerRight
            // 
            this.fillerRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fillerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.fillerRight.Location = new System.Drawing.Point(110, 0);
            this.fillerRight.Name = "fillerRight";
            this.fillerRight.Size = new System.Drawing.Size(18, 5);
            this.fillerRight.TabIndex = 4;
            this.fillerRight.Click += new System.EventHandler(this.ControlClick);
            // 
            // fillerLeft
            // 
            this.fillerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.fillerLeft.Location = new System.Drawing.Point(0, 0);
            this.fillerLeft.Name = "fillerLeft";
            this.fillerLeft.Size = new System.Drawing.Size(18, 5);
            this.fillerLeft.TabIndex = 3;
            this.fillerLeft.Click += new System.EventHandler(this.ControlClick);
            // 
            // animTimer
            // 
            this.animTimer.Interval = 10;
            this.animTimer.Tick += new System.EventHandler(this.animTimer_Tick);
            // 
            // Ctrl_RadioButtons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbl_Text);
            this.Controls.Add(this.bottomArea);
            this.Name = "Ctrl_RadioButtons";
            this.Size = new System.Drawing.Size(128, 52);
            this.Load += new System.EventHandler(this.ControlLoad);
            this.bottomArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel highlight;
        private System.Windows.Forms.Label lbl_Text;
        private System.Windows.Forms.Panel bottomArea;
        private System.Windows.Forms.Timer animTimer;
        private System.Windows.Forms.Panel fillerLeft;
        private System.Windows.Forms.Panel fillerRight;
    }
}
