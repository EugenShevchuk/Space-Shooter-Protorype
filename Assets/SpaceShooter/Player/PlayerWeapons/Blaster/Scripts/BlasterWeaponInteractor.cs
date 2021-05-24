using System.Collections;
using UnityEngine;
using SpaceShooter.Tools;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponInteractor : Interactor, IWeaponInteractor
    {
        public WeaponType WeaponType { get; set; }
        public GameObject ProjectilePrefab { get; }
        public int Level => repository.BlasterLevel;
        public float DamageOnHit => repository.DamageOnHit;
        public float FireRate => repository.FireRate;
        public float Velocity => repository.Velocity;
        public float DamagePerSecond { get; }

        private BlasterWeaponRepository repository;
        private WeaponsRepository weaponsRepository;
        
        public override void Initialize()
        {
            WeaponType = WeaponType.Blaster;
            repository = Game.GetRepository<BlasterWeaponRepository>();
            weaponsRepository = Game.GetRepository<WeaponsRepository>();
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