using System;
using System.Collections.Generic;
using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture
{    
    public class WeaponsRepository : Repository
    {
        public Type WeaponKey => weaponsData.typeKey; 
        public Dictionary<Type, IWeaponInteractor> WeaponsMap;

        private Storage storage;
        private WeaponsRepoData weaponsData;
        private const string path = "/Weapons.dat";

        public override void Initialize()
        {
            InitializeWeapons();

            storage = new Storage(path);
            weaponsData = (WeaponsRepoData)storage.Load(new WeaponsRepoData());
        }

        public override void Save()
        {
            storage.Save(weaponsData);
        }

        public void Load()
        {
            storage.Load(new WeaponsRepoData());
        }

        public void SetWeapon<T>() where T : IWeaponInteractor
        {
            weaponsData.typeKey = typeof(T);            
            Save();
        }

        private void InitializeWeapons()
        {
            WeaponsMap = new Dictionary<Type, IWeaponInteractor>
            {
                [typeof(KinematicWeaponInteractor)] = new KinematicWeaponInteractor(),
                [typeof(BlasterWeaponInteractor)] = new BlasterWeaponInteractor(),
                [typeof(LaserWeaponInteractor)] = new LaserWeaponInteractor()
            };
        }
    }
}