namespace SpaceShooter.Architecture {
    public class PlayerStatsInteractor : Interactor
    {
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
        public int HealthLevel => this.repository.HealthLevel;

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
        public int ShieldLevel => this.repository.ShieldLevel;

        private float speed;
        public float Speed
        {
            get => this.speed;
            set => this.speed = value;
        }
        public int SpeedLevel => this.repository.SpeedLevel;

        public override void Initialize()
        {
            this.repository = Game.GetRepository<PlayerStatsRepository>();
            
            this.Health = this.repository.Health;
            this.Shield = this.repository.Shield;
            this.Speed = this.repository.Speed;            
        }

        public void UpgradeMaxHealth()
        {
            this.repository.UpgradeMaxHealth();
        }

        public void UpgradeMaxShield()
        {
            this.repository.UpgradeMaxShield();
        }

        public void UpgradeMaxSpeed()
        {
            this.repository.UpgradeMaxSpeed();
        }        
    }
}