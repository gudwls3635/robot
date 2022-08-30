using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Debuffs : MonoBehaviour
{
    public GameObject mission;
    public GameObject Button;
    public GameObject content;
    public GameObject DebuffPopup;
    public int ch;
    int cch;
    public GameObject Message;
    GameObject[] TmpArray = new GameObject[3];

    public GameObject mess;

    public GameObject lightBroke;

    public Sprite foodIcon, batteryIcon, batteryMinusIcon;
    // Start is called before the first frame update
    void Start()
    {
        cch = 0;
        Acheivements();
        mission.SetActive(false);
        ch = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            cch = 1;
            if (DebuffPopup.activeSelf == true)
            {
                DebuffPopup.SetActive(false);
            }
            if (mission.activeSelf == false)
            {

                realpopup();

            }
            else
            {
              
                mission.SetActive(false);

                if (ch == 0)
                {
                    
                    ch = 1;
                }
            }
        }

        if (GameManager.instance.lightN == GameManager.instance.light_debuff
            || GameManager.instance.windowN == GameManager.instance.window_debuff
            || GameManager.instance.tableN == GameManager.instance.table_debuff)
        {
            if(mess.activeSelf == false)
                realpopup();
            
        }
       
    }
    public void destroyArcheive()
    {
        for (int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
    }        
                
    public void Acheivements()
    {
        //ll lu wl wu tl tu lloss_b wloss_c tloss_b tloss_c
        if (GameManager.instance.date < 4)
            ehh(8, 12, 3, 5, 3, 5, 10, 2, 5, 1);
        else if (GameManager.instance.date < 9)
            ehh(5, 9, 2, 4, 2, 4, 15, 3, 8, 2);
        else
            ehh(1, 3, 1, 2, 1, 2, 20 ,5, 10,2);


        if (!GameManager.instance.robot)
        {
            GameObject Tmp = Instantiate(Button, new Vector3(0, 0, 0), Quaternion.identity);
            Tmp.transform.SetParent(content.transform);
            Tmp.transform.localScale = new Vector3(1, 1, 1);
            Tmp.transform.GetChild(0).GetComponent<Text>().text
                = "전등 ? 번 사용하지 않기 (" + GameManager.instance.lightN + "/?)";
            Tmp.transform.GetChild(1).GetComponent<Image>().sprite = batteryIcon;
            Tmp.transform.GetChild(2).GetComponent<Text>().text = "- "+GameManager.instance.lloss_b.ToString();
            Tmp.transform.GetChild(3).gameObject.SetActive(false);
            Tmp.transform.GetChild(4).gameObject.SetActive(false);
            TmpArray[2] = Tmp;
            TmpArray[0] = null;
            TmpArray[1] = null;
        }
        else
        {
            if (GameManager.instance.date == 1)
            {
                GameObject Tmp = Instantiate(Button, new Vector3(0, 0, 0), Quaternion.identity);
                Tmp.transform.SetParent(content.transform);
                Tmp.transform.localScale = new Vector3(1, 1, 1);
                Tmp.transform.GetChild(0).GetComponent<Text>().text
                    = "창문 ? 번 열지 않기 (" + GameManager.instance.windowN + "/?)";
                TmpArray[0] = Tmp;
                Tmp.transform.GetChild(1).GetComponent<Image>().sprite = batteryIcon;
                Tmp.transform.GetChild(2).GetComponent<Text>().text = "- " + GameManager.instance.wloss_c.ToString();
                Tmp.transform.GetChild(3).gameObject.SetActive(false);
                Tmp.transform.GetChild(4).gameObject.SetActive(false);
            }
            else
            {
                ch = 0;
                if (GameManager.instance.date == 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        GameObject Tmp = Instantiate(Button, new Vector3(0, 0, 0), Quaternion.identity);
                        Tmp.transform.SetParent(content.transform);
                        Tmp.transform.localScale = new Vector3(1, 1, 1);
                        if (i == 0)
                        {
                            Tmp.transform.GetChild(0).GetComponent<Text>().text
                                = "창문 ? 번 열지 않기 (" + GameManager.instance.windowN + "/?)";
                            Tmp.transform.GetChild(1).GetComponent<Image>().sprite = batteryIcon;
                            Tmp.transform.GetChild(2).GetComponent<Text>().text = "- " + GameManager.instance.wloss_c.ToString();
                            Tmp.transform.GetChild(3).gameObject.SetActive(false);
                            Tmp.transform.GetChild(4).gameObject.SetActive(false);

                        }
                        if (i == 1)
                        {
                            Tmp.transform.GetChild(0).GetComponent<Text>().text
                                = "조리대 ? 번 사용하지 않기 (" + GameManager.instance.tableN + "/?)";
                            Tmp.transform.GetChild(1).GetComponent<Image>().sprite = batteryIcon;
                            Tmp.transform.GetChild(2).GetComponent<Text>().text = "- " + GameManager.instance.tloss_b.ToString();
                            
                            Tmp.transform.GetChild(3).GetComponent<Image>().sprite = batteryMinusIcon;
                            Tmp.transform.GetChild(4).GetComponent<Text>().text = "+ " + GameManager.instance.tloss_c.ToString();
                        }
                        TmpArray[i] = Tmp;
                    }
                }
                else
                {

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject Tmp = Instantiate(Button, new Vector3(0, 0, 0), Quaternion.identity);
                        Tmp.transform.SetParent(content.transform);
                        Tmp.transform.localScale = new Vector3(1, 1, 1);
                        if (i == 0)
                        {
                            Tmp.transform.GetChild(0).GetComponent<Text>().text
                                = "창문 ? 번 열지 않기 (" + GameManager.instance.windowN + "/?)";
                            Tmp.transform.GetChild(1).GetComponent<Image>().sprite = batteryIcon;
                            Tmp.transform.GetChild(2).GetComponent<Text>().text = "- " + GameManager.instance.wloss_c.ToString();
                            Tmp.transform.GetChild(3).gameObject.SetActive(false);
                            Tmp.transform.GetChild(4).gameObject.SetActive(false);
                        }
                        if (i == 1)
                        {
                            Tmp.transform.GetChild(0).GetComponent<Text>().text
                                = "조리대 ? 번 사용하지 않기 (" + GameManager.instance.tableN + "/?)";
                            Tmp.transform.GetChild(1).GetComponent<Image>().sprite = batteryIcon;
                            Tmp.transform.GetChild(2).GetComponent<Text>().text = "- " + GameManager.instance.tloss_b.ToString();

                            Tmp.transform.GetChild(3).GetComponent<Image>().sprite = batteryMinusIcon;
                            Tmp.transform.GetChild(4).GetComponent<Text>().text = "+ " + GameManager.instance.tloss_c.ToString();
                        }
                        if (i == 2)
                        {
                            Tmp.transform.GetChild(0).GetComponent<Text>().text
                                = "전등 ? 번 사용하지 않기 (" + GameManager.instance.lightN + "/?)";
                            Tmp.transform.GetChild(1).GetComponent<Image>().sprite = batteryIcon;
                            Tmp.transform.GetChild(2).GetComponent<Text>().text = "- " + GameManager.instance.lloss_b.ToString();
                            Tmp.transform.GetChild(3).gameObject.SetActive(false);
                            Tmp.transform.GetChild(4).gameObject.SetActive(false);
                        }
                        TmpArray[i] = Tmp;
                    }
                }
            }
        }
        


    }

    void ehh(int a, int b, int c, int d, int e, int f,int g, int h, int i, int j)
    {
        GameManager.instance.ll = a;
        GameManager.instance.lu = b;
        GameManager.instance.wl = c;
        GameManager.instance.wu = d;
        GameManager.instance.tl = e;
        GameManager.instance.tu = f;
        GameManager.instance.lloss_b = g;
        GameManager.instance.wloss_c = h;
        GameManager.instance.tloss_b = i;
        GameManager.instance.tloss_c = j;
    }

    public void popup()
    {
        Message.SetActive(false);
        GameManager.instance.transform.GetComponent<Debuffs>().mission.SetActive(true);
        if(cch!=0)
            GameManager.instance.transform.GetComponent<Debuffs>().mission.transform.GetChild(2).gameObject.SetActive(false);

    }

    public void realpopup()
    {
        if (TmpArray[0] != null)
        {
            if (GameManager.instance.windowN == GameManager.instance.window_debuff)
            {

                TmpArray[0].transform.GetChild(0).GetComponent<Text>().text
                        = "창문 " + GameManager.instance.window_debuff + "번 열지 않기 (" + GameManager.instance.windowN + "/" + GameManager.instance.window_debuff + ")";

                //디버프
                DebuffPopup.SetActive(true);
                DebuffPopup.transform.GetChild(0).GetComponent<Text>().text = "전력 소모! 배터리 - " + GameManager.instance.wloss_c;
                GameManager.instance.consumebattery -= GameManager.instance.wloss_c;

                //초기화
                GameManager.instance.windowN = 0;
                GameManager.instance.window_debuff
                   = Random.Range(GameManager.instance.wl, GameManager.instance.wu + 1);
            }
            else if (GameManager.instance.date == 1)
            {
                TmpArray[0].transform.GetChild(0).GetComponent<Text>().text
                        = "창문 " + GameManager.instance.window_debuff + "번 열지 않기 (" + GameManager.instance.windowN + "/" + GameManager.instance.window_debuff + ")";
            }
            else
                TmpArray[0].transform.GetChild(0).GetComponent<Text>().text
                                    = "창문 ? 번 열지 않기 (" + GameManager.instance.windowN + "/?)";
        }

        if (TmpArray[1] != null)
            if(GameManager.instance.tableN == GameManager.instance.table_debuff) {

                TmpArray[1].transform.GetChild(0).GetComponent<Text>().text
                        = "조리대 " + GameManager.instance.table_debuff + "번 사용하지 않기 (" + GameManager.instance.tableN + "/" + GameManager.instance.table_debuff + ")";

                //디버프
                DebuffPopup.SetActive(true);
                DebuffPopup.transform.GetChild(0).GetComponent<Text>().text = "전력 소모! 배터리 - " + GameManager.instance.tloss_b+"\n성능 저하! 전력소비량 + " +GameManager.instance.tloss_c;
                GameManager.instance.consumebattery+=GameManager.instance.tloss_c;
                GameManager.instance.battery-= GameManager.instance.tloss_b;

                //초기화
                GameManager.instance.table_debuff
                   = Random.Range(GameManager.instance.tl, GameManager.instance.tu + 1);
                GameManager.instance.tableN = 0;
            }

            else
                TmpArray[1].transform.GetChild(0).GetComponent<Text>().text
                    = "조리대 ? 번 사용하지 않기 (" + GameManager.instance.tableN + "/?)";
        if (TmpArray[2] != null)
            if (GameManager.instance.lightN == GameManager.instance.light_debuff) {


                TmpArray[2].transform.GetChild(0).GetComponent<Text>().text
                      = "전등 " + GameManager.instance.light_debuff + "번 사용하지 않기 (" + GameManager.instance.lightN + "/" + GameManager.instance.light_debuff + ")";

                //디버프
                if (GameManager.instance.robot)
                {
                    DebuffPopup.SetActive(true);
                    DebuffPopup.transform.GetChild(0).GetComponent<Text>().text = "전력 소모! 배터리 - " + GameManager.instance.lloss_b;
                    GameManager.instance.battery -= GameManager.instance.lloss_b;
                }
                else
                {
                    Debug.Log("???");
                    lightBroke.SetActive(true);
                    GameManager.instance.light = false;
                    GetComponent<Debuffs>().enabled=false;
                }

                //초기
                GameManager.instance.light_debuff
                  = Random.Range(GameManager.instance.ll, GameManager.instance.lu + 1);
                GameManager.instance.lightN = 0;
            }
               
            else
                TmpArray[2].transform.GetChild(0).GetComponent<Text>().text
                   = "전등 ? 번 사용하지 않기 (" + GameManager.instance.lightN + "/?)";

        mission.SetActive(true);
    }
    public void outt()
    {
        mission.SetActive(false);
    }
}
