using UnityEngine;
using System;

namespace SpaceShooter.Architecture.SaveSystem
{
    [Serializable]
    public class KinematicRepositoryData
    {
        public int KinematicLevel;
        public float DamageOnHit;
        public float FireRate;
        public float Velocity;

        public float DamageOnHitBonus1_5;
        public float DamageOnHitBonus5_10;

        [NonSerialized] private KinematicWeaponObject kinematicObject;
        [NonSerialized] private const string SO_PATH = "Kinematic";

        public KinematicRepositoryData()
        {
            this.kinematicObject = Resources.Load<KinematicWeaponObject>(SO_PATH);

            this.DamageOnHit = this.kinematicObject.DamageOnHit;
            this.FireRate = this.kinematicObject.FireRate;
            this.Velocity = this.kinematicObject.Velocity;
            this.KinematicLevel = 0;

            this.DamageOnHitBonus1_5 = this.kinematicObject.DamageOnHitBonus1_5;
            this.DamageOnHitBonus5_10 = this.kinematicObject.DamageOnHitBonus5_10;

            Resources.UnloadUnusedAssets();
        }
    }
}