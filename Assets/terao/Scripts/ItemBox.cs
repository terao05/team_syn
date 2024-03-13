using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots;
    //�ǂ��ł����s�ł���
    public static ItemBox instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //PickupObject���N���b�N���ꂽ��A�X���b�g�ɃA�C�e��������B
    public void SetItem(Item item)
    {
        foreach(Slot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                break;
            }
        }
        //Debug.Log(item.type);
    }
}
