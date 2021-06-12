using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private float damageFromCollisionWithEnemy = 5;
        [SerializeField] private GameObject shield;

        private PlayerStatsInteractor playerStats;
        private bool isStatsInitialized = false;

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
            playerStats = Game.GetInteractor<PlayerStatsInteractor>();
            isStatsInitialized = true;
        }

        private void Update()
        {
            if (isStatsInitialized)
            {
                if (playerStats.Shield == 0 && shield.activeSelf)
                    shield.SetActive(false);

                if (shield.activeSelf == false && playerStats.Shield > 0)
                    shield.SetActive(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
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

        private void CollidedWithEnemy()
        {
            TakeDamage(damageFromCollisionWithEnemy);
        }

        private void TakeDamage(float damage)
        {
            if (shield.activeSelf)
            {
                TakeDamageToShield(damage);
            }
            else
            {
                TakeDamageToHealth(damage);
            }            
        }

        private void TakeDamageToShield(float damage)
        {
            if (damage > playerStats.Shield)
            {
                var exscesAmount = damage - playerStats.Shield;
                playerStats.Shield -= (damage - exscesAmount);
                TakeDamageToHealth(exscesAmount);
            }
            else
            {
                playerStats.Shield -= damage;
            }
        }

        private void TakeDamageToHealth(float damage)
        {
            playerStats.Health -= damage;

            if (playerStats.Health <= 0)
                Destroy(this.gameObject);
        }
    }
}