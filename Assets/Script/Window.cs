using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    public GameObject[] objects = new GameObject[10];
    public int objectsize;
    public GameObject bird;
    public GameObject rock;
    public GameObject twobirds;
    public GameObject canvas;
    public GameObject Tmp;
    public int wd;
    public GameObject mess;
    public Text tex;
    public Text tex2;
    public Image img;
    public Sprite fd, bt, none;
    public int whether;
    public Image clwd;
    public Sprite clwd2;
    public Sprite opwd;



    public GameObject light;
    public GameObject warning;
    // Start is called before the first frame update
    void Start()
    {
        objectsize = 10;

        objects = new GameObject[objectsize];

        objects[1] = bird;
        objects[2] = rock;
        objects[3] = twobirds;

    }

    // Update is called once per frame
    void Update()
    {




    }
    public void ChangeImage()
    {
        transform.GetComponent<Image>().sprite = opwd;
    }


    //창문 클릭했을 떄
    public void clickWindow()
    {
        if (GameManager.instance.checkWindow())
        {
            if (light.GetComponent<Light>().lightOn)
            {
                GameManager.instance.windowN += 1;
                GameManager.instance.printClickNum();

                GetComponent<Window>().ChangeImage();
                whether = 1;

                mess.SetActive(false);

                wd = 1;

                int random = Random.Range(0, 11);

                switch (random)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        mess.SetActive(true);
                        tex.text = "창문을 열었지만 아무일도 일어나지 않았다!";
                        tex2.text = " ";
                        img.sprite = none;
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        Tmp = Instantiate(objects[1], transform.position, transform.rotation);
                        Tmp.transform.SetParent(canvas.transform);
                        Tmp.transform.localScale = new Vector3(1, 1, 1);
                        mess.SetActive(true);
                        tex.text = "오잉 창문을 열었더니 새가 날아들어왔다! 맜있어 보이는걸!";
                        img.sprite = fd;
                        tex2.text = "+3";
                        GameManager.instance.food = GameManager.instance.food + 3;
                        break;
                    case 8:
                    case 9:
                        Tmp = Instantiate(objects[2], transform.position, transform.rotation);
                        Tmp.transform.SetParent(canvas.transform);
                        Tmp.transform.localScale = new Vector3(1, 1, 1);
                        mess.SetActive(true);
                        tex.text = "폭풍이 몰아친다! 창문을 열었더니 돌이 날라왔다! 로봇이 데미지를 입었다!";
                        GameManager.instance.battery = GameManager.instance.battery - 10;
                        img.sprite = bt;
                        tex2.text = "-10";
                        if (GameManager.instance.battery <= 0)
                            GameManager.instance.gameover();
                        break;
                    case 10:
                        Tmp = Instantiate(objects[3], transform.position, transform.rotation);
                        Tmp.transform.SetParent(canvas.transform);
                        Tmp.transform.localScale = new Vector3(1, 1, 1);
                        mess.SetActive(true);
                        tex.text = "으아닛! 새가 두마리가 날아들어왔다! 이런것이 행운?!";
                        GameManager.instance.food = GameManager.instance.food + 7;
                        img.sprite = fd;
                        tex2.text = "+7";
                        break;

                }
            }
            else
            {
                warning.SetActive(true);
            }
                
        }

        
                   
    }
    public void popup()
    {
        mess.SetActive(false);
        light.GetComponent<Light>().lightOff();
        Destroy(Tmp);

        if (whether == 1)
        {
            transform.GetComponent<Image>().sprite = clwd2;

        }

    } 
}
