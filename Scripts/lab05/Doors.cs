using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // Start is called before the first frame update
    public float openingSpeed = 1.0f;

    private bool isOpening = false;
    private bool isClosing = false;
    private bool isAnimating = false;
    private float positionOpened;
    private float positionClosed;

    void Start()
    {
        positionClosed = transform.position.x ;
        positionOpened = transform.position.x+transform.localScale.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening && transform.position.x >= positionOpened)
        {
            isOpening = false;
            isAnimating = false;
        }
        else if(isClosing && transform.position.x <= positionClosed)
        {
            isClosing = false;
            isAnimating = false;
        }

        if (isAnimating)
        {
            Vector3 move = transform.right;
            if (isOpening)
            {
                move = transform.right * openingSpeed * Time.deltaTime;
            }
            else if(isClosing)
            {
                move = -transform.right * openingSpeed * Time.deltaTime;
            }
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpening = true;
            isClosing = false;
            isAnimating = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpening = false;
            isClosing = true;
            isAnimating = true;
        }
    }

}
