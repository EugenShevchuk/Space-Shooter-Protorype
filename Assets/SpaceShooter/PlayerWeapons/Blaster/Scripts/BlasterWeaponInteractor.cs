using System;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponInteractor : Interactor, IWeaponInteractor
    {
        #region NotImplemented
        public float DamagePerSecond => throw new NotImplementedException();
        #endregion

        public WeaponType WeaponType => WeaponType.Blaster;
        public int Level => this.repository.BlasterLevel;
        public float DamageOnHit => this.repository.DamageOnHit;
        public float FireRate => this.repository.FireRate + this.FireRateModifier;
        public float Velocity => this.repository.Velocity + this.VelocityModifier;

        public float FireRateModifier;
        public float VelocityModifier;
        public int modifiedTimes;

        private BlasterWeaponRepository repository;
        private WeaponsRepository weaponsRepository;
        
        public void InitializeWeapon()
        {
            this.repository = Game.GetRepository<BlasterWeaponRepository>();
            this.weaponsRepository = Game.GetRepository<WeaponsRepository>();
        }

        public void SetAsCurrentWeapon()
        {
            this.weaponsRepository.SetWeapon<BlasterWeaponInteractor>();
        }

        public void Upgrade()
        {
            this.repository.UpgradeBlaster();
        }
    }
}