namespace SpaceShooter.Architecture
{
    public class KinematicWeaponInteractor : Interactor, IWeaponInteractor
    {
        public WeaponType WeaponType => WeaponType.Kinematic;
        public int Level => repository.KinematicLevel;
        public float DamageOnHit => repository.DamageOnHit;
        public float FireRate => repository.FireRate;
        public float Velocity => repository.Velocity;
        public float DamagePerSecond { get; set; }

        private KinematicWeaponRepository repository;
        private WeaponsRepository weaponsRepository;

        public override void Initialize()
        {
            repository = Game.GetRepository<KinematicWeaponRepository>();
            weaponsRepository = Game.GetRepository<WeaponsRepository>();
        }

        public void InitializeWeapon()
        {
            repository = Game.GetRepository<KinematicWeaponRepository>();                       
        }

        public void SetAsCurrentWeapon()
        {
            weaponsRepository.SetWeapon<KinematicWeaponInteractor>();
        }

        public void Upgrade()
        {
            repository.UpgradeKinematic();
        }

        
    }
}