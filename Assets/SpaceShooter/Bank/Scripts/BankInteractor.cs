using System;

namespace SpaceShooter.Architecture
{
    public class BankInteractor : Interactor
    {
        public int Money => this.repository.Money;

        public event Action MoneyAmountChanged;

        private BankRepository repository;

        public override void Initialize()
        {
            repository = Game.GetRepository<BankRepository>();
        }

        public bool IsEnoughMoney(int moneyNeeded)
        {
            if (this.Money > moneyNeeded)
                return true;
            else
                return false;
        }

        public void AddMoney(int moneyToAdd)
        {
            this.repository.AddMoney(moneyToAdd);
            MoneyAmountChanged?.Invoke();
        }

        public void SpendMoney(int moneyToSpend)
        {
            if (this.IsEnoughMoney(moneyToSpend))
            {
                this.repository.SpendMoney(moneyToSpend);
                MoneyAmountChanged?.Invoke();
            }
        }
    }
}