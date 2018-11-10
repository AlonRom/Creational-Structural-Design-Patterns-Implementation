using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FacebookVip.Logic.Services
{
    public class AppConfigService : IConfigService
    {
        private const string filePath = @"appConfig.xml";
        private static readonly Object instanceLock = new Object();
        private static AppConfigService AppConf { get; set; }

        Point WindowPosition { get; set; }
        bool StayLogedIn { get; set; }
        string LastAccessTocken { get; set; }

        public AppConfigService()
        {
            WindowPosition = new Point(4, 5);
            StayLogedIn = true;
            LastAccessTocken = "234";
            // Load from file
            //AppConf = (AppConfigService)SerializerService.LoadFromFile(
            //                                                    filePath,
            //                                                    this.GetType());
        }

        // Add some word here to spesify it's a singelton ?
        public static AppConfigService GetInstance()
        {
            if (AppConf == null)
            {
                lock (instanceLock)
                {
                    if (AppConf == null)
                    {
                        AppConf = new AppConfigService();
                    }
                }
            }
            return AppConf;
        }

        public static void SaveToFile()
        {
            saveToFile(filePath, GetInstance());
        }

        private static void saveToFile(string filePath, AppConfigService i_Obj)
        {
            AppConfigService app = new AppConfigService();

            using (Stream stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(app.GetType());
                serializer.Serialize(stream, app);


            }
        }

        public static Object LoadFromFile(string filePath, Type type)
        {
            using (Stream stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(stream);
            }
        }

    }

        
}
