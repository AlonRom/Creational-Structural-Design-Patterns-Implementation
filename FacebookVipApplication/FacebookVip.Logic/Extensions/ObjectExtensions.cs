using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace FacebookVip.Logic.Extensions
{
    public static class ObjectExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> GetPropertiesForDisplay(this object i_Obj)
        {
            return from propertyInfo in i_Obj.GetType().GetProperties()
                   where propertyInfo.CanRead && Attribute.IsDefined(propertyInfo, typeof(DisplayAttribute))
                   let propertyDisplayValue = ((DisplayAttribute)propertyInfo.GetCustomAttribute(typeof(DisplayAttribute))).Name
                   let propertyValue = propertyInfo.GetValue(i_Obj, null) == null ? string.Empty : propertyInfo.GetValue(i_Obj, null)
                   let propertyOrder = ((DisplayAttribute)propertyInfo.GetCustomAttribute(typeof(DisplayAttribute))).Order
                   orderby propertyOrder
                   select new KeyValuePair<string, string>(propertyDisplayValue, propertyValue.ToString());
        }
    }
}
