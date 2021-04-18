using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour Instance;

    [SerializeField] private PlayerStatsObject playerStats;
    [SerializeField] private float roll = 20f;
    [SerializeField] private float pitch = 15f;

    private float speed;
    private float health;
    private float shieldHealth;
    private float deltaTime;

    private GameObject lastTriggerGo = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        deltaTime = Time.deltaTime;

        GetStats();
    }

    private void Update()
    {
        PlayerMove();
    }

    public void GetStats()
    {
        if (playerStats != null)
        {
            speed = playerStats.Speed; 
            health = playerStats.MaxHealthValue;
            shieldHealth = playerStats.MaxShieldValue;
        }
    }

    public void PlayerMove()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 position = transform.position;

        position.x += xAxis * speed * deltaTime;
        position.y += yAxis * speed * deltaTime;

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

        if (triggerGO.CompareTag("Enemy"))
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
