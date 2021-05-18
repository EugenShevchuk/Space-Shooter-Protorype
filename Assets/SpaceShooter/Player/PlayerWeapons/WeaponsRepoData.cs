using System;

namespace SpaceShooter.Architecture 
{
    [Serializable]
    public class WeaponsRepoData
    {
        public Type typeKey;

        public WeaponsRepoData()
        {
            typeKey = typeof(KinematicWeaponInteractor);
        }
    }
}