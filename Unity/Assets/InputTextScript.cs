using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
public class InputTextScript : MonoBehaviour
{

    public TMP_InputField userInput;
    private  GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider");
        userInput.onEndEdit.AddListener(delegate{
            LockInput(userInput);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

     void LockInput(TMP_InputField input)
    {
        float inputData = float.Parse(userInput.text);

        if(Input.GetKeyDown(KeyCode.Return) && inputData >= 0.0 && inputData <= 10.0)
            slider.GetComponent<UnityEngine.UI.Slider>().value = inputData;
    

    }
}
