using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolflower : MonoBehaviour
{
    
    public bool red1 = false;
    public bool blue2 = false;
    public bool yellow3 = false;
    public bool wrong = false;
    public bool last = false;
    public AudioClip sound1;
    AudioSource audioSource;
    private bool hasPlayed = false;

    // --- 追加：消費したアイテムを覚えておくリスト ---
    private List<Item> consumedItems = new List<Item>();

    // アイテムが使われたときに、そのアイテムデータをリストに追加するメソッド
    public void AddConsumedItem(Item item)
    {
        consumedItems.Add(item);
    }

    public void Setred1(bool a)
    {
        red1 = a;
    }
    public void Setblue2(bool a)
    {
        blue2 = a;
    }
    public void Setyellow3(bool a)
    {
        yellow3 = a;
    }
    public void Setwrong(bool a)
    {
        wrong = a;
    }

    public void Setcount(bool a)
    {
        last = a;
    }
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(wrong != true && red1 == true && blue2 ==true && yellow3 == true && hasPlayed != true)
        {
            audioSource.PlayOneShot(sound1);
            hasPlayed = true;
        }
        if (last == true)
        {
            ResetGimmick();
        }
        if (wrong || !red1 || !blue2 || !yellow3)
        {
            hasPlayed = false;  // フラグをリセット
        }
    }

    void ResetGimmick()
    {
        // 1. アイテムをインベントリに戻す
        foreach (Item item in consumedItems)
        {
            ItemBox.instance.SetItem(item);
        }
        consumedItems.Clear(); // リップ終了

        // 2. フラグをすべて初期化
        red1 = false;
        blue2 = false;
        yellow3 = false;
        wrong = false;
        last = false;
        hasPlayed = false;

        Debug.Log("失敗したためアイテムをリポップしました");
    }

}

