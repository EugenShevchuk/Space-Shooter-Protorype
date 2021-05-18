using UnityEngine;

[CreateAssetMenu(fileName = "Blaster", menuName = "ScriptableObjects/Weapons/Blaster")]
public class BlasterWeaponObject : ScriptableObject
{
    public GameObject ProjectilePrefab;

    [Header("Base Stats")]
    public float DamageOnHit;
    public float FireRate;
    public float Velocity;

    [Header("Bonuses for Upgrading")]
    public float DamageOnHitBonus1_5 = 1;
    public float DamageOnHitBonus5_10 = 2.5f;
}
