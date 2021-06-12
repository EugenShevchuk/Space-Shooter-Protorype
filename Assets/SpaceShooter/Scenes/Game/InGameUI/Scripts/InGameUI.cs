using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Architecture;
using TMPro;

namespace SpaceShooter
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private Slider shieldBar;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI shieldText;

        private PlayerStatsInteractor playerStats;
        private bool isStatsInitialized = false;

        private void OnEnable()
        {
            Scene.InitializedEvent += OnSceneInitialized;
        }

        private void OnDisable()
        {
            Scene.InitializedEvent -= OnSceneInitialized;
        }

        private void OnSceneInitialized()
        {
            playerStats = Game.GetInteractor<PlayerStatsInteractor>();

            healthBar.maxValue = playerStats.Health;
            shieldBar.maxValue = playerStats.Shield;

            isStatsInitialized = true;
        }

        private void Update()
        {
            if (isStatsInitialized)
            {
                healthBar.value = playerStats.Health;
                healthText.text = $"{playerStats.Health}";

                shieldBar.value = playerStats.Shield;
                shieldText.text = $"{playerStats.Shield}";
            }
        }
    }
}