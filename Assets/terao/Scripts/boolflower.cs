using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolflower : MonoBehaviour
{
    
    public bool red1 = false;
    public bool blue2 = false;
    public bool yellow3 = false;
    public bool wrong = false;
    public AudioClip sound1;
    AudioSource audioSource;
    private bool hasPlayed = false;

    public void Setred1(bool a)
    {
        red1 = a;
    }
    public void Setblue2(bool a)
    {
        blue2 = a;
    }
    public void Setyellow3(bool a)
    {
        yellow3 = a;
    }
    public void Setwrong(bool a)
    {
        wrong = a;
    }
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(wrong != true && red1 == true && blue2 ==true && yellow3 == true && hasPlayed != true)
        {
            audioSource.PlayOneShot(sound1);
            hasPlayed = true;
        }
        if (wrong || !red1 || !blue2 || !yellow3)
        {
            hasPlayed = false;  // フラグをリセット
        }
    }

}

