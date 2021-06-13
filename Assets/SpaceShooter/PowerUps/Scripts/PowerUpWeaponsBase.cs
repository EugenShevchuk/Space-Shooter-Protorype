using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class PowerUpWeaponsBase : PowerUpBase
    {
        protected WeaponsInteractor weaponsInteractor;

        protected void InitializeWeapons()
        {
            this.InitializeBase();
            this.weaponsInteractor = Game.GetInteractor<WeaponsInteractor>();
        }
    }
}