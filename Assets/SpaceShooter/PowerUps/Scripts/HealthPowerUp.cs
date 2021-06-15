using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class HealthPowerUp : PowerUpBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        [SerializeField] private float amountHealthToRestore;

        private PlayerHealthInteractor healthInteractor;

        private void Awake()
        {
            this.InitializeBase();
            this.healthInteractor = Game.GetInteractor<PlayerHealthInteractor>();
        }

        public void GetAbsorbed()
        {
            this.healthInteractor.Restore(this.amountHealthToRestore);
            Destroy(this.gameObject);
        }
    }
}