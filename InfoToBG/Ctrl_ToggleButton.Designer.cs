namespace InfoToBG
{
    partial class Ctrl_ToggleButton
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
            this.button1 = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.highlight = new System.Windows.Forms.Panel();
            this.spacer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Open Sans", 13.98561F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(325, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Button";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button_Click);
            this.button1.MouseEnter += new System.EventHandler(this.MouseOver);
            this.button1.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // picBox
            // 
            this.picBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.picBox.Location = new System.Drawing.Point(325, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(69, 45);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.Button_Click);
            this.picBox.MouseEnter += new System.EventHandler(this.MouseOver);
            this.picBox.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // highlight
            // 
            this.highlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.highlight.Dock = System.Windows.Forms.DockStyle.Right;
            this.highlight.Location = new System.Drawing.Point(394, 0);
            this.highlight.Name = "highlight";
            this.highlight.Size = new System.Drawing.Size(6, 45);
            this.highlight.TabIndex = 2;
            // 
            // spacer
            // 
            this.spacer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.spacer.Location = new System.Drawing.Point(394, 0);
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(0, 45);
            this.spacer.TabIndex = 3;
            this.spacer.Click += new System.EventHandler(this.Button_Click);
            this.spacer.MouseEnter += new System.EventHandler(this.MouseOver);
            this.spacer.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // Ctrl_ToggleButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.spacer);
            this.Controls.Add(this.highlight);
            this.Name = "Ctrl_ToggleButton";
            this.Size = new System.Drawing.Size(400, 45);
            this.Load += new System.EventHandler(this.Ctrl_ToggleButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel highlight;
        private System.Windows.Forms.Panel spacer;
    }
}
