namespace SpaceShooter.Architecture
{
    public interface IUpgradable
    {
        public int Level { get; }
        public void Upgrade();
    }
}