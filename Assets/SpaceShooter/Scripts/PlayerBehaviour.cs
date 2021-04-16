using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour Instance;

    private float speed;
    private float roll;
    private float pitch;
    private float health;
    private float shieldHealth;

    private GameObject lastTriggerGo = null;

    private void Awake()
    {        
        if (Instance == null)
            Instance = this;

        speed = PlayerManager.Instance.Speed;
        roll = PlayerManager.Instance.roll;
        pitch = PlayerManager.Instance.pitch;
        health = PlayerManager.Instance.Health;
        shieldHealth = PlayerManager.Instance.Shield;
    }

    private void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
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
