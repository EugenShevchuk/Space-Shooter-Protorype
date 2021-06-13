using UnityEngine;
using System;

namespace SpaceShooter.Architecture.SaveSystem
{
    [Serializable]
    public class LaserRepositoryData
    {
        public int LaserLevel;
        public float DamagePerSecond;

        public float DamagePerSecondBonus1_5;
        public float DamagePerSecondBonus5_10;

        [NonSerialized] private LaserWeaponObject laserObject;
        [NonSerialized] private const string SO_PATH = "Laser";

        public LaserRepositoryData()
        {
            this.laserObject = Resources.Load<LaserWeaponObject>(SO_PATH);

            this.LaserLevel = 0;
            this.DamagePerSecond = this.laserObject.DamagePerSecond;
            this.DamagePerSecondBonus1_5 = this.laserObject.DamagePerSecondBonus1_5;
            this.DamagePerSecondBonus5_10 = this.laserObject.DamagePerSecondBonus5_10;

            Resources.UnloadUnusedAssets();
        }
    }
}