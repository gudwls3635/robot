using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotScript : MonoBehaviour
{
    public Sprite robot1;
    public Sprite robot2;
    public Sprite robot3;
    public Sprite robot4;
    public Sprite robot5;
    public Sprite robot6;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.date < 2)
            gameObject.GetComponent<Image>().sprite = robot1;
        
        else if(GameManager.instance.date < 3)
            gameObject.GetComponent<Image>().sprite = robot2;

        else if (GameManager.instance.date < 6)
            gameObject.GetComponent<Image>().sprite = robot3;

        else if (GameManager.instance.date <8)
            gameObject.GetComponent<Image>().sprite = robot4;

        else if (GameManager.instance.date < 10)
            gameObject.GetComponent<Image>().sprite = robot5;

        else if (GameManager.instance.date == 10)
            gameObject.GetComponent<Image>().sprite = robot6;


    }
}
