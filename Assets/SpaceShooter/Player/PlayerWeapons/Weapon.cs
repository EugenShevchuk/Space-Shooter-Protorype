using UnityEngine;
using SpaceShooter.Architecture;
using System.Collections;

namespace SpaceShooter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        private WeaponsSystem weaponsSystem;

        private void Awake()
        {
            this.weaponsSystem = GetComponentInParent<WeaponsSystem>();
        }

        private void OnEnable()
        {
            this.weaponsSystem.AddWeapon(this);
        }

        private void OnDisable()
        {
            this.weaponsSystem.RemoveWeapon(this);
        }

        public void OpenFire(IWeaponInteractor interactor, ObjectPoolMono<Projectile> kinematicPool, ObjectPoolMono<Projectile> blasterPool)
        {
            Debug.Log($"Opening fire with {interactor.WeaponType}");
            switch (interactor.WeaponType)
            {
                case WeaponType.Kinematic:
                    this.StartCoroutine(FireGun(interactor, kinematicPool));
                    break;
                case WeaponType.Blaster:
                    this.StartCoroutine(FireGun(interactor, blasterPool));
                    break;
                case WeaponType.Laser:
                    this.StartCoroutine(FireLaser(interactor));
                    break;
                default:
                    Debug.LogError("No weapon selected");
                    break;
            }            
        }

        public void CeaseFire(IWeaponInteractor interactor, ObjectPoolMono<Projectile> kinematicPool, ObjectPoolMono<Projectile> blasterPool)
        {
            Debug.Log($"Ceasing fire with {interactor.WeaponType}");
            switch (interactor.WeaponType)
            {
                case WeaponType.Kinematic:
                    this.StopCoroutine(FireGun(interactor, kinematicPool));
                    break;
                case WeaponType.Blaster:
                    this.StopCoroutine(FireGun(interactor, blasterPool));
                    break;
                case WeaponType.Laser:
                    this.StopCoroutine(FireLaser(interactor));
                    break;
                default:
                    Debug.LogError("No weapon selected");
                    break;
            }
        }

        private IEnumerator FireGun(IWeaponInteractor interactor, ObjectPoolMono<Projectile> pool)
        {
            interactor.InitializeWeapon();
            while (true)
            {
                var projectile = pool.GetFreeElement();                
                projectile.gameObject.transform.position = this.firePoint.transform.position;
                projectile.gameObject.GetComponent<Rigidbody>().AddForce((Vector3.up * interactor.Velocity), ForceMode.Impulse);

                projectile.damageOnHit = interactor.DamageOnHit;

                projectile.gameObject.layer = LayerMask.NameToLayer("PlayerProjectile");                
                yield return new WaitForSeconds(1 / interactor.FireRate);
            }            
        }

        private IEnumerator FireLaser(IWeaponInteractor interactor)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}