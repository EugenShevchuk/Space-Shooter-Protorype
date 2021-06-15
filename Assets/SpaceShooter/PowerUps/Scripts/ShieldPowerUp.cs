using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter 
{
    public class ShieldPowerUp : PowerUpBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        [SerializeField] private float amountShieldToRestore;

        private PlayerShieldInteractor shieldInteractor;

        private void Awake()
        {
            this.InitializeBase();
            this.shieldInteractor = Game.GetInteractor<PlayerShieldInteractor>();
        }

        public void GetAbsorbed()
        {
            this.shieldInteractor.Restore(this.amountShieldToRestore);
            Destroy(this.gameObject);
        }
    }
}