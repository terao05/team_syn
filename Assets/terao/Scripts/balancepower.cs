using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balancepower : MonoBehaviour
{
    public float massThreshold = 10f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        float totalMass = GetMassOfObjectsOnTop();

        if (totalMass > massThreshold)
        {

        }
        else
        {

        }
    }

    float GetMassOfObjectsOnTop()
    {
        float totalMass = 0f;

        // 上方向にキャストして、上にあるオブジェクトを検出
        RaycastHit[] hits = Physics.RaycastAll(transform.position + Vector3.up * 0.5f, Vector3.up, 2f);

        foreach (var hit in hits)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null && rb.gameObject != this.gameObject)
            {
                totalMass += rb.mass;
            }
        }

        return totalMass;
    }
}
