using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightdetector : MonoBehaviour
{
    public Vector3 boxSize = new Vector3(2f, 1.5f, 2f);
    public float yOffset = -0.2f;

    public float GetMassOnTop()
    {
        float totalMass = 0f;

        Vector3 center = transform.position + Vector3.up * (boxSize.y / 2 + yOffset);
        Collider[] colliders = Physics.OverlapBox(center, boxSize / 2, Quaternion.identity);

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.attachedRigidbody;
            if (rb != null && rb.gameObject != this.gameObject)
            {
                totalMass += rb.mass;
            }
        }

        return totalMass;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 center = transform.position + Vector3.up * (boxSize.y / 2 + yOffset);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, boxSize);
    }
}
