using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

using System.Management;
using InfoToBG.Properties;
using System.Runtime.InteropServices;
//using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace InfoToBG
{
    public partial class Form1 : Form
    {
        // These are for allowing to set the background.
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
            UInt32 action, UInt32 uParam, String vPram, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        #region variables
        bool backgroundGenerated = false;

        public CPU cpu = new CPU();
        public GPU videoCard = new GPU();
        public GPU onBoardVideo = new GPU();

        public List<UInt32> ramAmount = new List<UInt32>();
        public int totalRamSlots = 0;

        public string osBitness = null;
        public string osName = null;
        public string updateVersion = null;

        public List<StorageDrive> storageDrives = new List<StorageDrive>();
        public string opticalDrive = null;

        public Computer computer/* = new Computer()*/;
        public List<string> allInfo = new List<string>();

        //public Bitmap wallpaperBitmap = new Bitmap(Resources.wallpaper_comp);
        //private Bitmap selectedBitmap = null;
        //private Bitmap overlayBitmap = new Bitmap(Resources.wallpaper1.Width, Resources.wallpaper1.Height);
        private Bitmap overlayBitmap = new Bitmap(1,1);
        //private Bitmap overlayText = new Bitmap(Resources.wallpaper1.Width, Resources.wallpaper1.Height);
        private Bitmap overlayText = new Bitmap(1,1);
        public string saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        public List<Bitmap> customBackgrounds = new List<Bitmap>();
        #endregion

        //public int fontSize = 25;
        //just for creating a file

        #region debug file stuff
        public List<string> newDebugLines = new List<string>();
        public List<string> debugLines = new List<string>();
        public string exeLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
        public string debuggery = "Debug.log";
        #endregion

        public Form1()
        {
            InitializeComponent();

            input_Price.Focus();
            //progressBar.Progress = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //opacityBar.Value = opacityBar.Value;
            
            exeLocation = exeLocation.Replace("InfoToBG.exe", "");
            openBG.InitialDirectory = exeLocation;
            //Console.WriteLine(exeLocation);
            debuggery = exeLocation + debuggery;
            //Console.WriteLine(debuggery);
            try
            {
                debugLines = DebugFile().ToList<string>();
            }
            catch { }

            DebugFile(String.Format("----- {0} -----", DateTime.Now.ToString("MM/dd/yy HH:mm")), 2);

            if (File.Exists(saveLocation + "\\Info.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Computer));
                FileStream read = new FileStream(saveLocation + "\\Info.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Computer oldComp = (Computer)xs.Deserialize(read);

                computer = oldComp;
                read.Close();

                input_Price.Text = computer.Price.ToString();
                input_ScreenSize.Text = computer.ScreenSize.ToString();

                xt_HDMI.Checked = computer.HDMI;
                xt_DP.Checked = computer.DP;
                xt_mDP.Checked = computer.mDP;
                xt_Thunder.Checked = computer.Thunder;
                xt_Touchscreen.Checked = computer.Touchscrean;
                xt_SSD.Checked = computer.Storage[0].SSD;

                if (!string.IsNullOrEmpty(computer.CustomExtra))
                {
                    input_Additional.Text = computer.CustomExtra;
                    input_Additional.ForeColor = Color.White;
                }
            }

            //previewBox.Image = wallpaperBitmap;

            DebugFile("program opened");
            textBoxFiller.Height = input_Additional.Height;
        }



        #region Form Controls

        // These somehow allow the ability to move the form.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();




        #region Buttons

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            backgroundGenerated = true;
            GatherInformation();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            backgroundGenerated = true;
            UpdateInformation();
        }

        private void changelog_Click(object sender, EventArgs e)
        {
            string changes = Resources.changelog;
            string newFile = exeLocation + "changelog.txt";
            if (File.Exists(newFile))
                File.SetAttributes(newFile, FileAttributes.Normal);
            File.Create(newFile).Close();

            File.WriteAllText(newFile, changes);
            //Console.WriteLine("changelog saved to: " + newFile);

            System.Diagnostics.Process.Start("notepad.exe", newFile);
            System.Threading.Thread.Sleep(100);
            File.SetAttributes(newFile, FileAttributes.Hidden);
            //File.Delete(newFile);
        }


        private void Wallpaper_Click(object sender, EventArgs e)
        {
            Ctrl_WallpaperSelector selection = (Ctrl_WallpaperSelector)sender;


            foreach (Ctrl_WallpaperSelector item in bgSelector.Controls)
            {
                item.BorderStyle = BorderStyle.None;
            }

            selection.BorderStyle = BorderStyle.FixedSingle;
            GenerateWallpaper(false, (Bitmap)selection.ImageDisplay);
        }

        private void Bg_Add_Click(object sender, EventArgs e)
        {
            openBG.FileName = "";
            if (openBG.ShowDialog() == DialogResult.OK)
            {
                AddCustomBG(openBG.FileName);
            }
        }


        private void AlignmentChanged(object sender, EventArgs e)
        {
            GenerateWallpaper(false);
            //UpdateInformation();
            //Console.WriteLine("asdfasdf");
        }



        private void btn_SetPowerSettings_Click(object sender, EventArgs e)
        {
            string[] commands = new string[]
            {
                "powercfg /change monitor-timeout-ac 0", // monitor timeout
                "powercfg /change -hibernate-timeout-ac 0",
                "powercfg /change -disk-timeout-ac 0",
                "Powercfg /x -standby-timeout-ac 0",
                "powercfg /change standby-timeout-ac 0", // sleep timer
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power\" /v HiberbootEnabled /t reg_dword /d 0 /f", // desable fast boot
                "powercfg -setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 5ca83367-6e45-459f-a27b-476b1d01c936 0" // close lid function
                //"powercfg -setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 7648efa3-dd9c-4e3e-b566-50f929386280 0" // power button function
            };


            Process cmd = new Process();
            cmd.StartInfo = new ProcessStartInfo("cmd.exe");
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            foreach (string com in commands)
            {
                //cmd.StartInfo.Arguments = "/k " + com; // this won't terminate the window.
                cmd.StartInfo.Arguments = "/c " + com;
                cmd.Start();
            }

            string startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\close.bat";

            string closeSysPrep = "taskkill -im sysprep.exe";
            File.WriteAllText(startup, closeSysPrep);

            MessageBox.Show("Power settings changed.", "Settings Applied", MessageBoxButtons.OK, MessageBoxIcon.None);
        }


        #endregion

        private void OpacityBar_ValueChanged(object sender, EventArgs e)
        {
            if (!backgroundGenerated)
                return;

            
            timer_UpdateBG.Stop();
            timer_UpdateBG.Start();
        }


        string GetAdditionalText()
        {
            return input_Additional.Text == "Additional Features" ? "" : input_Additional.Text;
        }

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        // Key down is called before key press.
        private void TextboxNumeric_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tBox = (TextBox)sender;
            backspacePressed = false;

            float stepAmount = 1;
            try { stepAmount = Convert.ToSingle(tBox.AccessibleDescription); } catch { }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;

                float num = Convert.ToSingle(tBox.Text);

                if (e.KeyCode == Keys.Up)
                    num += stepAmount;
                else
                    num -= stepAmount;

                tBox.Text = num.ToString();
                tBox.Select(tBox.Text.Length, 0);
            }
            else if (e.KeyCode == Keys.Back)
                backspacePressed = true;

            (sender as TextBox).KeyPress -= TextboxNumeric_KeyPress;
            (sender as TextBox).KeyPress += TextboxNumeric_KeyPress;
        }
        bool backspacePressed = false;
        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && (tBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            try
            {
                int selIndex = (backspacePressed && tBox.Text.Length > 0) ? tBox.SelectionStart - 1 : tBox.SelectionStart;
                string nextString = tBox.Text.Substring(0, selIndex);
                nextString += backspacePressed ? "" : e.KeyChar.ToString();
                nextString += tBox.Text.Substring(tBox.SelectionStart);
                if (nextString.Split('.')[1].Length > 1)
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        //highlight all text when entering
        private void InputField_Enter(object sender, EventArgs e)
        {
            //((NumericUpDown)sender).Select(0, 5);
            ((TextBox)sender).Select(0, 10);
        }

        private void AdditionalFeats_Enter(object sender, EventArgs e)
        {
            if (input_Additional.Text == "Additional Features")
            {
                input_Additional.Text = "";
                input_Additional.ForeColor = Color.White;
            }
        }

        private void AdditionalFeats_Leave(object sender, EventArgs e)
        {
            if (input_Additional.Text == "")
            {
                input_Additional.Text = "Additional Features";
                input_Additional.ForeColor = Color.Gray;
            }
            
        }

        private void Timer_UpdateBG_Tick(object sender, EventArgs e)
        {
            timer_UpdateBG.Stop();
            GenerateWallpaper(false);
            //UpdateWallpaper();
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string item in fileList)
            {
                try
                {
                    AddCustomBG(item);
                }
                catch { MessageBox.Show("File must be an image format.", "Error"); }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }


        #endregion





        #region gather information

        public Size DisplayRes()
        {
            int horRes = 0;
            int vertRes = 0;
            int totalPixels = 0;

            foreach (var item in new ManagementObjectSearcher("Select * from CIM_VideoControllerResolution").Get())
            {
                int xRes = Convert.ToInt32((item["HorizontalResolution"]));
                int yRes = Convert.ToInt32((item["VerticalResolution"]));

                if ((xRes * yRes) > totalPixels)
                {
                    totalPixels = xRes * yRes;
                    horRes = xRes;
                    vertRes = yRes;
                }
            }

            return new Size(horRes, vertRes);
        }

        public void GetOSInfo()
        {
            #region OS name
            string name = null;
            DebugFile("searching for OS info", 1);
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_OperatingSystem").Get())
            {
                name = item["Caption"].ToString();
                osBitness = item["OSArchitecture"].ToString();
            }

            if (name.Contains("Microsoft "))
            {
                name = name.Replace("Microsoft ", "");
            }
            osName = name;
            #endregion
            #region update version
            try
            {
                string subKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey skey = key.OpenSubKey(subKey);

                updateVersion = skey.GetValue("ReleaseId").ToString();
            }
            catch
            {
                Console.WriteLine("couldn't get version");
                updateVersion = "";
            }
            #endregion

            //add info to computer variable
            computer.OS = String.Format("{0} ({1})", osName, osBitness);
            computer.Update = updateVersion;

            DebugFile(computer.OS);
            DebugFile(computer.Update);
        }

        public void GetCPUInfo()
        {
            DebugFile("searching for processor info", 1);
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                cpu.Name = SeparateCPUInfo(item["Name"].ToString());
                cpu.SetSpeed(Convert.ToSingle(item["MaxClockSpeed"].ToString()));
                cpu.CoreCount = int.Parse(item["NumberOfCores"].ToString());
                cpu.ThreadCount = int.Parse(item["NumberOfLogicalProcessors"].ToString());
            }

            //set to computer variable
            computer.Processor = cpu;
        }

        public void GetGPUInfo()
        {
            List<string> names = new List<string>();
            List<UInt64> rams = new List<UInt64>();

            DebugFile("searching for GPU info", 1);
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_VideoController").Get())
            {
                names.Add(RemoveExtraCrap(item["Name"].ToString()));

                // Sometimes docks will register as a "GPU" but won't return a VRAM value. This will make sure it removes it from the list if there is no VRAM.
                try { rams.Add(ulong.Parse(item["AdapterRAM"].ToString())); } catch { names.RemoveAt(names.Count - 1); }
            }

            if (names.Count == 1)
            {
                DebugFile("found one GPU");
                DebugFile("GPU VRAM:  " + rams[0]);
                onBoardVideo.Name = names[0];
                //onBoardVideo.Ram = ConvertToMB(rams[0]);
                //onBoardVideo.Ram = rams[0].ConvertToGB(10, true);
                onBoardVideo.TotalRam = rams[0];

                Console.WriteLine(onBoardVideo.TotalRam);
                //set to computer
                computer.AddGraphics(onBoardVideo);
            }
            else
            {
                DebugFile("found multiple GPUs");
                videoCard.Name = names[0];
                videoCard.TotalRam = rams[0];
                //videoCard.Ram = ConvertToMB(rams[0]);

                onBoardVideo.Name = names[1];
                onBoardVideo.TotalRam = rams[1];
                //onBoardVideo.Ram = ConvertToMB(rams[1]);
                //set to computer
                computer.AddGraphics(videoCard);
                computer.AddGraphics(onBoardVideo);
            }
        }

        public void GetHDDInfo()
        {
            DebugFile("searching for storage drives");
            //bool firstStorageDrive = true;
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_DiskDrive").Get())
            {
                DebugFile(item.ToString(), 1);
                DebugFile(item["InterfaceType"].ToString());
                Console.WriteLine(item);


                string name = String.Format("Storage Drive " + (storageDrives.Count + 1));
                //UInt32 capacity = ConvertToGB(Convert.ToUInt64(item["Size"]));
                UInt64 capacity = (UInt64)item["Size"];
                bool isRemovable = false;

                if (item["InterfaceType"].ToString() == "USB")
                {
                    DebugFile("skipping USB device");
                    isRemovable = true;
                }

                if (isRemovable == false)
                {
                    storageDrives.Add(new StorageDrive(name, capacity));
                    DebugFile(String.Format("added {0}", name));

                    //firstStorageDrive = false;
                }
            }

            // Set smallest drive to ssd
            CheckAndSetSSD();
            //if (xt_SSD.Checked)
            //{
            //    int ssdIndex = 0;
            //    UInt64 smallestCapacity = UInt64.MaxValue;

            //    for (int i = 0; i < storageDrives.Count; i++)
            //    {
            //        if (storageDrives[i].Capacity < smallestCapacity)
            //        {
            //            ssdIndex = i;
            //            smallestCapacity = storageDrives[i].Capacity;
            //        }
            //    }

            //    storageDrives[ssdIndex].SSD = true;
            //}

            //set to computer
            computer.AddStorage(storageDrives);
            DebugFile("added all storage drives", 1);
        }
        void CheckAndSetSSD()
        {
            if (xt_SSD.Checked)
            {
                int ssdIndex = 0;
                UInt64 smallestCapacity = UInt64.MaxValue;

                for (int i = 0; i < storageDrives.Count; i++)
                {
                    storageDrives[i].SSD = false;
                    if (storageDrives[i].Capacity < smallestCapacity)
                    {
                        ssdIndex = i;
                        smallestCapacity = storageDrives[i].Capacity;
                    }
                }

                storageDrives[ssdIndex].SSD = true;
            }
        }

        public void GetMoBoInfo()
        {
            DebugFile("searching for ram info");
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_PhysicalMemory").Get())
            {
                //UInt64 tempNum = UInt64.Parse(item["Capacity"].ToString());

                //ramAmount.Add(ConvertToGB(tempNum, true));
                ramAmount.Add(((UInt64)item["Capacity"]).ConvertToGB(true));
            }
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_PhysicalMemoryArray").Get())
            {
                totalRamSlots = Convert.ToInt32(item["MemoryDevices"]);
            }
            DebugFile("searching for optical drive info");
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_CDRomDrive").Get())
            {
                opticalDrive = item["MediaType"].ToString();
            }

            //set to computer
            computer.RAM = String.Format("RAM: {0} GB", TotalRam());
            computer.RamSlots = totalRamSlots;
            computer.OpticalDrive = opticalDrive;
        }
        #endregion


        #region information cleanup/refining
        public string RemoveExtraCrap(string fullName)
        {
            string workingString = fullName;

            workingString = workingString.Replace("(R)", "");
            workingString = workingString.Replace("(r)", "");
            workingString = workingString.Replace("(TM)", "");
            workingString = workingString.Replace("(tm)", "");
            workingString = workingString.Replace(" @", "");
            workingString = workingString.Replace(" CPU", "");

            workingString = workingString.RemoveExtraSpaces();

            return workingString;
        }

        public string SeparateCPUInfo(string fullName)
        {
            string workingString = RemoveExtraCrap(fullName);
            //workingString = workingString.Replace(" with", "|");
            workingString = workingString.Split(new string[]{ " with" }, StringSplitOptions.RemoveEmptyEntries)[0]; // I guess some CPUs contain this in it.

            return workingString;
        }

        public float ConvertToMB(uint byteCount)
        {
            float currentNum = byteCount / Convert.ToSingle(Math.Pow(1000, 2));
            //float currentNum = byteCount / Convert.ToSingle(Math.Pow(1024, 2));
            //currentNum = Convert.ToSingle(Math.Round(currentNum / 64));
            //currentNum = currentNum * 64;

            return currentNum;
        }

        public ulong TotalRam()
        {
            ulong rams = 0;
            foreach (ulong count in ramAmount)
            {
                rams += count;
            }
            return rams;
        }
        #endregion

        public void SetAllValues()
        {
            computer.Price = Convert.ToInt32(Convert.ToSingle(input_Price.Text));
            computer.ScreenSize = Convert.ToSingle(input_ScreenSize.Text);
            List<string> ghastlyEntities = new List<string>();

            foreach (var item in new ManagementObjectSearcher("Select * from Win32_PnPEntity").Get())
            {
                //Console.WriteLine(item["Caption"]);
                if (item["Caption"] != null)
                {
                    ghastlyEntities.Add(item["Caption"].ToString());
                }
            }
            //create a string to add to debugging file
            string listedCaptions = "";
            string foundCaptions = "";
            //search everything from the entity list
            foreach (string item in ghastlyEntities)
            {
                if (item.Contains("USB 3"))
                {
                    computer.USB3 = true;
                    //Console.WriteLine("found USB 3");
                    foundCaptions += String.Format("     {0}", item);
                    foundCaptions += Environment.NewLine;
                }
                if (item.Contains("Webcam") || item.Contains("webcam") || item.Contains("Camera") || item.Contains("camera"))
                {
                    computer.Webcam = true;
                    //Console.WriteLine("found webcam");
                    foundCaptions += String.Format("     {0}", item);
                    foundCaptions += Environment.NewLine;
                }
                if (item.Contains("Bluetooth"))
                {
                    computer.Bluetooth = true;
                    //Console.WriteLine("found bluetooth");
                    foundCaptions += String.Format("     {0}", item);
                    foundCaptions += Environment.NewLine;
                }
                listedCaptions += String.Format("     {0}", item);
                listedCaptions += Environment.NewLine;
            }
            DebugFile("------------------------List of all Captions------------------------", 1);
            DebugFile(listedCaptions);
            DebugFile("------------------------List of found Captions------------------------", 1);
            DebugFile(foundCaptions);

            if (xt_HDMI.Checked)
            {
                computer.HDMI = true;
            }
            if (xt_DP.Checked)
            {
                computer.DP = true;
            }
            if (xt_mDP.Checked)
            {
                computer.mDP = true;
            }
            if (xt_Thunder.Checked)
            {
                computer.Thunder = true;
            }
            if (xt_Touchscreen.Checked)
            {
                computer.Touchscrean = true;
            }
            computer.AddExtras(GetAdditionalText());
        }


        private void GatherInformation()
        {
            //reset computer variable just in case you need to generate the wallpaper again
            DebugFile("detection started", 1);
            computer = new Computer(lbl_Version.Text);
            DebugFile("created empty 'computer' variable");
            storageDrives = new List<StorageDrive>();
            DebugFile("created empty 'storage drives' variable");
            ramAmount = new List<UInt32>();
            DebugFile("created empty 'ram' variable");
            //set resolution
            //computer.Resolution = new Size(DisplayRes().Width, DisplayRes().Height);
            computer.Resolution = DisplayRes();
            //computer.Resolution = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            DebugFile(String.Format("found resolution of {0}", computer.Resolution));

            DebugFile("");

            lbl_Think.Visible = true;
            //progressBar.Visible = true;
            lbl_Think.ForeColor = Color.Red;
            lbl_Think.Text = "Gathering information...";
            //progressBar.Progress = 0;

            //if (progressbarTask == null || progressbarTask.IsCompleted)
            //    progressbarTask = Task.Run(() => GatherInformation());

            //get info on button press
            lbl_Think.Text = "Gathering information... (OS Info)";
            //progressBar.Progress += 100 / 7;
            GetOSInfo();
            lbl_Think.Text = "Gathering information... (CPU Info)";
            //progressBar.Progress += 100 / 7;
            GetCPUInfo();
            lbl_Think.Text = "Gathering information... (GPU Info)";
            //progressBar.Progress += 100 / 7;
            GetGPUInfo();
            lbl_Think.Text = "Gathering information... (Storage Info)";
            //progressBar.Progress += 100 / 7;
            GetHDDInfo();
            lbl_Think.Text = "Gathering information... (MoBo Info)";
            //progressBar.Progress += 100 / 7;
            GetMoBoInfo();

            SetAllValues();
            lbl_Think.Text = "Generating Wallpaper";
            //progressBar.Progress += 100 / 7;
            GenerateWallpaper();
            //previewBox.Image = wallpaperBitmap;
            lbl_Think.ForeColor = Color.Green;
            //progressBar.Progress = 100;
            lbl_Think.Text = "Wallpaper generated and applied";

            DebugFile("saving computer info to file");
            SaveXml.SaveComputer(computer, saveLocation + "\\Info.xml");
            DebugFile("info saved");
        }

        private void UpdateInformation()
        {
            if (computer == null)
            {
                GatherInformation();
                return;
            }

            lbl_Think.Visible = true;
            lbl_Think.ForeColor = Color.Red;

            lbl_Think.Text = "Updating information...";
            //computer.SetVersion(lbl_Version.Text);
            computer.Price = Convert.ToInt32(Convert.ToSingle(input_Price.Text));
            computer.ScreenSize = Convert.ToSingle(input_ScreenSize.Text);
            computer.HDMI = xt_HDMI.Checked;
            computer.DP = xt_DP.Checked;
            computer.mDP = xt_mDP.Checked;
            computer.Thunder = xt_Thunder.Checked;
            computer.Touchscrean = xt_Touchscreen.Checked;
            CheckAndSetSSD();
            //computer.Storage[0].SSD = xt_SSD.Checked;
            //computer.Extras
            lbl_Think.Text = "Reapplying values...";
            SetAllValues();
            lbl_Think.Text = "Generating Wallpaper...";
            GenerateWallpaper();
            lbl_Think.ForeColor = Color.Green;
            lbl_Think.Text = "Wallpaper generated and applied";
            //previewBox.Image = wallpaperBitmap;

            DebugFile("updating computer info to file");
            SaveXml.SaveComputer(computer, saveLocation + "\\Info.xml");
            DebugFile("info updated");
        }

        public void GenerateWallpaper(bool updateInfo = true, Bitmap bg = null)
        {
            try
            {
                if (bg == null)
                    bg = (Bitmap)previewBox.InitialImage;
                else
                    previewBox.InitialImage = new Bitmap(bg);

                previewBox.Image = new Bitmap(bg);
                //if (computer.UpdateNumber >= 1903)
                //    wallpaperBitmap = new Bitmap(Resources.wallpaper2);
                //else
                //    wallpaperBitmap = new Bitmap(Resources.wallpaper1);
                //wallpaperBitmap = new Bitmap(Resources.wallpaper_comp);

                if (updateInfo)
                    CreateGradient(Color.White, 50);

                int centerVert = previewBox.Image.Height / 2;
                centerVert -= overlayBitmap.Height / 2;
                int alignHor = 0;

                if (rad_Left.Selected)
                    alignHor = 250;
                else if (rad_Right.Selected)
                    alignHor = 1030;

                using (Graphics g = Graphics.FromImage(previewBox.Image))
                {
                    float opacity = (float)opacityBar.Percentage / 100f;
                    //float opacity = (float)opacityBar.Value / (float)opacityBar.Maximum;
                    g.DrawImage(ImageControls.SetImageOpacity(overlayBitmap, opacity), alignHor, centerVert);
                    g.DrawImage(overlayText, alignHor, centerVert);
                    g.Dispose();
                }

                //previewBox.Image = wallpaperBitmap;
                previewBox.Image.Save(saveLocation + "\\wallpaper.jpg");
                SetWallpaper(saveLocation + "\\wallpaper.jpg");
            }
            catch
            {
                DebugFile("SOMETHING WENT WRONG!!!");
            }
        }
        public void CreateGradient(Color gradientColor, int pixelGradient)
        {
            //int overlayHorPos = 1020;
            //int textHorPos = 1070;
            int textHorPos = 50;


            int boxHeight = 60;

            //getting and setting the size of the gradient BG
            foreach (LineOfText line in computer.GetAllInfo())
                boxHeight += (int)(line.TextFont.Size + line.ExtraLineSpacing);

            Rectangle overlaySize = new Rectangle(0, pixelGradient, 800, boxHeight);
            Rectangle gradeTopSize = new Rectangle(0, 0, overlaySize.Width, pixelGradient);
            Rectangle gradeBottomSize = new Rectangle(0, boxHeight + pixelGradient - 1, overlaySize.Width, pixelGradient);
            LinearGradientBrush gradeTop = new LinearGradientBrush(gradeTopSize, Color.FromArgb(0, gradientColor), Color.FromArgb(255, gradientColor), 90);
            LinearGradientBrush gradeBottom = new LinearGradientBrush(gradeBottomSize, Color.FromArgb(0, gradientColor), Color.FromArgb(255, gradientColor), -90);
            SolidBrush bgColor = new SolidBrush(Color.FromArgb(255, gradientColor));

            overlayBitmap = new Bitmap(overlaySize.Width, boxHeight + (2 * pixelGradient));
            overlayText = new Bitmap(overlayBitmap.Width, overlayBitmap.Height);

            Graphics graphics = Graphics.FromImage(overlayBitmap);
            Graphics textGraphics = Graphics.FromImage(overlayText);
            textGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            //create actual background
            graphics.FillRectangle(bgColor, overlaySize);
            graphics.FillRectangle(gradeTop, gradeTopSize);
            graphics.FillRectangle(gradeBottom, gradeBottomSize);

            
            // apply text to gradient BG
            PointF textStart = new PointF(textHorPos, pixelGradient + 30);
            foreach (LineOfText line in computer.GetAllInfo())
            {
                textGraphics.DrawString(line.DisplayText, line.TextFont, Brushes.Black, textStart);
                textStart.Y += line.TextFont.Size + line.ExtraLineSpacing;
            }

            graphics.Dispose();
            textGraphics.Dispose();
        }

        public void SetWallpaper(String path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }



        public void DebugFile(string debugLine)
        {
            try //Just in case the flash drive isn't present.
            {
                //unhide debug file
                File.SetAttributes(debuggery, FileAttributes.Normal);

                newDebugLines.Add(debugLine);

                List<string> workingList = new List<string>();

                workingList.AddRange(newDebugLines);
                workingList.AddRange(debugLines);

                if (File.Exists(debuggery))
                {
                    File.WriteAllLines(debuggery, workingList);
                }
                File.SetAttributes(debuggery, FileAttributes.Hidden);
            }
            catch { }
        }
        public void DebugFile(string debugLine, int extraSpaceBefore)
        {
            try //Just in case the flash drive isn't present.
            {
                //unhide debug file
                File.SetAttributes(debuggery, FileAttributes.Normal);

                for (int i = 0; i < extraSpaceBefore; i++)
                {
                    newDebugLines.Add("");
                }

                newDebugLines.Add(debugLine);

                List<string> workingList = new List<string>();

                workingList.AddRange(newDebugLines);
                workingList.AddRange(debugLines);

                if (!File.Exists(debuggery))
                {
                    File.WriteAllLines(debuggery, workingList);
                }
                File.SetAttributes(debuggery, FileAttributes.Hidden);
            }
            catch { }
        }
        public string[] DebugFile()
        {
            try
            {
                //unhide debug file
                File.SetAttributes(debuggery, FileAttributes.Normal);

                //StreamReader file = new StreamReader(exeLocation + "Debug.log");
                string[] currentDebug = File.ReadAllLines(debuggery);
                File.SetAttributes(debuggery, FileAttributes.Hidden);

                return currentDebug;
            }
            catch
            {
                //File.Create(debuggery);
                File.WriteAllText(debuggery, "");
                File.SetAttributes(debuggery, FileAttributes.Hidden);
                return new string[0];
            }
        }


        private void AddCustomBG(string filePath)
        {
            // the number of default backgrounds
            int index = bgSelector.Controls.Count - 1;


            Ctrl_WallpaperSelector pict = BGThumbnail(new Bitmap(filePath));
            bgSelector.Controls.Add(pict);
            bgSelector.Controls.SetChildIndex(pict, index);
        }
        private Ctrl_WallpaperSelector BGThumbnail(Image image)
        {
            Ctrl_WallpaperSelector pict = new Ctrl_WallpaperSelector();
            pict.ImageDisplay = image;
            pict.Size = bg_Wallpaper01.Size;
            pict.Margin = bg_Wallpaper01.Margin;

            pict.ButtonClick += Wallpaper_Click;


            return pict;
        }
    }
}