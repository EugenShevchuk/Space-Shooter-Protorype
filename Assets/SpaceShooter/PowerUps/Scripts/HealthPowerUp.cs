using UnityEngine;

namespace SpaceShooter
{
    public class HealthPowerUp : PowerUpStatsBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        [SerializeField] private float amountHealthToRestore;

        private void Awake()
        {
            InitializeStats();
        }

        public void GetAbsorbed()
        {
            statsInteractor.Health += amountHealthToRestore;
            Destroy(this.gameObject);
        }
    }
}