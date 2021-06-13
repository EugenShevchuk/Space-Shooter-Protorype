using UnityEngine;

[CreateAssetMenu(fileName = "Laser", menuName = "ScriptableObjects/Weapons/Laser")]
public class LaserWeaponObject : ScriptableObject
{
    public GameObject ProjectilePrefab;

    [Header("Base Stats")]
    public float DamagePerSecond = 0;
    
    [Header("Bonuses for Upgrading")]
    public float DamagePerSecondBonus1_5 = 0.5f;
    public float DamagePerSecondBonus5_10 = 1.5f;
}
