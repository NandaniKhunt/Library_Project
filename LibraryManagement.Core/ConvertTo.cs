using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core
{
    public class ConvertTo
    {
        /// <summary> 
        /// check for given value is null string 
        /// </summary> 
        /// <param name="readField"></param> 
        /// <returns>if value=string return string else  string.Empty</returns> 
        /// <remarks></remarks> 
        public static string String(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    return Convert.ToString(readField);
                }
                return string.Empty;
            }
            return string.Empty;
        }

        /// <summary> 
        /// check for given value is not double 
        /// </summary> 
        /// <param name="readField"></param> 
        /// <returns>if value=double return double else 0.0</returns> 
        /// <remarks></remarks> 
        public static double Double(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0.0;
                    }
                    return Convert.ToDouble(readField);
                }
                return 0.0;
            }
            return 0.0;
        }

        /// <summary> 
        /// check for given value is not decimal 
        /// </summary> 
        /// <param name="readField"></param> 
        /// <returns>if value=double return double else 0.0</returns> 
        /// <remarks></remarks> 
        public static decimal Decimal(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {

                        return 0;
                    }
                    decimal x;
                    if (decimal.TryParse(readField.ToString(), out x))
                    {
                        return x;
                    }
                    return 0;
                }
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// Convert to float
        /// </summary>
        /// <param name="readField"></param>
        /// <returns></returns>
        public static float Float(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {

                        return 0;
                    }
                    float x;
                    if (float.TryParse(readField.ToString(), out x))
                    {
                        return x;
                    }
                    return 0;
                }
                return 0;
            }
            return 0;
        }

        /// <summary> 
        /// check given value is boolean or null 
        /// </summary> 
        /// <param name="readField"></param> 
        /// <returns>if value=boolen return true else false</returns> 
        /// <remarks></remarks> 
        public static bool Boolean(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    bool x;
                    bool.TryParse(Convert.ToString(readField), out x);
                    return x;
                }
                return false;
            }
            return false;
        }

        /// <summary> 
        /// check given value is interger or null 
        /// </summary> 
        /// <param name="readField"></param> 
        /// <returns>if value=integer return integer else 0</returns> 
        /// <remarks></remarks> 
        public static int Integer(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    int toReturn = 0;
                    int.TryParse(readField.ToString().Trim(), out toReturn);
                    return toReturn;
                }
                return 0;
            }
            return 0;
        }


        /// <summary> 
        /// check given value is interger or null 
        /// </summary> 
        /// <param name="readField"></param> 
        /// <returns>if value=integer return integer else 0</returns> 
        /// <remarks></remarks> 
        public static long Long(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    long toReturn = 0;
                    long.TryParse(readField.ToString().Trim(), out toReturn);
                    return toReturn;
                }
                return 0;
            }
            return 0;
        }

        /// <summary> 
        /// check given value is interger or null 
        /// </summary> 
        /// <param name="readField"></param> 
        /// <returns>if value=integer return integer else 0</returns> 
        /// <remarks></remarks> 
        public static short Short(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    short toReturn = 0;
                    short.TryParse(readField.ToString().Trim(), out toReturn);
                    return toReturn;
                }
                return 0;
            }
            return 0;
        }

        /// <summary> 
        /// check given value of date is date or null 
        /// </summary> 
        /// <param name="readField">date value to check</param> 
        /// <returns>return date if valid format else return nothing</returns> 
        /// <remarks></remarks> 
        public static DateTime Date(object readField)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    return Convert.ToDateTime(readField);
                }
            }
            return DateTime.MinValue;
        }

        /// <summary> 
        /// check given value of date is date or null 
        /// </summary> 
        /// <param name="readField">date value to check</param> 
        /// <param name="dateFormat">format for which u want to check like MM/dd/yyyy</param> 
        /// <returns>return date if valid format else return nothing</returns> 
        /// <remarks></remarks> 
        public static string Date(object readField, string dateFormat, bool today = false)
        {
            if ((readField != null))
            {
                if (readField.GetType() != typeof(DBNull))
                {
                    if (dateFormat != string.Empty)
                    {
                        DateTime dt = Convert.ToDateTime(readField);
                        if (dt.Year == 0001)
                        {
                            return DateTime.UtcNow.ToString(dateFormat);
                        }
                        return dt.ToString(dateFormat);
                    }
                    return Convert.ToDateTime(readField).ToString();
                }
            }
            if (today)
            {
                return DateTime.UtcNow.ToString(dateFormat);
            }
            return DateTime.MinValue.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string TimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="isNormal"></param>
        /// <returns></returns>
        public static string PastToCurrent(object dateTime, bool isNormal = false)
        {
            DateTime time = DateTime.Parse(ConvertTo.String(dateTime));
            DateTime currentTime = DateTime.UtcNow;
            TimeSpan substract = currentTime - time;
            if (isNormal)
            {
                if (substract.Days > 0)
                    return substract.Days + "day's ago";
                if (substract.Hours > 0)
                    return substract.Hours + "hour's ago";
                if (substract.Minutes > 0)
                    return substract.Minutes + "mimute's ago";
                return "Just Now";
            }
            if (substract.Days > 0)
                return substract.Days + "d " + substract.Hours + "h " + substract.Minutes + "m ";
            if (substract.Hours > 0)
                return substract.Hours + "h " + substract.Minutes + "m " + substract.Seconds + "s";
            if (substract.Minutes > 0)
                return substract.Minutes + "m " + substract.Seconds + "s";
            return "Just Now";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FutureToCurrent(object dateTime)
        {
            DateTime time = DateTime.Parse(ConvertTo.String(dateTime));
            DateTime currentTime = DateTime.UtcNow;
            TimeSpan substract = time - currentTime;
            if (substract.Days > 0)
                return substract.Days + " days";
            else
                return "today";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Rounds(decimal value)
        {
            decimal roundValue = Math.Round(value, MidpointRounding.AwayFromZero);
            if (roundValue < value)
                return Integer(roundValue + 1);
            return Integer(roundValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string Currency(object amount)
        {
            return string.Format("{0:0.00}", amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Currency(object amount, string format)
        {
            return string.Format(format, amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nvc"></param>
        /// <param name="handleMultipleValuesPerKey"></param>
        /// <returns></returns>
        public static Dictionary<string, object> NvcToDictionary(NameValueCollection nvc, bool handleMultipleValuesPerKey = false)
        {
            var result = new Dictionary<string, object>();
            foreach (string key in nvc.Keys)
            {
                if (handleMultipleValuesPerKey)
                {
                    string[] values = nvc.GetValues(key);
                    if (values.Length == 1)
                    {
                        result.Add(key, values[0]);
                    }
                    else
                    {
                        result.Add(key, values);
                    }
                }
                else
                {
                    result.Add(key, nvc[key]);
                }
            }

            return result;
        }
    }
}
