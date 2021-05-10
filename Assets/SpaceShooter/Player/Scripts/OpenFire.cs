using System.Collections;
using UnityEngine;
using SpaceShooter.Architecture;
using System.Collections.Generic;
using System;

namespace SpaceShooter
{
    public class OpenFire : MonoBehaviour
    {
        [SerializeField] private Transform firePointRight;
        [SerializeField] private Transform firePoinLeft;

        private WeaponsInteractor weaponsInteractor;        
        
        private void OnGameInitialized()
        {
            FireWeapon();
        }
        
        private void OnEnable()
        {
            SceneManagerBase.OnSceneInitializedEvent += OnGameInitialized;            
        }

        private void OnDisable()
        {
            SceneManagerBase.OnSceneInitializedEvent -= OnGameInitialized;            
        }
        
        private void Start()
        {
            weaponsInteractor = Game.GetInteractor<WeaponsInteractor>(); 
        }
        
        private void FireWeapon()
        {            
            if (weaponsInteractor == null)
                Debug.Log("Weapons Interactor is not Initialized");
            if (weaponsInteractor.CurrentWeapon == null)
                Debug.Log("No Current Weapon Selected");
            weaponsInteractor.CurrentWeapon.OpenFire(firePointRight, firePoinLeft);
        }
    }
        
}