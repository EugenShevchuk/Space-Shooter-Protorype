using UnityEngine;

namespace SpaceShooter 
{
    public class ShieldPowerUp : PowerUpStatsBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        [SerializeField] private float amountShieldToRestore;

        private void Awake()
        {
            this.InitializeStats();    
        }

        public void GetAbsorbed()
        {
            this.statsInteractor.Shield += this.amountShieldToRestore;
            Destroy(this.gameObject);
        }
    }
}