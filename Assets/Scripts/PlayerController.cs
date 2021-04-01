using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float speed = 25f;
    public float roll = 20f;
    public float pitch = 15f;

    private void Awake()
    {
         if (instance == null)
             instance = this;


        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 position = transform.position;

        position.x += xAxis * speed * Time.deltaTime;
        position.y += yAxis * speed * Time.deltaTime;

        transform.position = position;

        transform.rotation = Quaternion.Euler(-90 + (yAxis * pitch), xAxis * roll, 0);
    }
}
