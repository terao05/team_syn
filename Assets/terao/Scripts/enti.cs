using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class enti : MonoBehaviour
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // ���̃I�u�W�F�N�g�� Image �R���|�[�l���g���A�^�b�`����Ă��邩�m�F
        Image imageComponent = GetComponent<Image>();
        if (imageComponent != null)
        {
            // Source Image �̖��O���擾
            if (imageComponent.sprite != null)
            {
                string sourceImageName = imageComponent.sprite.name;
                Debug.Log($"�N���b�N���ꂽ�I�u�W�F�N�g�� Source Image ��: {sourceImageName}");
            }
            else
            {
                Debug.Log("���̃I�u�W�F�N�g�ɂ� Source Image ���ݒ肳��Ă��܂���B");
            }
        }
        else
        {
            Debug.Log("���̃I�u�W�F�N�g�ɂ� Image �R���|�[�l���g���A�^�b�`����Ă��܂���B");
        }
    }
}
