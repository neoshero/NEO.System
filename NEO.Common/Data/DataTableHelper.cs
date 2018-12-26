using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace NEO.Common
{
    public static class DataTableHelper
    {
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> list = new List<T>();
            Type type = typeof(T);
            PropertyInfo[] pArray = type.GetProperties(); 

            foreach (DataRow row in dt.Rows)
            {
                T entity = Activator.CreateInstance<T>(); 
                foreach (PropertyInfo p in pArray)
                {
                    if (!dt.Columns.Contains(p.Name) || row[p.Name] == null || row[p.Name] == DBNull.Value)
                    {
                        continue;     
                    }

                    var obj = Convert.ChangeType(row[p.Name], p.PropertyType);
                    p.SetValue(entity, obj, null);
                }
                list.Add(entity);
            }
            return list;
        }

        /// <summary>
        /// List To DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            DataTable dataTable = new DataTable();
            foreach (var item in properties)
            {
                dataTable.Columns.Add(item.Name, item.PropertyType); 
            }
            foreach (var item in list)
            {
                DataRow dr = dataTable.NewRow();
                foreach (var propertyInfo in properties)
                {
                    object obj = propertyInfo.GetValue(item);
                    if (obj == null)
                    {
                        continue;
                    }

                    if ( propertyInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < DateTime.MinValue)
                    {
                        continue;
                    }

                    dr[propertyInfo.Name] = obj;
                }
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }

        /// <summary>
        /// DataTable To Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static T TableToEntity<T>(this DataTable dataTable)
        {
            Type type = typeof(T);
            T entity = Activator.CreateInstance<T>();

            if (dataTable == null)
            {
                return entity;
            }

            DataRow row = dataTable.Rows[0];
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (!dataTable.Columns.Contains(propertyInfo.Name) || row[propertyInfo.Name] == null || row[propertyInfo.Name] == DBNull.Value)
                {
                    continue;
                }

                if (propertyInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(row[propertyInfo.Name]) < DateTime.MinValue)
                {
                    continue;
                }
                
                var obj = Convert.ChangeType(row[propertyInfo.Name], propertyInfo.PropertyType); 
                propertyInfo.SetValue(entity, obj, null);
                
            }
            return entity;
        }
    }
}
