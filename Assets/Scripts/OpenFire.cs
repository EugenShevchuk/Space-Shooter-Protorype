using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFire : MonoBehaviour
{
    private WeaponType _type = WeaponType.kinematic;
    private WeaponDefinition _definition;

    private GameObject _gunRight;
    private GameObject _gunLeft;

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

    public WeaponType type
    {
        get { return _type; }
        set { SetType(value); }
    }

    public void SetType(WeaponType weaponType)
    {
        _type = weaponType;
        if (type == WeaponType.basic)
            print("tvar");
        _definition = WeaponManager.GetWeaponDefinition(_type);
    }

    public IEnumerator Fire()
    {
        while (true)
        {
            if (_definition != null)
            {
                GameObject projectileRight = Instantiate(_definition.projectilePrefab);
                GameObject projectileLeft = Instantiate(_definition.projectilePrefab);
                
                if (_gunRight.transform.parent.gameObject.CompareTag("Player"))
                {
                    projectileRight.tag = "PlayerProjectile";
                    projectileRight.layer = LayerMask.NameToLayer("PlayerProjectile");
                    projectileLeft.tag = "PlayerProjectile";
                    projectileLeft.layer = LayerMask.NameToLayer("PlayerProjectile");
                }
                else
                {
                    projectileRight.tag = "EnemyProjectile";
                    projectileRight.layer = LayerMask.NameToLayer("EnemyProjectile");
                    projectileLeft.tag = "EnemyProjectile";
                    projectileLeft.layer = LayerMask.NameToLayer("EnemyProjectile");
                }
                
                projectileRight.transform.position = _gunRight.transform.position;
                projectileRight.GetComponent<Rigidbody>().velocity = Vector3.up * _definition.velocity;


                projectileLeft.transform.position = _gunLeft.transform.position;
                projectileLeft.GetComponent<Rigidbody>().velocity = Vector3.up * _definition.velocity;
            }
            yield return new WaitForSeconds(_definition.fireRate);
        }
    }
}
