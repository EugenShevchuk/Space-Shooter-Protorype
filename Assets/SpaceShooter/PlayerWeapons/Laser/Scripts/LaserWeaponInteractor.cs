using System;

namespace SpaceShooter.Architecture
{
    public class LaserWeaponInteractor : Interactor, IWeaponInteractor, IUpgradable
    {
        #region NotImplemented
        public float DamageOnHit => throw new NotImplementedException("Laser doesn't have damage on hit");
        public float FireRate => throw new NotImplementedException("Laser doesn't have fire rate");
        public float Velocity => throw new NotImplementedException("Laser doesn't have velocity");
        #endregion

        public WeaponType WeaponType => WeaponType.Laser;
        public float DamagePerSecond => this.repository.DamagePerSecond + this.DamagePerSecondBonus;        
        public int Level => this.repository.LaserLevel;

        public float DamagePerSecondBonus;
        public int modifiedTimes;

        private LaserWeaponRepository repository;
        private WeaponsRepository weaponsRepository;

        public override void Initialize()
        {
            this.repository = Game.GetRepository<LaserWeaponRepository>();
            this.weaponsRepository = Game.GetRepository<WeaponsRepository>();
        }

        public void InitializeWeapon()
        {
            this.repository = Game.GetRepository<LaserWeaponRepository>();
            this.weaponsRepository = Game.GetRepository<WeaponsRepository>();
        }

        public void SetAsCurrentWeapon()
        {
            this.weaponsRepository.SetWeapon<LaserWeaponInteractor>();
        }

        public void Upgrade()
        {
            this.repository.UpgradeLaser();
        }
    }
}