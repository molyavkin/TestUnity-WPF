using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeStart = 60;
    public Text timerText;
    public Text textFromServer;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timeStart.ToString();
       
       // textFromServer.text = Client.StartClient();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
        //textFromServer.text = Client.StartClient() + " " + Mathf.Round(timeStart).ToString();
        textFromServer.text = Client.StartClient();
       // print(Client.StartClient());
    }
    
}
