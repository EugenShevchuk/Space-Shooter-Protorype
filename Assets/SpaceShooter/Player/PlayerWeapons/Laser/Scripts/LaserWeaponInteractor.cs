using System;

namespace SpaceShooter.Architecture
{
    public class LaserWeaponInteractor : Interactor, IWeaponInteractor
    {
        #region NotImplemented
        public float DamageOnHit => throw new NotImplementedException("Laser doesn't have damage on hit");
        public float FireRate => throw new NotImplementedException("Laser doesn't have fire rate");
        public float Velocity => throw new NotImplementedException("Laser doesn't have velocity");
        #endregion

        public WeaponType WeaponType => WeaponType.Laser;
        public float DamagePerSecond => repository.DamagePerSecond + DamagePerSecondBonus;        
        public int Level => repository.LaserLevel;

        public float DamagePerSecondBonus;
        public int modifiedTimes;

        private LaserWeaponRepository repository;
        private WeaponsRepository weaponsRepository;

        public override void Initialize()
        {
            repository = Game.GetRepository<LaserWeaponRepository>();
            weaponsRepository = Game.GetRepository<WeaponsRepository>();
        }

        public void InitializeWeapon()
        {
            repository = Game.GetRepository<LaserWeaponRepository>();
        }

        public void SetAsCurrentWeapon()
        {
            weaponsRepository.SetWeapon<LaserWeaponInteractor>();
        }

        public void Upgrade()
        {
            repository.UpgradeLaser();
        }
    }
}