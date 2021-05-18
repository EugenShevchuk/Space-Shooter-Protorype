using System.Collections;
using UnityEngine;
using SpaceShooter.Tools;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponInteractor : Interactor, IWeapon
    {
        public GameObject ProjectilePrefab;

        public int BlasterLevel => repository.BlasterLevel;
        public float DamageOnHit => repository.DamageOnHit;
        public float FireRate => repository.FireRate;
        public float Velocity => repository.Velocity;
        
        private BlasterWeaponRepository repository;
        private Coroutine fireRoutine;
        
        private BlasterWeaponObject weaponObject;
        private const string SO_PATH = "Blaster";
        
        public BlasterWeaponInteractor()
        {
            repository = Game.GetRepository<BlasterWeaponRepository>();            
        }

        public void UpgradeBlaster()
        {
            repository.UpgradeBlaster();
        }

        public void OpenFire(Transform firePointRight, Transform firePointLeft)
        {
            weaponObject = Resources.Load<BlasterWeaponObject>(SO_PATH);
            ProjectilePrefab = weaponObject.ProjectilePrefab;

            fireRoutine = Coroutines.StartRoutine(FireRoutine(firePointRight, firePointLeft));
        }

        public void CeaseFire()
        {
            Coroutines.StopRoutine(fireRoutine);

            Resources.UnloadUnusedAssets();
        }

        private IEnumerator FireRoutine(Transform firePointRight, Transform firePointLeft)
        {
            while (true)
            {
                MakeProjectile(firePointRight);
                MakeProjectile(firePointLeft);

                yield return new WaitForSeconds(1 / repository.FireRate);
            }
        }

        private void MakeProjectile(Transform firePoint)
        {
            GameObject projectile = Object.Instantiate(weaponObject.ProjectilePrefab);

            projectile.tag = "PlayerProjectile";
            projectile.layer = LayerMask.NameToLayer("PlayerProjectile");

            projectile.transform.position = firePoint.transform.position;
            projectile.GetComponent<Rigidbody>().velocity = Vector3.up * repository.Velocity;
        }        
    }
}