using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProtectedBrowser.Common.Extensions
{
    public static class CommonExtensions
    {
        public static T? CastTo<T>(this string str) where T : struct
        {
            try
            {
                return (T)Convert.ChangeType(str, typeof(T));
            }
            catch
            {
                return null;
            }
        }

        public static bool BoolValue(this bool? val)
        {
            return val ?? false;
        }

        public static DateTime? GetDateYYYYMMDD(this string dateTimeStr)
        {
            if (string.IsNullOrEmpty(dateTimeStr))
                return null;

            if (new Regex("^[0-9]{4}-[0-9]{2}-[0-9]{2}").IsMatch(dateTimeStr))
            {
                return DateTime.ParseExact(dateTimeStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            return null;

            //if (new Regex("^[0-9]{2}-[0-9]{2}-[0-9]{4}T[0-9]{2}:[0-9]{2}:[0-9]{2}").IsMatch(dateTimeStr))//MM-dd-YYYYTHH:mm:ssZ+5:30
            //    return DateTime.ParseExact(dateTimeStr, "MM-dd-yyyyTHH:mm:ss", CultureInfo.InvariantCulture);

            //if (new Regex("^[0-9]{1}-[0-9]{2}-[0-9]{4}T[0-9]{2}:[0-9]{2}:[0-9]{2}").IsMatch(dateTimeStr))//M-dd-YYYYTHH:mm:ss
            //    return DateTime.ParseExact(dateTimeStr, "M-dd-yyyyTHH:mm:ss", CultureInfo.InvariantCulture);

            //if (new Regex("^[0-9]{2}-[0-9]{2}-[0-9]{4}").IsMatch(dateTimeStr))//MM-dd-YYYY
            //    return DateTime.ParseExact(dateTimeStr, "MM-dd-yyyy", CultureInfo.InvariantCulture);

            //if (new Regex("^[0-9]{1}-[0-9]{2}-[0-9]{4}").IsMatch(dateTimeStr))//M-dd-YYYY
            //    return DateTime.ParseExact(dateTimeStr, "M-dd-yyyy", CultureInfo.InvariantCulture);

            //return null;
        }

        public static string XmlSerialize<T>(this T obj)
        {
            if (obj == null) return null;

            var xmlSerializer = new XmlSerializer(typeof(T));
            var xmlNamespace = new XmlSerializerNamespaces();
            xmlNamespace.Add("", "");
            using (var stringWriter = new StringWriter())
            {
                var writer = XmlWriter.Create(stringWriter);
                xmlSerializer.Serialize(writer, obj, xmlNamespace);
                return stringWriter.ToString();
            }
        }


        public static string GetDescription(this Enum en)
        {
            if (en == null) return string.Empty;

            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription)).ToArray();

                if (attrs != null && attrs.Length > 0)
                    return ((EnumDescription)attrs[0]).Text;
            }
            return en.ToString();

        }

        public static T GetValueOrDefault<T>(this T? val)
            where T : struct
        {
            if (val.HasValue)
                return val.Value;
            return default(T);
        }


        public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
        {
            var dataList = new List<TSource>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select new
                                 {
                                     Name = aProp.Name,
                                     Type = Nullable.GetUnderlyingType(aProp.PropertyType) ??
                         aProp.PropertyType
                                 }).ToList();
            var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                     select new
                                     {
                                         Name = aHeader.ColumnName,
                                         Type = aHeader.DataType
                                     }).ToList();
            var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var aTSource = new TSource();
                foreach (var aField in commonFields)
                {
                    PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                    var value = (dataRow[aField.Name] == DBNull.Value) ?
                    null : dataRow[aField.Name]; //if database field is nullable
                    propertyInfos.SetValue(aTSource, value, null);
                }
                dataList.Add(aTSource);
            }
            return dataList;
        }
        /// <summary>
        /// To Get List
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="source"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static List<TDest> ToCustomList<TSource, TDest>(this List<TSource> source, Func<TSource, TDest> converter)
        {
            if (source == null) return null;
            if (!source.Any()) return null;

            return source.Select(x => converter(x)).ToList();
        }
        public static Dictionary<string, string> EnumToJson(this Type type)
        {
            if (!type.IsEnum)
                throw new InvalidOperationException("enum expected");

            return
                Enum.GetValues(type).Cast<object>()
                    .ToDictionary(enumValue => enumValue.ToString()[0].ToString().ToLower() + enumValue.ToString().Substring(1), enumValue => ((short)enumValue).ToString());

        }

        public static DateTimeOffset? AddMinutes(this DateTimeOffset? dt, int minute)
        {
            if (dt.HasValue) return dt.Value.AddMinutes(minute);
            return null;
        }
    }

    public class EnumDescription : Attribute
    {
        public string Text;
        public EnumDescription(string text)
        {
            Text = text;
        }
    }
}
