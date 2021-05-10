using UnityEngine;

namespace SpaceShooter.Architecture {
    
    public class KinematicWeaponRepository : Repository
    {
        public KinematicWeaponObject KinematicObject;

        private const string damageOnHit_KEY = "K_damageOnHit_KEY";
        public float DamageOnHit { get; set; }

        private const string fireRate_KEY = "K_fireRate_KEY";
        public float FireRate { get; set; }

        private const string velocity_KEY = "K_velocity_KEY";
        public float Velocity { get; set; }

        private const string level_KEY = "K_level_KEY";
        public int Level { get; set; }

        public override void OnCreate()
        {
            KinematicObject = Resources.Load<KinematicWeaponObject>("Kinematic");            
        }

        public override void Initialize()
        {
            DamageOnHit = PlayerPrefs.GetFloat(damageOnHit_KEY, KinematicObject.DamageOnHit);
            FireRate = PlayerPrefs.GetFloat(fireRate_KEY, KinematicObject.FireRate);
            Velocity = PlayerPrefs.GetFloat(velocity_KEY, KinematicObject.Velocity);
            Level = PlayerPrefs.GetInt(level_KEY, 0);            
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(damageOnHit_KEY, DamageOnHit);
            PlayerPrefs.SetFloat(fireRate_KEY, FireRate);
            PlayerPrefs.SetFloat(velocity_KEY, Velocity);
            PlayerPrefs.SetInt(level_KEY, Level);
        }
    }
}