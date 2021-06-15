using System;

namespace SpaceShooter.Architecture
{
    [Serializable]
    public class BankRepositoryData
    {
        public int money;

        public BankRepositoryData()
        {
            this.money = 0;
        }
    }
}