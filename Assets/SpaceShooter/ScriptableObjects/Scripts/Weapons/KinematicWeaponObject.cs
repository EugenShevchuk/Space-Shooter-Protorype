using UnityEngine;

[CreateAssetMenu(fileName = "Kinematic", menuName = "ScriptableObjects/Weapons/Kinematic")]
public class KinematicWeaponObject : WeaponObject
{
    private void Awake()
    {        
        WeaponType = WeaponType.Kinematic;
    }
}
