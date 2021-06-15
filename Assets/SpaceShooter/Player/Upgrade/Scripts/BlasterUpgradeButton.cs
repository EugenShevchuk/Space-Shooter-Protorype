using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class BlasterUpgradeButton : UpgradeButtonBase
    {
        private BlasterWeaponInteractor interactor;

        private void Start()
        {
            this.interactor = Game.GetInteractor<BlasterWeaponInteractor>();
            this.Initialize(this.interactor);
        }

        public void OnUpgradeButtonClicked()
        {
            this.Upgrade(this.interactor);
        }
    }
}