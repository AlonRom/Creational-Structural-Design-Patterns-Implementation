using System;
using System.Drawing;

namespace FacebookVip.Logic.Services
{
    public class AppAppConfigService
    {
        private const string k_FilePath = "appAppConfig.xml";
        private static readonly object sr_InstanceLock = new object();
        private static AppAppConfigService AppAppConf { get; set; }

        public Point WindowPosition { get; set; }
        public bool StayLogedIn { get; set; }
        public string LastAccessTocken { get; set; }

        private AppAppConfigService()
        {
            // Load from file
            StayLogedIn = true;
        }

        // Add some word here to spesify it's a singelton ?
        public static AppAppConfigService GetInstance()
        {
            if (AppAppConf == null)
            {
                lock (sr_InstanceLock)
                {
                    if (AppAppConf == null)
                    {
                        try
                        {
                            AppAppConf = SerializerService.LoadFromFile<AppAppConfigService>(
                                k_FilePath,
                                typeof(AppAppConfigService));
                        }
                        catch (Exception) {
                            AppAppConf = new AppAppConfigService();
                        } 
                    }
                }
            }
            return AppAppConf;
        }

        public static void SaveToFile()
        {
            SerializerService.SaveToFile(k_FilePath, GetInstance());
        }
    }      
}
