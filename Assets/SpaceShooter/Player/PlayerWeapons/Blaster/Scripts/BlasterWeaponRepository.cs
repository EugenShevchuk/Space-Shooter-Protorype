using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponRepository : Repository
    {
        public float DamageOnHit { get; private set; }
        public float FireRate { get; private set; }
        public float Velocity { get; private set; }
        public int BlasterLevel { get; private set; }
        private float damageOnHitBonus1_5 => blasterData.DamageOnHitBonus1_5;
        private float damageOnHitBonus5_10 => blasterData.DamageOnHitBonus5_10;

        private Storage storage;
        private BlasterRepositoryData blasterData;
        private const string SAVE_NAME = "/Blaster.dat";

        public override void Initialize()
        {
            storage = new Storage(SAVE_NAME);
            blasterData = (BlasterRepositoryData)storage.Load(new BlasterRepositoryData());

            Load();
        }

        public override void Save()
        {
            blasterData.DamageOnHit = this.DamageOnHit;
            blasterData.FireRate = this.FireRate;
            blasterData.Velocity = this.Velocity;
            blasterData.BlasterLevel = this.BlasterLevel;

            storage.Save(blasterData);
        }

        private void Load()
        {
            this.DamageOnHit = blasterData.DamageOnHit;
            this.FireRate = blasterData.FireRate;
            this.Velocity = blasterData.Velocity;
            this.BlasterLevel = blasterData.BlasterLevel;
        }

        public void UpgradeBlaster()
        {
            if (BlasterLevel < 10)
            {
                if (BlasterLevel <= 5)
                    this.DamageOnHit += damageOnHitBonus1_5;

                else
                    this.DamageOnHit += damageOnHitBonus5_10;

                BlasterLevel++;
                Save();
            }
        }
    }
}