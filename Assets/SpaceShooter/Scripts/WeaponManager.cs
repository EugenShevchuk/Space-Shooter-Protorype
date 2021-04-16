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
    public Material laserMaterial;
    public float damageOnHit = 0;
    public float damagePerSecond = 0;
    public float fireRate = 50;
    public float velocity = 80;
}

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }
    #region Fields
    public static WeaponType type = WeaponType.kinematic;

    public WeaponDefinition[] weaponDefinitions;
 
    [Header("Toggles")]
    public Toggle kinematic;
    public Toggle blaster;
    public Toggle laser;

    [HideInInspector] public bool isWeaponKinematic;
    [HideInInspector] public bool isWeaponBlaster;
    [HideInInspector] public bool isWeaponLaser;

    [Header("Sliders")]
    public Slider kinematicSlider;
    public Slider blasterSlider;
    public Slider laserSlider;

    private int kinematicLvl;
    private int blasterLvl;
    private int laserLvl;
  
    private static Dictionary<WeaponType, WeaponDefinition> _weaponDictionary;
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
    #region WeaponSwitcher
    public void WeaponSwitcher()
    {
        if (isWeaponKinematic == true)
            type = WeaponType.kinematic;
        if (isWeaponBlaster == true)
            type = WeaponType.blaster;
        if (isWeaponLaser == true)
            type = WeaponType.laser;
    }
    public void KinematicIsOn()
    {
        if (kinematic.isOn)
        {
            isWeaponKinematic = true;
            isWeaponBlaster = false;
            isWeaponLaser = false;
            WeaponSwitcher();
        }
    }

    public void BlasterIsOn()
    {
        if (blaster.isOn)
        {
            isWeaponBlaster = true;
            isWeaponKinematic = false;
            isWeaponLaser = false;
            WeaponSwitcher();
        }
    }

    public void LaserIsOn()
    {
        if (laser.isOn)
        {
            isWeaponLaser = true;
            isWeaponKinematic = false;
            isWeaponBlaster = false;
            WeaponSwitcher();
        }
    }
    #endregion

    #region UpgradeRegion
    public void UpgradeKinematic()
    {
        if (kinematicLvl <= 5)
        {
            weaponDefinitions[0].damageOnHit += .5f;
            kinematicSlider.value++;            
        }
        if (kinematicLvl > 5 && kinematicLvl < 10)
        {
            weaponDefinitions[0].damageOnHit += 1f;
            kinematicSlider.value++;
        }
        kinematicLvl++;
    }

    public void UpgradeBlaster()
    {
        if (blasterLvl <= 5)
        {
            weaponDefinitions[1].damageOnHit += 1f;
            blasterSlider.value++;
        }
        if (blasterLvl > 5 && blasterLvl < 10)
        {
            weaponDefinitions[1].damageOnHit += 2f;
            blasterSlider.value++;
        }
        blasterLvl++;        
    }

    public void UpgradeLaser()
    {
        if (laserLvl <= 5)
        {
            weaponDefinitions[2].damagePerSecond += .5f;
            laserSlider.value++;
        }
        if (laserLvl > 5 && laserLvl < 10)
        {
            weaponDefinitions[2].damagePerSecond += 1f;
            laserSlider.value++;
        }
        laserLvl++;
    }    
    #endregion
}
