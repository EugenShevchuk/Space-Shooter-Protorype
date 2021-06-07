using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter {
    public class LaserBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject hitEffectsGO;
        [SerializeField] private GameObject startEffectsGO;

        [SerializeField] private float maxLength;

        private LineRenderer laser;
        private ParticleSystem[] startEffects;
        private ParticleSystem[] hitEffects;

        private LaserWeaponInteractor weaponInteractor;

        private void Awake()
        {
            this.laser = GetComponent<LineRenderer>();
            this.startEffects = this.startEffectsGO.GetComponentsInChildren<ParticleSystem>();
            this.hitEffects = this.hitEffectsGO.GetComponentsInChildren<ParticleSystem>();
            this.laser.enabled = true;
        }

        private void Start()
        {
            foreach (var effect in startEffects)
            {
                effect.Play();
            }

            weaponInteractor = Game.GetInteractor<LaserWeaponInteractor>();
        }

        private void Update()
        {
            MoveLaser();

            if (Physics.Raycast(this.transform.position, Vector3.up, out RaycastHit hit, this.maxLength))
            {
                LaserHitObject(hit);
            }
            else
            {
                LaserDoesntHit();
            }
        }

        private void MoveLaser()
        {
            if (this.laser != null)
            {
                this.laser.SetPosition(0, this.transform.position);

                foreach (var effect in this.startEffects)
                {
                    if (effect.isPlaying == false)
                        effect.Play();
                }
            }
        }

        private void LaserHitObject(RaycastHit hit)
        {
            this.laser.SetPosition(1, hit.point);
            this.hitEffectsGO.transform.position = hit.point;
            this.hitEffectsGO.transform.rotation = Quaternion.identity;

            foreach (var effect in hitEffects)
            {
                if (effect.isPlaying == false)
                    effect.Play();
            }

            Transform rootTransform = hit.collider.gameObject.transform.root;
            GameObject hitGO = rootTransform.gameObject;

            if (hitGO.TryGetComponent(out EnemyBehaviour enemy))
                enemy.TakeDamageOverTime(weaponInteractor.DamagePerSecond);
        }

        private void LaserDoesntHit()
        {
            var EndPosition = this.transform.position + this.transform.up * this.maxLength;
            this.laser.SetPosition(1, EndPosition);

            this.hitEffectsGO.transform.position = EndPosition;
            foreach (var effect in this.hitEffects)
            {
                if (effect.isPlaying)
                    effect.Stop();
            }
        }
    }
}