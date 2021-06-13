using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class BlasterPowerUp : PowerUpWeaponsBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        public float fireRateModifier;
        public float velocityModifiet;
        
        private BlasterWeaponInteractor blasterInteractor;

        private void Awake()
        {
            this.InitializeWeapons();
            this.blasterInteractor = Game.GetInteractor<BlasterWeaponInteractor>();
        }   

        public void GetAbsorbed()
        {
            if (this.weaponsInteractor.CurrentWeapon != this.blasterInteractor)
            {
                this.weaponsInteractor.SelectWeapon(blasterInteractor);
                this.blasterInteractor.FireRateModifier = 0;
                this.blasterInteractor.VelocityModifier = 0;
                this.blasterInteractor.modifiedTimes = 0;
                Destroy(this.gameObject);
                return;
            }

            if (this.blasterInteractor.modifiedTimes < 3)
            {
                this.blasterInteractor.FireRateModifier += this.fireRateModifier;
                this.blasterInteractor.VelocityModifier += this.velocityModifiet;
                Debug.Log($"Blaster was upgraded {this.blasterInteractor.modifiedTimes} times");
                this.blasterInteractor.modifiedTimes++;
            }

            Destroy(this.gameObject);
        }
    }
}