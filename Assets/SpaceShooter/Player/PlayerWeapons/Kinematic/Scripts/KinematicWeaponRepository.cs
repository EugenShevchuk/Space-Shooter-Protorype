using UnityEngine;
using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture {
    
    public class KinematicWeaponRepository : Repository, IWeaponRepository
    {
        public GameObject ProjectilePrefab { get; set; }
        public float DamageOnHit { get; private set; }
        public float FireRate { get; private set; }
        public float Velocity { get; private set; }
        public int KinematicLevel { get; private set; }
        private float damageOnHitBonus1_5 => kinematicData.DamageOnHitBonus1_5;
        private float damageOnHitBonus5_10 => kinematicData.DamageOnHitBonus5_10;

        private Storage storage;
        private KinematicRepositoryData kinematicData;
        private const string SAVE_NAME = "/Kinematic.dat";
        
        public override void Initialize()
        {
            storage = new Storage(SAVE_NAME);
            kinematicData = (KinematicRepositoryData)storage.Load(new KinematicRepositoryData());
            ProjectilePrefab = kinematicData.ProjectilePrefab;

            Load();
        }

        public override void Save()
        {
            kinematicData.DamageOnHit = this.DamageOnHit;
            kinematicData.FireRate = this.FireRate;
            kinematicData.Velocity = this.Velocity;
            kinematicData.KinematicLevel = this.KinematicLevel;

            storage.Save(kinematicData);
        }

        public void Load()
        {
            this.DamageOnHit = kinematicData.DamageOnHit;
            this.FireRate = kinematicData.FireRate;
            this.Velocity = kinematicData.Velocity;
            this.KinematicLevel = kinematicData.KinematicLevel;
        }

        public void UpgradeKinematic()
        {
            if (KinematicLevel < 10)
            {
                if (KinematicLevel <= 5)
                    this.DamageOnHit += damageOnHitBonus1_5;

                else
                    this.DamageOnHit += damageOnHitBonus5_10;

                KinematicLevel++;
                Save();
            }
        }
    }
}