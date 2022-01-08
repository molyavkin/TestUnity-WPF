using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTCPserver
{[Serializable]
    public class SummaryInfo
    {
        protected string _weather;
        protected string _cpuName;
        protected string _cpuTemp;
        protected string _monitor;
        protected string _soundСard;
        protected string _camera;
        protected string _microphoneLevel;
        protected string _microphoneName;

        public string weather
        {
            get
            {
                return _weather;
            }
            set
            {
                _weather = value;
            }
        }
        public string cpuTemp
        {
            get
            {
                return _cpuTemp;
            }
            set
            {
                _cpuTemp = value;
            }
        }
        public string cpuName
        {
            get
            {
                return _cpuName;
            }
            set
            {
                _cpuName = value;
            }
        }
        public string monitor
        {
            get
            {
                return _monitor;
            }
            set
            {
                _monitor = value;
            }
        }
        public string soundCard
        {
            get
            {
                return _soundСard;
            }
            set
            {
                _soundСard = value;
            }
        }
        public string camera
        {
            get
            {
                return _camera;
            }
            set
            {
                _camera = value;
            }
        }
        public string microphoneLevel
        {
            get
            {
                return _microphoneLevel;
            }
            set
            {
                _microphoneLevel = value;
            }
        }
        public string microphoneName
        {
            get
            {
                return _microphoneName;
            }
            set
            {
                _microphoneName = value;
            }
        }

    }
}
