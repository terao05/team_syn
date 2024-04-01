using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZoomCameraBackButton : MonoBehaviour
{
    public GameObject objectWithCollider; // �R���C�_�[��L���ɂ���I�u�W�F�N�g�̎Q��
    [SerializeField] Camera subCamera = default;
    void Start()
    {
        // �{�^�����N���b�N�����Ƃ��ɌĂяo�����\�b�h��ݒ�
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // �R���C�_�[��L���ɂ���I�u�W�F�N�g�̃R���C�_�[���擾���A�L��������
        Collider collider = objectWithCollider.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
        }
        CameraManager.instance.MainCameraBack(subCamera);
        subCamera.gameObject.SetActive(false);
        
        
    }
}
