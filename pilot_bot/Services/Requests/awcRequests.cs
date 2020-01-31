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
            XmlNodeList raw_text, 
                        station_id, 
                        observation_time, 
                        latitude, 
                        longitude, 
                        temp_c, 
                        dewpoint_c, 
                        wind_dir_degrees, 
                        wind_speed_kt, 
                        visibility_statute_mi,
                        altim_in_hg, 
                        sea_level_pressure_mb, 
                        sky_condition, 
                        flight_category, 
                        maxT_c, minT_c, 
                        metar_type, elevation_m, 
                        data;

            string result = string.Empty;

            string Url = $"https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&hoursBeforeNow=3&mostRecent=true&stationString={Icao}";
            
            XmlDocument doc = new XmlDocument();
            
            doc.Load(Url);

            data                    = doc.GetElementsByTagName("data");
            raw_text                = doc.GetElementsByTagName("raw_text");
            station_id              = doc.GetElementsByTagName("station_id");
            observation_time        = doc.GetElementsByTagName("observation_time");
            latitude                = doc.GetElementsByTagName("latitude");
            longitude               = doc.GetElementsByTagName("longitude");
            temp_c                  = doc.GetElementsByTagName("temp_c");
            dewpoint_c              = doc.GetElementsByTagName("dewpoint_c");
            wind_dir_degrees        = doc.GetElementsByTagName("wind_dir_degrees");
            wind_speed_kt           = doc.GetElementsByTagName("wind_speed_kt");
            visibility_statute_mi   = doc.GetElementsByTagName("visibility_statute_mi");
            altim_in_hg             = doc.GetElementsByTagName("altim_in_hg");
            sea_level_pressure_mb   = doc.GetElementsByTagName("sea_level_pressure_mb");
            sky_condition           = doc.GetElementsByTagName("sky_condition");
            flight_category         = doc.GetElementsByTagName("flight_category");
            maxT_c                  = doc.GetElementsByTagName("maxT_c");
            minT_c                  = doc.GetElementsByTagName("minT_c");
            metar_type              = doc.GetElementsByTagName("metar_type");
            elevation_m             = doc.GetElementsByTagName("elevation_m");

            if (data[0].Attributes["num_results"].Value == "1")
            {
                for (int i = 0; i < data.Count; i++)
                {
                    result = $"####################\n\n" +
                             $"REPORT\n\n" +
                             $"Type:   {metar_type[i].InnerText}\n\n" +
                             $"Code:   {raw_text[i].InnerText}\n\n" +
                             $"Icao:   {station_id[i].InnerText}\n\n" +
                             $"Date/Time:   {observation_time[i].InnerText.Substring(0, 10)} / {observation_time[i].InnerText.Substring(11, 9)}\n\n" +
                             $"Temperature:   {temp_c[i].InnerText}°C\n\n" +
                             $"DewPoint:   {dewpoint_c[i].InnerText}°C\n\n" +
                             $"Wind Direction/Speed:   {wind_dir_degrees[i].InnerText}° / {wind_speed_kt[i].InnerText}KT\n\n" +
                             $"Visibility Distance:   {visibility_statute_mi[i].InnerText}m\n\n" +
                            //  $"WEATHER CONDITIONS: {sky_condition[i].Attributes["sky_cover"].Value} / {sky_condition[i].Attributes["cloud_base_ft_agl"].Value}\n\n" +
                             $"####################";
                }

                return result;             
            }
            else
            {
                return $"No METAR found for '{Icao}', try again later.";
            }
        }
    }
}