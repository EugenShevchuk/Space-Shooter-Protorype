using System.Collections;
using UnityEngine;
using SpaceShooter.Tools;

namespace SpaceShooter.Architecture
{
    public class KinematicWeaponInteractor : Interactor, IWeapon
    {
        public GameObject ProjectilePrefab;
        public int KinematicLevel => repository.KinematicLevel;
        public float DamageOnHit => repository.DamageOnHit;
        public float FireRate => repository.FireRate;
        public float Velocity => repository.Velocity;

        private KinematicWeaponRepository repository;
        private Coroutine fireRoutine;

        private KinematicWeaponObject weaponObject;        

        public KinematicWeaponInteractor()
        {
            repository = Game.GetRepository<KinematicWeaponRepository>();            
        }

        public void UpgradeKinematic()
        {
            repository.UpgradeKinematic();
        }

        public void OpenFire(Transform firePointRight, Transform firePointLeft)
        {
            weaponObject = Resources.Load<KinematicWeaponObject>("Kinematic");
            ProjectilePrefab = weaponObject.ProjectilePrefab;

            fireRoutine = Coroutines.StartRoutine(FireRoutine(firePointRight, firePointLeft));
            Debug.Log("Opened Fire");
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
            GameObject projectile = Object.Instantiate(ProjectilePrefab);
                        
            projectile.tag = "PlayerProjectile";
            projectile.layer = LayerMask.NameToLayer("PlayerProjectile");
               
            projectile.transform.position = firePoint.transform.position;
            projectile.GetComponent<Rigidbody>().velocity = Vector3.up * repository.Velocity;

            projectile.GetComponent<Projectile>().damageOnHit = repository.DamageOnHit;            
        }
    }
}