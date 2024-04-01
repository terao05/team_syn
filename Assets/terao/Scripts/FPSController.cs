using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class FPSController : MonoBehaviour
{
   
    public float moveSpeed = 0.2f;
    public float lookSensitivity = 3f;

    public CurveControlledBob headBob = new CurveControlledBob(); // CurveControlledBob インスタンス

    private Rigidbody rb;
    private Vector3 movement;
    private float verticalLookRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // CurveControlledBob のセットアップ
        headBob.Setup(Camera.main, 1.4f);
    }

    void Update()
    {
        // 入力の取得
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 移動方向の計算
        movement = transform.right * moveX + transform.forward * moveZ;
                      
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);

    }
        void FixedUpdate()
    {
        // Rigidbodyに力を加えて移動
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // カメラの位置を揺らす
        UpdateBobCamera();
    }
    private void UpdateBobCamera()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
        {
            Vector3 bobPosition = headBob.DoHeadBob(1.1f);
            Camera.main.transform.localPosition = bobPosition;
        }
    }
}