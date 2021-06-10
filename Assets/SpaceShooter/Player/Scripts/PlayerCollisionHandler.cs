using System;
using UnityEngine;

namespace SpaceShooter
{
    public class PlayerCollisionHandler : CollisionHandler
    {
        [SerializeField] private float damageFromCollisionWithEnemy = 5;

        public static event Action<float> HealthValueChangedEvent;        
                
        private ShieldCollisionHandler shield;

        private void Start()
        {
            shield = GetComponentInChildren<ShieldCollisionHandler>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (shield.isActiveAndEnabled)
                return;

            Transform rootTransform = other.gameObject.transform.root;
            GameObject triggerGO = rootTransform.gameObject;

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
            healthlValue -= damage;

            HealthValueChangedEvent?.Invoke(healthlValue);

            if (healthlValue <= 0)
                PlayerDied();
        }

        private void PlayerDied()
        {
            Destroy(this.gameObject);
        }
    }
}