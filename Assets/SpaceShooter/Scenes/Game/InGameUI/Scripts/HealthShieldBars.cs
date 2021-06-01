using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class HealthShieldBars : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private Slider shieldBar;
        [SerializeField] private PlayerStatsObject playerStats;

        private void Awake()
        {
            healthBar.maxValue = playerStats.BaseHealthValue;
            shieldBar.maxValue = playerStats.BaseShieldValue;
            healthBar.value = healthBar.maxValue;
            shieldBar.value = shieldBar.maxValue;
        }

        private void OnEnable()
        {
            PlayerStatsInteractor.OnHealthValueChangedEvent += OnHealthValueChanged;

            PlayerStatsInteractor.OnShieldValueChangedEvent += OnShieldValueChanged;
        }

        private void OnDisable()
        {
            PlayerStatsInteractor.OnHealthValueChangedEvent -= OnHealthValueChanged;

            PlayerStatsInteractor.OnShieldValueChangedEvent -= OnShieldValueChanged;
        }

        private void OnHealthValueChanged(float newValue)
        {
            healthBar.value = newValue;
        }

        private void OnShieldValueChanged(float newValue)
        {
            shieldBar.value = newValue;
        }
    }
}