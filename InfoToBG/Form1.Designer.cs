namespace InfoToBG
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.lbl_Think = new System.Windows.Forms.Label();
            this.changelogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.timer_UpdateBG = new System.Windows.Forms.Timer(this.components);
            this.bgSelector = new System.Windows.Forms.FlowLayoutPanel();
            this.bg_WallpaperComp = new InfoToBG.Ctrl_WallpaperSelector();
            this.bg_Wallpaper01 = new InfoToBG.Ctrl_WallpaperSelector();
            this.bg_Wallpaper02 = new InfoToBG.Ctrl_WallpaperSelector();
            this.bg_Add = new InfoToBG.Ctrl_WallpaperSelector();
            this.openBG = new System.Windows.Forms.OpenFileDialog();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.btn_SetPowerSettings = new System.Windows.Forms.Button();
            this.topBar = new System.Windows.Forms.Panel();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.btn_Changelog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Minimize = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pnl_LeftBG = new System.Windows.Forms.Panel();
            this.textBoxFiller = new System.Windows.Forms.Panel();
            this.input_Additional = new System.Windows.Forms.TextBox();
            this.xt_SSD = new InfoToBG.Ctrl_ToggleButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xt_Touchscreen = new InfoToBG.Ctrl_ToggleButton();
            this.xt_Thunder = new InfoToBG.Ctrl_ToggleButton();
            this.xt_mDP = new InfoToBG.Ctrl_ToggleButton();
            this.xt_DP = new InfoToBG.Ctrl_ToggleButton();
            this.xt_HDMI = new InfoToBG.Ctrl_ToggleButton();
            this.input_Price = new System.Windows.Forms.TextBox();
            this.input_ScreenSize = new System.Windows.Forms.TextBox();
            this.pnl_Alignment = new System.Windows.Forms.Panel();
            this.rad_Right = new InfoToBG.Ctrl_RadioButtons();
            this.rad_Left = new InfoToBG.Ctrl_RadioButtons();
            this.opacityBar = new InfoToBG.Ctrl_Opacity();
            this.progressBar = new InfoToBG.Ctrl_ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.bgSelector.SuspendLayout();
            this.topBar.SuspendLayout();
            this.pnl_LeftBG.SuspendLayout();
            this.pnl_Alignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewBox
            // 
            this.previewBox.Image = global::InfoToBG.Properties.Resources.wallpaper_comp;
            this.previewBox.InitialImage = global::InfoToBG.Properties.Resources.wallpaper_comp;
            this.previewBox.Location = new System.Drawing.Point(205, 76);
            this.previewBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(580, 338);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 4;
            this.previewBox.TabStop = false;
            // 
            // lbl_Think
            // 
            this.lbl_Think.AutoSize = true;
            this.lbl_Think.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbl_Think.Location = new System.Drawing.Point(207, 544);
            this.lbl_Think.Name = "lbl_Think";
            this.lbl_Think.Size = new System.Drawing.Size(50, 15);
            this.lbl_Think.TabIndex = 9;
            this.lbl_Think.Text = "thinking";
            this.lbl_Think.Visible = false;
            // 
            // changelogToolStripMenuItem1
            // 
            this.changelogToolStripMenuItem1.Name = "changelogToolStripMenuItem1";
            this.changelogToolStripMenuItem1.Size = new System.Drawing.Size(114, 29);
            this.changelogToolStripMenuItem1.Text = "Changelog";
            this.changelogToolStripMenuItem1.Click += new System.EventHandler(this.changelog_Click);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(772, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Opacity";
            // 
            // timer_UpdateBG
            // 
            this.timer_UpdateBG.Interval = 300;
            this.timer_UpdateBG.Tick += new System.EventHandler(this.Timer_UpdateBG_Tick);
            // 
            // bgSelector
            // 
            this.bgSelector.AutoScroll = true;
            this.bgSelector.Controls.Add(this.bg_WallpaperComp);
            this.bgSelector.Controls.Add(this.bg_Wallpaper01);
            this.bgSelector.Controls.Add(this.bg_Wallpaper02);
            this.bgSelector.Controls.Add(this.bg_Add);
            this.bgSelector.Location = new System.Drawing.Point(205, 449);
            this.bgSelector.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.bgSelector.Name = "bgSelector";
            this.bgSelector.Size = new System.Drawing.Size(606, 94);
            this.bgSelector.TabIndex = 16;
            this.bgSelector.WrapContents = false;
            // 
            // bg_WallpaperComp
            // 
            this.bg_WallpaperComp.ImageDisplay = global::InfoToBG.Properties.Resources.wallpaper_comp;
            this.bg_WallpaperComp.ImageMouseClick = null;
            this.bg_WallpaperComp.ImageMouseOver = ((System.Drawing.Image)(resources.GetObject("bg_WallpaperComp.ImageMouseOver")));
            this.bg_WallpaperComp.Location = new System.Drawing.Point(5, 3);
            this.bg_WallpaperComp.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bg_WallpaperComp.Name = "bg_WallpaperComp";
            this.bg_WallpaperComp.OverlayColor = System.Drawing.Color.White;
            this.bg_WallpaperComp.OverlayOpacity = 50;
            this.bg_WallpaperComp.Size = new System.Drawing.Size(125, 70);
            this.bg_WallpaperComp.TabIndex = 28;
            this.bg_WallpaperComp.TabStop = false;
            this.bg_WallpaperComp.ButtonClick += new System.EventHandler(this.Wallpaper_Click);
            // 
            // bg_Wallpaper01
            // 
            this.bg_Wallpaper01.ImageDisplay = global::InfoToBG.Properties.Resources.wallpaper1;
            this.bg_Wallpaper01.ImageMouseClick = null;
            this.bg_Wallpaper01.ImageMouseOver = ((System.Drawing.Image)(resources.GetObject("bg_Wallpaper01.ImageMouseOver")));
            this.bg_Wallpaper01.Location = new System.Drawing.Point(140, 3);
            this.bg_Wallpaper01.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bg_Wallpaper01.Name = "bg_Wallpaper01";
            this.bg_Wallpaper01.OverlayColor = System.Drawing.Color.White;
            this.bg_Wallpaper01.OverlayOpacity = 50;
            this.bg_Wallpaper01.Size = new System.Drawing.Size(125, 70);
            this.bg_Wallpaper01.TabIndex = 29;
            this.bg_Wallpaper01.TabStop = false;
            this.bg_Wallpaper01.ButtonClick += new System.EventHandler(this.Wallpaper_Click);
            // 
            // bg_Wallpaper02
            // 
            this.bg_Wallpaper02.ImageDisplay = global::InfoToBG.Properties.Resources.wallpaper2;
            this.bg_Wallpaper02.ImageMouseClick = null;
            this.bg_Wallpaper02.ImageMouseOver = ((System.Drawing.Image)(resources.GetObject("bg_Wallpaper02.ImageMouseOver")));
            this.bg_Wallpaper02.Location = new System.Drawing.Point(275, 3);
            this.bg_Wallpaper02.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bg_Wallpaper02.Name = "bg_Wallpaper02";
            this.bg_Wallpaper02.OverlayColor = System.Drawing.Color.White;
            this.bg_Wallpaper02.OverlayOpacity = 50;
            this.bg_Wallpaper02.Size = new System.Drawing.Size(125, 70);
            this.bg_Wallpaper02.TabIndex = 30;
            this.bg_Wallpaper02.TabStop = false;
            this.bg_Wallpaper02.ButtonClick += new System.EventHandler(this.Wallpaper_Click);
            // 
            // bg_Add
            // 
            this.bg_Add.ImageDisplay = global::InfoToBG.Properties.Resources.New_BG_Off;
            this.bg_Add.ImageMouseClick = global::InfoToBG.Properties.Resources.New_BG_Off;
            this.bg_Add.ImageMouseOver = global::InfoToBG.Properties.Resources.New_BG_On;
            this.bg_Add.Location = new System.Drawing.Point(410, 3);
            this.bg_Add.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bg_Add.Name = "bg_Add";
            this.bg_Add.OverlayColor = System.Drawing.Color.White;
            this.bg_Add.OverlayOpacity = 50;
            this.bg_Add.Size = new System.Drawing.Size(125, 70);
            this.bg_Add.TabIndex = 31;
            this.bg_Add.TabStop = false;
            this.bg_Add.ButtonClick += new System.EventHandler(this.Bg_Add_Click);
            // 
            // openBG
            // 
            this.openBG.Filter = "Images|*.png;*.jpg";
            this.openBG.Title = "Import Custom Background";
            // 
            // btn_SetPowerSettings
            // 
            this.btn_SetPowerSettings.FlatAppearance.BorderSize = 0;
            this.btn_SetPowerSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SetPowerSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_SetPowerSettings.ForeColor = System.Drawing.Color.White;
            this.btn_SetPowerSettings.Location = new System.Drawing.Point(0, 502);
            this.btn_SetPowerSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPowerSettings.Name = "btn_SetPowerSettings";
            this.btn_SetPowerSettings.Size = new System.Drawing.Size(202, 40);
            this.btn_SetPowerSettings.TabIndex = 12;
            this.btn_SetPowerSettings.Text = "Set Power Settings";
            this.tip.SetToolTip(this.btn_SetPowerSettings, "This disables the computer from going to sleep ever and disables fast boot.");
            this.btn_SetPowerSettings.UseVisualStyleBackColor = true;
            this.btn_SetPowerSettings.Click += new System.EventHandler(this.btn_SetPowerSettings_Click);
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.topBar.Controls.Add(this.lbl_Version);
            this.topBar.Controls.Add(this.btn_Changelog);
            this.topBar.Controls.Add(this.label1);
            this.topBar.Controls.Add(this.btn_Minimize);
            this.topBar.Controls.Add(this.btn_Close);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Margin = new System.Windows.Forms.Padding(2);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(822, 24);
            this.topBar.TabIndex = 25;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            // 
            // lbl_Version
            // 
            this.lbl_Version.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.769784F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Version.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Version.Location = new System.Drawing.Point(625, 0);
            this.lbl_Version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(79, 24);
            this.lbl_Version.TabIndex = 35;
            this.lbl_Version.Text = "Release v1.5.4";
            this.lbl_Version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Version.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            // 
            // btn_Changelog
            // 
            this.btn_Changelog.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Changelog.FlatAppearance.BorderSize = 0;
            this.btn_Changelog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Changelog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.769784F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Changelog.ForeColor = System.Drawing.Color.Gray;
            this.btn_Changelog.Location = new System.Drawing.Point(704, 0);
            this.btn_Changelog.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Changelog.Name = "btn_Changelog";
            this.btn_Changelog.Size = new System.Drawing.Size(66, 24);
            this.btn_Changelog.TabIndex = 36;
            this.btn_Changelog.TabStop = false;
            this.btn_Changelog.Text = "Changelog";
            this.btn_Changelog.UseVisualStyleBackColor = true;
            this.btn_Changelog.Click += new System.EventHandler(this.changelog_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 34;
            this.label1.Text = "Wallpaper Generator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Minimize.ForeColor = System.Drawing.Color.White;
            this.btn_Minimize.Location = new System.Drawing.Point(770, 0);
            this.btn_Minimize.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(26, 24);
            this.btn_Minimize.TabIndex = 26;
            this.btn_Minimize.TabStop = false;
            this.btn_Minimize.Text = "_";
            this.btn_Minimize.UseVisualStyleBackColor = true;
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Brown;
            this.btn_Close.Location = new System.Drawing.Point(796, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(26, 24);
            this.btn_Close.TabIndex = 25;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "X";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pnl_LeftBG
            // 
            this.pnl_LeftBG.Controls.Add(this.textBoxFiller);
            this.pnl_LeftBG.Controls.Add(this.btn_SetPowerSettings);
            this.pnl_LeftBG.Controls.Add(this.input_Additional);
            this.pnl_LeftBG.Controls.Add(this.xt_SSD);
            this.pnl_LeftBG.Controls.Add(this.button1);
            this.pnl_LeftBG.Controls.Add(this.button2);
            this.pnl_LeftBG.Controls.Add(this.label4);
            this.pnl_LeftBG.Controls.Add(this.label5);
            this.pnl_LeftBG.Controls.Add(this.label6);
            this.pnl_LeftBG.Controls.Add(this.xt_Touchscreen);
            this.pnl_LeftBG.Controls.Add(this.xt_Thunder);
            this.pnl_LeftBG.Controls.Add(this.xt_mDP);
            this.pnl_LeftBG.Controls.Add(this.xt_DP);
            this.pnl_LeftBG.Controls.Add(this.xt_HDMI);
            this.pnl_LeftBG.Controls.Add(this.input_Price);
            this.pnl_LeftBG.Controls.Add(this.input_ScreenSize);
            this.pnl_LeftBG.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_LeftBG.Location = new System.Drawing.Point(0, 24);
            this.pnl_LeftBG.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_LeftBG.Name = "pnl_LeftBG";
            this.pnl_LeftBG.Size = new System.Drawing.Size(202, 542);
            this.pnl_LeftBG.TabIndex = 26;
            // 
            // textBoxFiller
            // 
            this.textBoxFiller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(94)))), ((int)(((byte)(104)))));
            this.textBoxFiller.Location = new System.Drawing.Point(2, 374);
            this.textBoxFiller.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFiller.Name = "textBoxFiller";
            this.textBoxFiller.Size = new System.Drawing.Size(6, 22);
            this.textBoxFiller.TabIndex = 28;
            // 
            // input_Additional
            // 
            this.input_Additional.AccessibleDescription = "";
            this.input_Additional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(94)))), ((int)(((byte)(104)))));
            this.input_Additional.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input_Additional.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.input_Additional.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Additional.ForeColor = System.Drawing.Color.Gray;
            this.input_Additional.Location = new System.Drawing.Point(8, 374);
            this.input_Additional.Margin = new System.Windows.Forms.Padding(0);
            this.input_Additional.Name = "input_Additional";
            this.input_Additional.Size = new System.Drawing.Size(189, 17);
            this.input_Additional.TabIndex = 9;
            this.input_Additional.Text = "Additional Features";
            this.input_Additional.Enter += new System.EventHandler(this.AdditionalFeats_Enter);
            this.input_Additional.Leave += new System.EventHandler(this.AdditionalFeats_Leave);
            // 
            // xt_SSD
            // 
            this.xt_SSD.BackColor = System.Drawing.Color.Transparent;
            this.xt_SSD.Checked = false;
            this.xt_SSD.CheckHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.xt_SSD.IconRightSpacing = 15;
            this.xt_SSD.IconSize = 28;
            this.xt_SSD.ImageDeselected = global::InfoToBG.Properties.Resources.SSD_Deselected;
            this.xt_SSD.ImageSelected = global::InfoToBG.Properties.Resources.SSD_Selected;
            this.xt_SSD.Location = new System.Drawing.Point(0, 329);
            this.xt_SSD.Margin = new System.Windows.Forms.Padding(0);
            this.xt_SSD.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_SSD.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_SSD.Name = "xt_SSD";
            this.xt_SSD.Size = new System.Drawing.Size(202, 45);
            this.xt_SSD.TabIndex = 8;
            this.xt_SSD.TextColor = System.Drawing.Color.White;
            this.xt_SSD.TextDisplay = "SSD";
            this.xt_SSD.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 464);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 401);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 63);
            this.button2.TabIndex = 10;
            this.button2.Text = "Do the thing";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(5, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Other Features:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label5.Location = new System.Drawing.Point(5, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "Screen Size:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label6.Location = new System.Drawing.Point(5, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 18);
            this.label6.TabIndex = 24;
            this.label6.Text = "Price:";
            // 
            // xt_Touchscreen
            // 
            this.xt_Touchscreen.BackColor = System.Drawing.Color.Transparent;
            this.xt_Touchscreen.Checked = false;
            this.xt_Touchscreen.CheckHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.xt_Touchscreen.IconRightSpacing = 15;
            this.xt_Touchscreen.IconSize = 28;
            this.xt_Touchscreen.ImageDeselected = global::InfoToBG.Properties.Resources.Touch_Deselected;
            this.xt_Touchscreen.ImageSelected = global::InfoToBG.Properties.Resources.Touch_Selected;
            this.xt_Touchscreen.Location = new System.Drawing.Point(0, 284);
            this.xt_Touchscreen.Margin = new System.Windows.Forms.Padding(0);
            this.xt_Touchscreen.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_Touchscreen.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_Touchscreen.Name = "xt_Touchscreen";
            this.xt_Touchscreen.Size = new System.Drawing.Size(202, 45);
            this.xt_Touchscreen.TabIndex = 7;
            this.xt_Touchscreen.TextColor = System.Drawing.Color.White;
            this.xt_Touchscreen.TextDisplay = "Touchscreen";
            this.xt_Touchscreen.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // xt_Thunder
            // 
            this.xt_Thunder.BackColor = System.Drawing.Color.Transparent;
            this.xt_Thunder.Checked = false;
            this.xt_Thunder.CheckHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.xt_Thunder.IconRightSpacing = 16;
            this.xt_Thunder.IconSize = 20;
            this.xt_Thunder.ImageDeselected = global::InfoToBG.Properties.Resources.Thunderbolt_Deselected;
            this.xt_Thunder.ImageSelected = global::InfoToBG.Properties.Resources.Thunderbolt_Selected;
            this.xt_Thunder.Location = new System.Drawing.Point(0, 240);
            this.xt_Thunder.Margin = new System.Windows.Forms.Padding(0);
            this.xt_Thunder.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_Thunder.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_Thunder.Name = "xt_Thunder";
            this.xt_Thunder.Size = new System.Drawing.Size(202, 45);
            this.xt_Thunder.TabIndex = 6;
            this.xt_Thunder.TextColor = System.Drawing.Color.White;
            this.xt_Thunder.TextDisplay = "Thunderbolt";
            this.xt_Thunder.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // xt_mDP
            // 
            this.xt_mDP.BackColor = System.Drawing.Color.Transparent;
            this.xt_mDP.Checked = false;
            this.xt_mDP.CheckHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.xt_mDP.IconRightSpacing = 5;
            this.xt_mDP.IconSize = 43;
            this.xt_mDP.ImageDeselected = global::InfoToBG.Properties.Resources.MiniDP_Deselected;
            this.xt_mDP.ImageSelected = global::InfoToBG.Properties.Resources.MiniDP_Selected;
            this.xt_mDP.Location = new System.Drawing.Point(0, 195);
            this.xt_mDP.Margin = new System.Windows.Forms.Padding(0);
            this.xt_mDP.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_mDP.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_mDP.Name = "xt_mDP";
            this.xt_mDP.Size = new System.Drawing.Size(202, 45);
            this.xt_mDP.TabIndex = 5;
            this.xt_mDP.TextColor = System.Drawing.Color.White;
            this.xt_mDP.TextDisplay = "Mini Displayport";
            this.xt_mDP.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // xt_DP
            // 
            this.xt_DP.BackColor = System.Drawing.Color.Transparent;
            this.xt_DP.Checked = false;
            this.xt_DP.CheckHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.xt_DP.IconRightSpacing = 0;
            this.xt_DP.IconSize = 55;
            this.xt_DP.ImageDeselected = global::InfoToBG.Properties.Resources.DP_Deselected;
            this.xt_DP.ImageSelected = global::InfoToBG.Properties.Resources.DP_Selected;
            this.xt_DP.Location = new System.Drawing.Point(0, 150);
            this.xt_DP.Margin = new System.Windows.Forms.Padding(0);
            this.xt_DP.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_DP.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_DP.Name = "xt_DP";
            this.xt_DP.Size = new System.Drawing.Size(202, 45);
            this.xt_DP.TabIndex = 4;
            this.xt_DP.TextColor = System.Drawing.Color.White;
            this.xt_DP.TextDisplay = "Displayport";
            this.xt_DP.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // xt_HDMI
            // 
            this.xt_HDMI.BackColor = System.Drawing.Color.Transparent;
            this.xt_HDMI.Checked = false;
            this.xt_HDMI.CheckHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.xt_HDMI.IconRightSpacing = 0;
            this.xt_HDMI.IconSize = 55;
            this.xt_HDMI.ImageDeselected = global::InfoToBG.Properties.Resources.HDMI_Deselected;
            this.xt_HDMI.ImageSelected = global::InfoToBG.Properties.Resources.HDMI_Selected;
            this.xt_HDMI.Location = new System.Drawing.Point(0, 106);
            this.xt_HDMI.Margin = new System.Windows.Forms.Padding(0);
            this.xt_HDMI.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_HDMI.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(79)))), ((int)(((byte)(88)))));
            this.xt_HDMI.Name = "xt_HDMI";
            this.xt_HDMI.Size = new System.Drawing.Size(202, 45);
            this.xt_HDMI.TabIndex = 3;
            this.xt_HDMI.TextColor = System.Drawing.Color.White;
            this.xt_HDMI.TextDisplay = "HDMI";
            this.xt_HDMI.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // input_Price
            // 
            this.input_Price.AccessibleDescription = "5";
            this.input_Price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(94)))), ((int)(((byte)(104)))));
            this.input_Price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input_Price.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.input_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.input_Price.ForeColor = System.Drawing.Color.White;
            this.input_Price.Location = new System.Drawing.Point(8, 18);
            this.input_Price.Margin = new System.Windows.Forms.Padding(0);
            this.input_Price.Name = "input_Price";
            this.input_Price.Size = new System.Drawing.Size(194, 20);
            this.input_Price.TabIndex = 0;
            this.input_Price.Text = "200";
            this.input_Price.Enter += new System.EventHandler(this.InputField_Enter);
            this.input_Price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxNumeric_KeyDown);
            // 
            // input_ScreenSize
            // 
            this.input_ScreenSize.AccessibleDescription = ".1";
            this.input_ScreenSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(94)))), ((int)(((byte)(104)))));
            this.input_ScreenSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input_ScreenSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.input_ScreenSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_ScreenSize.ForeColor = System.Drawing.Color.White;
            this.input_ScreenSize.Location = new System.Drawing.Point(8, 62);
            this.input_ScreenSize.Margin = new System.Windows.Forms.Padding(0);
            this.input_ScreenSize.Name = "input_ScreenSize";
            this.input_ScreenSize.Size = new System.Drawing.Size(194, 20);
            this.input_ScreenSize.TabIndex = 2;
            this.input_ScreenSize.Text = "14";
            this.input_ScreenSize.Enter += new System.EventHandler(this.InputField_Enter);
            this.input_ScreenSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxNumeric_KeyDown);
            // 
            // pnl_Alignment
            // 
            this.pnl_Alignment.Controls.Add(this.rad_Right);
            this.pnl_Alignment.Controls.Add(this.rad_Left);
            this.pnl_Alignment.Location = new System.Drawing.Point(205, 414);
            this.pnl_Alignment.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Alignment.Name = "pnl_Alignment";
            this.pnl_Alignment.Size = new System.Drawing.Size(580, 36);
            this.pnl_Alignment.TabIndex = 34;
            // 
            // rad_Right
            // 
            this.rad_Right.BackColor = System.Drawing.Color.Transparent;
            this.rad_Right.DisplayFont = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rad_Right.DisplayText = "Right Align";
            this.rad_Right.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.rad_Right.Location = new System.Drawing.Point(292, 6);
            this.rad_Right.Margin = new System.Windows.Forms.Padding(0);
            this.rad_Right.Name = "rad_Right";
            this.rad_Right.Selected = false;
            this.rad_Right.Size = new System.Drawing.Size(100, 29);
            this.rad_Right.TabIndex = 30;
            this.rad_Right.TabStop = false;
            this.rad_Right.ButtonClick += new System.EventHandler(this.AlignmentChanged);
            // 
            // rad_Left
            // 
            this.rad_Left.BackColor = System.Drawing.Color.Transparent;
            this.rad_Left.DisplayFont = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rad_Left.DisplayText = "Left Align";
            this.rad_Left.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
            this.rad_Left.Location = new System.Drawing.Point(188, 6);
            this.rad_Left.Margin = new System.Windows.Forms.Padding(0);
            this.rad_Left.Name = "rad_Left";
            this.rad_Left.Selected = true;
            this.rad_Left.Size = new System.Drawing.Size(100, 29);
            this.rad_Left.TabIndex = 29;
            this.rad_Left.TabStop = false;
            this.rad_Left.ButtonClick += new System.EventHandler(this.AlignmentChanged);
            // 
            // opacityBar
            // 
            this.opacityBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(68)))));
            this.opacityBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(68)))));
            this.opacityBar.Location = new System.Drawing.Point(786, 76);
            this.opacityBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.opacityBar.MaxAtTop = true;
            this.opacityBar.Name = "opacityBar";
            this.opacityBar.Percentage = 50;
            this.opacityBar.ScrollerColor = System.Drawing.Color.Silver;
            this.opacityBar.ScrollerHeight = 27;
            this.opacityBar.Size = new System.Drawing.Size(29, 338);
            this.opacityBar.TabIndex = 35;
            this.opacityBar.ValueChanged += new System.EventHandler(this.OpacityBar_ValueChanged);
            // 
            // progressBar
            // 
            this.progressBar.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.progressBar.Location = new System.Drawing.Point(868, 384);
            this.progressBar.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Progress = 100;
            this.progressBar.Size = new System.Drawing.Size(202, 28);
            this.progressBar.StepInterval = 4;
            this.progressBar.TabIndex = 32;
            this.progressBar.TabStop = false;
            this.progressBar.Visible = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(822, 566);
            this.Controls.Add(this.opacityBar);
            this.Controls.Add(this.pnl_Alignment);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pnl_LeftBG);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.bgSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Think);
            this.Controls.Add(this.previewBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Wallpaper Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.bgSelector.ResumeLayout(false);
            this.topBar.ResumeLayout(false);
            this.pnl_LeftBG.ResumeLayout(false);
            this.pnl_LeftBG.PerformLayout();
            this.pnl_Alignment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Label lbl_Think;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer_UpdateBG;
        private System.Windows.Forms.FlowLayoutPanel bgSelector;
        private System.Windows.Forms.OpenFileDialog openBG;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem1;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Button btn_Minimize;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel pnl_LeftBG;
        private System.Windows.Forms.TextBox input_Additional;
        private Ctrl_ToggleButton xt_SSD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Ctrl_ToggleButton xt_Touchscreen;
        private Ctrl_ToggleButton xt_Thunder;
        private Ctrl_ToggleButton xt_mDP;
        private Ctrl_ToggleButton xt_DP;
        private Ctrl_ToggleButton xt_HDMI;
        private System.Windows.Forms.TextBox input_Price;
        private System.Windows.Forms.TextBox input_ScreenSize;
        private Ctrl_WallpaperSelector bg_WallpaperComp;
        private Ctrl_RadioButtons rad_Left;
        private Ctrl_RadioButtons rad_Right;
        private Ctrl_WallpaperSelector bg_Wallpaper01;
        private Ctrl_WallpaperSelector bg_Wallpaper02;
        private Ctrl_WallpaperSelector bg_Add;
        private Ctrl_ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Button btn_Changelog;
        private System.Windows.Forms.Panel pnl_Alignment;
        private System.Windows.Forms.Button btn_SetPowerSettings;
        private System.Windows.Forms.Panel textBoxFiller;
        private Ctrl_Opacity opacityBar;
    }
}

