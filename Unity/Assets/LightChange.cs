using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;
using TMPro;

public class LightChange : MonoBehaviour
{

    /* light value define */
    float originalRange;
    float lightRange = 0.0f;
    Light lt;
    bool flag = true;    // Light Range = true: 0.0f -> 10.0f, false: 10.0f -> 0.0f
    
    /* light value define */

   /* Arduino Communication value define */
    float airData = 0.0f;
     public enum PortNumber{
        COM1,   COM2,   COM3,   COM4,
        COM5,   COM6,   COM7,   COM8,
        COM9,   COM10,  COM11,  COM12,
        COM13,  COM14,  COM15,  COM16
    }

    private SerialPort serial;

    [SerializeField]
    private PortNumber portNumber = PortNumber.COM4;
    [SerializeField]
    private string baudRate = "9600";
     /* Arduino Communication  value define */

    [SerializeField] private TextMeshProUGUI ioCheckText;

    public bool ioCheckFlag = false;

    public List<float> dataList = new List<float>();

    void Start()
    {
        InitArduinoCommunication();

        lt = GetComponent<Light>();
        originalRange = lt.range;
    }
    void Update()
    {
    
        //  StartCoroutine("Fade");     // 조명의 값이 잘 바뀌는지 확인하고 싶으면 여기 있는 주석을 풀어주세요 

        InputArduinoData();
        lt.range = airData;
    }

    void InitArduinoCommunication(){
        serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate), Parity.None, 8, StopBits.One);
        serial.Open();
        serial.ReadTimeout = 5000;
    }

    void onApplicationQuit(){
        serial.Close();
    }

    void InputArduinoData(){
        if(serial.IsOpen){
            try
            {   ioCheckFlag = true;
                airData = float.Parse(serial.ReadLine());
                Debug.Log("Air Pressure Sensor: " + airData);
                ioCheckText.text = "Air Pressure Sensor " + airData ;
                lt.range = airData;
                dataList.Add(airData);
    
            }
            catch (System.Exception)
            {
                ioCheckFlag = false;
                Debug.Log("error");
                ioCheckText.text = "Unable to read data from Arduino";
                throw;
            }
        }else if(!serial.IsOpen){
            serial.Open();
        }
    }

        /* Coroutine Code 
       test Light Range*/
    IEnumerator Fade(){
        if(lightRange >= 10.0f) flag = false;
        else if(lightRange <= 0.0f) flag = true;

        lightRange += (flag == true) ? 1.0f : -1.0f;
        Debug.Log("LightRange: "+ lightRange);
        lt.range = lightRange;

        yield return new WaitForSeconds(0.5f);
    }

}