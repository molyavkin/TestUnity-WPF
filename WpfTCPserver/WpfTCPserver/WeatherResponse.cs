using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WpfTCPserver
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }

        public void GetTemperatureInfo(ref SummaryInfo info)
        {
            string[] getTemperature = new string[2];
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Chelyabinsk&units=metric&appid=ca45e6d39cc20ab055d7057c33c06734";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
                
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            //Console.WriteLine("Temperature in {0}: {1} C", weatherResponse.Name, weatherResponse.Main.Temp);

            //return weatherResponse.Name + weatherResponse.Main.Temp.ToString();
            info.weather = weatherResponse.Name + " " + weatherResponse.Main.Temp.ToString() + " С";
        }

    }
}
