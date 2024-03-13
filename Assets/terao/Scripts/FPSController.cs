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
    private bool isCursorLocked = true; // マウスカーソルがロックされているかどうかのフラグ

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LockCursor(); // 初期状態でマウスカーソルをロック

        // CurveControlledBob のセットアップ
        headBob.Setup(Camera.main, 1f);
    }

    void Update()
    {
        // 入力の取得
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 移動方向の計算
        movement = transform.right * moveX + transform.forward * moveZ;

        // 右クリックが押された場合
        if (Input.GetMouseButtonDown(1))
        {
            isCursorLocked = true; // マウスカーソルをロック
            LockCursor();
        }

        // 右クリックが離された場合
        if (Input.GetMouseButtonUp(1))
        {
            isCursorLocked = false; // マウスカーソルをロック解除
            UnlockCursor();
        }

        // 右クリックを押している間のみ視点の回転を行う
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    void FixedUpdate()
    {
        // Rigidbodyに力を加えて移動
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // カメラの位置を揺らす
        UpdateBobCamera();
    }

    // マウスカーソルをロックする関数
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // マウスカーソルのロックを解除する関数
    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void UpdateBobCamera()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
        {
            Vector3 bobPosition = headBob.DoHeadBob(0.8f);
            Camera.main.transform.localPosition = bobPosition;
        }
    }
}