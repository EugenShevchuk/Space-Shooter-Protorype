using UnityEngine;

[CreateAssetMenu(fileName = "Blaster", menuName = "ScriptableObjects/Weapons/Blaster")]
public class BlasterWeaponObject : WeaponObject
{
    private void Awake()
    {
        WeaponType = WeaponType.Blaster;
    }
}
