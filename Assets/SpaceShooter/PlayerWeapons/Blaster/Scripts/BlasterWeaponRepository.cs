using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture
{
    public class BlasterWeaponRepository : Repository
    {
        public float DamageOnHit { get; private set; }
        public float FireRate { get; private set; }
        public float Velocity { get; private set; }
        public int BlasterLevel { get; private set; }
        private float damageOnHitBonus1_5 => this.blasterData.DamageOnHitBonus1_5;
        private float damageOnHitBonus5_10 => this.blasterData.DamageOnHitBonus5_10;

        private Storage storage;
        private BlasterRepositoryData blasterData;
        private const string SAVE_NAME = "/Blaster.dat";

        public override void Initialize()
        {
            this.storage = new Storage(SAVE_NAME);
            this.blasterData = (BlasterRepositoryData)this.storage.Load(new BlasterRepositoryData());

            this.Load();
        }

        public override void Save()
        {
            this.blasterData.DamageOnHit = this.DamageOnHit;
            this.blasterData.FireRate = this.FireRate;
            this.blasterData.Velocity = this.Velocity;
            this.blasterData.BlasterLevel = this.BlasterLevel;

            this.storage.Save(blasterData);
        }

        private void Load()
        {
            this.DamageOnHit = this.blasterData.DamageOnHit;
            this.BlasterLevel = this.blasterData.BlasterLevel;
            this.Velocity = this.blasterData.Velocity;
            this.FireRate = this.blasterData.FireRate;
        }

        public void UpgradeBlaster()
        {
            if (this.BlasterLevel < 10)
            {
                if (this.BlasterLevel <= 5)
                    this.DamageOnHit += this.damageOnHitBonus1_5;

                else
                    this.DamageOnHit += this.damageOnHitBonus5_10;

                this.BlasterLevel++;
                this.Save();
            }
        }
    }
}