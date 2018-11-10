using System;
using System.IO;
using System.Xml.Serialization;

namespace FacebookVip.Logic.Services
{
    static class SerializerService
    {
        public static void SaveToFile<T>(string i_FilePath, T i_Obj)
        {
            using (Stream stream = new FileStream(i_FilePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(i_Obj.GetType());
                serializer.Serialize(stream, i_Obj);
            }
        }

        public static T LoadFromFile<T>(string i_FilePath, Type i_Type)
        {
            using (Stream stream = new FileStream(i_FilePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(i_Type);
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
