using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSystem : MonoBehaviour
{
    public GameObject plot;
    public GameObject tutorial;
    public GameObject next;
    public GameObject st;
    public GameObject et;
    public GameObject tt;
    public GameObject plot2;
    public GameObject plot3;
    public GameObject plot4;
    public GameObject plot5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start 버튼 눌렀을 때
    public void start()
    {
        plot.SetActive(true);
        st.SetActive(false);
        et.SetActive(false);
        tt.SetActive(false);



    }

    public void exit()
    {
        Application.Quit();
    }

    public void Plot()
    {
        plot.SetActive(false);
        plot2.SetActive(true);
    }
    public void Plot2()
    {
        plot2.SetActive(false);
        plot3.SetActive(true);
    }
    public void Plot3()
    {
        plot3.SetActive(false);
        plot4.SetActive(true);
    }
    public void Plot4()
    {
        plot4.SetActive(false);
        plot5.SetActive(true);
    }
    public void Plot5()
    {
        plot4.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void Next()
    {
        tutorial.SetActive(false);

    }
}
