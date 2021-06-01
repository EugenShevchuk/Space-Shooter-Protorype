using UnityEngine;

namespace SpaceShooter.Architecture
{
    public class LaserWeaponInteractor : Interactor, IWeaponInteractor
    {
        public GameObject ProjectilePrefab { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public float DamageOnHit { get; set; }

        public float DamagePerSecond { get; set; }

        public float FireRate { get; set; }

        public float Velocity { get; set; }

        public WeaponType WeaponType { get; set; }

        public int Level => throw new System.NotImplementedException();

        public override void Initialize()
        {
            base.Initialize();
        }

        public void InitializeWeapon()
        {
            throw new System.NotImplementedException();
        }

        public void SetAsCurrentWeapon()
        {
            throw new System.NotImplementedException();
        }

        public void Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}