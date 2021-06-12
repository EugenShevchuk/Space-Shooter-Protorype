using UnityEngine;

namespace SpaceShooter 
{
    public class ShieldPowerUp : PowerUpStatsBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        [SerializeField] private float amountShieldToRestore;

        private void Awake()
        {
            InitializeStats();    
        }

        public void GetAbsorbed()
        {
            statsInteractor.Shield += amountShieldToRestore;
            Destroy(this.gameObject);
        }
    }
}