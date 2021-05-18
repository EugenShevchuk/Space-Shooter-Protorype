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
            statsObject = Resources.Load<PlayerStatsObject>("PlayerStats");

            this.MaxHealth = statsObject.BaseHealthValue;
            HealthLevel = 0;
            HealthBonusLevel1_5 = statsObject.healthBonusLevel1_5;
            HealthBonusLevel5_10 = statsObject.healthBonusLevel5_10;

            MaxShield = statsObject.BaseShieldValue;
            ShieldLevel = 0;
            ShieldBonusLevel1_5 = statsObject.shieldBonusLevel1_5;
            ShieldBonusLevel5_10 = statsObject.shieldBonusLevel5_10;

            MaxSpeed = statsObject.BaseSpeedValue;
            SpeedLevel = 0;
            SpeedBonusLevel1_5 = statsObject.speedBonusLevel1_5;
            SpeedBonusLevel5_10 = statsObject.speedBonusLevel5_10;

            Resources.UnloadUnusedAssets();
        }
    }
}