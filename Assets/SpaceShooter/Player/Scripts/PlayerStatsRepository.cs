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
            this.statsData.MaxHealth = this.Health;
            this.statsData.HealthLevel = this.HealthLevel;

            this.statsData.MaxShield = this.Shield;
            this.statsData.ShieldLevel = this.ShieldLevel;

            this.statsData.MaxSpeed = this.Speed;
            this.statsData.SpeedLevel = this.SpeedLevel;

            this.storage.Save(this.statsData);
        }

        public void Load()
        {
            this.Health = this.statsData.MaxHealth;
            this.HealthLevel = this.statsData.HealthLevel;

            this.Shield = this.statsData.MaxShield;
            this.ShieldLevel = this.statsData.ShieldLevel;

            this.Speed = this.statsData.MaxSpeed;
            this.SpeedLevel = this.statsData.SpeedLevel;
        }

        public void UpgradeMaxHealth()
        {
            if (this.HealthLevel < 10)
            {
                if (this.HealthLevel <= 5)
                    this.Health += this.healthBonusLevel1_5;

                else
                    this.Health += this.healthBonusLevel5_10;

                this.HealthLevel++;
                this.Save();
            }
        }

        public void UpgradeMaxShield()
        {
            if (this.ShieldLevel < 10)
            {
                if (this.ShieldLevel <= 5)
                    this.Shield += this.shieldBonusLevel1_5;

                else
                    this.Shield += this.shieldBonusLevel5_10;

                this.ShieldLevel++;
                this.Save();
            }
        }

        public void UpgradeMaxSpeed()
        {
            if (this.SpeedLevel < 10)
            {
                if (this.SpeedLevel <= 5)
                    this.Speed += this.speedBonusLevel1_5;

                else
                    this.Speed += this.speedBonusLevel5_10;

                this.SpeedLevel++;
                this.Save();
            }
        }
    }
}