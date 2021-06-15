using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class LaserUpgradeButton : UpgradeButtonBase
    {
        private LaserWeaponInteractor interactor;

        private void Start()
        {
            this.interactor = Game.GetInteractor<LaserWeaponInteractor>();
            this.Initialize(this.interactor);
        }

        public void OnUpgradeButtonClicked()
        {
            this.Upgrade(this.interactor);
        }
    }
}