using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedY = 10f;
    public float speedX = 15f;
    public float health = 10f;
    public float directionChangeChance = 0.01f;

    private Borderline _borderline;
    private bool startDirection = false;

    public Vector3 position 
    { 
        get { return (transform.position); }
        set { transform.position = value; }    
    }

    private void Awake()
    {
        _borderline = GetComponent<Borderline>();

        if (Random.value > 1)
            startDirection = true;
    }

    private void Update()
    {
        Move();

        if (_borderline != null && _borderline.offDown)
        {
            Destroy(gameObject);            
        }
    }


    private void Move()
    {
        Vector3 tempPosition = position;
        tempPosition.y -= speedY * Time.deltaTime;
        
        // Меняет направление движения в случае выхода объекта за границы по сторонам.
        if (_borderline.offLeft || _borderline.offRight)
            speedX *= -1;
        // Случайно меняет направление движения
        if (Random.value < directionChangeChance)
            speedX *= -1;
        // Случайно определяет изначальное напрвление движения по оси Х.
        if (startDirection == true)
            tempPosition.x += speedX * Time.deltaTime;
        else
            tempPosition.x -= speedX * Time.deltaTime;

        position = tempPosition;
    }
}
