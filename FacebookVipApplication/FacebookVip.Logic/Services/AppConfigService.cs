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
        private const string filePath = "appConfig.xml";
        private static readonly Object instanceLock = new Object();
        private static AppConfigService AppConf { get; set; }

        public Point WindowPosition { get; set; }
        public bool StayLogedIn { get; set; }
        public string LastAccessTocken { get; set; }

        private AppConfigService()
        {
            // Load from file
            StayLogedIn = true;
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
                        try
                        {
                            AppConf = (AppConfigService)SerializerService.LoadFromFile(
                                                        filePath,
                                                        typeof(AppConfigService));
                        }
                        catch (Exception) {
                            AppConf = new AppConfigService();
                        } 
                    }
                }
            }
            return AppConf;
        }

        public static void SaveToFile()
        {
            SerializerService.SaveToFile(filePath, GetInstance());
        }

    }

        
}
