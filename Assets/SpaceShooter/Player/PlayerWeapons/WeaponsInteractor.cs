using System;

namespace SpaceShooter.Architecture
{
    public class WeaponsInteractor : Interactor
    {
        public IWeapon CurrentWeapon => repository.WeaponsMap[repository.WeaponKey];
        public Type WeaponType => repository.WeaponKey;
        
        private WeaponsRepository repository;

        public WeaponsInteractor()
        {
            repository = Game.GetRepository<WeaponsRepository>();
        }
                
        public void SelectKinematic()
        {
            repository.SetWeapon<KinematicWeaponInteractor>();
        }

        public void SelectBlaster()
        {
            repository.SetWeapon<BlasterWeaponInteractor>();
        }

        public void SelectLaser()
        {
            repository.SetWeapon<LaserWeaponInteractor>();
        }
    }
}