﻿using System;
using System.IO;
using System.Xml.Serialization;

public static class XmlSerializer
{
    public static void SaveToXml(string filePath, object sourceObj, Type type, string xmlRootName)
    {
        if (!string.IsNullOrEmpty(filePath) && sourceObj != null)
        {

            string dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }
            type = type != null ? type : sourceObj.GetType();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrEmpty(xmlRootName) ?
                    new System.Xml.Serialization.XmlSerializer(type) :
                    new System.Xml.Serialization.XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                xmlSerializer.Serialize(writer, sourceObj);
            }
        }
    }

    public static object LoadFromXml(string filePath, Type type)
    {
        object result = null;

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                result = xmlSerializer.Deserialize(reader);
            }
        }

        return result;
    }
}