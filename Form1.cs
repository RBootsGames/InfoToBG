using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Management;
using InfoToBG.Properties;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace InfoToBG
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
            UInt32 action, UInt32 uParam, String vPram, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        #region variables
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

        public Computer computer = new Computer();
        public List<string> allInfo = new List<string>();

        public Bitmap wallpaperBitmap = new Bitmap(Resources.wallpaper);
        public string saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        #endregion

        public int fontSize = 25;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            exeLocation = exeLocation.Replace("InfoToBG.exe", "");
            Console.WriteLine(exeLocation);
            debuggery = exeLocation + debuggery;
            Console.WriteLine(debuggery);
            try
            {
                //File.SetAttributes(exeLocation + "Debug.log", FileAttributes.Normal);
                debugLines = DebugFile().ToList<string>();
            }
            catch { }
            
            DebugFile(String.Format("----- {0} -----", DateTime.Now.ToString("MM/dd/yy HH:mm")), 2);
            
            /* get info on program load
            GetOSInfo();
            GetCPUInfo();
            GetGPUInfo();
            GetHDDInfo();
            GetMoBoInfo();
            */
            previewBox.Image = wallpaperBitmap;

            if (File.Exists(saveLocation + "\\Info.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Computer));
                FileStream read = new FileStream(saveLocation + "\\Info.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Computer oldComp = (Computer)xs.Deserialize(read);

                computer = oldComp;
                read.Close();
            }

            DebugFile("program opened");
        }

        private void btn_SetValues_Click(object sender, EventArgs e)
        {
            //reset computer variable just in case you need to generate the wallpaper again
            try
            {
                File.SetAttributes(debuggery, FileAttributes.Normal);
            }
            catch { }

            DebugFile("detection started", 1);
            computer = new Computer();
            DebugFile("created empty 'computer' variable");
            storageDrives = new List<StorageDrive>();
            DebugFile("created empty 'storage drives' variable");
            ramAmount = new List<UInt32>();
            DebugFile("created empty 'ram' variable");
            //set resolution
            computer.Resolution = new Size(DisplayRes().Width, DisplayRes().Height);
            //computer.Resolution = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            DebugFile(String.Format("found resolution of {0}", computer.Resolution));

            DebugFile("");

            lbl_Think.Visible = true;
            lbl_Think.ForeColor = Color.Red;
            lbl_Think.Text = "Gathering information...";

            //get info on button press
            lbl_Think.Text = "Gathering information... (OS Info)";
            GetOSInfo();
            lbl_Think.Text = "Gathering information... (CPU Info)";
            GetCPUInfo();
            lbl_Think.Text = "Gathering information... (GPU Info)";
            GetGPUInfo();
            lbl_Think.Text = "Gathering information... (Storage Info)";
            GetHDDInfo();
            lbl_Think.Text = "Gathering information... (MoBo Info)";
            GetMoBoInfo();

            SetAllValues();
            lbl_Think.Text = "Generating Wallpaper";
            GenerateWallpaper();
            previewBox.Image = wallpaperBitmap;
            lbl_Think.ForeColor = Color.Green;
            lbl_Think.Text = "Wallpaper generated and applied";

            if (File.Exists(debuggery))
            {
                File.SetAttributes(debuggery, FileAttributes.Hidden);
            }
        }

        public Size DisplayRes()
        {
            int horRes = 0;
            int vertRes = 0;

            foreach (var item in new ManagementObjectSearcher("Select * from CIM_VideoControllerResolution").Get())
            {
                //these return all possible resolution values: select highest possible value
                if (Convert.ToInt32((item["HorizontalResolution"])) > horRes)
                {
                    horRes = Convert.ToInt32(item["HorizontalResolution"]);
                }
                if (Convert.ToInt32((item["VerticalResolution"])) > vertRes)
                {
                    vertRes = Convert.ToInt32(item["VerticalResolution"]);
                }
                //Console.WriteLine(item["PelsHeight"]);
            }
            return new Size(horRes, vertRes);
            /*
            using (Graphics graphics = this.CreateGraphics())
            {
                return new Size((Screen.PrimaryScreen.Bounds.Width * (int)graphics.DpiX) / 96,
                    (Screen.PrimaryScreen.Bounds.Height * (int)graphics.DpiY) / 96);
            }*/
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
            List<uint> rams = new List<uint>();

            DebugFile("searching for GPU info", 1);
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_VideoController").Get())
            {
                names.Add(RemoveExtraCrap(item["Name"].ToString()));

                rams.Add(uint.Parse(item["AdapterRAM"].ToString()));
            }

            if (names.Count == 1)
            {
                DebugFile("found one GPU");
                onBoardVideo.Name = names[0];
                onBoardVideo.Ram = ConvertToMB(rams[0]);
                //set to computer
                computer.AddGraphics(onBoardVideo);
            }
            else
            {
                DebugFile("found multiple GPUs");
                videoCard.Name = names[0];
                videoCard.Ram = ConvertToMB(rams[0]);

                onBoardVideo.Name = names[1];
                onBoardVideo.Ram = ConvertToMB(rams[1]);
                //set to computer
                computer.AddGraphics(videoCard);
                computer.AddGraphics(onBoardVideo);
            }
        }

        public void GetHDDInfo()
        {
            DebugFile("searching for storage drives");
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_DiskDrive").Get())
            {
                DebugFile(item.ToString(), 1);
                DebugFile(item["InterfaceType"].ToString());
                Console.WriteLine(item);

                
                string name = String.Format("Storage Drive " + (storageDrives.Count + 1));
                UInt32 capacity = ConvertToGB(Convert.ToUInt64(item["Size"]));
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
                }
                //storageDrives.Add(new StorageDrive(("Storage Drive " + (storageDrives.Count + 1)), ConvertToGB(Convert.ToUInt64(item["Size"]))));
            }

            //set to computer
            computer.AddStorage(storageDrives);
            DebugFile("added all storage drives", 1);

            //Console.WriteLine("HDD size: " + storageDriveSize);
        }

        public void GetMoBoInfo()
        {
            DebugFile("searching for ram info");
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_PhysicalMemory").Get())
            {
                UInt64 tempNum = UInt64.Parse(item["Capacity"].ToString());

                ramAmount.Add(ConvertToGB(tempNum, true));
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


        public string RemoveExtraCrap(string fullName)
        {
            string workingString = fullName;

            workingString = workingString.Replace("(R)", "");
            workingString = workingString.Replace("(r)", "");
            workingString = workingString.Replace("(TM)", "");
            workingString = workingString.Replace("(tm)", "");

            return workingString;
        }

        public string SeparateCPUInfo(string fullName)
        {
            string workingString = fullName;
            //remove extra crap
            workingString = workingString.Replace("(R)", "");
            workingString = workingString.Replace("(r)", "");
            //workingString = Regex.Replace(workingString, " (R)", "", RegexOptions.IgnoreCase);
            workingString = workingString.Replace("(TM)", "");
            workingString = workingString.Replace("(tm)", "");
            //workingString = Regex.Replace(workingString, "(TM)", "", RegexOptions.IgnoreCase);
            workingString = workingString.Replace(" @", "");
            //workingString = Regex.Replace(workingString, " @", "", RegexOptions.IgnoreCase);
            workingString = workingString.Replace(" CPU", "");
            workingString = workingString.Replace(" with", "|");
            //remove unneccessary spaces
            
            while (workingString.Contains("  "))
            {
                workingString = workingString.Replace("  ", " ");
            }
            
            string newWorkingString = null;
            for (int i = 0; i < workingString.Length; i++)
            {
                if (workingString[i] != '|')
                {
                    newWorkingString += workingString[i];
                }
                else if (workingString[i] == '|')
                {
                    break;
                }
            }
            workingString = newWorkingString;

            //Console.WriteLine(workingString);
            return workingString;
        }

        public float ConvertToMB(uint byteCount)
        {
            float currentNum = byteCount / Convert.ToSingle(Math.Pow(1024, 2));
            currentNum = Convert.ToSingle(Math.Round(currentNum / 64));
            currentNum = currentNum * 64;

            return currentNum;
        }

        public UInt32 ConvertToGB(UInt64 byteCount)
        {
            float currentNum = byteCount / Convert.ToSingle(Math.Pow(1000, 3));
            currentNum = Convert.ToSingle(Math.Round(currentNum));

            if (currentNum > 950)
            {
                currentNum = Convert.ToSingle(Math.Round(currentNum / 1000));
                return Convert.ToUInt32(currentNum);
            }

            return Convert.ToUInt32(currentNum);
        }
        public UInt32 ConvertToGB(UInt64 byteCount, bool isByte)
        {
            if (isByte)
            {
                float currentNum = byteCount / Convert.ToSingle(Math.Pow(1024, 3));
                currentNum = Convert.ToSingle(Math.Round(currentNum));

                if (currentNum > 950)
                {
                    currentNum = Convert.ToSingle(Math.Round(currentNum / 1024));
                    return Convert.ToUInt32(currentNum);
                }
                return Convert.ToUInt32(currentNum);
            }
            else
            {
                return ConvertToGB(byteCount);
            }
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

        public void SetAllValues()
        {
            computer.Price = String.Format("${0}", input_Price.Value);
            computer.ScreenSize = String.Format("Display Size: {0} in.", input_ScreenSize.Value);
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
            computer.AddExtras();
            //Console.WriteLine(computer.Extras.Count());
            //###########################################################################################################################
            //add checked items
            //computer.Extras = null;
            if (xt_HDMI.Checked)
            {
                //computer.AddExtras(xt_HDMI.Text);
                computer.HDMI = true;
            }
            if (xt_DP.Checked)
            {
                //computer.AddExtras(xt_DP.Text);
                computer.DP = true;
            }
            if (xt_mDP.Checked)
            {
                //computer.AddExtras(xt_mDP.Text);
                computer.mDP = true;
            }
            if (xt_thunder.Checked)
            {
                //computer.AddExtras(xt_thunder.Text);
                computer.Thunder = true;
            }
            if (xt_touchscreen.Checked)
            {
                //computer.AddExtras(xt_touchscreen.Text);
                computer.Touchscrean = true;
            }
        }

        public void GenerateWallpaper()
        {
            wallpaperBitmap = new Bitmap(Resources.wallpaper);
            Graphics graphics = Graphics.FromImage(wallpaperBitmap);
            Font font = new Font("Arial", fontSize);
            int lineSpacing = 20;

            SolidBrush myBrush = new SolidBrush(Color.FromArgb(80, Color.White));

            LineOfText[] computerSpecs = computer.GetAllInfo();
            int boxHeight = 0;
            for (int i = 0; i < computerSpecs.Length; i++)
            {
                boxHeight += Convert.ToInt32(computerSpecs[i].TextFont.Size + computerSpecs[i].ExtraLineSpacing) + lineSpacing;
            }
            boxHeight += 60;

            Rectangle textBG = new Rectangle(1020, ((Resources.wallpaper.Height / 2) - (boxHeight / 2)), 800, boxHeight);

            CreateGradient(graphics, myBrush, textBG, 40, 255);

            PointF textStart = new PointF(1070, (((Resources.wallpaper.Height / 2) - (boxHeight / 2))) + 30);
            for (int i = 0; i < computerSpecs.Length; i++)
            {
                graphics.DrawString(computerSpecs[i].DisplayText, computerSpecs[i].TextFont, Brushes.Black, textStart);
                textStart.Y += computerSpecs[i].TextFont.Size + computerSpecs[i].ExtraLineSpacing + lineSpacing;
            }

            wallpaperBitmap.Save(saveLocation + "\\wallpaper.jpg");
            SetWallpaper(saveLocation + "\\wallpaper.jpg");
            graphics.Dispose();
        }

        public void SetWallpaper(String path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public void CreateGradient(Graphics graphics, SolidBrush myBrush, Rectangle rect, int pixelGradient, int finalOpacity)
        {
            Rectangle workingRect = new Rectangle(rect.X, rect.Y - pixelGradient, rect.Width, rect.Height + (pixelGradient * 2));
            SolidBrush workingBrush = new SolidBrush(Color.FromArgb(finalOpacity / pixelGradient, myBrush.Color));

            for (int i = 0; i < pixelGradient + 1; i++)
            {
                graphics.FillRectangle(workingBrush, workingRect);

                workingRect = new Rectangle(workingRect.X, workingRect.Y + 1, workingRect.Width, workingRect.Height - 2);
            }
        }



        public void DebugFile(string debugLine)
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
        public void DebugFile(string debugLine, int extraSpaceBefore)
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

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string changes = Resources.changelog;
            string newFile = exeLocation + "changelog.txt";
            if (File.Exists(newFile))
                File.SetAttributes(newFile, FileAttributes.Normal);
            File.Create(newFile).Close();

            File.WriteAllText(newFile, changes);
            Console.WriteLine("changelog saved to: " + newFile);
            //Console.WriteLine(changes);

            System.Diagnostics.Process.Start("notepad.exe", newFile);
            System.Threading.Thread.Sleep(100);
            File.SetAttributes(newFile, FileAttributes.Hidden);
            //File.Delete(newFile);
        }
    }

    public class StorageDrive
    {
        public string Name { get; set; }
        public UInt32 Capacity { get; set; }
        public string UnitMeasurement { get; set; }

        public StorageDrive()
        {

        }
        public StorageDrive(string _name, UInt32 _capacity)
        {
            Name = _name;
            Capacity = _capacity;
            if (_capacity <= 3)
            {
                UnitMeasurement = "TB";
            }
            else
            {
                UnitMeasurement = "GB";
            }
            //Console.WriteLine("{0} has {1} storage", Name, Capacity);
        }
    }

    public class CPU
    {
        public string Name { get; set; }
        public int CoreCount { get; set; }
        public int ThreadCount { get; set; }
        public float Speed { get; set; }

        public CPU()
        {

        }

        public void SetSpeed(float _speed)
        {
            float workingNum = _speed;

            workingNum = Convert.ToSingle(Math.Round(workingNum / 10));
            workingNum = workingNum / 100;

            Speed = workingNum;
            //Console.WriteLine(Speed);
        }
    }

    public class GPU
    {
        public string Name { get; set; }
        public float Ram { get; set; }

        public GPU()
        {

        }

        public string GetRamAmount()
        {
            //ram is currently being measured in MB
            if (Ram >= 1024)
            {
                //Console.WriteLine((Ram / 1024) + "GB");
                return (Convert.ToSingle(Math.Round((Ram / 1024) * 10)) / 10) + " GB";
            }
            else
            {
                //Console.WriteLine(Ram + "MB");
                return Ram + " MB";
            }
        }
        public int GetRamAmount(bool justNumber)
        {
            Console.WriteLine((Ram / 1024) + "GB");
            return Convert.ToInt32((Ram / 1024));
        }
    }

    public class LineOfText
    {
        public string DisplayText { get; set; }
        public Font TextFont { get; set; }
        public int ExtraLineSpacing { get; set; }

        public LineOfText(string _displayText)
        {
            DisplayText = _displayText;
            TextFont = new Font("Arial", 25);
        }
        public LineOfText(string _displayText, int _fontSize)
        {
            DisplayText = _displayText;
            TextFont = new Font("Arial", _fontSize);
        }
        public LineOfText(string _displayText, int _fontSize, int _extraLineSpacing)
        {
            DisplayText = _displayText;
            TextFont = new Font("Arial", _fontSize);
            ExtraLineSpacing = _extraLineSpacing;
        }
    }

    [Serializable()]
    public class Computer
    {
        public string Price { get; set; }
        public string OS { get; set; }
        public string Update { get; set; }
        public List<StorageDrive> Storage { get; set; }
        public string RAM { get; set; }
        public CPU Processor { get; set; }
        public List<GPU> Graphics { get; set; }
        public Size Resolution { get; set; }
        public string ScreenSize { get; set; }
        public int RamSlots { get; set; }
        public string OpticalDrive { get; set; }
        public List<string> Extras { get; set; }
        //extras
        public bool USB3 { get; set; }
        public bool Webcam { get; set; }
        public bool Bluetooth { get; set; }

        public bool HDMI { get; set; }
        public bool DP { get; set; }
        public bool mDP { get; set; }
        public bool Thunder { get; set; }
        public bool Touchscrean { get; set; }

        public Computer()
        {
            Extras = null;
            USB3 = false;
            Webcam = false;
            Bluetooth = false;
        }

        public void AddStorage(StorageDrive _storageDrive)
        {
            List<StorageDrive> temp = new List<StorageDrive>();
            if (this.Storage != null)
            {
                foreach (StorageDrive item in this.Storage)
                {
                    temp.Add(item);
                }
            }
            temp.Add(_storageDrive);

            this.Storage = temp;
        }
        public void AddStorage(List<StorageDrive> _driveList)
        {
            this.Storage = _driveList;
        }

        public void AddGraphics(GPU _graphics)
        {
            List<GPU> temp = new List<GPU>();

            if (this.Graphics != null)
            {
                foreach (GPU item in this.Graphics)
                {
                    temp.Add(item);
                }
            }
            temp.Add(_graphics);

            this.Graphics = temp;
        }

        public void AddExtras(string extra)
        {
            List<string> temp = new List<string>();

            if (Extras != null)
            {
                foreach (string item in Extras)
                {
                    temp.Add(item);
                }
            }
            temp.Add(extra);

            Extras = temp;
        }
        public void AddExtras()
        {
            List<string> temp = new List<string>();
            if (USB3)
                temp.Add("USB 3.0");
            if (Webcam)
                temp.Add("Webcam");
            if (Bluetooth)
                temp.Add("Bluetooth");
            if (HDMI)
                temp.Add("HDMI");
            if (DP)
                temp.Add("Displayport");
            if (mDP)
                temp.Add("Mini Displayport");
            if (Thunder)
                temp.Add("Thunderbolt");
            if (Touchscrean)
                temp.Add("Touchscreen");

            Extras = temp;
        }

        public string[] GetExtras()
        {
            List<string> temp = new List<string>();
            string line1 = "";
            string line2 = "";

            if (Extras != null && Extras.Count <= 3)
            {
                foreach (string item in Extras)
                {
                    line1 += String.Format("{0}, ", item);
                }
                line1 = RemoveThatStupidComma(line1);

                temp.Add(line1);
            }
            else if (Extras != null && Extras.Count > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    line1 += String.Format("{0}, ", Extras[i]);
                }
                for (int i = 3; i < Extras.Count; i++)
                {
                    line2 += String.Format("{0}, ", Extras[i]);
                }
                line2 = RemoveThatStupidComma(line2);

                temp.Add(line1);
                temp.Add(line2);
            }

            return temp.ToArray<string>();
        }
        public string RemoveThatStupidComma(string items)
        {
            string workingString = "";

            for (int i = 0; i < items.Length - 2; i++)
            {
                workingString += items[i];
            }
            Console.WriteLine(workingString);
            return workingString;
        }

        public LineOfText[] GetAllInfo()
        {
            List<LineOfText> workingList = new List<LineOfText>();

            workingList.Add(new LineOfText(Price, 50, 25));
            workingList.Add(new LineOfText(String.Format("CPU: {0}", Processor.Name)));
            workingList.Add(new LineOfText(String.Format("     {0} Cores {1} Threads", Processor.CoreCount, Processor.ThreadCount), 25));

            //storage drives
            for (int i = 0; i < Storage.Count; i++)
            {
                workingList.Add(new LineOfText(String.Format("{0}: {1} {2}", Storage[i].Name, Storage[i].Capacity, Storage[i].UnitMeasurement)));
            }
            //workingList.Add(new LineOfText("", 1, -10));

            workingList.Add(new LineOfText(RAM, 25));

            //graphics devices
            if (Graphics.Count == 1)
            {
                workingList.Add(new LineOfText(String.Format("Graphics: {0} {1}", Graphics[0].Name, Graphics[0].GetRamAmount())));
            }
            else
            {
                workingList.Add(new LineOfText("Graphics: "));
                for (int i = 0; i < this.Graphics.Count; i++)
                {
                    workingList.Add(new LineOfText(String.Format("     {0} {1}", Graphics[i].Name, Graphics[i].GetRamAmount())));
                }
            }
            //workingList.Add(new LineOfText("", 1, -10));
            //workingList.Add(new LineOfText(OS));
            //workingList.Add(new LineOfText(String.Format("     {0}",Update)));
            workingList.Add(new LineOfText(String.Format("{0} Version: {1}", OS, Update)));

            if (OpticalDrive != null)
            {
                workingList.Add(new LineOfText(String.Format("Optical Drive: {0}", OpticalDrive)));
            }
            else
            {
                workingList.Add(new LineOfText("Optical Drive: N/A"));
            }

            workingList.Add(new LineOfText(String.Format("Display Resolution: {0} x {1}", Resolution.Width, Resolution.Height)));
            workingList.Add(new LineOfText(ScreenSize, 25));
            
            if (GetExtras().Length == 1)
            {
                   workingList.Add(new LineOfText(String.Format("Other: {0}", GetExtras())));
            }
            else if (GetExtras().Length == 2)
            {
                workingList.Add(new LineOfText(String.Format("Other: {0}", GetExtras()[0])));
                workingList.Add(new LineOfText(String.Format("          {0}", GetExtras()[1])));
            }

            return workingList.ToArray<LineOfText>();
        }
    }
}
