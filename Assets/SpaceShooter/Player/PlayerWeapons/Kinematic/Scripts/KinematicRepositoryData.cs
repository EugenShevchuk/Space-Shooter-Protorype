using UnityEngine;
using System;

namespace SpaceShooter.Architecture.SaveSystem
{
    [Serializable]
    public class KinematicRepositoryData
    {
        public GameObject ProjectilePrefab => kinematicObject.ProjectilePrefab;
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
            kinematicObject = Resources.Load<KinematicWeaponObject>(SO_PATH);

            this.DamageOnHit = kinematicObject.DamageOnHit;
            this.FireRate = kinematicObject.FireRate;
            this.Velocity = kinematicObject.Velocity;
            this.KinematicLevel = 0;

            this.DamageOnHitBonus1_5 = kinematicObject.DamageOnHitBonus1_5;
            this.DamageOnHitBonus5_10 = kinematicObject.DamageOnHitBonus5_10;

            Resources.UnloadUnusedAssets();
        }
    }
}