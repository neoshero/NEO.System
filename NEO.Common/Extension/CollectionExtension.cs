using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace NEO.Common.Extension
{
    public static class CollectionExtension
    {
        /// <summary>
        /// 循环遍历
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="collection">泛型集合</param>
        /// <param name="action">委托代理</param>
        public static void Each<T>(this ICollection<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        /// <summary>
        /// 循环遍历
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="collection">泛型集合</param>
        /// <param name="action">委托代理</param>
        public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
        

    }
}
