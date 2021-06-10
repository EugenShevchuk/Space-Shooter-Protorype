namespace SpaceShooter.Architecture {
    public class PlayerStatsInteractor : Interactor
    {
        private PlayerStatsRepository repository;

        public float Health => repository.Health;
        public int HealthLevel => repository.HealthLevel;
        public float Shield => repository.Shield;
        public int ShieldLevel => repository.ShieldLevel;
        public float Speed => repository.Speed;
        public int SpeedLevel => repository.SpeedLevel;

        public override void Initialize()
        {
            repository = Game.GetRepository<PlayerStatsRepository>();
        }

        public void UpgradeMaxHealth()
        {
            repository.UpgradeMaxHealth();
        }

        public void UpgradeMaxShield()
        {
            repository.UpgradeMaxShield();
        }

        public void UpgradeMaxSpeed()
        {
            repository.UpgradeMaxSpeed();
        }        
    }
}