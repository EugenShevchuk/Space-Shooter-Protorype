using UnityEngine;

[CreateAssetMenu(fileName = "Laser", menuName = "ScriptableObjects/Weapons/Laser")]
public class LaserWeaponObject : WeaponObject
{
    private void Awake()
    {
        WeaponType = WeaponType.Laser;
    }
}
