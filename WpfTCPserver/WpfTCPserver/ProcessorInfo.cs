using Microsoft.Win32;
using System;
using System.Management;


//Please remember to add a reference to the System.Management.dll in Visual Studio.

namespace WpfTCPserver
{
    public static class ProcessorInfo
    {
        public static void GetProcessorInfo(ref SummaryInfo info)
        {


            string cpuInfo = "x";

            //Console.WriteLine("Количество процессоров");
            cpuInfo += Environment.ProcessorCount.ToString();
            //Console.WriteLine("Имя процессора:");
            object result = Registry.GetValue(
"HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0",
"ProcessorNameString", "");

            if (result != null) cpuInfo += (result).ToString() + " ";

            result = Registry.GetValue(
            "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0",
            "~MHz", 0);

            if (result != null)
            {
                cpuInfo += ((int)result).ToString() + " MHz";
            }
            info.cpuName = cpuInfo;
            string cpu = "CPU: ";
            try
            {
                Double CPUtprt = 0;
                /*System.Management.ManagementObjectSearcher MOS = new System.Management.ManagementObjectSearcher("root\\WMI",
                        "SELECT * FROM MSAcpi_ThermalZoneTemperature");*/
                System.Management.ManagementObjectSearcher MOS = new System.Management.ManagementObjectSearcher("root\\WMI",
                        "SELECT * FROM Win32_PerfFormattedData_Counters_ThermalZoneInformation");
                /* $data = Get - WMIObject - Query "SELECT * FROM Win32_PerfFormattedData_Counters_ThermalZoneInformation" - Namespace "root/CIMV2"
 @($data)[0].HighPrecisionTemperature*/
                foreach (System.Management.ManagementObject Mo in MOS.Get())
                {
                    CPUtprt = Convert.ToDouble(Convert.ToDouble(Mo.GetPropertyValue("CurrentTemperature".ToString())) - 2732) / 10.0;
                    //listBox1.Items.Add(" CPU: " + CPUtprt.ToString() + " ° C");
                    cpu += CPUtprt.ToString() + " ° C";
                }
            }
            catch (ManagementException ex)
            {
                //MessageBox.Show("Ошибка получения данных " + ex.Message);
                cpu += "Error receiving data " + ex.Message;
            }
            info.cpuTemp = cpu;
           
        }

    }
}
