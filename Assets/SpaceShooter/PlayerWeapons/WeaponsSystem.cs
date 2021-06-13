using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class WeaponsSystem : MonoBehaviour
    {
        private IWeaponInteractor CurrentWeapon => this.weaponsInteractor.CurrentWeapon;      
        private WeaponsInteractor weaponsInteractor;
        private HashSet<Weapon> weapons = new HashSet<Weapon>();
        public ProjectileObjectPool objectPool;

        private void Awake()
        {
            this.weaponsInteractor = Game.GetInteractor<WeaponsInteractor>();
        }

        private void OnEnable()
        {
            this.weaponsInteractor.SwitchingSelectedWeaponEvent += CeaseFire;
            this.weaponsInteractor.SelectedWeaponSwitchedEvent += OpenFire;
        }

        private void OnDisable()
        {
            this.weaponsInteractor.SwitchingSelectedWeaponEvent -= CeaseFire;
            this.weaponsInteractor.SelectedWeaponSwitchedEvent -= OpenFire;
        }

        public void OpenFire()
        {
            this.CurrentWeapon.InitializeWeapon();

            foreach (var weapon in this.weapons)
            {
                weapon.OpenFire(this.CurrentWeapon, this.objectPool.kinematicPool, this.objectPool.blasterPool);
            }            
        }

        public void CeaseFire()
        {
            foreach (var weapon in this.weapons)
            {
                weapon.CeaseFire();
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public void RemoveWeapon(Weapon weapon)
        {
            this.weapons.Remove(weapon);
        }
    }
}