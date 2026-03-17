using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinshaopen : MonoBehaviour
{

    private Quaternion targetRotation;
    // 回転速度（Degrees per second）
    public float rotationSpeed = 90f;
    // weightcompareスクリプトがアタッチされているオブジェクト
    public weightcompare weightComparer;

    // 現在使用している（切り替え前の）カメラ
    public GameObject currentCamera;

    // 遷移先のカメラ
    public GameObject targetCamera;

    // コライダーを有効にするオブジェクト
    public Collider objectToEnableCollider;


    [SerializeField] Item.Type itemType;
    Item item;

    private bool hasSwitched = false; // 一度だけ実行するためのフラグ
    void Start()
    {
        // 目標の回転（現在のY軸に90度加算）
        targetRotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x - 90f,
            transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z
        );
        if (targetCamera != null)
        {
            targetCamera.SetActive(false);
        }

        // 初期設定: コライダーを無効にしておく (必要に応じて)
        if (objectToEnableCollider != null)
        {
            // objectToEnableCollider.enabled = false; // 必要であればStartで無効にする
        }
        //itemTypeに応じてitemを生成する
        item = ItemGenerater.instance.Spawn(itemType);
    }

    void Update()
    {
        // weightcompareがアタッチされているか、また切り替えがまだ行われていないかを確認
        if (weightComparer != null && !hasSwitched)
        {
            // balanceclearがtrueになったら処理を実行
            if (weightComparer.balanceclear)
            {
                PerformSwitchAndEnable();
                hasSwitched = true; // フラグを立てて二重実行を防ぐ
                
            }
        }
        // 2. **Quaternion.RotateTowards** を使用した回転
        if (hasSwitched)
        {
            // 毎フレーム、最大 `rotationSpeed * Time.deltaTime` 分だけ目標に近づけます。
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,         // 現在の回転
                targetRotation,             // 目標の回転
                rotationSpeed * Time.deltaTime // 1フレームで回転する最大角度
            );
        }
    }
    private void PerformSwitchAndEnable()
    {
        // 1. カメラの遷移
        Debug.Log("バランスが取れました！カメラを切り替えます。");
        if (currentCamera != null)
        {
            currentCamera.SetActive(false); // 現在のカメラを無効にする
        }

        if (targetCamera != null)
        {
            targetCamera.SetActive(true); // 遷移先のカメラを有効にする
        }
        else
        {
            Debug.LogWarning("遷移先のカメラ (targetCamera) が設定されていません。");
        }

        // 2. オブジェクトのコライダーをオン
        Debug.Log("オブジェクトのコライダーを有効にします。");
        if (objectToEnableCollider != null)
        {
            objectToEnableCollider.enabled = true; // コライダーを有効にする
        }
        else
        {
            Debug.LogWarning("コライダーを有効にするオブジェクト (objectToEnableCollider) が設定されていません。");
        }
    }
    // ?? 【追加】コライダーを持つオブジェクトがクリックされたときに実行されるメソッド
    public void Onclick()
    {
        // コライダーが有効な状態で、かつ現在targetCameraがアクティブな場合のみ実行
        if (targetCamera != null && targetCamera.activeInHierarchy)
        {
            ReturnToCurrentCamera();
            OnclickObj();
        }
    }

    private void ReturnToCurrentCamera()
    {
        Debug.Log("オブジェクトがクリックされました。元のカメラに戻します。");

        // カメラの切り替え（元に戻す）
        if (targetCamera != null)
        {
            targetCamera.SetActive(false); // 遷移後のカメラを無効化
        }

        if (currentCamera != null)
        {
            currentCamera.SetActive(true); // 元のカメラを有効化
        }
        else
        {
            Debug.LogWarning("元のカメラ (currentCamera) が設定されていません。");
        }

        // 必要に応じて、コライダーを再度無効にする処理などをここに追加できます
        // 例: objectToEnableCollider.enabled = false;
    }
    //[SerializeField] Item item;
    //クリックしたら非表示にする
    public void OnclickObj()
    {
        //ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
    }
}
