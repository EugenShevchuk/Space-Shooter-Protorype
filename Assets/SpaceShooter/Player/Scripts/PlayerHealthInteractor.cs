using System;

namespace SpaceShooter.Architecture
{
    public class PlayerHealthInteractor : Interactor, IUpgradable
    {
        public event Action<float> HealthValueChangedEvent;

        private PlayerStatsRepository repository;

        private float health;
        public float Health
        {
            get => this.health;
            set
            {
                if (value <= this.repository.Health)
                    this.health = value;
                else
                    this.health = this.repository.Health;
            }
        }
        public int Level => this.repository.HealthLevel;

        public override void Initialize()
        {
            this.repository = Game.GetRepository<PlayerStatsRepository>();

            this.health = this.repository.Health;
        }

        public void Upgrade()
        {
            this.repository.UpgradeMaxHealth();
        }

        public void TakeDamage(float damage)
        {
            this.Health -= damage;
            HealthValueChangedEvent?.Invoke(this.Health);
        }

        public void Restore(float amount)
        {
            this.Health += amount;
            HealthValueChangedEvent?.Invoke(this.Health);
        }
    }
}