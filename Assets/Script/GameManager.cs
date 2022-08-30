using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance; // 싱글톤

    public int lightN;
    public int windowN;
    public int tableN;
    public int date;

    public int light_debuff;
    public int window_debuff;
    public int table_debuff;

    public int ll, lu;
    public int tl, tu;
    public int wl, wu;

    public int lloss_b;
    public int wloss_c;
    public int tloss_c;
    public int tloss_b;

    public int food;
    public int battery;

    public int lootpower;
    public int consumebattery;

    public bool robot;
    public bool light=true;
    public GameObject message;
    public GameObject achive;


    public GameObject gameOverPopup,gameOverObj,gameOverBack,gameOverText;
    public bool time,gameoverClick;
    bool clearOrOver = false; // false : over , true: clear
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        date = 1;
        robot = true;
        time = true;
        gameoverClick = false;
        clearOrOver = false;
        // GameBGM.instance.audio.Stop();
        //GameBGM.instance.audio.clip = GameBGM.instance.mainBgm;
        //GameBGM.instance.audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(gameoverClick == true )
            {
                
                Destroy(GameObject.Find("GameManager"));
                Destroy(GameObject.Find("GameBGM"));
                Destroy(GameObject.Find("GameEffect"));
                SceneManager.LoadScene("StartScene");
            }
        }
    }
    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);

    }
    public void printClickNum()
    {
        Debug.Log("전구 클릭: " + lightN);
        Debug.Log("창문 클릭: " + windowN);
        Debug.Log("식탁 클릭: " + tableN);
    }
    public bool checkWindow()
    {
        if( time && message.activeSelf == false && achive.activeSelf== false)
        {
            return true;
        }
        return false;
       
    }
    
    public void gameClearPopupOn(string str)
    {
        gameOverPopup.transform.GetChild(1).GetComponent<Text>().text = str;
        gameOverPopup.SetActive(true);
        clearOrOver = true;
    }
    public void gameOverPopupOn(string str)
    {
        gameOverPopup.transform.GetChild(1).GetComponent<Text>().text = str;
        gameOverPopup.SetActive(true);
        clearOrOver = false;
    }
    public void gameOverPopupExit()
    {
        gameOverPopup.SetActive(false);
        time = false;
        if (clearOrOver)
            gameClear(); 
        else
            gameover();
    }
    public void gameover()
    {
        StartCoroutine(die());
    }
    public void gameClear()
    {
        gameOverText.GetComponent<Text>().text = "Game Clear!";
        StartCoroutine(die());
    }
    IEnumerator die()
    {
        gameOverObj.SetActive(true);
        while (gameOverBack.GetComponent<Image>().color.a <1)
        {
            Vector4 tmp = gameOverBack.GetComponent<Image>().color;
            tmp  += new Vector4(0, 0, 0, Time.time * 0.02f);
            gameOverBack.GetComponent<Image>().color = new Color(tmp.x, tmp.y, tmp.z, tmp.w);
            gameOverText.GetComponent<Text>().color = new Color(gameOverText.GetComponent<Text>().color.r, gameOverText.GetComponent<Text>().color.g, gameOverText.GetComponent<Text>().color.b, tmp.w);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        gameoverClick = true;
    }
}
