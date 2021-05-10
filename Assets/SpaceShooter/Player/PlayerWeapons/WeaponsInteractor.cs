using System;

namespace SpaceShooter.Architecture
{
    public class WeaponsInteractor : Interactor
    {
        public static event Action OnWeaponSelectedAction;

        public IWeapon CurrentWeapon
        { 
            get 
            {
                if (repository.SelectedWeapon == null)
                    repository.Load();

                return repository.SelectedWeapon;
            } 
        }

        private WeaponsRepository repository;

        public WeaponsInteractor()
        {
            repository = Game.GetRepository<WeaponsRepository>();
        }
                
        public void SelectKinematic()
        {
            var weapon = repository.GetWeapon<KinematicWeaponInteractor>();
            SetWeapon(weapon);
        }

        public void SelectBlaster()
        {
            var weapon = repository.GetWeapon<BlasterWeaponInteractor>();
            SetWeapon(weapon);
        }

        public void SelectLaser()
        {
            var weapon = repository.GetWeapon<LaserWeaponInteractor>();
            SetWeapon(weapon);
        }

        private void SetWeapon(IWeapon weapon)
        {
            repository.SelectedWeapon = weapon;
            repository.Save();
            OnWeaponSelectedAction?.Invoke();
        }
    }
}