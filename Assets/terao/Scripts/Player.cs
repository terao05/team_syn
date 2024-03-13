using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    float speed = 1.0f;
    public int jumpflg;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpflg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * speed;
        }
        if (jumpflg <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpflg++;
                rb.AddForce(Vector3.up * speed, ForceMode.Impulse);

            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        jumpflg = 0;
    }
}
