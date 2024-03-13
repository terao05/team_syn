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
    public Type type;       //���
    public Sprite sprite;   //Slot�ɕ\������摜

    public Item(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }
}
