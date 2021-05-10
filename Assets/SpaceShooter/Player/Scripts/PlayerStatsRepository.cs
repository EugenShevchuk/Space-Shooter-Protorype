using UnityEngine;

namespace SpaceShooter.Architecture
{
    public class PlayerStatsRepository : Repository
    {
        public PlayerStatsObject stats;

        private const string health_KEY = "Health_KEY";        
        public float Health { get; set; }
        private const string healthLevel_KEY = "HealthLevel_KEY";
        public int HealthLevel { get; set; }

        private const string shield_KEY = "Shield_KEY";
        public float Shield { get; set; }
        private const string shieldLevel_KEY = "ShieldLevel_KEY";
        public int ShieldLevel { get; set; }

        private const string speed_KEY = "Speed_KEY";
        public float Speed { get; set; }
        private const string speedLevel_KEY = "SpeedLevel_KEY";
        public int SpeedLevel { get; set; }

        private PlayerStatsObject statsObject;

        public override void OnCreate()
        {
            statsObject = Resources.Load<PlayerStatsObject>("PlayerStats");
        }

        public override void Initialize()
        {
            Health = PlayerPrefs.GetFloat(health_KEY, statsObject.BaseHealthValue);
            HealthLevel = PlayerPrefs.GetInt(healthLevel_KEY, 0);

            Shield = PlayerPrefs.GetFloat(shield_KEY, statsObject.BaseShieldValue);
            ShieldLevel = PlayerPrefs.GetInt(shieldLevel_KEY, 0);

            Speed = PlayerPrefs.GetFloat(speed_KEY, statsObject.BaseSpeedValue);
            SpeedLevel = PlayerPrefs.GetInt(speedLevel_KEY, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(health_KEY, Health);
            PlayerPrefs.SetInt(healthLevel_KEY, HealthLevel);

            PlayerPrefs.SetFloat(shield_KEY, Shield);
            PlayerPrefs.SetInt(shieldLevel_KEY, ShieldLevel);

            PlayerPrefs.SetFloat(speed_KEY, Speed);
            PlayerPrefs.SetInt(speedLevel_KEY, SpeedLevel);
        }

        public void Reset()
        {
            PlayerPrefs.DeleteKey(health_KEY);
            PlayerPrefs.DeleteKey(healthLevel_KEY);

            PlayerPrefs.DeleteKey(shield_KEY);
            PlayerPrefs.DeleteKey(shieldLevel_KEY);

            PlayerPrefs.DeleteKey(speed_KEY);
            PlayerPrefs.DeleteKey(speedLevel_KEY);
        }
    }
}