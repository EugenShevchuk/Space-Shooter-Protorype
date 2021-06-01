using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : MonoBehaviour
    {
        private Borderline borderline;
        [HideInInspector] public float damageOnHit;

        private void Awake()
        {
            this.borderline = GetComponent<Borderline>();
        }

        private void Update()
        {
            if (this.borderline.offUp)
                this.gameObject.SetActive(false);
        }
    }
}