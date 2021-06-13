namespace SpaceShooter.Architecture
{
    public enum WeaponType
    { 
        Kinematic,
        Blaster,
        Laser,
    }
    public interface IWeaponInteractor
    {
        public WeaponType WeaponType { get; }
        public int Level { get; }
        public float DamageOnHit { get; }
        public float DamagePerSecond { get; }
        public float FireRate { get; }
        public float Velocity { get; }
        public void InitializeWeapon();
        public void SetAsCurrentWeapon();
        public void Upgrade();
    }
}