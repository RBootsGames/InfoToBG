using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoToBG
{
    public static class CustomExtensions
    {
        public static void Clamp(this ref int input, int min, int max)
        {
            if (input < min)
                input = min;
            else if (input > max)
                input = max;
        }

        public static void Clamp(this ref float input, float min, float max)
        {
            if (input < min)
                input = min;
            else if (input > max)
                input = max;
        }

        public static string RemoveExtraSpaces(this string input)
        {
            while (input.Contains("  "))
                input = input.Replace("  ", " ");

            return input;
        }

        public static float ConvertToMB(this UInt64 input, int decimalPlaces, bool useMiBInstead = false)
        {
            return Convert.ToSingle(Math.Round(input / Math.Pow(!useMiBInstead ? 1000 : 1024, 2), decimalPlaces));
        }
        public static float ConvertToGB(this UInt64 input, int decimalPlaces, bool useGiBInstead = false)
        {
            return Convert.ToSingle(Math.Round(input / Math.Pow(!useGiBInstead ? 1000 : 1024, 3), decimalPlaces));
        }
        public static uint ConvertToGB(this UInt64 input, bool useGiBInstead = false)
        {
            return Convert.ToUInt32(input / Math.Pow(!useGiBInstead ? 1000 : 1024, 3));
        }
        public static uint ConvertToTB(this UInt64 input)
        {
            return Convert.ToUInt32(input / Math.Pow(1000, 4));
        }
    }
}
