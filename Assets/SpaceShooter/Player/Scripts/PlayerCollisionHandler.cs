using System;
using UnityEngine;

namespace SpaceShooter
{
    public class PlayerCollisionHandler
    {
        /*
        public static event Action<float> HealthValueChangedEvent;
        
        private ShieldCollisionHandler shield;

        private void Start()
        {
            shield = GetComponentInChildren<ShieldCollisionHandler>();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (shield.isActiveAndEnabled)
                return;

            base.OnTriggerEnter(other);
            
            if (shield.isActiveAndEnabled)
                return;

            GameObject triggerGO = other.gameObject.transform.root.gameObject;

            if (triggerGO == lastTriggerGo)
                return;
            lastTriggerGo = triggerGO;

            if (triggerGO.TryGetComponent(out EnemyBehaviour enemy)) 
            {
                Destroy(triggerGO);
                CollidedWithEnemy();
            }
            if (triggerGO.TryGetComponent(out IPowerUp powerUp))
            {
                powerUp.GetAbsorbed();
            }
            
        }

        protected override void CollidedWithEnemy()
        {
            TakeDamage(damageFromCollisionWithEnemy);            
        }

        protected override void TakeDamage(float damage)
        {
            healthValue -= damage;

            HealthValueChangedEvent?.Invoke(healthValue);

            if (healthValue <= 0)
                PlayerDied();
        }

        private void PlayerDied()
        {
            Destroy(this.gameObject);
        }*/
    }
}