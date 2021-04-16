using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speedY = 10f;
    [SerializeField] private float speedX = 15f;
    [SerializeField] private float health = 10f;
    [SerializeField] private float directionChangeChance = 0.01f;

    private Borderline borderline;
    private bool startDirection = false;
    private float deltaTime;

    public Vector3 Position 
    { 
        get { return (transform.position); }
        set { transform.position = value; }    
    }

    private void Awake()
    {
        borderline = GetComponent<Borderline>();
        deltaTime = Time.deltaTime;

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
        tempPosition.y -= speedY * deltaTime;
        
        // ������ ����������� �������� � ������ ������ ������� �� ������� �� ��������.
        if (borderline.offLeft || borderline.offRight)
            speedX *= -1;
        // �������� ������ ����������� ��������
        if (Random.value < directionChangeChance)
            speedX *= -1;
        // �������� ���������� ����������� ���������� �������� �� ��� �.
        if (startDirection == true)
            tempPosition.x += speedX * deltaTime;
        else
            tempPosition.x -= speedX * deltaTime;

        Position = tempPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject triggerGO = other.gameObject;
        if (triggerGO.tag == "PlayerProjectile")
        {
            Projectile proj = triggerGO.GetComponent<Projectile>();
            health -= WeaponManager.GetWeaponDefinition(proj.Ptype).damageOnHit;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(triggerGO);
        }        
    }

    public void TakeDamageFromLaser(float damage)
    {
        health -= damage * deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}