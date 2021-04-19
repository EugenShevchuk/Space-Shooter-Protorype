using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour Instance;

    [SerializeField] private PlayerStatsObject playerStats;
    [SerializeField] private float roll = 20f;
    [SerializeField] private float pitch = 15f;

    public int healthValue;
    public int shieldValue;

    private int speedValue;
    private float deltaTime;

    private GameObject lastTriggerGo = null;

    public static event Action<int> OnHealthValueChangedEvent;
    public static event Action<int> OnShieldValueChangedEvent;

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
            speedValue = playerStats.Speed; 
            healthValue = playerStats.MaxHealthValue;
            shieldValue = playerStats.MaxShieldValue;
        }
    }

    public void PlayerMove()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 position = transform.position;

        position.x += xAxis * speedValue * deltaTime;
        position.y += yAxis * speedValue * deltaTime;

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
            if (shieldValue > 0)
            {
                shieldValue -= 5;
                OnShieldValueChangedEvent?.Invoke(shieldValue);
                if (shieldValue <= 0)
                {
                    transform.Find("Shield").gameObject.SetActive(false);
                }
                return;
            }
            // Если щит выключен наносится урон по хп.
            if (transform.Find("Shield").gameObject.activeSelf == false)
            {
                healthValue -= 5;
                OnHealthValueChangedEvent?.Invoke(healthValue);
                if (healthValue <= 0)
                    Destroy(gameObject);
            }                       
        }
    }
}
