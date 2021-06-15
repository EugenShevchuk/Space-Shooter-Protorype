using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class KinematicUpgradeButton : UpgradeButtonBase
    {
        private KinematicWeaponInteractor interactor;

        private void Start()
        {
            this.interactor = Game.GetInteractor<KinematicWeaponInteractor>();
            this.Initialize(this.interactor);
        }

        public void OnUpgradeButtonClicked()
        {
            this.Upgrade(this.interactor);
        }
    }
}