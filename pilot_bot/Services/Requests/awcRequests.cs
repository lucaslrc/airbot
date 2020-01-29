using System;
using System.IO;
using System.Net;
using System.Xml;

namespace airbot.Services.Requests
{
    public class awcRequests
    {
        public string getMetar(string Icao)
        {
            string result = string.Empty;

            string Url = $"https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&hoursBeforeNow=3&mostRecent=true&stationString={Icao}";
            
            XmlDocument doc = new XmlDocument();
            
            doc.Load(Url);

            XmlNodeList elemList = doc.GetElementsByTagName("METAR");

            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerXml);
            }


            return null;
        }
    }
}