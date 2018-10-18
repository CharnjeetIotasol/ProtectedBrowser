using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProtectedBrowser.Common.Extensions
{
    public static class XmlExtension
    {
        public static T? GetValue<T>(this XElement xAttr)
            where T : struct
        {
            if (xAttr == null) return default(T);

            return (T)Convert.ChangeType(xAttr.Value, typeof(T));
        }
        public static string GetStrValue(this XElement xAttr)

        {
            if (xAttr == null) return null;
            return xAttr.Value;
        }

        public static DateTimeOffset? GetDateOffset(this XElement element)
        {
            if (element == null) return null;
            try
            {
                return DateTimeOffset.Parse(element.Value);
            }
            catch
            {
                return null;
            }

        }
        public static DateTime? GetDate(this XElement element)
        {
            if (element == null) return null;
            try
            {
                return DateTime.Parse(element.Value);
            }
            catch
            {
                return null;
            }

        }

        public static bool? GetBoolVal(this XElement element)
        {
            if (element == null) return null;
            int a = 0;
            if (!int.TryParse(element.Value, out a))
                return null;
            else if(element.Value == "1" || element.Value=="0" )
                return  element.Value == "1"? true :false;
            bool b;
            if (!bool.TryParse(element.Value, out b))
                return null;
            return b;

        }


    }
}
