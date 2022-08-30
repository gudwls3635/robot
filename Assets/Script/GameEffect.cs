using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffect : MonoBehaviour
{
    [HideInInspector] public static GameEffect instance; // 싱글톤
    public AudioSource audio;
    public AudioClip btnSound,door;
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
        if (GameEffect.instance == null)
        {
            GameEffect.instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);

    }
}
