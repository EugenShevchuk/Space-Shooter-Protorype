using UnityEngine;

namespace SpaceShooter
{
    public class Borderline : MonoBehaviour
    {
        [SerializeField] private float radius = 1f;
        [SerializeField] private bool keepOnScreen = false;
        [SerializeField] private bool isOnscreen = true;

        [HideInInspector]
        public bool offRight, offLeft, offUp, offDown;
        
        public float CamWidth;
        public float CamHeight;

        private void Awake()
        {
            this.CamHeight = Camera.main.orthographicSize;
            this.CamWidth = CamHeight * Camera.main.aspect;
        }

        private void LateUpdate()
        {
            Vector3 position = this.transform.position;
            this.isOnscreen = true;
            this.offDown = this.offUp = this.offRight = this.offLeft = false;

            if (this.TryGetComponent(out PlayerMoveBehaviour player))
                this.keepOnScreen = true;

            if (position.x > this.CamWidth - this.radius)
            {
                position.x = this.CamWidth - this.radius;
                this.offRight = true;
            }

            if (position.x < this.radius - this.CamWidth)
            {
                position.x = this.radius - this.CamWidth;
                this.offLeft = true;
            }

            if (position.y > this.CamHeight - this.radius)
            {
                position.y = this.CamHeight - this.radius;
                this.offUp = true;
            }

            if (position.y < this.radius - this.CamHeight)
            {
                position.y = this.radius - this.CamHeight;
                this.offDown = true;
            }

            this.isOnscreen = (this.offUp || this.offDown || this.offRight || this.offLeft) == false;
            if (this.keepOnScreen && this.isOnscreen == false)
            {
                this.transform.position = position;
                this.isOnscreen = true;
                this.offUp = this.offDown = this.offRight = this.offLeft = false;
            }
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying) return;

            Vector3 borders = new Vector3(this.CamWidth * 2, this.CamHeight * 2, 0.1f);

            Gizmos.DrawWireCube(Vector3.zero, borders);
        }
    }
}