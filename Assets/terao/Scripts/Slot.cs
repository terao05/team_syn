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

    // アイテムを使用・削除した時に、データと見た目の両方を消去する
    public void HideSlot()
    {
        this.item = null;      // データを空にする（これでIsEmptyがtrueになる）
        image.sprite = null;   // 参照を消す
        //image.enabled = false; // Imageコンポーネントをオフにして見えなくする
    }

    public void useitem()
    {
        this.item = null;
    }

    // Slotクラスにこれを追加しておくと便利です
    public Item GetItem() { return item; }
}
