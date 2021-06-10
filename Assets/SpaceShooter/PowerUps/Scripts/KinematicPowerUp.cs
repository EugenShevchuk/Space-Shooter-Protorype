using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter 
{
    public class KinematicPowerUp : PowerUpWeaponsBase, IPowerUp
    {
        [Header("On Absorb Modifiers")]
        public float fireRateModifier;
        public float velocityModifiet;

        private KinematicWeaponInteractor kinematicInteractor;

        private void Awake()
        {
            InitializeWeapons();
            this.kinematicInteractor = Game.GetInteractor<KinematicWeaponInteractor>();
        }

        public void GetAbsorbed()
        {
            if (this.weaponsInteractor.CurrentWeapon != this.kinematicInteractor)
            {
                this.weaponsInteractor.SelectWeapon(kinematicInteractor);
                this.kinematicInteractor.modifiedTimes = 0;
                Destroy(this.gameObject);
                return;
            }

            if (this.kinematicInteractor.modifiedTimes < 3)
            {
                this.kinematicInteractor.FireRateModifier += this.fireRateModifier;
                this.kinematicInteractor.VelocityModifier += this.velocityModifiet;
                Debug.Log($"Kinematic was upgraded {kinematicInteractor.modifiedTimes} times"); 
                this.kinematicInteractor.modifiedTimes++;
            }

            Destroy(this.gameObject);
        }        
    }
}