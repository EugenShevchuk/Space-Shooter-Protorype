using UnityEngine;
using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture {    
    public class KinematicWeaponRepository : Repository
    { 
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
            this.storage = new Storage(SAVE_NAME);
            this.kinematicData = (KinematicRepositoryData)this.storage.Load(new KinematicRepositoryData());

            this.Load();
        }

        public override void Save()
        {
            this.kinematicData.DamageOnHit = this.DamageOnHit;
            this.kinematicData.FireRate = this.FireRate;
            this.kinematicData.Velocity = this.Velocity;
            this.kinematicData.KinematicLevel = this.KinematicLevel;

            this.storage.Save(this.kinematicData);
        }

        public void Load()
        {
            this.DamageOnHit = this.kinematicData.DamageOnHit;
            this.FireRate = this.kinematicData.FireRate;
            this.Velocity = this.kinematicData.Velocity;
            this.KinematicLevel = this.kinematicData.KinematicLevel;
        }

        public void UpgradeKinematic()
        {
            if (this.KinematicLevel < 10)
            {
                if (this.KinematicLevel <= 5)
                    this.DamageOnHit += damageOnHitBonus1_5;

                else
                    this.DamageOnHit += damageOnHitBonus5_10;

                this.KinematicLevel++;
                this.Save();
            }
        }
    }
}