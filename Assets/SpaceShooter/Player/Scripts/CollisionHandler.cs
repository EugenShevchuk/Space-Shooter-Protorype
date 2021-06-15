using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private float damageFromCollisionWithEnemy = 5;
        [SerializeField] private GameObject shield;

        private PlayerHealthInteractor healthInteractor;
        private PlayerShieldInteractor shieldInteractor;

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
            this.healthInteractor = Game.GetInteractor<PlayerHealthInteractor>();
            this.shieldInteractor = Game.GetInteractor<PlayerShieldInteractor>();

            if (this.shield.activeSelf == false && this.shieldInteractor.Shield > 0)
                this.shield.SetActive(true);
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

                if (this.shield.activeSelf == false && this.shieldInteractor.Shield > 0)
                    this.shield.SetActive(true);
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
            if (damage > this.shieldInteractor.Shield)
            {
                var exscesAmount = damage - this.shieldInteractor.Shield;
                this.shieldInteractor.TakeDamage(damage - exscesAmount);
                this.TakeDamageToHealth(exscesAmount);
            }
            else
            {
                this.shieldInteractor.TakeDamage(damage);
            }

            if (this.shieldInteractor.Shield <= 0 && this.shield.activeSelf)
                this.shield.SetActive(false);
        }

        private void TakeDamageToHealth(float damage)
        {
            this.healthInteractor.TakeDamage(damage);

            if (this.healthInteractor.Health <= 0)
                Destroy(this.gameObject);
        }
    }
}