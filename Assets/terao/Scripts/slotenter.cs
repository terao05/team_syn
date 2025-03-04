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
            // Source Image の名前を取得
            if (imageComponent.sprite != null)
            {
                string sourceImageName = imageComponent.sprite.name;
                // ボタンが押された際などに呼び出し
                yesNoMsg.ShowMessage(
                   sourceImageName + "を使用しますか？",
                    () => itemuse(imageComponent) ,  // Yes選択時のアクション
                    () => Debug.Log("キャンセルされました。"), // No選択時のアクション
                    "はい", "いいえ"
                ) ;
                Debug.Log($"クリックされたオブジェクトの Source Image 名: {sourceImageName}");
            }
            else
            {
                Debug.Log("このオブジェクトには Source Image が設定されていません。");
            }
        }
        else
        {
            Debug.Log("このオブジェクトには Image コンポーネントがアタッチされていません。");
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
                Debug.Log("red1の状態"+ Boolflower.red1 );
            }
            else
            {
                Boolflower.Setred1(true);
                Boolflower.Setwrong(true);
                
            }
        }
        if (sourceImageName == "Blue")
        {
            Debug.Log("今のred1の状態" + Boolflower.red1);
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
                Debug.Log("間違ってるよ");
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