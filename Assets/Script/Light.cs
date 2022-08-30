using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public bool lightOn;
    public GameObject ligtWarning;
    public GameObject lightObj;
    public GameObject lightdead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 전구 클릭했을 때
    public void clickLight()
    {
        if (GameManager.instance.light) {

            if (GameManager.instance.checkWindow())
            {
                if (lightOn)
                {
                    lightOff();
                }
                else
                {
                    if (!GameManager.instance.robot)
                    {
                        GameManager.instance.lightN += 1;
                        GameManager.instance.printClickNum();

                        if (Random.Range(0, 2) == 0)
                        {
                            lightOn = true;
                            lightObj.SetActive(true);
                        }
                    }
                    else {

                        GameManager.instance.lightN += 1;
                        GameManager.instance.printClickNum();
                        lightOn = true;
                        lightObj.SetActive(true);
                    }
                }

            }
        }
        else
        {
            lightdead.SetActive(true);
        }
        
        
    }
    public void lightOff()
    {
        lightOn = false;
        lightObj.SetActive(false);
    }
    public void lightWarningExit()
    {
        ligtWarning.SetActive(false);
    }
}
