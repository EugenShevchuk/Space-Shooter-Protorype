using System.Collections;
using UnityEngine;

public class OpenFire : MonoBehaviour
{
    [SerializeField] private WeaponObject weapon;

    [SerializeField] private GameObject firePointRight;
    [SerializeField] private GameObject firePoinLeft;

    private Projectile proj;

    private void Start()
    {
        weapon = WeaponsData.Instance.CurrentWeapon;

        StartCoroutine(nameof(Fire));
    }

    public IEnumerator Fire()
    {
        if (weapon != null)
        {
            if (weapon.WeaponType == WeaponType.Kinematic || weapon.WeaponType == WeaponType.Blaster)
            {
                while (true)
                {
                    MakeProjectile(firePointRight);
                    MakeProjectile(firePoinLeft);

                    yield return new WaitForSeconds(1 / weapon.FireRate);
                }                
            }
            if (weapon.WeaponType == WeaponType.Laser)
            {
                LineRenderer laserRight = firePointRight.GetComponent<LineRenderer>();
                LineRenderer laserLeft = firePoinLeft.GetComponent<LineRenderer>();

                laserLeft.enabled = true;
                laserRight.enabled = true;

                while(true)
                {
                    FireLaser(laserRight, firePointRight);
                    FireLaser(laserLeft, firePoinLeft);
                    
                    yield return new WaitForEndOfFrame();
                }
            }
            
        }
    }

    private void MakeProjectile(GameObject firePoint)
    {
        GameObject projectile = Instantiate(weapon.ProjectilePrefab);

        if (firePoint.transform.parent.root.gameObject.CompareTag("Player"))
        {
            projectile.tag = "PlayerProjectile";
            projectile.layer = LayerMask.NameToLayer("PlayerProjectile");
        }
        else
        {
            projectile.tag = "EnemyProjectile";
            projectile.layer = LayerMask.NameToLayer("EnemyProjectile");
        }
        projectile.transform.position = firePoint.transform.position;
        projectile.GetComponent<Rigidbody>().velocity = Vector3.up * weapon.Velocity;

        proj = projectile.GetComponent<Projectile>();
        proj.ProjectileType = weapon;
    }

    private void FireLaser(LineRenderer laser, GameObject firePoint)
    {
        Vector3 endPos;        
        Vector3 direction = Vector3.up;

        RaycastHit hit;

        endPos = new Vector3(firePoint.transform.position.x, Mathf.Abs(firePoint.transform.position.y * 500f), firePoint.transform.position.z);
        laser.SetPosition(0, firePoint.transform.position);

        if (Physics.Raycast(firePoint.transform.position, direction.normalized, out hit, 500f))
        {
            laser.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyBehaviour>().TakeDamageFromLaser(weapon.DamagePerSecond);
            }
        }
        else
        {
            laser.SetPosition(1, firePointRight.transform.position + endPos);
        }
    }
}
