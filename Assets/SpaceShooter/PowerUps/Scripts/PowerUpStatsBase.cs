using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class PowerUpStatsBase : PowerUpBase
    {
        protected PlayerStatsInteractor statsInteractor;

        protected void InitializeStats()
        {
            InitializeBase();
            statsInteractor = Game.GetInteractor<PlayerStatsInteractor>();
        }
    }
}