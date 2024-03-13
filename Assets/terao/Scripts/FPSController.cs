using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float lookSensitivity = 3f;

    public CurveControlledBob headBob = new CurveControlledBob(); // CurveControlledBob �C���X�^���X

    private Rigidbody rb;
    private Vector3 movement;
    private bool isCursorLocked = true; // �}�E�X�J�[�\�������b�N����Ă��邩�ǂ����̃t���O

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LockCursor(); // ������ԂŃ}�E�X�J�[�\�������b�N

        // CurveControlledBob �̃Z�b�g�A�b�v
        headBob.Setup(Camera.main, 1f);
    }

    void Update()
    {
        // ���͂̎擾
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // �ړ������̌v�Z
        movement = transform.right * moveX + transform.forward * moveZ;

        // �E�N���b�N�������ꂽ�ꍇ
        if (Input.GetMouseButtonDown(1))
        {
            isCursorLocked = true; // �}�E�X�J�[�\�������b�N
            LockCursor();
        }

        // �E�N���b�N�������ꂽ�ꍇ
        if (Input.GetMouseButtonUp(1))
        {
            isCursorLocked = false; // �}�E�X�J�[�\�������b�N����
            UnlockCursor();
        }

        // �E�N���b�N�������Ă���Ԃ̂ݎ��_�̉�]���s��
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    void FixedUpdate()
    {
        // Rigidbody�ɗ͂������Ĉړ�
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // �J�����̈ʒu��h�炷
        UpdateBobCamera();
    }

    // �}�E�X�J�[�\�������b�N����֐�
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // �}�E�X�J�[�\���̃��b�N����������֐�
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