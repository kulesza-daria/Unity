using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningToEnd = true;
    private bool isRunningToStart = false;
    private float xStartPosition;
    private float xEndPosition;
    private GameObject oldParent;
    private CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        xEndPosition = transform.position.x + distance;
        xStartPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunningToEnd && transform.position.x >= xEndPosition)
        {
            isRunning = false;
        }
        else if (isRunningToStart && transform.position.x <= xStartPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move;
            if (isRunningToEnd)
            {
                move = transform.right * elevatorSpeed * Time.deltaTime;
            }
            else
            {
                move = -transform.right * elevatorSpeed * Time.deltaTime;
            }
            transform.Translate(move);
            controller.Move(move);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            //other.gameObject.transform.parent = transform;

            controller = other.gameObject.GetComponent<CharacterController>();
           
            isRunningToEnd = true;
            isRunningToStart = false;
            elevatorSpeed = Mathf.Abs(elevatorSpeed);
            isRunning = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (transform.position.x >= xEndPosition)
            {
                isRunningToEnd = false;
                isRunningToStart = true;
                isRunning = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }
}
