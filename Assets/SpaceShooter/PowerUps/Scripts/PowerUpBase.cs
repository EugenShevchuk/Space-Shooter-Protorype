using UnityEngine;

namespace SpaceShooter
{
    public class PowerUpBase : MonoBehaviour
    {
        protected float floatSpeed = 0.3f;
        protected float rotationSpeed = 1f;

        protected Borderline borderline;

        protected void InitializeBase()
        {
            this.borderline = GetComponent<Borderline>();

            if (borderline == null)
                Debug.LogError("Object has no attached borderline script");
        }

        private void FixedUpdate()
        {
            this.Move();
        }

        public void Move()
        {
            this.transform.Translate(Vector3.down * floatSpeed);

            this.transform.Rotate(0, rotationSpeed, 0);

            if (this.borderline.offDown)
                Destroy(this.gameObject);
        }
    }
}