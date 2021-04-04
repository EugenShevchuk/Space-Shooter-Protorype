using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFire : MonoBehaviour
{
    private WeaponType _type = WeaponType.kinematic;
    private WeaponDefinition _definition;

    private GameObject _gunRight;
    private GameObject _gunLeft;

    private Projectile proj;

    private void Start()
    {
        GameObject gunSet = transform.Find("GunSet").gameObject;
        GameObject gRight = gunSet.transform.Find("GunRight").gameObject;
        GameObject gLeft = gunSet.transform.Find("GunLeft").gameObject;
        _gunRight = gRight.transform.Find("GunRightAnchor").gameObject;
        _gunLeft = gLeft.transform.Find("GunLeftAnchor").gameObject;

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
        while (true)
        {
            if (_definition != null)
            {
                MakeProjectile(_gunRight);
                MakeProjectile(_gunLeft);
            }
            yield return new WaitForSeconds(_definition.fireRate);
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
