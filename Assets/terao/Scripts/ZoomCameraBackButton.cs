using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZoomCameraBackButton : MonoBehaviour
{
    public GameObject objectWithCollider; // コライダーを有効にするオブジェクトの参照
    [SerializeField] Camera subCamera = default;
    void Start()
    {
        // ボタンをクリックしたときに呼び出すメソッドを設定
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // コライダーを有効にするオブジェクトのコライダーを取得し、有効化する
        Collider collider = objectWithCollider.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
        }
        CameraManager.instance.MainCameraBack(subCamera);
        subCamera.gameObject.SetActive(false);
        
        
    }
}
