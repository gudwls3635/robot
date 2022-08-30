using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    public GameObject light;
    public GameObject warning;

    public GameObject mess;
    public Text tex, tex2;
    public Image img;
    public Sprite fd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 식탁 클릭했을 떄
    public void clickTable()
    {
        if(GameManager.instance.checkWindow())
        {
            if(light.GetComponent<Light>().lightOn)
            {
                GameManager.instance.tableN += 1;
                GameManager.instance.printClickNum();


                mess.SetActive(true);
                tex.text = "식탁을 사용해 맛있는 음식을 만들었다!";
                GameManager.instance.food = GameManager.instance.food + 2;
                img.sprite = fd;
                tex2.text = "+2";
            }
            else
            {
                warning.SetActive(true);
            }
            

        }

    }
}
