using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter 
{
    public class LaserPowerUp : PowerUpWeaponsBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        public float damagePerSecondModifier;

        private LaserWeaponInteractor laserInteractor;

        private void Awake()
        {
            this.InitializeWeapons();
            this.laserInteractor = Game.GetInteractor<LaserWeaponInteractor>();
        }

        public void GetAbsorbed()
        {
            if (this.weaponsInteractor.CurrentWeapon != this.laserInteractor)
            {
                this.weaponsInteractor.SelectWeapon(this.laserInteractor);
                this.laserInteractor.modifiedTimes = 0;
                Destroy(this.gameObject);
                return;
            }

            if (this.laserInteractor.modifiedTimes < 3)
            {
                this.laserInteractor.DamagePerSecondBonus += this.damagePerSecondModifier;
                this.laserInteractor.modifiedTimes++;
            }

            Destroy(this.gameObject);
        }
    }
}