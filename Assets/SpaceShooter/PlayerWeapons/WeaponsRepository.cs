using System;
using System.Collections.Generic;
using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture
{    
    public class WeaponsRepository : Repository
    {
        public IWeaponInteractor SelectedWeapon => this.WeaponsMap[this.WeaponKey];
        public Type WeaponKey => this.weaponsData.typeKey; 
        public Dictionary<Type, IWeaponInteractor> WeaponsMap;

        private Storage storage;
        private WeaponsRepoData weaponsData;
        private const string path = "/Weapons.dat";

        public override void Initialize()
        {
            this.InitializeWeapons();

            this.storage = new Storage(path);
            this.weaponsData = (WeaponsRepoData)this.storage.Load(new WeaponsRepoData());
        }

        public override void Save()
        {
            this.storage.Save(this.weaponsData);
        }

        public void Load()
        {
            this.storage.Load(new WeaponsRepoData());
        }

        public void SetWeapon<T>() where T : IWeaponInteractor
        {
            this.weaponsData.typeKey = typeof(T);
            this.Save();
        }

        private void InitializeWeapons()
        {
            this.WeaponsMap = new Dictionary<Type, IWeaponInteractor>
            {
                [typeof(KinematicWeaponInteractor)] = new KinematicWeaponInteractor(),
                [typeof(BlasterWeaponInteractor)] = new BlasterWeaponInteractor(),
                [typeof(LaserWeaponInteractor)] = new LaserWeaponInteractor()
            };
        }
    }
}