using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


public class ConfigManager
{
    public static bool hasUserConfig(string phoneNum)
    {
        return File.Exists("./config/" + phoneNum + ".xml");
    }

    public static UserConfig GetUserConfig(string phoneNum)
    {
        string path = "./config/" + phoneNum + ".xml";
        if (hasUserConfig(phoneNum)) {
            return (UserConfig)XmlSerializer.LoadFromXml(path, typeof(UserConfig));
        }
        return null;
    }

    public static void SaveUserConfig(UserConfig config)
    {
        XmlSerializer.SaveToXml("./config/" + config.PhoneNum + ".xml", config, typeof(UserConfig), "UserConfig");
    }

}
