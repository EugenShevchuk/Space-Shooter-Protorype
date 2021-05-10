using System.Collections;
using UnityEngine;
using SpaceShooter.Tools;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponInteractor : Interactor, IWeapon
    {
        private BlasterWeaponRepository repository;

        private Coroutine fireRoutine;

        public BlasterWeaponObject WeaponObject { get; }

        public BlasterWeaponInteractor()
        {
            repository = Game.GetRepository<BlasterWeaponRepository>();
            WeaponObject = repository.BlasterObject;
        }

        private void UpgradeKinematic()
        {

        }

        public void OpenFire(Transform firePointRight, Transform firePointLeft)
        {
            fireRoutine = Coroutines.StartRoutine(FireRoutine(firePointRight, firePointLeft));
        }

        public void CeaseFire()
        {
            Coroutines.StopRoutine(fireRoutine);
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
            GameObject projectile = Object.Instantiate(WeaponObject.ProjectilePrefab);

            projectile.tag = "PlayerProjectile";
            projectile.layer = LayerMask.NameToLayer("PlayerProjectile");

            projectile.transform.position = firePoint.transform.position;
            projectile.GetComponent<Rigidbody>().velocity = Vector3.up * repository.Velocity;
        }        
    }
}