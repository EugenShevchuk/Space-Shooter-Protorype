using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Architecture
{    
    public class WeaponsRepository : Repository
    {
        public IWeapon SelectedWeapon;
        private const string selectedWeapon_KEY = "selectedWeapon_KEY";

        private Dictionary<Type, IWeapon> weaponsMap;
        private WeaponsRepositoryData repoData = new WeaponsRepositoryData();

        public override void OnCreate()
        {
            InitializeWeapons();
        }        

        public override void Initialize()
        {
            
        }

        public void SetDefaultWeapon()
        {
            SelectedWeapon = GetWeapon<KinematicWeaponInteractor>();
        }

        public override void Save()
        {
            repoData.Weapon = SelectedWeapon;            

            var json = JsonUtility.ToJson(repoData);
            Debug.Log($"Saved Value: {json}");
            PlayerPrefs.SetString(selectedWeapon_KEY, json);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            if (!PlayerPrefs.HasKey(selectedWeapon_KEY))
            {
                SetDefaultWeapon();
                Save();
                return;
            }

            var json = PlayerPrefs.GetString(selectedWeapon_KEY);
            repoData = JsonUtility.FromJson<WeaponsRepositoryData>(json);
            SelectedWeapon = repoData.Weapon;
        }
        
        public IWeapon GetWeapon<T>() where T : IWeapon
        {
            var type = typeof(T);
            return weaponsMap[type];
        }

        private void InitializeWeapons()
        {
            weaponsMap = new Dictionary<Type, IWeapon>
            {
                [typeof(KinematicWeaponInteractor)] = new KinematicWeaponInteractor(),
                [typeof(BlasterWeaponInteractor)] = new BlasterWeaponInteractor(),
                [typeof(LaserWeaponInteractor)] = new LaserWeaponInteractor()
            };
        }
    }
}