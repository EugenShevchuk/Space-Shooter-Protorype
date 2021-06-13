using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private float damageFromCollisionWithEnemy = 5;
        [SerializeField] private GameObject shield;

        private PlayerStatsInteractor playerStats;

        private GameObject lastTriggerGo = null;

        private void OnEnable()
        {
            Scene.InitializedEvent += OnSceneInitialized;
        }

        private void OnDisable()
        {
            Scene.InitializedEvent -= OnSceneInitialized;
        }

        private void OnSceneInitialized()
        {
            this.playerStats = Game.GetInteractor<PlayerStatsInteractor>();
        }

        private void Update()
        {
            if (this.playerStats != null)
            {
                if (this.playerStats.Shield <= 0 && this.shield.activeSelf)
                    this.shield.SetActive(false);

                if (this.shield.activeSelf == false && this.playerStats.Shield > 0)
                    this.shield.SetActive(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject triggerGO = other.gameObject.transform.root.gameObject;

            if (triggerGO == this.lastTriggerGo)
                return;
            this.lastTriggerGo = triggerGO;

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

        private void CollidedWithEnemy()
        {
            TakeDamage(this.damageFromCollisionWithEnemy);
        }

        private void TakeDamage(float damage)
        {
            if (this.shield.activeSelf)            
                this.TakeDamageToShield(damage);
            
            else            
                this.TakeDamageToHealth(damage);                        
        }

        private void TakeDamageToShield(float damage)
        {
            if (damage > this.playerStats.Shield)
            {
                var exscesAmount = damage - this.playerStats.Shield;
                this.playerStats.Shield -= (damage - exscesAmount);
                this.TakeDamageToHealth(exscesAmount);
            }
            else
            {
                this.playerStats.Shield -= damage;
            }
        }

        private void TakeDamageToHealth(float damage)
        {
            this.playerStats.Health -= damage;

            if (this.playerStats.Health <= 0)
                Destroy(this.gameObject);
        }
    }
}