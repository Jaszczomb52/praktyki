using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace gra1
{
    class Config
    {
        static Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        
        private static void Refresh()
        {
            conf.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void UpdateScore(int score)
        {
            conf.AppSettings.Settings["points"].Value = score.ToString();
            Refresh();
        }

        public static void UpdateCoins(int coins)
        {
            conf.AppSettings.Settings["coins"].Value = coins.ToString();
            Refresh();
        }
        
        public static bool ChceckScore(int score)
        {
            if (GetScore() >= score)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int GetScore()
        {
            return int.Parse(conf.AppSettings.Settings["points"].Value);
        }

        public static int GetCoins()
        {
            return int.Parse(conf.AppSettings.Settings["coins"].Value);
        }
    }
}
