using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TTTN_WEB_ASP.Models;

namespace TTTN_WEB_ASP.Common
{
    public class SettingHelper
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static string GetValue(string key)
        {
            var item = db.SystemSettings.SingleOrDefault(x => x.SettingKey == key);
            if (item != null)
            {
                return item.SettingValue;
            }
            return "";
        }
    }
}