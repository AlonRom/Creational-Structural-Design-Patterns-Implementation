using System;
using System.Collections;
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
            foreach(PropertyInfo propertyInfo in i_Obj.GetType().GetProperties())
            {
                if(propertyInfo.CanRead && Attribute.IsDefined(propertyInfo, typeof(DisplayAttribute)))
                {
                    object propertyDisplayValue = ((DisplayAttribute)propertyInfo.GetCustomAttribute(typeof(DisplayAttribute))).Name;
                    object propertyValue = propertyInfo.GetValue(i_Obj, null);
                    yield return new KeyValuePair<string, string>(propertyDisplayValue.ToString(), propertyValue.ToString());
                }
            }
        }
    }
}
