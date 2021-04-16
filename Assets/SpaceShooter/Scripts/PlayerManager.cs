using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private float baseHealth = 10f;
    [SerializeField] private float baseShield = 10f;
    [SerializeField] private float baseSpeed = 25f;    

    public float Health 
    { 
        get { return baseHealth; } 
        set { baseHealth = value; } 
    }
    public float Shield
    { 
        get { return baseShield; } 
        set { baseShield = value; } 
    }
    public float Speed
    {
        get { return baseSpeed; }
        set { baseSpeed = value; }
    }
    
    public float roll = 20f;
    public float pitch = 15f;

    private int healthLvl;
    private int shieldLvl;
    private int engineLvl;

    [SerializeField] private Slider HealthSlider;
    [SerializeField] private Slider ShieldSlider;
    [SerializeField] private Slider EngineSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public void UpgradeHealth()
    {
        if (healthLvl <= 5)
        {
            Health += 1f;
            HealthSlider.value++;
        }
        if (healthLvl > 5 && healthLvl < 10)
        {
            Health += 2f;
            HealthSlider.value++;
        }
        healthLvl++;
    }

    public void UpgradeShield()
    {
        if (shieldLvl <= 5)
        {
            Shield += 1f;
            ShieldSlider.value++;
        }
        if (shieldLvl > 5 && shieldLvl < 10)
        {
            Shield += 2f;
            ShieldSlider.value++;
        }
        shieldLvl++;
    }

    public void UpgradeEngine()
    {
        if (engineLvl <= 5)
        {
            Speed += 1f;
            EngineSlider.value++;
        }
        if (engineLvl > 5 && engineLvl < 10)
        {
            Speed += 2f;
            EngineSlider.value++;
        }
        engineLvl++;
    }
}
