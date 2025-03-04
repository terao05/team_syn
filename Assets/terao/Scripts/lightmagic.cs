using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightmagic : MonoBehaviour
{
    public Camera subCamera;
    public Light spotlight;
    public Color hitColor0 = Color.yellow; // ヒット時の色
    public Color hitColor1 = Color.black; // ヒット時の色
    public Color hitColor2 = Color.red; // ヒット時の色
    private Renderer lastHitRenderer;  // 前回ヒットしたオブジェクトのRenderer
    private Color originalColor;       // 元の色を保存
    public bool lightuse = false;
    private void Start()
    {

        spotlight.enabled = false;
    }
    private void FixedUpdate()
    {
        if(lightuse == true)
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = subCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            spotlight.transform.position = ray.origin;
            spotlight.transform.forward = ray.direction;
            spotlight.range = 100f;
            spotlight.enabled = true;
            if (Physics.SphereCast(ray, 0.16f, out hit))
            {
                // ヒットしたオブジェクトの情報を表示
                Debug.Log($"Hit object: {hit.collider.gameObject.name}, Distance: {hit.distance}");
                Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
                if (hitRenderer != null)
                {
                    // 前回のオブジェクトと異なる場合に処理
                    if (lastHitRenderer != hitRenderer)
                    {
                        // 前回のオブジェクトの色を元に戻す
                        ResetLastHitObject();

                        // 現在のオブジェクトの元の色を保存して変更
                        originalColor = hitRenderer.material.color;
                        if(hit.collider.gameObject.name == "liquid0")
                        {
                            hitRenderer.material.color = hitColor0;
                        }
                        if(hit.collider.gameObject.name == "liquid1")
                        {
                            hitRenderer.material.color = hitColor1;
                        }
                        if (hit.collider.gameObject.name == "liquid2")
                        {
                            hitRenderer.material.color = hitColor2;
                        }
                        // 現在のヒットしたオブジェクトを記録
                        lastHitRenderer = hitRenderer;
                    }
                }

            }
            else
            {
                ResetLastHitObject();
                Debug.Log("No hit detected.");
            }
        }
    }

    private void ResetLastHitObject()
    {
        if (lastHitRenderer != null)
        {
            lastHitRenderer.material.color = originalColor; // 元の色に戻す
            lastHitRenderer = null; // リセット
        }
    }
    public void Setlight(bool a)
    {
        lightuse = a;
    }
}
