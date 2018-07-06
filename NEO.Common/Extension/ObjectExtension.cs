using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common.Extension
{
    public static class ObjectExtension
    {
        public static T ToEntity<T>(this object obj) where T : class
        {
            T target = Activator.CreateInstance<T>();

            PropertyInfo[] tProperties = target.GetType().GetProperties();
            PropertyInfo[] cProperties = obj.GetType().GetProperties();

            foreach (var item in tProperties)
            {
                var property = cProperties.FirstOrDefault(t => t.Name == item.Name);
                if (property != null)
                {
                    var value = property.GetValue(obj);
                    item.SetValue(target, value);
                }
            }

            return target;
        }
    }
}
