using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getFood : MonoBehaviour
{
    // 
    public int[] weights = new int[16] { 1 ,4, 7 ,7 ,12 ,12 ,10 ,9 ,8, 8 ,6, 5, 4, 4, 2, 1 };
    public int[] percent = new int[16];
    public GameObject Message;
    // Start is called before the first frame update
    void Start()
    {
        percent = new int[16];
        for (int i = 0; i<16; i++)
        {
            for(int j = 0; j< i;j++)
            {
                percent[i] = percent[i] + weights[j];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void plusFood()
    {
        int rnd = Random.Range(0, 100);
        int food=0;
        Debug.Log(percent[2]);
        for (int i = 0; i< 16;i++)
        {
            if(rnd <percent[i])
            {
                Debug.Log("aa");
                GameManager.instance.food += i;
                food = i; 
                break;
            }
        }
        if(GameManager.instance.robot == true)
        {
            Message.transform.GetChild(1).GetComponent<Text>().text = "로봇이 식량 " + food + " 만큼 가져왔습니다.";
        }else
        {
            Message.transform.GetChild(1).GetComponent<Text>().text = "로봇이 고장나서 식량을 가져올 수 없습니다.";
        }
        
    }
}
