using UnityEngine;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponInteractor : Interactor, IWeaponInteractor
    {
        public WeaponType WeaponType { get; set; }
        public int Level => repository.BlasterLevel;
        public float DamageOnHit { get; set; }
        public float FireRate { get; set; }
        public float Velocity { get; set; }
        public float DamagePerSecond { get; set; }

        private BlasterWeaponRepository repository;
        private WeaponsRepository weaponsRepository;
        
        public override void Initialize()
        {
            repository = Game.GetRepository<BlasterWeaponRepository>();
            weaponsRepository = Game.GetRepository<WeaponsRepository>();

            WeaponType = WeaponType.Blaster;
            DamageOnHit = repository.DamageOnHit;
        }

        public void InitializeWeapon()
        { 
            
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