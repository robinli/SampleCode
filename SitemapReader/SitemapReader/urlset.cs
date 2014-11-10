using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace SitemapReader
{
    public class GoogleSiteMapHelper
    {
        public static void SerializeToXml<T>(T obj, string fileName)
        {
            //Kim01
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(fileName,
    FileMode.OpenOrCreate);
            ser.Serialize(fileStream, obj);
            fileStream.Close();
        }

        public static T DeserializeFromXml<T>(string fileName)
        {
            FileStream ReadFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // Load the object saved above by using the Deserialize function
            XmlSerializer SerializerObj = new XmlSerializer(typeof(T));
            T LoadedObj = (T)SerializerObj.Deserialize(ReadFileStream);
            // Cleanup
            ReadFileStream.Close();
            return LoadedObj;
        }
    }

    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class GoogleSiteMap
    {
        private readonly List<SiteUrl> urls = new List<SiteUrl>();
        [XmlElement("url")]
        public List<SiteUrl> Urls { get { return urls; } }
    }

    public class SiteUrl
    {
        [XmlElement("loc")]
        public string Location { get; set; }
        [XmlElement("news", Namespace = "http://www.google.com/schemas/sitemap-news/0.9")]
        public string News { get; set; }
        [XmlElement("lastmod")]
        public DateTime? LastModified { get; set; }
        [XmlElement("changefreq")]
        public string ChangeFrequency { get; set; }

        public bool ShouldSerializeLastModified() { return LastModified.HasValue; }
    }
}
