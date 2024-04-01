using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordPanel : MonoBehaviour
{
    // 全体を管理するもの
    // 正解の数字
    int[] correctAnswer = { 2, 3, 5 };
    [SerializeField] DialNumber[] dialNumbers = default;
    //正解とユーザーの入力を確かめる。
    public void OnClickButton()
    {
        if (CheckClear())
        {
            //宝箱を開ける
            Debug.Log("開いた！！");
        }
    }
    bool CheckClear()
    {
        for (int i = 0; i < dialNumbers.Length; i++)
        {
            if (dialNumbers[i].number != correctAnswer[i])
            {
                return false;//一致しないものがあれば不正解
            }
        }
        return true;
    }
}
