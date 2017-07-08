using System.Xml;

namespace QLNhapTinh
{
    class ReadConfig
    {
        XmlDocument xml;
        public void Read()
        {
            xml = new XmlDocument();
            xml.Load("config.xml");
            AppConfig.Server = xml.SelectSingleNode("config/server").InnerText.ToString();
            AppConfig.Database = xml.SelectSingleNode("config/batabase").InnerText.ToString();
            AppConfig.Username = xml.SelectSingleNode("config/user").InnerText.ToString();
            AppConfig.Password = xml.SelectSingleNode("config/password").InnerText.ToString();
            AppConfig.Databaseoff= xml.SelectSingleNode("config/databaseoff").InnerText.ToString();
            AppConfig.Serveroff = xml.SelectSingleNode("config/serveroff").InnerText.ToString();
            AppConfig.Nhamay = xml.SelectSingleNode("config/nhamay").InnerText.ToString();
            AppConfig.Role = xml.SelectSingleNode("config/role").InnerText.ToString();
        }
    }
}
