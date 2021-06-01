using System;
using UnityEngine;

namespace SpaceShooter
{
    public class ProjectileObjectPool : MonoBehaviour
    {
        [Header("Kinematic")]
        [SerializeField] private int kinematicPoolSize = 300;
        [SerializeField] private bool isKinematicPoolExpandable;
        [SerializeField] private Projectile kinematicPrefab;

        [Header("Blaster")]
        [SerializeField] private int blasterPoolSize = 300;
        [SerializeField] private bool isBlasterPoolExpandable;
        [SerializeField] private Projectile blasterPrefab;

        public ObjectPoolMono<Projectile> kinematicPool;
        public ObjectPoolMono<Projectile> blasterPool;

        private void Awake()
        {
            CreatePools();
        }

        private void CreatePools()
        {
            this.kinematicPool = new ObjectPoolMono<Projectile>(kinematicPrefab, kinematicPoolSize, this.transform)
            {
                isExpandable = this.isKinematicPoolExpandable
            };           

            this.blasterPool = new ObjectPoolMono<Projectile>(blasterPrefab, blasterPoolSize, this.transform)
            {
                isExpandable = this.isBlasterPoolExpandable
            };            
        }
    }
}