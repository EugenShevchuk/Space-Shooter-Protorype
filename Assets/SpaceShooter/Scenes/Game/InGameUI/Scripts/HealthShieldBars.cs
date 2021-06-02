using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Architecture;
using System.Collections;

namespace SpaceShooter
{
    public class HealthShieldBars : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private Slider shieldBar;

        public static PlayerStatsInteractor playerStats;

        private void Awake()
        {
            ShieldCollisionHandler.ShieldValueChangedEvent += OnShieldValueChanged;

            PlayerCollisionHandler.HealthValueChangedEvent += OnHealthValueChanged;
        }

        private void OnDisable()
        {
            ShieldCollisionHandler.ShieldValueChangedEvent += OnShieldValueChanged;

            PlayerCollisionHandler.HealthValueChangedEvent -= OnHealthValueChanged;
        }

        private void Start()
        {
            StartCoroutine(InitializeRoutine());
        }

        private IEnumerator InitializeRoutine()
        {
            yield return new WaitUntil(() => playerStats != null);

            healthBar.maxValue = playerStats.Health;
            shieldBar.maxValue = playerStats.Shield;
            healthBar.value = playerStats.Health;
            shieldBar.value = playerStats.Shield;
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