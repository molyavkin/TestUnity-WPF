using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WpfTCPserver
{
    public static class SystemBoardInfo
    {
        enum Devices
        {
            phon = 0,
            udio = 1,
            cam = 2
        }
        public static string[] FilterLines(string[] source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));


            var result = new List<string>();

            for (int i = 0; i < source.Length; i++)
            {
                var currentElement = source[i];

                if (!source.HasDuplicateFor(currentElement))
                    result.Add(currentElement);
            }

            return result.ToArray();
        }

        public static bool HasDuplicateFor(this string[] source, string needle)
        {
            var counter = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == needle)
                    counter++;
            }

            return counter > 1;

        }

        static string[] MicrophoneAudioCamera(string[] words)
        {
            //string[] devises = new string[] { "phon", "udio", "cam" };
            string[] lines = new string[3];


            for (int i = (int)Devices.phon; i <= (int)Devices.cam; i++)
            {
                var device = (Devices)i;
                string dev = device.ToString();
                foreach (var item in words)
                {
                    if (item.IndexOf(dev) != -1)//Если в строке есть части "phon" или "udio" или "cam"
                    {
                        lines[i] += item + " ";
                    }
                }
                //lines[i] += dev

                Console.WriteLine();

            }

            //string[] result = lines.ToArray();
            return lines;
        }

        public static string SystemBoard()
        {
            string system = "";
            ManagementScope scope = new ManagementScope("\\\\localhost\\root\\cimv2");
            scope.Connect();
            // Запрашиваем информацию о устройствах 

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PnPEntity");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                string nl = Environment.NewLine;

                system += mo["Name"] + nl;
            }
            Console.WriteLine();
            return system;


        }

        public static void GetSystemBoardInfo(ref SummaryInfo info)
        {
            string system = SystemBoard();
            string[] separatingStrings = { "\r\n", "..." };

            string[] words = system.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine($"{words.Length} substrings in text:");

            foreach (var word in words)
            {
                //Console.WriteLine(word);
            }
            string[] filterDevices = FilterLines(words);
            string[] devices = MicrophoneAudioCamera(filterDevices);
            info.microphoneName = devices[(int)Devices.phon];
            info.soundCard = devices[(int)Devices.udio];
            info.camera = devices[(int)Devices.cam];
            Console.WriteLine();

        }

    }
}
