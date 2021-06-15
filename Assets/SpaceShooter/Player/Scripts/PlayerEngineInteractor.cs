namespace SpaceShooter.Architecture 
{
    public class PlayerEngineInteractor : Interactor, IUpgradable
    {
        private float speed;
        public float Speed
        {
            get => this.speed;
            set => this.speed = value;
        }
        public int Level => this.repository.SpeedLevel;

        private PlayerStatsRepository repository;

        public override void Initialize()
        {
            this.repository = Game.GetRepository<PlayerStatsRepository>();

            this.speed = this.repository.Speed;
        }

        public void Upgrade()
        {
            this.repository.UpgradeMaxSpeed();
        }
    }
}