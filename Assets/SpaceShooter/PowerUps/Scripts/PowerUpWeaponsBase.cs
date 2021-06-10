using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class PowerUpWeaponsBase : PowerUpBase
    {
        protected WeaponsInteractor weaponsInteractor;

        protected void InitializeWeapons()
        {
            InitializeBase();
            weaponsInteractor = Game.GetInteractor<WeaponsInteractor>();
        }
    }
}