using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public float tempo = 120;
    public Text timerText;

    void Update()
    {
        if(tempo > 0)
        {
            tempo -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Acabou o tempo");
        }
        
        MostrarTempo(tempo);
    }

    void MostrarTempo(float tempo)
    {
        if(tempo < 0)
        {
            tempo = 0;
        }
        
        float minutos = Mathf.FloorToInt(tempo / 60);
        float segundos = Mathf.FloorToInt(tempo % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        Debug.Log(minutos + ":" + segundos);
    }
}
