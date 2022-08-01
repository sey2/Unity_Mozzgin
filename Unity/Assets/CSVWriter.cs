using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CSVWriter : MonoBehaviour
{
    string filename = "";
    public GameObject lanternObj;
    public Button saveBtn;
   
    [System.Serializable]
    public class Breath{
        public float atm;

        public Breath(float atm){this.atm = atm;}
    }

    public List<Breath> breathList = new List<Breath>();

    void Start()
    {
        lanternObj = GameObject.Find("Lentern Light");
        filename = Application.dataPath + "/dataSheet.csv";

        saveBtn.onClick.AddListener(delegate{
            List<float> tmp = lanternObj.GetComponent<LightChange>().dataList;

            for(int i=0; i<tmp.Count; i++){
                breathList.Add(new Breath(tmp[i]));
            }
            WriteCSV();
            lanternObj.GetComponent<LightChange>().dataList.Clear();
        });
    }
    void Update()
    {

    }

    public void WriteCSV()
    {
        if(breathList.Count> 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Sensor Data");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(int i=0; i<breathList.Count; i++){
                tw.WriteLine(breathList[i].atm);
            }

            tw.Close();
        }
    }
}
