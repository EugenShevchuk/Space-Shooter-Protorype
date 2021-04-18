using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance;

    [SerializeField] private PlayerStatsObject playerStats;
    private float health;
    private float shield;
    private float speed;

    private int healthLvl;
    private int shieldLvl;
    private int engineLvl;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider shieldSlider;
    [SerializeField] private Slider engineSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  
        }
        GetStats();

        healthSlider.value = healthLvl;
        shieldSlider.value = shieldLvl;
        engineSlider.value = engineLvl;
    }

    public void GetStats()
    {
        if (playerStats != null)
        {
            speed = playerStats.Speed;
            health = playerStats.MaxHealthValue;
            shield = playerStats.MaxShieldValue;
            healthLvl = playerStats.HealthLvl;
            shieldLvl = playerStats.ShieldLvl;
            engineLvl = playerStats.SpeedLvl;
        }
    }

    public void SetStats()
    {
        if (playerStats != null)
        {
            playerStats.Speed = speed;
            playerStats.MaxHealthValue = health;
            playerStats.MaxShieldValue = shield;
            playerStats.HealthLvl = healthLvl;
            playerStats.ShieldLvl = shieldLvl; 
            playerStats.SpeedLvl = engineLvl;
        }
    }

    public void UpgradeHealth()
    {
        if (healthLvl < 10)
        {
            if (healthLvl <= 5)
                health += 1f;
            if (healthLvl > 5 && healthLvl < 10)
                health += 2f;
            healthLvl++;
            healthSlider.value = healthLvl;
        }
        SetStats();
    }

    public void UpgradeShield()
    {
        if (shieldLvl < 10)
        {
            if (shieldLvl <= 5)
                shield += 1f;

            if (shieldLvl > 5 && shieldLvl < 10)
                shield += 2f;

            shieldLvl++;
            shieldSlider.value = shieldLvl;
        }
        SetStats();
    }

    public void UpgradeEngine()
    {
        if (engineLvl < 10)
        {
            if (engineLvl <= 5)
                speed += 1f;

            if (engineLvl > 5)
                speed += 2f;

            engineLvl++;
            engineSlider.value = engineLvl;
        }
        SetStats();
    }
}
