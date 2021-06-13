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
            get { return (this.transform.position); }
            set { this.transform.position = value; }
        }

        private void Awake()
        {
            this.borderline = GetComponent<Borderline>();

            if (Random.value > 1)
                this.startDirection = true;
        }

        private void FixedUpdate()
        {
            this.Move();

            if (this.borderline != null && this.borderline.offDown)            
                Destroy(this.gameObject);

            if (this.health <= 0)
                this.EnemyDie();            
        }

        public virtual void Move()
        {
            Vector3 tempPosition = this.Position;
            tempPosition.y -= this.speedY * Time.deltaTime;

            if (this.borderline.offLeft || this.borderline.offRight)
                this.speedX *= -1;            
            if (Random.value < directionChangeChance)
                this.speedX *= -1;
            
            if (this.startDirection == true)
                tempPosition.x += this.speedX * Time.deltaTime;
            else
                tempPosition.x -= this.speedX * Time.deltaTime;

            this.Position = tempPosition;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Projectile projectile))
            {
                this.health -= projectile.damageOnHit;
                
                other.gameObject.SetActive(false);
            }
        }

        public void TakeDamageOverTime(float damage)
        {
            this.health -= damage * Time.deltaTime;
        }

        private void EnemyDie()
        {
            if (Random.value < this.powerUpDropChance)
            {
                var powerUp = this.powerUps[Random.Range(0, this.powerUps.Length)];
                var position = this.transform.position;
                Instantiate(powerUp, position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}