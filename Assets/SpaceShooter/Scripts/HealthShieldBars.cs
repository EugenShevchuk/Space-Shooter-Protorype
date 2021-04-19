using UnityEngine;
using UnityEngine.UI;

public class HealthShieldBars : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider shieldBar;
    [SerializeField] private PlayerStatsObject playerStats;

    private void Awake()
    {        
        healthBar.maxValue = playerStats.MaxHealthValue;
        shieldBar.maxValue = playerStats.MaxShieldValue;
        healthBar.value = healthBar.maxValue;
        shieldBar.value = shieldBar.maxValue;

        PlayerBehaviour.OnHealthValueChangedEvent += OnHealthValueChanged;        

        PlayerBehaviour.OnShieldValueChangedEvent += OnShieldValueChanged;        
    }

    private void OnHealthValueChanged(int newValue)
    {
        healthBar.value = newValue;
    }

    private void OnShieldValueChanged(int newValue)
    {
        shieldBar.value = newValue;
    }
}
