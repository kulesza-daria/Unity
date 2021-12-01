using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDirectionalElevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private bool isRunningBack = false;
    private bool isRunningForward = true;


    private CharacterController controller;
    public List<Vector3> destinations = new List<Vector3>();
    private Vector3 currentDestination;
    private Vector3 initialPosition;
    private int index = 1;

    private bool ascendingX;
    private bool ascendingY;
    private bool ascendingZ;
    private Vector3 move = new Vector3(0, 0, 0);
    void Start()
    {
        initialPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (isRunningForward)
            {
                //brak ruchu, czyli platforma dotarła do danego punktu
                if (move.Equals(new Vector3(0, 0, 0)))
                {
                    if (index < destinations.Count)
                    {
                        currentDestination = destinations[index];
                        index++;
                        positionChangeDetection();
                    }
                    else
                    {
                        isRunningForward = false;
                        isRunningBack = true;
                        index--;
                    }

                }
            }
            else if (isRunningBack)
            {
                if (move.Equals(new Vector3(0, 0, 0)))
                {
                    if (index > -1)
                    {
                        currentDestination = destinations[index];
                        index--;
                        positionChangeDetection();
                    }
                    else if(index == -1)
                    {
                        //powrót do pierwotnego stanu
                        currentDestination = initialPosition;
                        index--;
                        positionChangeDetection();
                    }
                    else 
                    {
                        //reset skryptu
                        isRunningForward = true;
                        isRunningBack = false;
                        isRunning = false;
                        index = 1;
                    }

                }
            }

            move = new Vector3(0, 0, 0);

            if (ascendingX && transform.position.x <= currentDestination.x)
            {
                move.x = transform.right.x * elevatorSpeed * Time.deltaTime;
            }
            else if (!ascendingX && transform.position.x >= currentDestination.x)
            {
                move.x = -transform.right.x * elevatorSpeed * Time.deltaTime;
            }


            if (ascendingY && transform.position.y <= currentDestination.y)
            {
                move.y = transform.up.y * elevatorSpeed * Time.deltaTime;
            }
            else if (!ascendingY && transform.position.y >= currentDestination.y)
            {
                move.y = -transform.up.y * elevatorSpeed * Time.deltaTime;
            }


            if (ascendingZ && transform.position.z <= currentDestination.z)
            {
                move.z = transform.forward.z * elevatorSpeed * Time.deltaTime;
            }
            else if (!ascendingZ && transform.position.z >= currentDestination.z)
            {
                move.z = -transform.forward.z * elevatorSpeed * Time.deltaTime;
            }

            transform.Translate(move);
            controller.Move(move);

        }
    }

    private void positionChangeDetection()
    {
        //ustalenie czy wartości mają być rosnące czy malejące
        ascendingX = currentDestination.x > transform.position.x ? true : false;
        ascendingY = currentDestination.y > transform.position.y ? true : false;
        ascendingZ = currentDestination.z > transform.position.z ? true : false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller = other.gameObject.GetComponent<CharacterController>();
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //zrobionę na takiej zasadzie, że player po ponownym wejściu powinien kontynuuować ostatnią trasę
            //a nie ją resetować 
            isRunning = false;
            controller = null;
        }
    }
}
