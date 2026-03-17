using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightcompare : MonoBehaviour
{
    public weightdetector objectA;
    public weightdetector objectB;
    public bool balanceclear = false;

    public Transform pivotObject; // åXÇØÇÈëŒè€
    public float maxTiltAngle = 15f; // ç≈ëÂåXéŒäp
    public float smoothSpeed = 2f; // âÒì]ÇÃääÇÁÇ©Ç≥ÅiëÂÇ´Ç¢ÇŸÇ«ë¨Ç≠ìÆÇ≠Åj

    void Update()
    {
        float massA = objectA.GetMassOnTop();
        float massB = objectB.GetMassOnTop();

        float targetZRotation = 0f;
        Debug.Log("massA:" + massA + " massB:" + massB);
        if (massA > massB)
        {
            targetZRotation = Mathf.Lerp(0f, -maxTiltAngle, (massA - massB) );
        }
        else if (massB > massA)
        {
            targetZRotation = Mathf.Lerp(0f, maxTiltAngle, (massB - massA) );
        }
        else
        {
            // ìØÇ∂èdÇ≥ Å® äpìx0Ç…ñﬂÇ∑
            targetZRotation = 0f;
            if (massA != 0)
            {
                balanceclear = true;
            }
        }

        Quaternion currentRotation = pivotObject.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetZRotation);

        // ÉXÉÄÅ[ÉYÇ…âÒì]
        pivotObject.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * smoothSpeed);
    }
}
