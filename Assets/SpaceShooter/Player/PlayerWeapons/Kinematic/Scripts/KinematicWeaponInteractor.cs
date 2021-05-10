using System.Collections;
using UnityEngine;
using SpaceShooter.Tools;

namespace SpaceShooter.Architecture
{
    public class KinematicWeaponInteractor : Interactor, IWeapon
    {
        private KinematicWeaponRepository repository;

        private Coroutine fireRoutine;

        public KinematicWeaponInteractor()
        {
            repository = Game.GetRepository<KinematicWeaponRepository>();            
        }

        private void UpgradeKinematic()
        {

        }

        public void OpenFire(Transform firePointRight, Transform firePointLeft)
        {            
            fireRoutine = Coroutines.StartRoutine(FireRoutine(firePointRight, firePointLeft));
            Debug.Log("Opened Fire");
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

                yield return new WaitForSeconds(1 / repository.KinematicObject.FireRate);
            }
        }

        private void MakeProjectile(Transform firePoint)
        {
            GameObject projectile = Object.Instantiate(repository.KinematicObject.ProjectilePrefab);

            Debug.Log("Has Projectile");
            
            projectile.tag = "PlayerProjectile";
            projectile.layer = LayerMask.NameToLayer("PlayerProjectile");
               
            projectile.transform.position = firePoint.transform.position;
            projectile.GetComponent<Rigidbody>().velocity = Vector3.up * repository.KinematicObject.Velocity;

            projectile.GetComponent<Projectile>().damageOnHit = repository.KinematicObject.DamageOnHit;            
        }
    }
}