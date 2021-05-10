using UnityEngine;

namespace SpaceShooter
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float speedY = 10f;
        [SerializeField] private float speedX = 15f;
        [SerializeField] private float health = 10f;
        [SerializeField] private float directionChangeChance = 0.01f;

        private Borderline borderline;
        private bool startDirection = false;

        public Vector3 Position
        {
            get { return (transform.position); }
            set { transform.position = value; }
        }

        private void Awake()
        {
            borderline = GetComponent<Borderline>();

            if (Random.value > 1)
                startDirection = true;
        }

        private void Update()
        {
            Move();

            if (borderline != null && borderline.offDown)
            {
                Destroy(gameObject);
            }
        }

        public virtual void Move()
        {
            Vector3 tempPosition = Position;
            tempPosition.y -= speedY * Time.deltaTime;

            // Меняет направление движения в случае выхода объекта за границы по сторонам.
            if (borderline.offLeft || borderline.offRight)
                speedX *= -1;
            // Случайно меняет направление движения
            if (Random.value < directionChangeChance)
                speedX *= -1;
            // Случайно определяет изначальное напрвление движения по оси Х.
            if (startDirection == true)
                tempPosition.x += speedX * Time.deltaTime;
            else
                tempPosition.x -= speedX * Time.deltaTime;

            Position = tempPosition;
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject triggerGO = other.gameObject;
            if (triggerGO.CompareTag("PlayerProjectile"))
            {
                Projectile proj = triggerGO.GetComponent<Projectile>();
                health -= proj.damageOnHit;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
                Destroy(triggerGO);
            }
        }

        public void TakeDamageFromLaser(float damage)
        {
            health -= damage * Time.deltaTime;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}