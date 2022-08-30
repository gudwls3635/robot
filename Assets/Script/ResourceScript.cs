using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceScript : MonoBehaviour
{
    public GameObject batterytxt;
    public GameObject foodtxt;
    public GameObject consumetxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Day - " + GameManager.instance.date.ToString();
        batterytxt.GetComponent<Text>().text = GameManager.instance.battery.ToString();
        foodtxt.GetComponent<Text>().text = GameManager.instance.food.ToString();
        consumetxt.GetComponent<Text>().text = "-"+GameManager.instance.consumebattery;
    }
}
