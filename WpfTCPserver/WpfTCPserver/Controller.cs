using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfTCPserver
{
    public static class Controller
    {
        public static string GetInfo()
        {
            SummaryInfo info = new SummaryInfo();
            string serializedXML = "";

            SystemBoardInfo.GetSystemBoardInfo(ref info);
            ProcessorInfo.GetProcessorInfo(ref info);
            AudioVolume.GetVolumeMicrophone(ref info);
            WeatherResponse weather = new WeatherResponse();
            weather.GetTemperatureInfo(ref info);
            

            
            Monitor.GetMonitorInfo(ref info);
            
            XmlSerializer serializer = new XmlSerializer(typeof(SummaryInfo));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, info);
                serializedXML = writer.ToString();
            }
            return serializedXML;
        }
        

    }
}
