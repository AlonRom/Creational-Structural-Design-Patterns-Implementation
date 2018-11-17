using System;
using System.Collections.Generic;

namespace FacebookVip.Logic.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T, S>(this Dictionary<string, int> i_Source, Dictionary<string, int> i_Collection)
        {
            if(i_Collection == null)
            {
                throw new ArgumentNullException($"Collection is null");
            }

            foreach(var item in i_Collection)
            {
                if(!i_Source.ContainsKey(item.Key))
                {
                    i_Source.Add(item.Key, item.Value);
                }
                else
                {
                    // handle duplicate key issue here
                    i_Source[item.Key] += item.Value;
                }
            }
        }
    }
}
