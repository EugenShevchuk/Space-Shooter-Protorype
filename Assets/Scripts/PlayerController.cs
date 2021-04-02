using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float speed = 25f;
    public float roll = 20f;
    public float pitch = 15f;
    public float health = 10;
    public float shieldHealth = 10;

    private GameObject lastTriggerGo = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
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

    private void OnTriggerEnter(Collider other)
    {
        Transform rootTransform = other.gameObject.transform.root;
        GameObject triggerGO = rootTransform.gameObject;

        if (triggerGO == lastTriggerGo) 
            return;
        lastTriggerGo = triggerGO;

        if (triggerGO.tag == "Enemy")
        {
            Destroy(triggerGO);
            // При столкновении с вражеским кораблем деактивируется щит.
            if (shieldHealth > 0)
            {
                shieldHealth = 0;
                transform.Find("Shield").gameObject.SetActive(false);
                return;
            }
            // Если щит выключен наносится урон по хп.
            if (transform.Find("Shield").gameObject.activeSelf == false)
            {
                health -= 5;
                if (health <= 0)
                    Destroy(gameObject);
            }
                       
        }
    }
}
