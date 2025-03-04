using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomSetter : MonoBehaviour
{
    [SerializeField] Camera subCamera = default;

    private void Start()
    {
        // オブジェクト自体のコライダーを取得
        Collider collider = GetComponent<Collider>();
        subCamera.gameObject.SetActive(false);　//最初は非表示

    }
    public void Onclick()
    {
        // オブジェクト自体のコライダーを取得
        Collider collider = GetComponent<Collider>();

        // コライダーが存在するか確認して無効化する
        if (collider != null)
        {
            collider.enabled = false;
        }
        CameraManager.instance.ChangeCamera(subCamera);
        subCamera.gameObject.SetActive(true);
        Cursor.visible = true;
    }
    public void EnableCollider()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
        }
    }
}
