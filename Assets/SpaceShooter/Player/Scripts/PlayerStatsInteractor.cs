using System;
using UnityEngine;

namespace SpaceShooter.Architecture {
    public class PlayerStatsInteractor : Interactor
    {
        private PlayerStatsRepository repository;

        public static event Action OnPlayerDiedEvent;
        public static event Action<float> OnShieldValueChangedEvent;
        public static event Action<float> OnHealthValueChangedEvent;

        public float Health => repository.Health;
        public int HealthLevel => repository.HealthLevel;
        public float Shield => repository.Shield;
        public int ShieldLevel => repository.ShieldLevel;
        public float Speed => repository.Speed;
        public int SpeedLevel => repository.SpeedLevel;


        public override void Initialize()
        {
            //PlayerCollisionHandler.OnDamageTakenEvent += OnDamageTaken;
            repository = Game.GetRepository<PlayerStatsRepository>();            
        }

        public void UpgradeMaxHealth()
        {
            repository.UpgradeMaxHealth();
        }

        public void UpgradeMaxShield()
        {
            repository.UpgradeMaxShield();
        }

        public void UpgradeMaxSpeed()
        {
            repository.UpgradeMaxSpeed();
        }
        /*
        private void OnDamageTaken(float damageValue)
        {
            if (repository.Shield > 0)
            {
                if (Shield >= damageValue)
                {
                    repository.Shield -= damageValue;
                    OnShieldValueChangedEvent?.Invoke(Shield);
                    return;
                }
                if (Shield < damageValue)
                {
                    var exscessDamage = Mathf.Abs(repository.Shield -= damageValue);
                    repository.Shield = 0;
                    repository.Health -= exscessDamage;
                    OnShieldValueChangedEvent?.Invoke(Shield);
                    OnHealthValueChangedEvent?.Invoke(Health);
                    return;
                }
            }
            if (Shield <= 0 && Health > 0)
            {
                repository.Health -= damageValue;
            }
            if (Health < 0)
                OnPlayerDiedEvent?.Invoke();
        }
        */
    }
}