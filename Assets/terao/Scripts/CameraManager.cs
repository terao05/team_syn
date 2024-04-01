using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //�ǂ�����ł��A�N�Z�X�ł���悤�ɂ���
    public static CameraManager instance;
    Camera mainCamera;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }
    public void ChangeCamera(Camera subCamera)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        FPSController script = player.GetComponent<FPSController>();

        if (script != null)
        {
            // �X�N���v�g�𖳌�������
            script.enabled = false;
        }
        Camera.main.gameObject.SetActive(false);
        // �I�u�W�F�N�g�����݂��邩�`�F�b�N
        //if (player.activeSelf)
        //{
        // player �I�u�W�F�N�g���A�N�e�B�u�ȏꍇ�̏���
        //player.SetActive(false);
        //}
        //else
        //{
        // player �I�u�W�F�N�g����A�N�e�B�u�ȏꍇ�̏���
        //player.SetActive(true);
        //}

    }

    public void MainCameraBack(Camera subCamera)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        FPSController script = player.GetComponent<FPSController>();

        if (script != null)
        {
            // �X�N���v�g��L��������
            script.enabled = true;
        }
        mainCamera.gameObject.SetActive(true);

    }
}
