using UnityEngine;

namespace SpaceShooter.Architecture
{
    public class LaserWeaponInteractor : Interactor, IWeaponInteractor
    {
        public GameObject ProjectilePrefab { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public float DamageOnHit => throw new System.NotImplementedException();

        public float DamagePerSecond => throw new System.NotImplementedException();

        public float FireRate => throw new System.NotImplementedException();

        public float Velocity => throw new System.NotImplementedException();

        public WeaponType WeaponType { get ; set ; }

        public int Level => throw new System.NotImplementedException();

        public override void Initialize()
        {
            base.Initialize();
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