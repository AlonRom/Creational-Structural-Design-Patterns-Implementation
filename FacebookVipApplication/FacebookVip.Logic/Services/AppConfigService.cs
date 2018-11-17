using System;
using System.Drawing;
using FacebookVip.Model.Models;

namespace FacebookVip.Logic.Services
{
    public class AppConfigService
    {
        private const string k_FilePath = "appConfig.xml";
        private static readonly object sr_InstanceLock = new object();
        private static AppConfigService AppConf { get; set; }

        public Point WindowPosition { get; set; }
        public bool StayLogedIn { get; set; }
        public string LastAccessTocken { get; set; }

        public StateSettings StateSettings { get; set; }

        public int LabelFontSize { get; set; } = 12;

        public int TitleFontSize { get; set; } = 20;

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
                lock (sr_InstanceLock)
                {
                    if (AppConf == null)
                    {
                        try
                        {
                            AppConf = SerializerService.LoadFromFile<AppConfigService>(
                                k_FilePath,
                                typeof(AppConfigService));
                        }
                        catch (Exception)
                        {
                            AppConf = new AppConfigService{StateSettings = new StateSettings()};
                        } 
                    }
                }
            }
            return AppConf;
        }

        public static void SaveToFile()
        {
            SerializerService.SaveToFile(k_FilePath, GetInstance());
        }
    }      
}
