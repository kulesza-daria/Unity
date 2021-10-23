using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad4 : MonoBehaviour
{
    public float speed = 10.0f;
    GameObject[] walls;
    GameObject player;
    void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(xDirection, 0, zDirection);
        player.transform.position += moveDirection * speed;
        foreach (var wall in walls)
        {
            float distanse = Vector3.Distance(player.transform.position, wall.transform.position);

            if (distanse <= 1.6f)
                Debug.Log("You touched the wall!");
        }
    }
}
