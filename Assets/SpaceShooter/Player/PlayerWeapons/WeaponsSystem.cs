using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class WeaponsSystem : MonoBehaviour
    {
        private IWeaponInteractor selectedWeapon => weaponsInteractor.CurrentWeapon;      
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
            foreach (var weapon in weapons)
            {
                weapon.OpenFire(this.selectedWeapon, this.objectPool.kinematicPool, this.objectPool.blasterPool);
            }            
        }

        public void CeaseFire()
        {
            foreach (var weapon in weapons)
            {
                weapon.CeaseFire(this.selectedWeapon, this.objectPool.kinematicPool, this.objectPool.blasterPool);
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