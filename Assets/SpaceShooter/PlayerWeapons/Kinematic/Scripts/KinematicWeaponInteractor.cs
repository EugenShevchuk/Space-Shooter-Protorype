using System;

namespace SpaceShooter.Architecture
{
    public class KinematicWeaponInteractor : Interactor, IWeaponInteractor, IUpgradable
    {
        #region NotImplemented
        public float DamagePerSecond => throw new NotImplementedException("Kinematic doesn't have damage per second");
        #endregion

        public WeaponType WeaponType => WeaponType.Kinematic;
        public int Level => this.repository.KinematicLevel;
        public float DamageOnHit => this.repository.DamageOnHit;
        public float FireRate => this.repository.FireRate + this.FireRateModifier;        
        public float Velocity => this.repository.Velocity + this.VelocityModifier;

        public int modifiedTimes;
        public float FireRateModifier;
        public float VelocityModifier;
        
        private KinematicWeaponRepository repository;
        private WeaponsRepository weaponsRepository;

        public override void Initialize()
        {
            this.repository = Game.GetRepository<KinematicWeaponRepository>();
            this.weaponsRepository = Game.GetRepository<WeaponsRepository>();
        }

        public void InitializeWeapon()
        {
            this.repository = Game.GetRepository<KinematicWeaponRepository>();
            this.weaponsRepository = Game.GetRepository<WeaponsRepository>();
        }

        public void SetAsCurrentWeapon()
        {
            this.weaponsRepository.SetWeapon<KinematicWeaponInteractor>();
        }

        public void Upgrade()
        {
            this.repository.UpgradeKinematic();
        }
    }
}