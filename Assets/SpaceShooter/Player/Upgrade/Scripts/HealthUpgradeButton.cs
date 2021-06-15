using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class HealthUpgradeButton : UpgradeButtonBase
    {
        private PlayerHealthInteractor interactor;

        private void Start()
        {
            this.interactor = Game.GetInteractor<PlayerHealthInteractor>();
            this.Initialize(this.interactor);
        }

        public void OnUpgradeButtonClicked()
        {
            this.Upgrade(interactor);
        }
    }
}