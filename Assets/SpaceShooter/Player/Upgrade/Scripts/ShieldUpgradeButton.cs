using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class ShieldUpgradeButton : UpgradeButtonBase
    {
        private PlayerShieldInteractor interactor;

        private void Start()
        {
            this.interactor = Game.GetInteractor<PlayerShieldInteractor>();
            this.Initialize(this.interactor);
        }

        public void OnUpgradeButtonClicked()
        {
            this.Upgrade(this.interactor);
        }
    }
}