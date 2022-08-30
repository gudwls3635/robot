using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Fade;
    public Animator fadeOut;
    public Animator Robot;

    public GameObject getFood;
    public GameObject rbDead;
    public GameObject lowBattery;

    public GameObject robotObj;
    int lowbattery=0;
    void Start()
    {
        GameManager.instance.light_debuff
            = Random.Range(GameManager.instance.ll, GameManager.instance.lu + 1);
        GameManager.instance.table_debuff
            = Random.Range(GameManager.instance.tl, GameManager.instance.tu + 1);
        GameManager.instance.window_debuff
            = Random.Range(GameManager.instance.wl, GameManager.instance.wu + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 문 클릭했을 때
    public void clickDoor()
    {
        /*GameManager.instance.doorN += 1;
        GameManager.instance.printClickNum();*/
        if (GameManager.instance.checkWindow())
        {
            Debug.Log("door clicked");

            if (GameManager.instance.robot)
            {
                Robot.Play("goout");
                Fade.Play("darken");

            }
            else
            {
                rbDead.SetActive(true);
            }
        }
            
    }

    public void Darken()
    {
        rbDead.SetActive(false);
        Fade.Play("darken");
    }

    public void nextDay()
    {
        
        if ( GameManager.instance.food < 10)
        {
            GameManager.instance.food = 0;
            GameManager.instance.gameOverPopupOn("먹을 식량이 다 떨어졌습니다...");
        }else if(GameManager.instance.date >=9 )
        {
            GameManager.instance.date++;
            GameManager.instance.gameClearPopupOn("인간 부품을 다모았습니다.");
        }
        else
        {
            if (GameManager.instance.battery < GameManager.instance.consumebattery)
            {
                GameManager.instance.robot = false;
                robotObj.GetComponent<Image>().color = new Color(1, 0.4f, 0.4f, 1);
            }
            else
                GameManager.instance.battery -= GameManager.instance.consumebattery;

            GameManager.instance.food -= 10;
            GameManager.instance.date++;

            GameManager.instance.light_debuff
                = Random.Range(GameManager.instance.ll, GameManager.instance.lu+1);
            GameManager.instance.table_debuff
                = Random.Range(GameManager.instance.tl, GameManager.instance.tu+1);
            GameManager.instance.window_debuff
                = Random.Range(GameManager.instance.wl, GameManager.instance.wu+1);


            if (GameManager.instance.robot)
                GameManager.instance.lightN = 0;
            GameManager.instance.windowN = 0;
            GameManager.instance.tableN = 0;

            getFood.GetComponent<getFood>().plusFood();

            if (GameManager.instance.light)
            {
                GameManager.instance.transform.GetComponent<Debuffs>().destroyArcheive();
                GameManager.instance.transform.GetComponent<Debuffs>().Acheivements();
                GameManager.instance.transform.GetComponent<Debuffs>().Message.SetActive(true);

                if (!GameManager.instance.robot)
                {
                    lowBattery.SetActive(true);
                    lowbattery = 1;
                }

            }
        }
        
        
    }
}
