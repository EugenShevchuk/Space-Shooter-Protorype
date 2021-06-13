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
            this.playerStats = Game.GetInteractor<PlayerStatsInteractor>();

            this.healthBar.maxValue = this.playerStats.Health;
            this.shieldBar.maxValue = this.playerStats.Shield;

            this.isStatsInitialized = true;
        }

        private void Update()
        {
            if (this.isStatsInitialized)
            {
                this.healthBar.value = this.playerStats.Health;
                this.healthText.text = $"{this.playerStats.Health}";

                this.shieldBar.value = this.playerStats.Shield;
                this.shieldText.text = $"{this.playerStats.Shield}";
            }
        }
    }
}