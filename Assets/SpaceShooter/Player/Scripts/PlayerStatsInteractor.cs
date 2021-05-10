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

        private PlayerStatsObject statsObject;

        public PlayerStatsInteractor()
        {
            repository = Game.GetRepository<PlayerStatsRepository>();
            statsObject = Resources.Load<PlayerStatsObject>("PlayerStats");
        }

        public override void OnStart()
        {
            PlayerCollisionHandler.OnDamageTakenEvent += OnDamageTaken;
        }

        public void UpgradeMaxHealth()
        {
            if (HealthLevel < 10)
            {
                if (HealthLevel <= 5)                
                    repository.Health += statsObject.healthBonusLevel1_5;

                else                
                    repository.Health += statsObject.healthBonusLevel5_10;                    
                
                repository.HealthLevel++;
                repository.Save();
            }
        }

        public void UpgradeMaxShield()
        {
            if (repository.ShieldLevel < 10)
            {
                if (repository.ShieldLevel <= 5)                
                    repository.Shield += statsObject.shieldBonusLevel1_5;
                
                else                
                    repository.Shield += statsObject.shieldBonusLevel5_10;
                
                repository.ShieldLevel++;
                repository.Save();
            }
        }

        public void UpgradeMaxSpeed()
        {
            if (repository.SpeedLevel < 10)
            {
                if (repository.SpeedLevel <= 5)                
                    repository.Speed += statsObject.speedBonusLevel1_5;
                
                else                
                    repository.Speed += statsObject.speedBonusLevel5_10;
                               
                repository.SpeedLevel++;
                repository.Save();
            }
        }

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
    }
}