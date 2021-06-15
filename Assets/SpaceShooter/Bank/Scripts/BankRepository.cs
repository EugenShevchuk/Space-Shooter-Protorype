using SpaceShooter.Architecture.SaveSystem;

namespace SpaceShooter.Architecture
{
    public class BankRepository : Repository
    {
        public int Money { get; private set; }

        private Storage storage;
        private BankRepositoryData bankData;
        private const string path = "/Bank.dat";

        public override void Initialize()
        {
            this.storage = new Storage(path);
            this.bankData = (BankRepositoryData)this.storage.Load(new BankRepositoryData());

            this.Load();
        }

        public override void Save()
        {
            this.bankData.money = this.Money;

            this.storage.Save(this.bankData);
        }

        public void Load()
        {
            this.Money = this.bankData.money;
        }

        public void AddMoney(int moneyToAdd)
        {
            this.Money += moneyToAdd;
            this.Save();
        }

        public void SpendMoney(int moneyToSpend)
        {
            this.Money -= moneyToSpend;
            this.Save();
        }
    }
}