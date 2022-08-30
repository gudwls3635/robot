using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batteryScript : MonoBehaviour
{
    public Sprite fullbattery;
    public Sprite battery;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //-87 -631
    // Update is called once per frame
    void Update()
    {
       
        if(GameManager.instance.battery<=0)
            gameObject.GetComponent<RectTransform>().localPosition = new Vector3(5f, -631, 0);
        if (GameManager.instance.battery >= 200)
        {
            gameObject.GetComponent<Image>().sprite = fullbattery;
            gameObject.GetComponent<RectTransform>().localPosition = new Vector3(5f, -87, 0);
        }
           
        else
        {
            gameObject.GetComponent<Image>().sprite = battery;
            gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-7.7f, -87 - (200 - GameManager.instance.battery) * 2.7f, 0);
        }
            

    }
}
