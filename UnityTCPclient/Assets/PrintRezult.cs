using UnityEngine;
using UnityEngine.UI;

public class PrintRezult : MonoBehaviour
{
    public Text weather;
    public Text microphoneLevel;
    public Text microphoneName;
    public Text soundCard;
    public Text myCamera;
    public Text cpuName;
    public Text cpuTemp;
    public Text monitor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string rezultLine = Client.StartClient();
        SummaryInfo info = GetInfo.DeserializeXml(rezultLine);

        weather.text = "Погода: " + info.weather;
        microphoneLevel.text = "Громкость микрофона: " + info.microphoneLevel;
        microphoneName.text = "Микрофон: " + info.microphoneName;
        soundCard.text = "Звуковая карта: " + info.soundCard;
        myCamera.text = "Веб-камера " + info.camera;
        cpuName.text = "Процессор: " + info.cpuName;
        cpuTemp.text = "Температура прцессора: " + info.cpuTemp;
        monitor.text = "Монитор: " + info.monitor;
    }
}
