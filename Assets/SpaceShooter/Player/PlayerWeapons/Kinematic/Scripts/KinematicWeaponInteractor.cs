using UnityEngine;

namespace SpaceShooter.Architecture
{
    public class KinematicWeaponInteractor : Interactor, IWeaponInteractor
    {
        public WeaponType WeaponType { get; set; }
        public int Level => repository.KinematicLevel;
        public float DamageOnHit => repository.DamageOnHit;
        public float FireRate => repository.FireRate;
        public float Velocity => repository.Velocity;
        public float DamagePerSecond => throw new System.NotImplementedException();

        public GameObject ProjectilePrefab => repository.ProjectilePrefab;
                

        private KinematicWeaponRepository repository;
        private WeaponsRepository weaponsRepository;

        public override void Initialize()
        {
            WeaponType = WeaponType.Kinematic;
            repository = Game.GetRepository<KinematicWeaponRepository>();
            weaponsRepository = Game.GetRepository<WeaponsRepository>();
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