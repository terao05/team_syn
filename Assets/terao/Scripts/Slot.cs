using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //アイテムを受け取ったら画像をスロットに表示
    Image image;
    Item item;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public bool IsEmpty()
    {
        if (item == null)
        {
            return true;
        }
        return false;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        UpdateImage(item);
    }

    void UpdateImage(Item item)
    {
        image.sprite = item.sprite;
    }
    public void useitem()
    {
        this.item = null;
    }
}
