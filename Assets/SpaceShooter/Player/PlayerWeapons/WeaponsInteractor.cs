using System;

namespace SpaceShooter.Architecture
{
    public class WeaponsInteractor : Interactor
    {
        public event Action<IWeaponInteractor> SelectedWeaponSwitchedEvent;
        public IWeaponInteractor CurrentWeapon;

        private WeaponsRepository repository;

        public override void Initialize()
        {
            repository = Game.GetRepository<WeaponsRepository>();
            CurrentWeapon = repository.SelectedWeapon;
        }

        public void SelectWeapon(IWeaponInteractor weapon)
        {
            weapon.SetAsCurrentWeapon();
            SelectedWeaponSwitchedEvent?.Invoke(CurrentWeapon);
        }
    }
}