using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture
{
    public class LaserWeaponRepository : Repository
    {
        public int LaserLevel { get; private set; }
        public float DamagePerSecond { get; private set; }

        private float damagePerSecondBonus1_5 => this.laserData.DamagePerSecondBonus1_5;
        private float damagePerSecondBonus5_10 => this.laserData.DamagePerSecondBonus5_10;

        private Storage storage;
        private LaserRepositoryData laserData;
        private const string SAVE_NAME = "/Laser.dat";

        public override void Initialize()
        {
            this.storage = new Storage(SAVE_NAME);
            this.laserData = (LaserRepositoryData)this.storage.Load(new LaserRepositoryData());

            this.Load();
        }

        public override void Save()
        {
            this.laserData.DamagePerSecond = this.DamagePerSecond;
            this.laserData.LaserLevel = this.LaserLevel;
        }

        private void Load()
        {
            this.DamagePerSecond = this.laserData.DamagePerSecond;
            this.LaserLevel = this.laserData.LaserLevel;
        }

        public void UpgradeLaser()
        {
            if (this.LaserLevel < 10)
            {
                if (this.LaserLevel <= 5)
                    this.DamagePerSecond += damagePerSecondBonus1_5;

                else
                    this.DamagePerSecond += damagePerSecondBonus5_10;

                this.LaserLevel++;
                this.Save();
            }
        }
    }
}