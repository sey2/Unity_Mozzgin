using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class SliderScripts : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private Light lt;

    GameObject lanternObj;
    // Start is called before the first frame update
    void Start()
    {
        lanternObj = GameObject.Find("Lentern Light");

        slider.onValueChanged.AddListener((v)=>{
            sliderText.text = v.ToString("0.00");

            if(lanternObj.GetComponent<LightChange>().ioCheckFlag == false)
              lt.range = float.Parse(v.ToString("0.00"));
            else if(lanternObj.GetComponent<LightChange>().ioCheckFlag == true)
              sliderText.text  = "Cannot change to slider because reading value with Arduino";

        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
