using UnityEngine;

namespace SpaceShooter
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float powerUpDropChance;
        [SerializeField] private GameObject[] powerUps;
 
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

        private void FixedUpdate()
        {
            Move();

            if (borderline != null && borderline.offDown)            
                Destroy(gameObject);

            if (health <= 0)
                EnemyDie();            
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
            if (other.gameObject.TryGetComponent(out Projectile projectile))
            {
                health -= projectile.damageOnHit;
                
                other.gameObject.SetActive(false);
            }
        }

        public void TakeDamageOverTime(float damage)
        {
            health -= damage * Time.deltaTime;
        }

        private void EnemyDie()
        {
            if (Random.value < powerUpDropChance)
            {
                var powerUp = powerUps[Random.Range(0, powerUps.Length)];
                var position = this.transform.position;
                Instantiate(powerUp, position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}