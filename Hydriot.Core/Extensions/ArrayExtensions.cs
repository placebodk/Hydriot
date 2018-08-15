using System;
using System.Linq;

namespace Hydriot.Core.Extensions
{
    public static class ArrayExtensions
    {
        public static T? FirstOfType<T>(this object[] list) where T: struct
        {
            if( list == null)
            {
                return null;
            }

            return list.OfType<T>().FirstOrDefault();
        }

        //public static T FirstOfType<T>(this object[] list) where T : class
        //{
        //    if (list == null)
        //    {
        //        return null;
        //    }

        //    return list.OfType<T>().FirstOrDefault();
        //}
    }
}