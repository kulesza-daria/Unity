using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    Vector3 startPosition;
    Vector3 endPosition;
    float x = 1;
    float z = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = rb.position;
        endPosition = startPosition + new Vector3(10, 0, 0);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(rb.position, endPosition) >= 0.1f)
        {
            Vector3 velocity = new Vector3(x, 0, z);
            velocity = velocity.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + velocity);
        }
        else
        {
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            if (x == 1 && z == 0) 
            { 
                x = 0; 
                z = 1; 
                startPosition = rb.position; 
                endPosition = startPosition + new Vector3(0, 0, 10); 
            }
            else if (x == 0 && z == 1) 
            { 
                x = -1; 
                z = 0; 
                startPosition = rb.position; 
                endPosition = startPosition + new Vector3(-10, 0, 0); 
            }
            else if (x == -1 && z == 0) 
            { 
                x = 0; 
                z = -1; 
                startPosition = rb.position; 
                endPosition = startPosition + new Vector3(0, 0, -10); 
            }
            else 
            { 
                x = 1; 
                z = 0; 
                startPosition = rb.position; 
                endPosition = startPosition + new Vector3(10, 0, 0); 
            }
        }
    }
}
