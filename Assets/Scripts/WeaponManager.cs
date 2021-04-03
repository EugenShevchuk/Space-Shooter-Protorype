using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum WeaponType
{
    basic,
    kinematic,
    blaster,
    laser
}

[System.Serializable]
public class WeaponDefinition
{
    public WeaponType type = WeaponType.basic;
    public GameObject projectilePrefab;
    public float damageOnHit = 0;
    public float damagePerSecond = 0;
    public float fireRate = 50;
    public float velocity = 80;
}

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance { get; private set; }

    public static WeaponType type = WeaponType.kinematic;

    public WeaponDefinition[] weaponDefinitions;
 
    public Toggle kinematic;
    public Toggle blaster;
    public Toggle laser;

    private static Dictionary<WeaponType, WeaponDefinition> _weaponDictionary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        _weaponDictionary = new Dictionary<WeaponType, WeaponDefinition>();
        foreach  (WeaponDefinition definition in weaponDefinitions)
        {
            _weaponDictionary[definition.type] = definition;
        }
    }

    public static WeaponDefinition GetWeaponDefinition(WeaponType weaponType)
    {
        // Проверить наличие ключа в словаре и вернуть соответствующее описание.
        if (_weaponDictionary.ContainsKey(weaponType))
            return _weaponDictionary[weaponType];
        // Если ключа нет в словаре, создать новое описание basic.
        return new WeaponDefinition();
    }
    public void KinematicIsOn()
    {
        if (kinematic.isOn)
            type = WeaponType.kinematic;
    }

    public void BlasterIsOn()
    {
        if (blaster.isOn)
            type = WeaponType.blaster;
    }

    public void LaserIsOn()
    {
        if (laser.isOn)
            type = WeaponType.laser;
    }
}
