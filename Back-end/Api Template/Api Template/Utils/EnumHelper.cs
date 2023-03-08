using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Api_Template.Utils
{
    public static class EnumHelper
    {
        public static T? ToEnum<T>(this string FromString, T ToEnum) where T : struct, Enum
        {
            if (string.IsNullOrEmpty(FromString)) return null;
            else return (T)Enum.Parse(ToEnum.GetType(), FromString);
        }
        public static string GetDescriptionForEnumItem<T>(T enumItemValue) where T : struct, Enum
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumItemValue.ToString();
            var fieldInfo = enumItemValue.GetType().GetField(enumItemValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }
        public static string GetDescription<T>(this T enumItemValue) where T : struct, Enum
        {
            return GetDescriptionForEnumItem(enumItemValue);
        }

        public static List<string> GetDescriptions<T>() where T : struct, Enum
        {
            var descs = new List<string>();
            var names = Enum.GetNames(typeof(T));
            foreach (var name in names)
            {
                var field = (typeof(T)).GetField(name);
                var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                foreach (DescriptionAttribute fd in fds)
                {
                    descs.Add(fd.Description);
                }
            }
            return descs;
        }
        public static List<string> GetDescriptions<T>(this T enumType) where T : struct, Enum
        {
            return GetDescriptions<T>();
        }
        public static int Index<T>(this T enumItemValue) where T : struct, Enum
        {
            var enumItemName = enumItemValue.ToString();

            var enumnItemsNames = Enum.GetNames(typeof(T)).ToList();

            int index = enumnItemsNames.IndexOf(enumItemName);

            return index;
        }
        public static T GetEnumFromIndex<T>(int index) where T : struct, Enum
        {
            var enumnItemsNames = Enum.GetNames(typeof(T)).ToList();
            var enumItemName = enumnItemsNames[index];

            var enumItemValue = (T)enumItemName.ToEnum(new T());
            return enumItemValue;
        }
    }
}