using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightmagic : MonoBehaviour
{
    public Camera subCamera;
    public Light spotlight;
    public Color hitColor0 = Color.yellow; // �q�b�g���̐F
    public Color hitColor1 = Color.black; // �q�b�g���̐F
    public Color hitColor2 = Color.red; // �q�b�g���̐F
    private Renderer lastHitRenderer;  // �O��q�b�g�����I�u�W�F�N�g��Renderer
    private Color originalColor;       // ���̐F��ۑ�
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
                // �q�b�g�����I�u�W�F�N�g�̏���\��
                Debug.Log($"Hit object: {hit.collider.gameObject.name}, Distance: {hit.distance}");
                Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
                if (hitRenderer != null)
                {
                    // �O��̃I�u�W�F�N�g�ƈقȂ�ꍇ�ɏ���
                    if (lastHitRenderer != hitRenderer)
                    {
                        // �O��̃I�u�W�F�N�g�̐F�����ɖ߂�
                        ResetLastHitObject();

                        // ���݂̃I�u�W�F�N�g�̌��̐F��ۑ����ĕύX
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
                        // ���݂̃q�b�g�����I�u�W�F�N�g���L�^
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
            lastHitRenderer.material.color = originalColor; // ���̐F�ɖ߂�
            lastHitRenderer = null; // ���Z�b�g
        }
    }
    public void Setlight(bool a)
    {
        lightuse = a;
    }
}
