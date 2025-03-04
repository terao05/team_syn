using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomSetter : MonoBehaviour
{
    [SerializeField] Camera subCamera = default;

    private void Start()
    {
        // �I�u�W�F�N�g���̂̃R���C�_�[���擾
        Collider collider = GetComponent<Collider>();
        subCamera.gameObject.SetActive(false);�@//�ŏ��͔�\��

    }
    public void Onclick()
    {
        // �I�u�W�F�N�g���̂̃R���C�_�[���擾
        Collider collider = GetComponent<Collider>();

        // �R���C�_�[�����݂��邩�m�F���Ė���������
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
