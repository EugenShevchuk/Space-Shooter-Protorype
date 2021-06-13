using System;
using UnityEngine;

namespace SpaceShooter.Architecture.SaveSystem
{
    [Serializable]
    public class PlayerStatsRepositoryData
    {
        public float MaxHealth;
        public int HealthLevel;
        public float HealthBonusLevel1_5;
        public float HealthBonusLevel5_10;

        public float MaxShield;
        public int ShieldLevel;
        public float ShieldBonusLevel1_5;
        public float ShieldBonusLevel5_10;

        public float MaxSpeed;
        public int SpeedLevel;
        public float SpeedBonusLevel1_5;
        public float SpeedBonusLevel5_10;

        [NonSerialized] private PlayerStatsObject statsObject;

        public PlayerStatsRepositoryData()
        {
            this.statsObject = Resources.Load<PlayerStatsObject>("PlayerStats");

            this.MaxHealth = this.statsObject.BaseHealthValue;
            this.HealthLevel = 0;
            this.HealthBonusLevel1_5 = this.statsObject.healthBonusLevel1_5;
            this.HealthBonusLevel5_10 = this.statsObject.healthBonusLevel5_10;

            this.MaxShield = this.statsObject.BaseShieldValue;
            this.ShieldLevel = 0;
            this.ShieldBonusLevel1_5 = this.statsObject.shieldBonusLevel1_5;
            this.ShieldBonusLevel5_10 = this.statsObject.shieldBonusLevel5_10;

            this.MaxSpeed = this.statsObject.BaseSpeedValue;
            this.SpeedLevel = 0;
            this.SpeedBonusLevel1_5 = this.statsObject.speedBonusLevel1_5;
            this.SpeedBonusLevel5_10 = this.statsObject.speedBonusLevel5_10;

            Resources.UnloadUnusedAssets();
        }
    }
}