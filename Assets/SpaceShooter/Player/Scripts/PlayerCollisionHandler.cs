using SpaceShooter.Architecture;
using System;
using UnityEngine;

namespace SpaceShooter
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        [SerializeField] private GameObject shield;
        [SerializeField] private float damageFromCollisionWithEnemy = 5;

        public static event Action<float> OnDamageTakenEvent;

        private GameObject lastTriggerGo = null;

        private void OnEnable()
        {
            PlayerStatsInteractor.OnPlayerDiedEvent += OnPlayerDied;
            shield.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            PlayerStatsInteractor.OnPlayerDiedEvent -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Transform rootTransform = other.gameObject.transform.root;
            GameObject triggerGO = rootTransform.gameObject;

            if (triggerGO == lastTriggerGo)
                return;
            lastTriggerGo = triggerGO;

            if (triggerGO.CompareTag("Enemy"))
            {
                Destroy(triggerGO);
                OnDamageTakenEvent(damageFromCollisionWithEnemy);
            }
        }

        private void CollisionWithEnemy()
        { 
            
        }
    }
}