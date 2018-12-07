using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

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

        public static string GetPropertyForDisplay(this object i_Obj)
        {
            MemberInfo[] memInfo = i_Obj?.GetType().GetMember(i_Obj.ToString());
            object[] attributes = memInfo?[0]?.GetCustomAttributes(typeof(DisplayAttribute), false);
            if(attributes != null)
            {
                return ((DisplayAttribute)attributes[0])?.Name;
            }
            return string.Empty;
        }

        public static T DeepClone<T>(this T i_ToClone) where T : class 
        {
            using(Stream stream = new MemoryStream())
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, i_ToClone);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                T theClone = serializer.Deserialize(stream) as T;
                return theClone;
            }       
        }
    }
}
