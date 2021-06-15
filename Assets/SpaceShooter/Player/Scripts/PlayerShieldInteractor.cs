using System;

namespace SpaceShooter.Architecture
{
    public class PlayerShieldInteractor : Interactor, IUpgradable
    {
        public event Action<float> ShieldValueChangedEvent;

        private PlayerStatsRepository repository;

        private float shield;
        public float Shield
        {
            get => this.shield;
            set
            {
                if (value <= this.repository.Shield)
                    this.shield = value;
                else
                    this.shield = this.repository.Shield;
            }
        }
        public int Level => this.repository.ShieldLevel;

        public override void Initialize()
        {
            this.repository = Game.GetRepository<PlayerStatsRepository>();

            this.Shield = this.repository.Shield;
        }

        public void Upgrade()
        {
            this.repository.UpgradeMaxShield();
        }

        public void TakeDamage(float damage)
        {
            this.Shield -= damage;
            ShieldValueChangedEvent?.Invoke(this.Shield);
        }

        public void Restore(float amount)
        {
            this.Shield += amount;
            ShieldValueChangedEvent?.Invoke(this.Shield);
        }
    }
}