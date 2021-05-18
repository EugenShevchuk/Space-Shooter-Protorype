using UnityEngine;
using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture
{
    public class PlayerStatsRepository : Repository
    {        
        public float Health { get; private set; }        
        public int HealthLevel { get; private set; }
        private float healthBonusLevel1_5 => statsData.HealthBonusLevel1_5;
        private float healthBonusLevel5_10 => statsData.HealthBonusLevel5_10;

        public float Shield { get; private set; }        
        public int ShieldLevel { get; private set; }
        private float shieldBonusLevel1_5 => statsData.ShieldBonusLevel1_5;
        private float shieldBonusLevel5_10 => statsData.ShieldBonusLevel5_10;
                
        public float Speed { get; private set; }        
        public int SpeedLevel { get; private set; }
        private float speedBonusLevel1_5 => statsData.SpeedBonusLevel1_5;
        private float speedBonusLevel5_10 => statsData.SpeedBonusLevel5_10;

        private Storage storage;
        private PlayerStatsRepositoryData statsData;
        private const string path = "/PlayerStats.dat";

        public override void Initialize()
        {
            storage = new Storage(path);
            statsData = (PlayerStatsRepositoryData)storage.Load(new PlayerStatsRepositoryData());

            Load();
        }

        public override void Save()
        {
            statsData.MaxHealth = this.Health;
            statsData.HealthLevel = this.HealthLevel;

            statsData.MaxShield = this.Shield;
            statsData.ShieldLevel = this.ShieldLevel;

            statsData.MaxSpeed = this.Speed;
            statsData.SpeedLevel = this.SpeedLevel;

            storage.Save(statsData);
        }

        public void Load()
        {
            this.Health = statsData.MaxHealth;
            this.HealthLevel = statsData.HealthLevel;

            this.Shield = statsData.MaxShield;
            this.ShieldLevel = statsData.ShieldLevel;

            this.Speed = statsData.MaxSpeed;
            this.SpeedLevel = statsData.SpeedLevel;
        }

        public void UpgradeMaxHealth()
        {
            if (HealthLevel < 10)
            {
                if (HealthLevel <= 5)
                    Health += healthBonusLevel1_5;

                else
                    Health += healthBonusLevel5_10;

                HealthLevel++;
                Save();
            }
        }

        public void UpgradeMaxShield()
        {
            if (ShieldLevel < 10)
            {
                if (ShieldLevel <= 5)
                    Shield += shieldBonusLevel1_5;

                else
                    Shield += shieldBonusLevel5_10;

                ShieldLevel++;
                Save();
            }
        }

        public void UpgradeMaxSpeed()
        {
            if (SpeedLevel < 10)
            {
                if (SpeedLevel <= 5)
                    Speed += speedBonusLevel1_5;

                else
                    Speed += speedBonusLevel5_10;

                SpeedLevel++;
                Save();
            }
        }
    }
}