using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Camera subCamera;
    public string nonCollisionLayerName = "Grabbable"; // 衝突を避けるレイヤー名

    private GameObject grabbedObject;
    private int originalLayer;
    private float grabDistance;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = subCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject target = hit.collider.gameObject;
                if (target.CompareTag("Grabbable"))
                {
                    grabbedObject = target;
                    grabDistance = Vector3.Distance(subCamera.transform.position, target.transform.position);

                    Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;

                    // レイヤー変更（衝突しないように）
                    originalLayer = grabbedObject.layer;
                    grabbedObject.layer = LayerMask.NameToLayer(nonCollisionLayerName);
                }
            }
        }

        if (Input.GetMouseButton(0) && grabbedObject != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = grabDistance;
            Vector3 worldPos = subCamera.ScreenToWorldPoint(mousePos);
            worldPos.z = grabbedObject.transform.position.z;

            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            rb.MovePosition(worldPos); // 物理演算と衝突を保ったまま追従
        }

        if (Input.GetMouseButtonUp(0) && grabbedObject != null)
        {
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            rb.useGravity = true;

            // レイヤーを元に戻す
            grabbedObject.layer = originalLayer;
            grabbedObject = null;
        }
    }
}
