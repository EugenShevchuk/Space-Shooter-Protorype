using UnityEngine;
using System;

namespace SpaceShooter.Architecture.SaveSystem
{
    [Serializable]
    public class BlasterRepositoryData
    {
        public int BlasterLevel;
        public float DamageOnHit;
        public float FireRate;
        public float Velocity;

        public float DamageOnHitBonus1_5;
        public float DamageOnHitBonus5_10;

        [NonSerialized] private BlasterWeaponObject blasterObject;
        [NonSerialized] private const string SO_PATH = "Blaster";

        public BlasterRepositoryData()
        {
            this.blasterObject = Resources.Load<BlasterWeaponObject>(SO_PATH);

            this.BlasterLevel = 0;
            this.DamageOnHit = this.blasterObject.DamageOnHit;
            this.FireRate = this.blasterObject.FireRate;
            this.Velocity = this.blasterObject.Velocity;

            this.DamageOnHitBonus1_5 = this.blasterObject.DamageOnHitBonus1_5;
            this.DamageOnHitBonus5_10 = this.blasterObject.DamageOnHitBonus5_10;

            Resources.UnloadUnusedAssets();
        }
    }
}