using System;

namespace SpaceShooter.Architecture
{
    public class KinematicWeaponInteractor : Interactor, IWeaponInteractor
    {
        #region NotImplemented
        public float DamagePerSecond => throw new NotImplementedException("Kinematic doesn't have damage per second");
        #endregion

        public WeaponType WeaponType => WeaponType.Kinematic;
        public int Level => repository.KinematicLevel;
        public float DamageOnHit => repository.DamageOnHit;
        public float FireRate => repository.FireRate;
        public float Velocity => repository.Velocity;
        
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