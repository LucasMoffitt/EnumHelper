using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace EnumHelperDemo
{
    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }

        public static SelectList GetSelectList<T>(string prefix) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("This is for use with enums only!");

            var items = Enum.GetValues(typeof(T)).Cast<T>().Select(x => new SelectListItem
            {
                Text = string.IsNullOrEmpty(prefix) ? GetCustomDescription(x) : string.Format("{0} {1}", prefix, GetCustomDescription(x)),
                Value = Convert.ToInt32(x).ToString(CultureInfo.InvariantCulture)
            });

            return new SelectList(items, "Value", "Text");
        }

        public static IEnumerable<string> GetList<T>(string prefix) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("This is for use with enums only!");

            return Enum.GetValues(typeof (T)).Cast<T>().Select(x => string.IsNullOrEmpty(prefix) ? GetCustomDescription(x) : string.Format("{0} {1}", prefix, GetCustomDescription(x)));
        }

        public static IEnumerable<string> GetList<T>() where T : struct, IConvertible
        {
            return GetList<T>(string.Empty);
        }

        private static string GetCustomDescription(object objEnum)
        {
            var fieldInfo = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }
    }
}