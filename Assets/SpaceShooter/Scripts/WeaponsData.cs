using UnityEngine;
using UnityEngine.UI;

public class WeaponsData : MonoBehaviour
{
    public static WeaponsData Instance;

    [SerializeField] private KinematicWeaponObject KinematicWeapon;
    [SerializeField] private BlasterWeaponObject BlasterWeapon;
    [SerializeField] private LaserWeaponObject LaserWeapon;

    [Header("Set Dynamically")] public WeaponObject CurrentWeapon;

    public static WeaponType CurrentWeaponType;

    [Header("Toggles")]
    [SerializeField] private Toggle kinematic;
    [SerializeField] private Toggle blaster;
    [SerializeField] private Toggle laser;

    private int kinematicLvl;
    private int blasterLvl;
    private int laserLvl;

    [Header("Sliders")]
    [SerializeField] private Slider kinematicSlider;
    [SerializeField] private Slider blasterSlider;
    [SerializeField] private Slider laserSlider;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (KinematicWeapon != null && BlasterWeapon != null && LaserWeapon != null)
        {
            kinematicLvl = KinematicWeapon.Level;
            blasterLvl = BlasterWeapon.Level;
            laserLvl = LaserWeapon.Level;
        }
        WeaponSwitcher();
    }

    public void WeaponSwitcher()
    {
        if (kinematic.isOn)
        {
            CurrentWeapon = KinematicWeapon;            
        }
        if (blaster.isOn)
        {
            CurrentWeapon = BlasterWeapon;
        }
        if (laser.isOn)
        {
            CurrentWeapon = LaserWeapon;
        }
    }

    public void UpgradeKinematic()
    {
        if (kinematicLvl < 10)
        {
            if (kinematicLvl <= 5)            
                KinematicWeapon.DamageOnHit += .5f;                
            
            if (kinematicLvl > 5)            
                KinematicWeapon.DamageOnHit += 1f;

            kinematicLvl++;
            kinematicSlider.value = kinematicLvl;
        }        
    }

    public void UpgradeBlaster()
    {
        if (blasterLvl < 10) 
        {
            if (blasterLvl <= 5)            
                BlasterWeapon.DamageOnHit += 1f;
                
            if (blasterLvl > 5)            
                BlasterWeapon.DamageOnHit += 2f;

            blasterLvl++;
            blasterSlider.value = blasterLvl;
        }        
    }

    public void UpgradeLaser()
    {
        if (laserLvl < 10)
        {
            if (laserLvl <= 5)
            {
                LaserWeapon.DamagePerSecond += .5f;                
            }
            if (laserLvl > 5 && laserLvl < 10)
            {
                LaserWeapon.DamagePerSecond += 1f;                
            }

            laserLvl++;
            laserSlider.value = laserLvl;
        }
    }

}
