using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordPanel : MonoBehaviour
{
    // �S�̂��Ǘ��������
    // �����̐���
    int[] correctAnswer = { 2, 3, 5 };
    [SerializeField] DialNumber[] dialNumbers = default;
    //�����ƃ��[�U�[�̓��͂��m���߂�B
    public void OnClickButton()
    {
        if (CheckClear())
        {
            //�󔠂��J����
            Debug.Log("�J�����I�I");
        }
    }
    bool CheckClear()
    {
        for (int i = 0; i < dialNumbers.Length; i++)
        {
            if (dialNumbers[i].number != correctAnswer[i])
            {
                return false;//��v���Ȃ����̂�����Εs����
            }
        }
        return true;
    }
}
