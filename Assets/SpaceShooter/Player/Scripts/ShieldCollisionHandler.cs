using UnityEngine;
using System;

namespace SpaceShooter 
{
    public class ShieldCollisionHandler : CollisionHandler
    {
        public static event Action<float> ShieldValueChangedEvent;

        [SerializeField] private float damageFromCollisionWithEnemy = 5;
                
        private void OnTriggerEnter(Collider other)
        {
            Transform rootTransform = other.gameObject.transform.root;
            GameObject triggerGO = rootTransform.gameObject;
            Debug.Log($"Shield collided with {triggerGO.name}");

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
            shieldValue -= damage;

            ShieldValueChangedEvent?.Invoke(shieldValue);

            if (shieldValue <= 0)
                ShieldDestroyed();
        }

        private void ShieldDestroyed()
        {
            this.gameObject.SetActive(false);
        }
    }
}