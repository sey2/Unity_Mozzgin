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
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v)=>{
            sliderText.text = v.ToString("0.00");
            lt.range = float.Parse(v.ToString("0.00"));
        });
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
