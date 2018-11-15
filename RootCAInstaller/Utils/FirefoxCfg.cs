using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootCAInstaller.Utils
{
    class FirefoxCfg
    {
        private static string[] local_settings = new string[] {"pref(\"general.config.obscure_value\", 0);", "pref(\"general.config.filename\", \"umbrella.cfg\");"};
        private static string[] umbrella = new string[] { "//", "lockPref(\"security.enterprise_roots.enabled\", true);" };

        public static void setUsingWindowCertStore()
        {
            var rootPath = Path.GetPathRoot(Environment.SystemDirectory) + "Program Files\\Mozilla Firefox\\";
            
            string settingPath = rootPath + "defaults\\pref\\local-settings.js";
            string umbrellaPath = rootPath + "umbrella.cfg";
            try
            {
                File.WriteAllLines(settingPath, local_settings);
                File.WriteAllLines(umbrellaPath, umbrella);
            }catch(Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
