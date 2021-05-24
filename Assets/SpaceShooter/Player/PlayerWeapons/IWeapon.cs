using SpaceShooter.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter 
{
    public interface IWeapon
    {
        public void OpenFire(IWeaponInteractor interactor);
        public void CeaseFire(IWeaponInteractor interactor);
    }
}