using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YesNoMsg : MonoBehaviour
{
    public TextMeshProUGUI confirmText;  // メッセージのテキスト表示部分
    public Button yesButton;             // Yesボタン
    public Button noButton;              // Noボタン
    public GameObject panel;             // メッセージウィンドウ全体のパネル

    private Action yesAction;            // Yesを押した時のアクション
    private Action noAction;             // Noを押した時のアクション

    void Start()
    {
        // Yes/Noボタンにクリックイベントを追加
        yesButton.onClick.AddListener(OnYesClick);
        noButton.onClick.AddListener(OnNoClick);

        // 初期状態では非表示にする
        panel.SetActive(false);
    }

    public void ShowMessage(string message, Action onYes, Action onNo, string yesText = "Yes", string noText = "No")
    {
        // メッセージとボタンのテキストを設定
        confirmText.text = message;
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = yesText;
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = noText;

        // YesとNoのアクションを設定
        yesAction = onYes;
        noAction = onNo;

        // メッセージウィンドウを表示
        panel.SetActive(true);
    }

    private void OnYesClick()
    {
        // Yesアクションを実行してパネルを閉じる
        yesAction?.Invoke();
        panel.SetActive(false);
    }

    private void OnNoClick()
    {
        // Noアクションを実行してパネルを閉じる
        noAction?.Invoke();
        panel.SetActive(false);
    }
}
