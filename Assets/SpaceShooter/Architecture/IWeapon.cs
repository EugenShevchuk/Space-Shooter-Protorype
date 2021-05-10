using UnityEngine;

namespace SpaceShooter.Architecture
{
    public interface IWeapon
    {
        public void OpenFire(Transform firePointRight, Transform firePointLeft);
        public void CeaseFire();
    }
}