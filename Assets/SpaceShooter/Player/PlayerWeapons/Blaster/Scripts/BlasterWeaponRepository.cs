using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponRepository : Repository
    {
        public BlasterWeaponObject BlasterObject;

        private const string damageOnHit_KEY = "B_damageOnHit_KEY";
        public float DamageOnHit { get; set; }

        private const string fireRate_KEY = "B_fireRate_KEY";
        public float FireRate { get; set; }

        private const string velocity_KEY = "B_velocity_KEY";
        public float Velocity { get; set; }

        private const string level_KEY = "B_level_KEY";
        public int Level { get; set; }

        public override void OnCreate()
        {
            BlasterObject = Resources.Load<BlasterWeaponObject>("Blaster");
        }

        public override void Initialize()
        {
            DamageOnHit = PlayerPrefs.GetFloat(damageOnHit_KEY, BlasterObject.DamageOnHit);
            FireRate = PlayerPrefs.GetFloat(fireRate_KEY, BlasterObject.FireRate);
            Velocity = PlayerPrefs.GetFloat(velocity_KEY, BlasterObject.Velocity);
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