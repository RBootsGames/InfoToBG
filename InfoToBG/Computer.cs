using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace InfoToBG
{
    [Serializable()]
    public class Computer
    {
        #region variables
        public string Version { get; set; }
        public int Price { get; set; }
        public string OS { get; set; }
        public string Update { get; set; }
        public int UpdateNumber
        {
            get
            {
                int num;
                if (int.TryParse(Update, out num))
                    return num;

                return 0;
            }
        }
        public List<StorageDrive> Storage { get; set; }
        public string RAM { get; set; }
        public CPU Processor { get; set; }
        public List<GPU> Graphics { get; set; }
        public Size Resolution { get; set; }
        public float ScreenSize { get; set; }
        public int RamSlots { get; set; }
        public string OpticalDrive { get; set; }
        public List<string> Extras { get; set; }
        // extras
        public bool USB3 { get; set; }
        public bool Webcam { get; set; }
        public bool Bluetooth { get; set; }

        public bool HDMI { get; set; }
        public bool DP { get; set; }
        public bool mDP { get; set; }
        public bool Thunder { get; set; }
        public bool Touchscrean { get; set; }
        public string CustomExtra { get; set; }
        #endregion

        /// <summary>
        /// Don't use this ever!!!
        /// </summary>
        public Computer() { }
        public Computer(string progVersion)
        {
            Extras = null;
            USB3 = false;
            Webcam = false;
            Bluetooth = false;
            Graphics = new List<GPU>();
            Version = progVersion.Replace("Release", "").Trim();
        }

        public void SetVersion(string progVersion) => Version = progVersion.Replace("Release", "").Trim();

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
        public void AddStorage(List<StorageDrive> _driveList) => Storage = _driveList;

        public void AddGraphics(GPU _graphics) => Graphics.Add(_graphics);

        public void AddExtras(string custom = "")
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
            if (custom != "")
            {
                temp.Add(custom);
            }
            CustomExtra = custom;

            Extras = temp;
        }

        public string[] GetExtras()
        {
            if (Extras == null)
                return new string[] { "" };

            List<string> temp = new List<string>();
            string line1 = "";
            string line2 = "";
            string line3 = "";
            string line4 = "";

            int i = 0;
            do
            {
                if (i < 3)
                    line1 += String.Format("{0}, ", Extras[i]);
                else if (i < 6)
                    line2 += String.Format("{0}, ", Extras[i]);
                else if (i < 8)
                    line3 += String.Format("{0}, ", Extras[i]);
                else
                    line4 += String.Format("{0}, ", Extras[i]);



                i++;
            } while (i < Extras.Count);


            if (i <= 3)
            {
                temp.Add(RemoveThatStupidComma(line1));
                return temp.ToArray();
            }
            else if (i <= 6)
            {
                temp.Add(line1);
                temp.Add(RemoveThatStupidComma(line2));
                return temp.ToArray();
            }
            else if (i <= 8)
            {
                temp.Add(line1);
                temp.Add(line2);
                temp.Add(RemoveThatStupidComma(line3));
                return temp.ToArray();
            }
            else
            {
                temp.Add(line1);
                temp.Add(line2);
                temp.Add(line3);
                temp.Add(RemoveThatStupidComma(line4));
                return temp.ToArray();
            }
        }
        public string RemoveThatStupidComma(string items)
        {
            string workingString = "";

            for (int i = 0; i < items.Length - 2; i++)
            {
                workingString += items[i];
            }
            return workingString;
        }

        public LineOfText[] GetAllInfo()
        {
            List<LineOfText> workingList = new List<LineOfText>();

            workingList.Add(new LineOfText("$" + Price, 50, 25));
            workingList.Add(new LineOfText(String.Format("CPU: {0}", Processor.Name)));
            workingList.Add(new LineOfText(String.Format("     {0} Cores {1} Threads", Processor.CoreCount, Processor.ThreadCount), 25));

            //storage drives
            for (int i = 0; i < Storage.Count; i++)
            {
                workingList.Add(new LineOfText(Storage[i].GetCapacity()));
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

            workingList.Add(new LineOfText(String.Format("{0} Version: {1}", OS, Update)));

            if (OpticalDrive != null)
            {
                workingList.Add(new LineOfText(String.Format("Optical Drive: {0}", OpticalDrive)));
            }
            else
            {
                workingList.Add(new LineOfText("Optical Drive: N/A"));
            }

            if (ScreenSize > 0)
            {
                workingList.Add(new LineOfText(String.Format("Display Resolution: {0} x {1}", Resolution.Width, Resolution.Height)));
                workingList.Add(new LineOfText(String.Format("Display Size: {0} in.", ScreenSize), 25));
            }

            string[] extraLines = GetExtras();
            if (extraLines.Length == 1)
            {
                workingList.Add(new LineOfText(String.Format("Other: {0}", extraLines)));
            }
            else if (extraLines.Length == 2)
            {
                workingList.Add(new LineOfText(String.Format("Other: {0}", extraLines[0])));
                workingList.Add(new LineOfText(String.Format("          {0}", extraLines[1])));
            }
            else if (extraLines.Length == 3)
            {
                workingList.Add(new LineOfText(String.Format("Other: {0}", extraLines[0])));
                workingList.Add(new LineOfText(String.Format("          {0}", extraLines[1])));
                workingList.Add(new LineOfText(String.Format("          {0}", extraLines[2])));
            }
            else if (extraLines.Length == 4)
            {
                workingList.Add(new LineOfText(String.Format("Other: {0}", extraLines[0])));
                workingList.Add(new LineOfText(String.Format("          {0}", extraLines[1])));
                workingList.Add(new LineOfText(String.Format("          {0}", extraLines[2])));
                workingList.Add(new LineOfText(String.Format("          {0}", extraLines[3])));
            }

            return workingList.ToArray<LineOfText>();
        }
    }

    public class StorageDrive
    {
        public string Name { get; set; }
        public UInt64 Capacity { get; set; }
        //public string UnitMeasurement { get; set; }
        public bool SSD { get; set; }

        public StorageDrive() { }
        public StorageDrive(string _name, UInt64 _capacity)
        {
            Name = _name;
            Capacity = _capacity;
            SSD = false;
            //if (_capacity <= 10)
            //{
            //    UnitMeasurement = "TB";
            //}
            //else
            //{
            //    UnitMeasurement = "GB";
            //}
            //Console.WriteLine("{0} has {1} storage", Name, Capacity);
        }

        public string GetCapacity()
        {
            if (Capacity >= Math.Pow(1000, 4))
            {
                return $"{Name}: {Capacity.ConvertToTB()} TB" + (SSD ? " (SSD)" : "");
            }
            else
                return $"{Name}: {Capacity.ConvertToGB()} GB" + (SSD ? " (SSD)" : "");
        }
    }

    public class CPU
    {
        public string Name { get; set; }
        public int CoreCount { get; set; }
        public int ThreadCount { get; set; }
        public float Speed { get; set; }

        public CPU(){}

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
        //public float Ram { get; set; }
        public UInt64 TotalRam { get; set; }


        public string GetRamAmount()
        {
            if (TotalRam >= Math.Pow(1024, 3))
            {
                return $"{TotalRam.ConvertToGB(1, true)} GB";
            }
            else
                return $"{TotalRam.ConvertToMB(1, true)} MB";

            ////ram is currently being measured in MB
            //if (Ram >= 1024)
            //{
            //    //Console.WriteLine((Ram / 1024) + "GB");
            //    return (Convert.ToSingle(Math.Round((Ram / 1024) * 10)) / 10) + " GB";
            //}
            //else
            //{
            //    //Console.WriteLine(Ram + "MB");
            //    return Ram + " MB";
            //}
        }
        //public int GetRamAmount(bool justNumber)
        //{
        //    Console.WriteLine((Ram / 1024) + "GB");
        //    return Convert.ToInt32((Ram / 1024));
        //}
    }

    public class LineOfText
    {
        public string DisplayText { get; set; }
        public Font TextFont { get; set; }
        public int ExtraLineSpacing { get { return RawExtraSpacing + DefaultLineSpacing; } set { RawExtraSpacing = value; } }
        private int RawExtraSpacing { get; set; }
        private int DefaultLineSpacing = 20;

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
}