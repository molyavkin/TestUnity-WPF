using System;
using UnityEngine;

[Serializable]
public class SummaryInfo
{
    private string _weather;
    private string _cpuName;
    private string _cpuTemp;
    private string _monitor;
    private string _soundСard;
    private string _camera;
    private string _microphoneLevel;
    private string _microphoneName;
    

    public SummaryInfo(string weather, string cpuName, string cpuTemp, string monitor, 
                       string soundСard, string camera, string microphoneLevel, string microphoneName)
    {
        _weather = weather;
        _cpuName = cpuName;
        _cpuTemp = cpuTemp;
        _monitor = monitor;
        _soundСard = soundСard;
        _camera = camera;
        _microphoneLevel = microphoneLevel;
        _microphoneName = microphoneName;
    }
    public SummaryInfo()
    {

    }

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
