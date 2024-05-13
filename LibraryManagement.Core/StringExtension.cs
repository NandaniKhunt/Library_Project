using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core
{
    public static class StringExtension
    {
        public static string Truncate(this string s, int length)
        {
            string _str = s;
            if (!string.IsNullOrWhiteSpace(_str))
            {
                if (_str.Length > length)
                {
                    return _str.Substring(0, length) + "...";
                }
            }
            else
            {
                _str = "--   no description   --";
            }
            return _str;
        }
    }
}
