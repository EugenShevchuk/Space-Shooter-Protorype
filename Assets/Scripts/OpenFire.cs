using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFire : MonoBehaviour
{
    private WeaponType _type = WeaponType.kinematic;
    protected WeaponDefinition _definition;

    public GameObject firePointRight;
    public GameObject firePoinLeft;

    private Borderline _borderline;

    private Projectile proj;

    private void Start()
    {
        SetType(WeaponManager.type);

        StartCoroutine(nameof(Fire));
    }

    public void SetType(WeaponType weaponType)
    {
        _type = weaponType;        
        _definition = WeaponManager.GetWeaponDefinition(_type);
    }

    public IEnumerator Fire()
    {
        if (_definition != null)
        {
            if (_type == WeaponType.kinematic || _type == WeaponType.blaster)
            {
                while (true)
                {
                    MakeProjectile(firePointRight);
                    MakeProjectile(firePoinLeft);

                    yield return new WaitForSeconds(_definition.fireRate);
                }                
            }
            if (_type == WeaponType.laser)
            {
                LineRenderer laserRight = firePointRight.GetComponent<LineRenderer>();
                LineRenderer laserLeft = firePoinLeft.GetComponent<LineRenderer>();

                laserLeft.enabled = true;
                laserRight.enabled = true;

                Vector3 endPosRight;
                Vector3 endPosLeft;
                Vector3 direction = Vector3.up;

                RaycastHit hit;

                while(true)
                {
                    endPosRight = new Vector3(firePointRight.transform.position.x, Mathf.Abs(firePointRight.transform.position.y * 500f), firePointRight.transform.position.z);
                    laserRight.SetPosition(0, firePointRight.transform.position);
                    
                    if (Physics.Raycast(firePointRight.transform.position, direction.normalized, out hit, 500f))
                    {
                        laserRight.SetPosition(1, hit.point);
                        if (hit.collider.tag == "Enemy") 
                        {
                            hit.collider.GetComponent<Enemy>().TakeDamageFromLaser(_definition.damagePerSecond);
                        }
                    }
                    else
                    {
                        laserRight.SetPosition(1, firePointRight.transform.position + endPosRight);
                    }

                    endPosLeft = new Vector3(firePoinLeft.transform.position.x, Mathf.Abs(firePoinLeft.transform.position.y * 500f), firePoinLeft.transform.position.z);
                    laserLeft.SetPosition(0, firePoinLeft.transform.position);

                    if (Physics.Raycast(firePoinLeft.transform.position, direction.normalized, out hit, 500f))
                    {
                        laserLeft.SetPosition(1, hit.point);
                        if (hit.collider.tag == "Enemy")
                        {
                            hit.collider.GetComponent<Enemy>().TakeDamageFromLaser(_definition.damagePerSecond);
                        }
                    }
                    else 
                    {
                        laserLeft.SetPosition(1, firePoinLeft.transform.position + endPosLeft);
                    }
                    
                    yield return new WaitForEndOfFrame();
                }
            }
            
        }
    }

    private void MakeProjectile(GameObject projectileAnchor)
    {
        GameObject projectile = Instantiate(_definition.projectilePrefab);

        if (projectileAnchor.transform.parent.root.gameObject.CompareTag("Player"))
        {
            projectile.tag = "PlayerProjectile";
            projectile.layer = LayerMask.NameToLayer("PlayerProjectile");
        }
        else 
        {
            projectile.tag = "EnemyProjectile";
            projectile.layer = LayerMask.NameToLayer("EnemyProjectile");
        }
        projectile.transform.position = projectileAnchor.transform.position;
        projectile.GetComponent<Rigidbody>().velocity = Vector3.up * _definition.velocity;

        proj = projectile.GetComponent<Projectile>();
        proj.Ptype = _type;
    }    
}
