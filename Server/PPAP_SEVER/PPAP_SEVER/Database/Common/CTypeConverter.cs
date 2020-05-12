using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAP_SEVER
{
    public static class CTypeConverter
    {
        #region Public Methods

        public static string ToShortTimeText(DateTime dtTime)
        {
            return dtTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToLongTimeText(DateTime dtTime)
        {
            return dtTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public static DateTime ToShortTextTime(string sTime)
        {
            DateTime dtTime = DateTime.MinValue;
            DateTime.TryParseExact(sTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None, out dtTime);

            return dtTime;
        }

        public static DateTime ToLongTextTime(string sTime)
        {
            DateTime dtTime = DateTime.MinValue;
            DateTime.TryParseExact(sTime, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.CurrentCulture, DateTimeStyles.None, out dtTime);

            return dtTime;
        }

        public static int ToInteger(string sValue)
        {
            int iValue = 0;

            int.TryParse(sValue, out iValue);

            return iValue;
        }

        public static double ToDouble(string sValue)
        {
            double nValue = 0;

            double.TryParse(sValue, out nValue);

            return nValue;
        }

        public static byte[] ToByteFromFile(string sFile)
        {
            byte[] baData = File.ReadAllBytes(sFile);
            return baData;
        }

        public static byte[] ToByteFromText(string sText)
        {
            byte[] baData = Encoding.Default.GetBytes(sText);
            return baData;
        }

        public static string ToTextFromByte(byte[] baData)
        {
            string sText = Encoding.Default.GetString(baData);
            return sText;
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
