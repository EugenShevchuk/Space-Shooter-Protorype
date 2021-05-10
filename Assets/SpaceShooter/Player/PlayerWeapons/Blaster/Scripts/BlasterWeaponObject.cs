using UnityEngine;

[CreateAssetMenu(fileName = "Blaster", menuName = "ScriptableObjects/Weapons/Blaster")]
public class BlasterWeaponObject : ScriptableObject
{
    public GameObject ProjectilePrefab;

    [Header("Base Stats")]
    public float DamageOnHit = 0;
    public float FireRate = 0;
    public float Velocity = 0;

    [Header("Bonuses for Upgrading")]
    public float DamageOnHitBonus1_5 = 1;
    public float DamageOnHitBonus5_10 = 2.5f;
}
