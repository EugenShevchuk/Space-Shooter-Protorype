using System.Collections.Generic;

namespace SpaceShooter.Architecture
{
    public class WeaponsInteractor : Interactor
    {
        public IWeaponInteractor CurrentWeapon => repository.WeaponsMap[repository.WeaponKey];

        private HashSet<IWeapon> weapons = new HashSet<IWeapon>();
        private WeaponsRepository repository;

        public override void Initialize()
        {
            repository = Game.GetRepository<WeaponsRepository>();            
        }

        public void OpenFire()
        {
            foreach (var weapon in weapons)
            {
                weapon.OpenFire(CurrentWeapon);
            }
        }

        public void CeaseFire()
        {
            foreach (var weapon in weapons)
            {
                weapon.CeaseFire(CurrentWeapon);
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            weapons.Remove(weapon);
        }

        #region WeaponSelector
        public void SwitchWeapon(IWeaponInteractor weapon)
        {
            CeaseFire();
            weapon.SetAsCurrentWeapon();
            OpenFire();            
        }

        public void SelectWeapon(IWeaponInteractor weapon)
        {
            weapon.SetAsCurrentWeapon();
        }
        #endregion
    }
}