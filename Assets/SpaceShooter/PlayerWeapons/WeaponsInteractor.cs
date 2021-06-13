using System;

namespace SpaceShooter.Architecture
{
    public class WeaponsInteractor : Interactor
    {
        public event Action SelectedWeaponSwitchedEvent;
        public event Action SwitchingSelectedWeaponEvent;
        public IWeaponInteractor CurrentWeapon => repository.SelectedWeapon;

        private WeaponsRepository repository;

        public override void Initialize()
        {
            repository = Game.GetRepository<WeaponsRepository>();
        }

        public void SelectWeapon(IWeaponInteractor weapon)
        {
            SwitchingSelectedWeaponEvent?.Invoke();

            weapon.SetAsCurrentWeapon();

            SelectedWeaponSwitchedEvent?.Invoke();
        }
    }
}