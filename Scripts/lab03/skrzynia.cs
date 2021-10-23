using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skrzynia : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    Vector3 startPosition;
    Vector3 endPosition;
    int destination = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = rb.position;
        endPosition = startPosition + new Vector3(10, 0, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(rb.position, endPosition) >= 0.1f)
        {
            Vector3 velocity = new Vector3(1, 0, 0);
            velocity = velocity.normalized * destination * speed * Time.deltaTime;
            rb.MovePosition(transform.position + velocity);
        }
        else
        {
            destination = -destination;
            endPosition = rb.position + new Vector3(10 * destination, 0, 0);
        }
    }
}
