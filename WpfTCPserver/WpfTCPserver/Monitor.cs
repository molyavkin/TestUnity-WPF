using System;
using System.Management;

namespace WpfTCPserver
{
    public static class Monitor
    {
        public static void GetMonitorInfo(ref SummaryInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            else
            {
                string monitor = "";
                ManagementScope scope = new ManagementScope("\\\\localhost\\root\\cimv2");
                scope.Connect();
                // Запрашиваем информацию о мониторе 

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_DesktopMonitor");
                ManagementObjectSearcher searcher3 = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher3.Get();
                foreach (ManagementObject mo in queryCollection)
                {
                    string nl = Environment.NewLine;
                    // Выводим информацию с компьютера 
                    //Console.WriteLine("Описание: " + mo["Description"] + nl);
                    //Console.WriteLine("Тип монитора: " + mo["MonitorType"] + nl);
                    // monitor += mo["Description"] + nl + mo["MonitorType"] + nl;
                    monitor += mo["Description"];
                }
                info.monitor = monitor;
                //return monitor;
            }
        }

    }
}
