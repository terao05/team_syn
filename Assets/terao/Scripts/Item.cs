using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]

public class Item
{
    public enum Type
    {
        Cube,
        Ball,
    }
    public Type type;       //Ží—Þ
    public Sprite sprite;   //Slot‚É•\Ž¦‚·‚é‰æ‘œ

    public Item(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }
}
