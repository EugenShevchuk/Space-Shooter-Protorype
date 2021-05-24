using UnityEngine;
using SpaceShooter.Architecture;
using System.Collections;

namespace SpaceShooter
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform firePoint;

        private void OnEnable()
        {
            Game.GetInteractor<WeaponsInteractor>().AddWeapon(this);          
        }

        private void OnDisable()
        {
            Game.GetInteractor<WeaponsInteractor>().RemoveWeapon(this);
        }

        public void OpenFire(IWeaponInteractor interactor)
        {
            Debug.Log($"Opening fire with {interactor.WeaponType}");
            switch (interactor.WeaponType)
            {
                case WeaponType.Kinematic:
                    this.StartCoroutine(FireGun(interactor));
                    break;
                case WeaponType.Blaster:
                    this.StartCoroutine(FireGun(interactor));
                    break;
                case WeaponType.Laser:
                    this.StartCoroutine(FireLaser(interactor));
                    break;
                default:
                    Debug.LogError("No weapon selected");
                    break;
            }            
        }

        public void CeaseFire(IWeaponInteractor interactor)
        {
            Debug.Log($"Ceasing fire with {interactor.WeaponType}");
            switch (interactor.WeaponType)
            {
                case WeaponType.Kinematic:
                    this.StopCoroutine(FireGun(interactor));
                    break;
                case WeaponType.Blaster:
                    this.StopCoroutine(FireGun(interactor));
                    break;
                case WeaponType.Laser:
                    this.StopCoroutine(FireLaser(interactor));
                    break;
                default:
                    Debug.LogError("No weapon selected");
                    break;
            }
        }

        private IEnumerator FireGun(IWeaponInteractor interactor)
        {
            while (true)
            {
                GameObject projectile = Instantiate(interactor.ProjectilePrefab);

                projectile.tag = "PlayerProjectile";
                projectile.layer = LayerMask.NameToLayer("PlayerProjectile");

                projectile.transform.position = this.firePoint.transform.position;
                projectile.GetComponent<Rigidbody>().velocity = Vector3.up * interactor.Velocity;

                yield return new WaitForSeconds(1 / interactor.FireRate);
            }
        }

        private IEnumerator FireLaser(IWeaponInteractor interactor)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}