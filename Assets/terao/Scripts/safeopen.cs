using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeopen : MonoBehaviour
{
    public safestate state;
    public bool a = false;
    private Animator anim;
    public AudioClip sound1;
    AudioSource audioSource;
    void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        if(state.clear == true && a == false)
        {
            audioSource.PlayOneShot(sound1);
            anim.SetBool("DoorBL", true);
            a = true;
        }
    }
}
