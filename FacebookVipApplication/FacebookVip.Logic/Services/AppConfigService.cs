using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FacebookVip.Logic.Services
{
    class AppConfigService : IConfigService
    {
        private const string filePath = @"appConfig.xml";
        private static readonly Object instanceLock = new Object();
        private AppConfigService AppConf { get; set; }

        Point WindowPosition { get; set; }
        bool StayLogedIn { get; set; }
        string LastAccessTocken { get; set; }

        private AppConfigService()
        {
            // Load from file
            AppConfigService AppConf = (AppConfigService) SerializerService.LoadFromFile(
                                                                            filePath,
                                                                            typeof(AppConfigService));
        }

        public AppConfigService GetInstance() {
            if (AppConf == null) {
                lock (instanceLock)
                {
                    if (AppConf == null) {
                        AppConf = new AppConfigService();
                    }
                }
            }
            return AppConf;
        }

        public void SaveToFile() {
            SerializerService.SaveToFile(filePath, this);
        }



        
}
