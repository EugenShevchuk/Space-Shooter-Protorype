using System;
using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public abstract class CollisionHandler : MonoBehaviour
    {
        public static event Action<PlayerStatsInteractor> StatsInitialized;

        protected PlayerStatsInteractor playerStats;
        protected float shieldValue;
        protected float healthlValue;

        protected GameObject lastTriggerGo = null;

        private void OnEnable()
        {
            Scene.InitializedEvent += OnSceneInitialized;
        }

        private void OnDisable()
        {
            Scene.InitializedEvent -= OnSceneInitialized;
        }

        protected void OnSceneInitialized()
        {
            playerStats = Game.GetInteractor<PlayerStatsInteractor>();
            shieldValue = playerStats.Shield;
            healthlValue = playerStats.Health;
            HealthShieldBars.playerStats = this.playerStats;
        }

        protected abstract void CollidedWithEnemy();

        protected abstract void TakeDamage(float damage);
    }
}