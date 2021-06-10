using System;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponInteractor : Interactor, IWeaponInteractor
    {
        #region NotImplemented
        public float DamagePerSecond => throw new NotImplementedException();
        #endregion

        public WeaponType WeaponType => WeaponType.Blaster;
        public int Level => repository.BlasterLevel;
        public float DamageOnHit => repository.DamageOnHit;
        public float FireRate => repository.FireRate + FireRateModifier;
        public float Velocity => repository.Velocity + VelocityModifier;

        public float FireRateModifier;
        public float VelocityModifier;
        public int modifiedTimes;

        private BlasterWeaponRepository repository;
        private WeaponsRepository weaponsRepository;
        
        public override void Initialize()
        {
            repository = Game.GetRepository<BlasterWeaponRepository>();
            weaponsRepository = Game.GetRepository<WeaponsRepository>();
        }

        public void InitializeWeapon()
        {
            repository = Game.GetRepository<BlasterWeaponRepository>();
        }

        public void SetAsCurrentWeapon()
        {
            weaponsRepository.SetWeapon<BlasterWeaponInteractor>();
        }

        public void Upgrade()
        {
            repository.UpgradeBlaster();
        }
    }
}