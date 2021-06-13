using UnityEngine;

namespace SpaceShooter
{
    public class HealthPowerUp : PowerUpStatsBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        [SerializeField] private float amountHealthToRestore;

        private void Awake()
        {
            this.InitializeStats();
        }

        public void GetAbsorbed()
        {
            this.statsInteractor.Health += this.amountHealthToRestore;
            Destroy(this.gameObject);
        }
    }
}