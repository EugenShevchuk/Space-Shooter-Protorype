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

        private PlayerHealthInteractor healthInteractor;
        private PlayerShieldInteractor shieldInteractor;

        private void OnEnable()
        {
            Scene.InitializedEvent += OnSceneInitialized;
        }

        private void OnDisable()
        {
            Scene.InitializedEvent -= OnSceneInitialized;

            this.healthInteractor.HealthValueChangedEvent -= OnHealthValueChanged;
            this.shieldInteractor.ShieldValueChangedEvent -= OnShieldValueChanged;
        }

        private void OnSceneInitialized()
        {
            this.healthInteractor = Game.GetInteractor<PlayerHealthInteractor>();
            this.shieldInteractor = Game.GetInteractor<PlayerShieldInteractor>();

            this.healthInteractor.HealthValueChangedEvent += OnHealthValueChanged;
            this.shieldInteractor.ShieldValueChangedEvent += OnShieldValueChanged;

            this.healthBar.maxValue = this.healthInteractor.Health;
            this.shieldBar.maxValue = this.shieldInteractor.Shield;

            this.OnHealthValueChanged(this.healthInteractor.Health);
            this.OnShieldValueChanged(this.shieldInteractor.Shield);
        }

        private void OnHealthValueChanged(float value)
        {
            this.healthBar.value = value;
            this.healthText.text = $"{value}";
        }

        private void OnShieldValueChanged(float value)
        {
            this.shieldBar.value = value;
            this.shieldText.text = $"{value}";
        }
    }
}