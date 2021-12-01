using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float sensitivity = 200f;
    float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") *sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y")*sensitivity * Time.deltaTime;


        yRotation -= mouseYMove;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        
        // wykonujemy rotację wokół osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamerę
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }
}
