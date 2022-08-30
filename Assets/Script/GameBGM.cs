using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour
{
    [HideInInspector] public static GameBGM instance; // 싱글톤
    public AudioSource audio;

    public AudioClip mainBgm;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (GameBGM.instance == null)
        {
            GameBGM.instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);

    }
}
