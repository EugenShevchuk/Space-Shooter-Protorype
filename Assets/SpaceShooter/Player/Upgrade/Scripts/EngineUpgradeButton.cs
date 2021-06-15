using SpaceShooter.Architecture;

namespace SpaceShooter 
{
    public class EngineUpgradeButton : UpgradeButtonBase
    {
        private PlayerEngineInteractor interactor;

        private void Start()
        {
            this.interactor = Game.GetInteractor<PlayerEngineInteractor>();
            this.Initialize(this.interactor);
        }

        public void OnUpgradeButtonClicked()
        {
            this.Upgrade(interactor);
        }
    }
}