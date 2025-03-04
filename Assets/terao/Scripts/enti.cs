using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class enti : MonoBehaviour
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // このオブジェクトに Image コンポーネントがアタッチされているか確認
        Image imageComponent = GetComponent<Image>();
        if (imageComponent != null)
        {
            // Source Image の名前を取得
            if (imageComponent.sprite != null)
            {
                string sourceImageName = imageComponent.sprite.name;
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
}
