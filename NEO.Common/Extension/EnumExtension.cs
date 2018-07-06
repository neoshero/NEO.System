using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common.Extension
{
    public static class EnumExtension
    {
        /// <summary>
        /// Get enum description
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum source)
        {
            if (source == null)
                return null;

            Type type = source.GetType();

            FieldInfo fieldInfo = type.GetField(source.ToString());
            DescriptionAttribute description = null;
            if (fieldInfo != null)
            {
                description = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
            }

            return description != null ? description.Description: source.ToString();
        }

        /// <summary>
        /// Get enum array
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetDictionaryByEnum(this Enum oEnum)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            Type source = oEnum.GetType();
            FieldInfo[] fields = source.GetFields(BindingFlags.Public|BindingFlags.Static);
            foreach (var field in fields)
            {
                int value = (int)field.GetValue(source);
                dictionary[value] = field.Name;
            }

            return dictionary;
        }

        /// <summary>
        /// Get enum array
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetDescritionByEnum(this Enum oEnum)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            Type source = oEnum.GetType();
            FieldInfo[] fields = source.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                int value = (int)field.GetValue(source);
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field,typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    dictionary[value] = attribute.Description;
                }
            }

            return dictionary;
        }
    }
}
