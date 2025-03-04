using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotenter : MonoBehaviour
{
    public YesNoMsg yesNoMsg;
    public boolflower Boolflower;
    public Bloom bloom;
    public lightmagic lightmagic;
    public void Onclick()
    {
        Image imageComponent = GetComponent<Image>();
        if (imageComponent != null)
        {
            // Source Image �̖��O���擾
            if (imageComponent.sprite != null)
            {
                string sourceImageName = imageComponent.sprite.name;
                // �{�^���������ꂽ�ۂȂǂɌĂяo��
                yesNoMsg.ShowMessage(
                   sourceImageName + "���g�p���܂����H",
                    () => itemuse(imageComponent) ,  // Yes�I�����̃A�N�V����
                    () => Debug.Log("�L�����Z������܂����B"), // No�I�����̃A�N�V����
                    "�͂�", "������"
                ) ;
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
    public void itemuse(Image imageComponent)
    {
        string sourceImageName = imageComponent.sprite.name;
        if (sourceImageName == "Red")
        {
            if (Boolflower.wrong != true)
            {
                Boolflower.Setred1(true);
                imageComponent.sprite = null;
                //Boolflower.Setred1(true);
                Debug.Log("red1�̏��"+ Boolflower.red1 );
            }
            else
            {
                Boolflower.Setred1(true);
                Boolflower.Setwrong(true);
                
            }
        }
        if (sourceImageName == "Blue")
        {
            Debug.Log("����red1�̏��" + Boolflower.red1);
            if (Boolflower.wrong != true && Boolflower.red1 == true)
            {
                Boolflower.Setblue2(true);
                imageComponent.sprite = null;
            }
            else
            {
                Boolflower.Setblue2(true);
                Boolflower.Setwrong(true);
            }
        }
        if (sourceImageName == "Yellow")
        {
            if (Boolflower.wrong != true && Boolflower.red1 == true && Boolflower.blue2 == true)
            {
                Boolflower.Setyellow3(true);
                imageComponent.sprite = null;
            }
            else
            {
                Boolflower.Setyellow3(true);
                Boolflower.Setwrong(true);
            }
        }
        
        if(Boolflower.red1 == true && Boolflower.blue2==true && Boolflower.yellow3 == true)
        {
            if (Boolflower.wrong == true)
            {
                Debug.Log("�Ԉ���Ă��");
            }
        }

        if(Boolflower.wrong!=true && Boolflower.red1 == true && Boolflower.blue2 == true && Boolflower.yellow3 == true)
        {
            
            bloom.animstart();
        }
        if(sourceImageName == "lightmagicitem")
        {
            imageComponent.sprite = null;
            lightmagic.Setlight(true);
        }

    }
}