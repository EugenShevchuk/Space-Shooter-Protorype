using UnityEngine;

[CreateAssetMenu(fileName = "Kinematic", menuName = "ScriptableObjects/Weapons/Kinematic")]
public class KinematicWeaponObject : ScriptableObject
{
    public GameObject ProjectilePrefab;

    [Header("Base Stats")]
    public float DamageOnHit = 0;    
    public float FireRate = 0;
    public float Velocity = 0;

    [Header("Bonuses for Upgrading")]
    public float DamageOnHitBonus1_5 = 0.5f;
    public float DamageOnHitBonus5_10 = 1;
}
