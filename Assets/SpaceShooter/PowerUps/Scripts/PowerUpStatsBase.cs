using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class PowerUpStatsBase : PowerUpBase
    {
        protected PlayerStatsInteractor statsInteractor;

        protected void InitializeStats()
        {
            this.InitializeBase();
            this.statsInteractor = Game.GetInteractor<PlayerStatsInteractor>();
        }
    }
}