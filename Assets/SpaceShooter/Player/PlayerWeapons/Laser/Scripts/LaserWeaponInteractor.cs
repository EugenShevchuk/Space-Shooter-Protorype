using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Architecture
{
    public class LaserWeaponInteractor : Interactor, IWeapon
    {
        public void OpenFire(Transform firePointRight, Transform firePointLeft)
        {
            throw new System.NotImplementedException();
        }

        public void CeaseFire()
        {
            throw new System.NotImplementedException();
        }
    }
}