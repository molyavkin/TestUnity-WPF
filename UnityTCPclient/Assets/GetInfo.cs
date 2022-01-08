using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;

public static class GetInfo 
{
    public static SummaryInfo DeserializeXml(string XMLstring)
    {
        if (XMLstring == "start")
        {
            SummaryInfo summaryInfo = new SummaryInfo("Информация не найдена",
                                                      "Информация не найдена",
                                                      "Информация не найдена",
                                                      "Информация не найдена",
                                                      "Информация не найдена",
                                                      "Информация не найдена",
                                                      "Информация не найдена",
                                                      "Информация не найдена");
            return summaryInfo;

            
        }
        else
        {
            using (StringReader writer = new StringReader(XMLstring))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SummaryInfo));
                return (SummaryInfo)serializer.Deserialize(writer);

            }
        }
        
        
    }

    
}
