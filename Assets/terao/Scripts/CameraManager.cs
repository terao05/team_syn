using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //どこからでもアクセスできるようにする
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
            // スクリプトを無効化する
            script.enabled = false;
        }
        Camera.main.gameObject.SetActive(false);
        // オブジェクトが存在するかチェック
        //if (player.activeSelf)
        //{
        // player オブジェクトがアクティブな場合の処理
        //player.SetActive(false);
        //}
        //else
        //{
        // player オブジェクトが非アクティブな場合の処理
        //player.SetActive(true);
        //}

    }

    public void MainCameraBack(Camera subCamera)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        FPSController script = player.GetComponent<FPSController>();

        if (script != null)
        {
            // スクリプトを有効化する
            script.enabled = true;
        }
        mainCamera.gameObject.SetActive(true);

    }
}
